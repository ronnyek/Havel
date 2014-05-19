/***********************************************************************
<copyright file="ColumnAttribute.cs" company="Ikarii">
    Copyright © Ikarii 2014 All rights reserved.
    Author: Shawn Hall
</copyright>
***********************************************************************/
namespace Havel.Mapping.Annotation
{
	using System;

	using Havel.Utility;

	[AttributeUsage( AttributeTargets.Property, AllowMultiple = false )]
	public class ColumnAttribute : BaseAnnotationAttribute
	{
		/// <summary>
		/// Gets or sets the <see cref="T:Boolean" /> value for determining whether this member can be null when persisted to the database.
		/// </summary>
		public bool AllowNull { get; set; }


		/// <summary>
		/// Gets or sets the size of this column. This is used for creating tables that don't already exist and ensuring that the data stored
		/// in the annotated field does not exceed the length of the database column. The default value of 0 will cause Havel to ignore 
		/// validation regarding column size.
		/// </summary>
		public int Size { get; set; }

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
		/// <param name="size"></param>
		public ColumnAttribute( string name = Constants.EMPTY_STRING, MappingBehavior behavior = MappingBehavior.Inherit, bool allowNull = false, object defaultValue = null, int size = 0 )
			: base( name: name, behavior: behavior )
		{
			this.AllowNull = allowNull;
			this.DefaultValue = defaultValue;
			this.Size = size;
		}
	}
}
