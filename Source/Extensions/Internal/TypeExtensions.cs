/***********************************************************************
<copyright file="TypeExtensions.cs" company="Ikarii">
    Copyright © Ikarii 2014 All rights reserved.
    Author: Shawn Hall
</copyright>
***********************************************************************/
namespace Havel.Extensions.Internal
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;

	using Havel.Utility;
	using Havel.Adapters;

	public static class TypeExtensions
	{
		public static bool Implements<Interface>( this Type type )
		{
			return ( type.GetInterface( typeof( Interface ).FullName ) != null );
		}

		//Internal Operations For Easy Access To Conventions
		internal static bool IsIdentity( this Type type )
		{
			var format = Common.GetIdentityFormat( type, true );
			return ( format.Equals( IdentityFormat.Unknown ) ? false : true );
		}

		internal static object GetInstance( this Type t )
		{
			return ( Activator.CreateInstance( t ) );
		}

		internal static T GetInstance<T>( this Type t )
		{
			return ( ( T )Activator.CreateInstance( t ) );
		}
	}
}
