/***********************************************************************
<copyright file="PrimaryKeyAttribute.cs" company="Ikarii">
    Copyright © Ikarii 2014 All rights reserved.
    Author: Shawn Hall
</copyright>
***********************************************************************/
namespace Havel.Mapping.Annotation
{
	using System;

	[AttributeUsage( AttributeTargets.Property, AllowMultiple = false )]
	public class PrimaryKeyAttribute : BaseAnnotationAttribute
	{
		/// <summary>
		/// Defines the value persist should compare when determining if this instance is a new or existing id.
		/// </summary>
		/// <remarks>IMPORTANT: This does not automatically set the value of your primary key field - it is only
		/// an arbitrary value that persist compares the current value of your primary key field with.
		/// By default this value is 0 for Integer types, String.Empty for String types and new Guid() for Guid types.
		/// </remarks>
		public object UnsavedValue { get; set; }

		
	}
}
