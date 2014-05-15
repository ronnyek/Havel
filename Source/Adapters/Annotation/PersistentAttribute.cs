/***********************************************************************
<copyright file="PersistentAttribute.cs" company="Ikarii">
    Copyright © Ikarii 2014 All rights reserved.
    Author: Shawn Hall
</copyright>
***********************************************************************/
namespace Havel.Adapters.Annotation
{

	using System;

	using Havel.Configuration;

	/// <summary>
	/// Required class attribute for objects to be used in all of Havel's operations.
	/// </summary>
	[System.AttributeUsage( AttributeTargets.Class, AllowMultiple = false )]
	public class PersistentAttribute
	{
		/// <summary>
		///Gets or Sets the Name of the table the persistent object is stored to.
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// <see cref="T:Convention"/> to use in determining database table and column naming conventions. If this property is left blank
		/// Havel will use the default <see cref="T:Convention"/> found in <see cref="ConventionTable.Instance.NamingConvention"/>. 
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
		/// <param name="convention"><see cref="T:Convention"/> to use in determining database table and column names.</param>
		public PersistentAttribute( string table, string convention )
		{
			this.Name = table;
			this.NamingConvention = Activator.CreateInstance( Type.GetType( convention ) ) as NamingConvention;
		}
	}
}
