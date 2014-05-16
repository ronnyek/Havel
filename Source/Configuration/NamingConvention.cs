/***********************************************************************
<copyright file="Convention.cs" company="Ikarii">
    Copyright © Ikarii 2014 All rights reserved.
    Author: Shawn Hall
</copyright>
***********************************************************************/
namespace Havel.Configuration
{
	using System;
	using System.Globalization;
	using System.Reflection;

	using Havel.Utility;

	/// <summary>
	/// Provides a naming convention definition that Alpaca can use to generate proper table and column names.
	/// </summary>
	public class NamingConvention
	{
		/// <summary>
		/// Generates a usuable table name based on the <see cref="T:Type"/>.
		/// </summary>
		public Func<Type, String> TableName = type =>
			String.Format( CultureInfo.InvariantCulture, "{0}", Inflector.Underscore( type.Name ).ToLower() );

		/// <summary>
		/// Generates usuable primary key field name based on the <see cref="T:PropertyInfo"/>.
		/// </summary>
		public Func<PropertyInfo, String> PrimaryKey = field =>
			String.Format( CultureInfo.InvariantCulture, "{0}", Inflector.Underscore( field.Name.ToLower() ) );

		/// <summary>
		/// Generates usuable foreign key field name based on the <see cref="T:PropertyInfo"/>.
		/// </summary>
		public Func<PropertyInfo, String> ForeignKey = field =>
			String.Format( CultureInfo.InvariantCulture, "{0}_id", Inflector.Underscore( field.Name ).ToLower() );

		/// <summary>
		/// Generates usuable reference field name based on the <see cref="T:PropertyInfo"/>.
		/// </summary>
		public Func<PropertyInfo, String> Reference = field =>
			String.Format( CultureInfo.InvariantCulture, "{0}_id", Inflector.Underscore( field.Name ).ToLower() );

		/// <summary>
		/// Generates usuable field name based on the <see cref="T:PropertyInfo"/>.
		/// </summary>
		public Func<PropertyInfo, String> Field = property =>
			String.Format( CultureInfo.InvariantCulture, "{0}", Inflector.Underscore( property.Name ).ToLower() );

		/// <summary>
		/// Generates usuable many to many table name based on the parent and child <see cref="T:Type"/>s.
		/// </summary>
		public Func<Type, Type, String> ManyToManyTableName = ( parent, child ) =>
			String.Format( CultureInfo.InvariantCulture, "{0}_{1}", Inflector.Underscore( parent.Name ).ToLower(), Inflector.Underscore( child.Name ).ToLower() );

		/// <summary>
		/// Generates usuable left (parent) key column name based on the <see cref="T:Type"/>.
		/// </summary>
		public Func<Type, String> ManyToManyLeftKey = parent =>
			String.Format( CultureInfo.InvariantCulture, "{0}_id", Inflector.Underscore( parent.Name ).ToLower() );

		/// <summary>
		/// Generates usuable right (child) key column name based on the <see cref="T:Type"/>.
		/// </summary>
		public Func<Type, String> ManyToManyRightKey = child =>
			String.Format( CultureInfo.InvariantCulture, "{0}_id", Inflector.Underscore( child.Name ).ToLower() );

		/// <summary>
		/// Helper method to get <see cref="T:Type"/> based names.
		/// </summary>
		/// <param name="type"><see cref="T:Type"/> of source to get.</param>
		/// <param name="expression">Expression to use.</param>
		/// <returns><see cref="T:String"/> value from expression.</returns>
		/// <example>Get( typeof(Car), TableName );</example>
		public String Get( Type type, Func<Type, String> expression ) { return ( expression( type ) ); }

		/// <summary>
		/// Helper method to get <see cref="T:Type"/> based names.
		/// </summary>
		/// <param name="field"><see cref="T:PropertyInfo"/> to use.</param>
		/// <param name="expression">Expression to use.</param>
		/// <returns><see cref="T:String"/> value from expression.</returns>
		/// <example>Get( Id, PrimaryKey ); //where Id is a <see cref="T:PropertyInfo"/> of the Car.Id member.</example>
		public String Get( PropertyInfo field, Func<PropertyInfo, String> expression ) { return ( expression( field ) ); }

		/// <summary>
		/// Helper method to get <see cref="T:Type"/> based names.
		/// </summary>
		/// <param name="parent"><see cref="T:Type"/> representing parent.</param>
		/// <param name="child"><see cref="T:Type"/> representing child.</param>
		/// <param name="expression">Expression to use.</param>
		/// <returns><see cref="T:String"/> value from expression.</returns>
		/// <example>Get( typeof( Person ), typeof( Address ), ManyToManyTableName );</example>
		public String Get( Type parent, Type child, Func<Type, Type, String> expression ) { return ( expression( parent, child ) ); }
	}
}
