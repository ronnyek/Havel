/***********************************************************************
<copyright file="PersistentAttribute.cs" company="Ikarii">
    Copyright © Ikarii 2014 All rights reserved.
    Author: Shawn Hall
</copyright>
***********************************************************************/
namespace Havel.Mapping.Annotation
{

	using System;

	using Havel.Configuration;

	/// <summary>
	/// Required class-level attribute for objects using the <see cref="T:Havel.Mapping.Annotation.AnnotationStrategy"/> for mapping objects.
	/// </summary>
	[System.AttributeUsage( AttributeTargets.Class, AllowMultiple = false )]
	public class PersistentAttribute : Attribute
	{
		/// <summary>
		///Gets or Sets the Name of the table the persistent object is stored to.
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// <see cref="T:Havel.Configuration.NamingConvention"/> to use in determining database table and column naming conventions. If this property is left blank
		/// Havel will use the default <see cref="T:Havel.Configuration.NamingConvention"/> 
		/// found in <see cref="Havel.Configuration.ConventionTable.Instance.NamingConvention"/>. 
		/// </summary>
		public NamingConvention NamingConvention { get; set; }

		/// <summary>
		/// Initializes a default instance of <see cref="T:PersistentAttribute" />.  Use this constructor if your object has a parent and does not persist to it's own table.
		/// </summary>
		public PersistentAttribute() : this( String.Empty ) { }

		/// <summary>
		/// Instantiates the <see cref="T:PersistentAttribute" /> with the table name defined.
		/// </summary>
		/// <param name="table">Name of the table the persistent object is stored to.</param>
		public PersistentAttribute( string table )
		{
			this.Name = table;
			this.NamingConvention = Configuration.ConventionTable.Instance.NamingConvention;
		}

		/// <summary>
		/// Instantiates the <see cref="T:PersistentAttribute" /> with the table name and naming convention defined.
		/// </summary>
		/// <param name="table">Name of the table the persistent object is stored to.</param>
		/// <param name="convention"><see cref="T:Havel.Configuration.NamingConvention"/> to use in determining database table and column names.</param>
		public PersistentAttribute( string table, string convention )
		{
			this.Name = table;
			var type = Type.GetType( convention );
			if( type == null ) 
				throw ( new ArgumentException( String.Format( "Could not instantiate type {0}. Please ensure that convention is a fully qualified name.", convention ), "convention" ) );
			this.NamingConvention = Activator.CreateInstance( type ) as NamingConvention;
		}
	}
}
