/***********************************************************************
<copyright file="Common.cs" company="Ikarii">
    Copyright © Ikarii 2014 All rights reserved.
    Author: Shawn Hall
</copyright>
***********************************************************************/
namespace Havel.Utility
{
	using System;
	using System.IO;
	using System.Text;
	using System.Linq.Expressions;
	using System.Reflection;
	using System.Security.Cryptography;

	using Havel.Adapters;
	using Havel.Extensions;
	using Havel.Extensions.Internal;
	using Havel.Exceptions;

	internal static class Common
	{
		/// <summary>
		/// Used to ensure database objects are properly identified to avoid problems where table or column names 
		/// are reserved words.
		/// </summary>
		/// <param name="source">Source string to create mark up with identifiers.</param>
		/// <param name="format">Specific identifier format to use.</param>
		/// <returns>String of source with appropriate identifers</returns>
		internal static string PopulateIdentifiers( string source, IdentifierFormat format = IdentifierFormat.None )
		{
			if( format.Equals( IdentifierFormat.Bracketed ) )
				return ( "[{0}]".F( source ) );
			else if( format.Equals( IdentifierFormat.Quoted ) )
				return ( "\"{0}\"".F( source ) );
			else
				return ( source );
		}

		/// <summary>
		/// Determines if Type test implements Type iface
		/// </summary>
		/// <param name="test">Type to test.</param>
		/// <param name="iface">Interface to find.</param>
		/// <returns>Boolean value where true indicates that test implements iface.</returns>
		/// <remarks>Will return true if test actually is iface.</remarks>
		internal static bool ImplementsInterface( Type test, Type iface )
		{
			if( test.GetInterface( iface.Name ).Null() && !test.IsInterface && test.NotEquals( iface ) )
			{
				return ( false );
			}
			return ( true );
		}

		/// <summary>
		/// Retrieves an instanced version of the specified Type attribute from the PropertyInfo field.
		/// </summary>
		/// <param name="field">Object field to retrieve the attribute from.</param>
		/// <param name="attribute">Type of attribute to locate and return.</param>
		/// <returns>Instance of attribute or null if none found.</returns>
		internal static object GetCustomFieldAttribute( PropertyInfo field, Type attribute )
		{
			var attributes = field.GetCustomAttributes( attribute, false );
			return ( attributes.Length > 0 ? attributes[ 0 ] : null );
		}

		/// <summary>
		/// Retrieves an instanced version of the specified generic T attribute from the PropertyInfo field.
		/// </summary>
		/// <typeparam name="T">Type of attribute to locate and return.</typeparam>
		/// <param name="field">Object field to retrieve the attribute from.</param>
		/// <returns>Instance of attribute or null if none found.</returns>
		internal static T GetCustomFieldAttribute<T>( PropertyInfo field )
		{
			return ( ( T )GetCustomFieldAttribute( field, typeof( T ) ) );
		}

		/// <summary>
		/// Retrieves an instanced version of the specified Type attribute from the Type obj.
		/// </summary>
		/// <param name="obj">Type to retrieve the attribute from.</param>
		/// <param name="attribute">Type of attribute to locate and return.</param>
		/// <returns>Instance of attribute or null if none found.</returns>
		internal static object GetCustomObjectAttribute( Type obj, Type attribute )
		{
			var attributes = obj.GetCustomAttributes( attribute, false );
			return ( attributes.Length > 0 ? attributes[ 0 ] : null );
		}

		/// <summary>
		/// Retrieves an instanced version of the specified generic T attribute from the Type obj.
		/// </summary>
		/// <typeparam name="T">Type of attribute to locate and return.</typeparam>
		/// <param name="obj">Type to retrieve the attribute from.</param>
		/// <returns>Instance of attribute or null if none found.</returns>
		internal static T GetCustomObjectAttribute<T>( Type obj )
		{
			return ( ( T )GetCustomObjectAttribute( obj, typeof( T ) ) );
		}

		/// <summary>
		/// Based on the Type passed in, GetIdentityFormat will return an IdentityFormat usable for that Type.
		/// If no usable IdentityFormat is located, a MappingException will be thrown.
		/// </summary>
		/// <param name="idtype">Type to find an IdentityFormat for.</param>
		/// <param name="soft">If true, GetIdentityFormat will not throw an exception and will instead return IdentityFormat.Unknown.</param>
		/// <returns>IdentityFormat appropriate for specified Type.</returns>
		/// <exception cref="MappyingException">Thrown if no acceptable IdentityFormat is found for the specified idtype</exception>
		internal static IdentityFormat GetIdentityFormat( Type idtype, bool soft = false )
		{
			IdentityFormat result = IdentityFormat.Integer;
			if( idtype.Equals( typeof( System.Int32 ) ) || idtype.Equals( typeof( System.Int64 ) ) )
			{
				result = IdentityFormat.Integer;
			}
			else if( idtype.Equals( typeof( System.Guid ) ) )
			{
				result = IdentityFormat.Guid;
			}
			else if( idtype.Equals( typeof( System.String ) ) )
			{
				result = IdentityFormat.String;
			}
			else
			{
				if( soft ) result = IdentityFormat.Unknown;
				else
					throw new MappingException(
						String.Format( System.Globalization.CultureInfo.InvariantCulture,
						"Primary Key is an unknown datatype.  Primary Keys must be integers, guids or strings." ) );
			}
			return ( result );
		}


		internal static PropertyInfo GetProperty<TYPE>( Expression<Func<TYPE, object>> expression )
		{
			return ( ( PropertyInfo )GetMemberExpression( expression ).Member );
		}

		internal static MemberExpression GetMemberExpression<TYPE, MAP>( Expression<Func<TYPE, MAP>> expression )
		{
			MemberExpression memberExpression = null;
			if( expression.Body.NodeType == ExpressionType.Convert )
			{
				var body = ( UnaryExpression )expression.Body;
				memberExpression = body.Operand as MemberExpression;
			}
			else if( expression.Body.NodeType == ExpressionType.MemberAccess )
			{
				memberExpression = expression.Body as MemberExpression;
			}

			if( memberExpression == null )
			{
				throw new ArgumentException( "Not a member access", "member" );
			}

			return memberExpression;
		}

		public static bool IsElemental( Type t )
		{
			return ( t.IsValueType ||
				t.Namespace.Equals( "System.Xml" ) ||
				t.Namespace.Equals( "System.Drawing" ) ||
				t.Equals( typeof( Byte[] ) ) ||
				t.Equals( typeof( String ) ) );
		}

		public static string Encrypt( string source, string password ) { return ( Crypt( source, password, true, "TripleDES" ) ); }

		public static string Decrypt( string source, string password ) { return ( Crypt( source, password, false, "TripleDES" ) ); }

		internal static string Crypt( string source, string password, bool encrypt, string alg )
		{
			byte[] salt = new byte[] { 0x26, 0x19, 0x81, 0x4E, 0xA0, 0x6D, 0x95, 0x34, 0x26, 0x75, 0x64, 0x05, 0xF6 };

			PasswordDeriveBytes pass = new PasswordDeriveBytes( password, salt );

			Rijndael algorithm = Rijndael.Create();
			//SymmetricAlgorithm algorithm = SymmetricAlgorithm.Create( alg );
			//algorithm.GenerateKey();
			//algorithm.GenerateIV();
			algorithm.Key = pass.GetBytes( 32 );
			algorithm.IV = pass.GetBytes( 16 );

			ICryptoTransform transform = ( encrypt ) ? algorithm.CreateEncryptor() : algorithm.CreateDecryptor();

			using( MemoryStream ms = new MemoryStream() )
			using( CryptoStream cs = new CryptoStream( ms, transform, CryptoStreamMode.Write ) )
			{
				byte[] data;
				if( encrypt ) data = Encoding.Unicode.GetBytes( source );
				else data = Convert.FromBase64String( source );

				try
				{
					cs.Write( data, 0, data.Length );
					cs.FlushFinalBlock();

					if( encrypt ) return Convert.ToBase64String( ms.ToArray() );
					else return Encoding.Unicode.GetString( ms.ToArray() );

				}
				catch( Exception e ) { throw ( e ); }
				finally
				{
					cs.Close();
					ms.Close();
				}
			}
		}
	}
}
