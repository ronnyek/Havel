/***********************************************************************
<copyright file="ColumnAttribute.cs" company="Ikarii">
    Copyright © Ikarii 2014 All rights reserved.
    Author: Shawn Hall
</copyright>
***********************************************************************/
namespace Havel.Mapping.Annotation
{
	using System;

	[AttributeUsage( AttributeTargets.Property, AllowMultiple = false )]
	public class ColumnAttribute : BaseAnnotationAttribute
	{
		/// <summary>
		/// Gets or sets the <see cref="T:Boolean" /> value for determining whether this member can be null when persisted to the database.
		/// </summary>
		public bool AllowNull { get; set; }

		/// <summary>
		/// Gets or sets the default value for this column.  If not set, the value for this decorated member will persist as 
		/// <see cref="T:DBNull"/>
		/// </summary>
		public object DefaultValue { get; set; }

		/// <summary>
		/// 
		/// </summary>
		/// <param name="name"></param>
		/// <param name="behavior"></param>
		/// <param name="allowNull"></param>
		/// <param name="defaultValue"></param>
		public ColumnAttribute( string name = "", MappingBehavior behavior = MappingBehavior.Inherit, bool allowNull = false, object defaultValue = null )
			: base( name: name, behavior: behavior )
		{
			this.AllowNull = allowNull;
			this.DefaultValue = defaultValue;
		}
	}
}
