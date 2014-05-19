/***********************************************************************
<copyright file="BaseColumnAttribute.cs" company="Ikarii">
    Copyright © Ikarii 2014 All rights reserved.
    Author: Shawn Hall
</copyright>
***********************************************************************/
namespace Havel.Mapping.Annotation
{
	using System;

	[AttributeUsage( AttributeTargets.Property )]
	public abstract class RelationalBaseAttribute : BaseAnnotationAttribute
	{
		/// <summary>
		/// Gets or sets the linked status of this field.  If a field is linked, persist will attempt to use
		/// a linking table to manage the relationship of this field with it's parent object.
		/// </summary>
		public bool Linked { get; set; }

		/// <summary>
		/// Gets or Sets the Name of the linking table used to join the primary object with the child object
		/// </summary>
		public string LinkName { get; set; }

		/// <summary>
		/// Gets or Sets the field name for the parent column in the linking table.
		/// </summary>
		public string LinkLeft { get; set; }

		/// <summary>
		/// Gets or Sets the field name for the child column in the linking table.
		/// </summary>
		public string LinkRight { get; set; }

		/// <summary>
		/// Gets or sets how this decorated member is retrieved.  If Lazy then this member will not be retrieved from the database
		/// until the member is accessed directly. 
		/// </summary>
		/// <remarks>Lazy loading only affects related objects which are mapped to different tables than the declaring object.
		/// For example &#151; Assuming that the Name property of the class Person is a string, Loading.Lazy would have no effect.
		/// In contrast Person.Orders would not be retrieved until accessed which would trigger a database call to load the Order objects
		/// into the Orders collection.</remarks>
		public Loading Loading { get; set; }

		/// <summary>
		/// Gets or sets if this decorated member will be included in Update or Delete operations.
		/// </summary>
		/// <remarks>This does not use, inherit, or otherwise manipulate the cascading feature in SQL and is not directly related.</remarks>
		public Cascade Cascade { get; set; }

		/// <summary>
		/// Gets or Sets the <see cref="T:System.Type"/> for the objects contained within this collection.
		/// </summary>
		public Type ChildReturnType { get; set; }
	}
}
