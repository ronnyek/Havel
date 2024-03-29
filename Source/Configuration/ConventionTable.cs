﻿/***********************************************************************
<copyright file="PersistentAttribute.cs" company="Ikarii">
    Copyright © Ikarii 2014 All rights reserved.
    Author: Shawn Hall
</copyright>
***********************************************************************/
namespace Havel.Configuration
{
	using System; 

	using Havel.Configuration;
	using Havel.Cache;
	using Havel.Mapping;

	/// <summary>
	/// The convention table stores the current convention being used by Havel, and allows for manually
	/// generated <see cref="T:Havel.Mapping.TypeMap"/>s to be added to the <see cref="T:Havel.Cache.TypeCache"/>.  This allows 
	/// <see cref="T:Havel.Mapping.TypeMap"/>s to be added that have no usuable mapping strategies.  ConventionTable is a singleton and
	/// can only have one instance per process.
	/// </summary>
	public sealed class ConventionTable
	{
		private static readonly Lazy<ConventionTable> m_instance = new Lazy<ConventionTable>( () => new ConventionTable() );
		private NamingConvention m_convention;

		/// <summary>
		/// Gets the <see cref="T:ConventionTable"/> singleton instance.
		/// </summary>
		public static ConventionTable Instance
		{
			get { return ( m_instance.Value ); }
		}

		/// <summary>
		/// Gets the current <see cref="T:Convention"/> being used by Persist.
		/// </summary>
		public NamingConvention NamingConvention
		{
			get { return ( this.m_convention ); }
			set { this.m_convention = value; }
		}

		private ConventionTable()
		{
			this.m_convention = Settings.GetNamingConvention();
		}

		/// <summary>
		/// Registers a <see cref="T:TypeMap"/> with the Type cache.
		/// </summary>
		/// <param name="typemap"><see cref="T:TypeMap"/> to register.</param>
		public void RegisterTypeMap( TypeMap typemap ) { TypeCache.AddType( typemap.Type, typemap ); }
	}
}
