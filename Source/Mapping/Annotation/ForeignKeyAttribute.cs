/***********************************************************************
<copyright file="ForeignKeyAttribute.cs" company="Ikarii">
    Copyright © Ikarii 2014 All rights reserved.
    Author: Shawn Hall
</copyright>
***********************************************************************/
namespace Havel.Mapping.Annotation
{
	using System;

	using Havel.Utility;

	[AttributeUsage( AttributeTargets.Property, AllowMultiple = false )]
	public class ForeignKeyAttribute : BaseAnnotationAttribute
	{
		/// <summary>
		/// Gets or sets the <see cref="System.Type" /> of the object this decorated member is a child of.
		/// </summary>
		public Type Parent { get; set; }

		public ForeignKeyAttribute( Type parent, string name = Constants.EMPTY_STRING, MappingBehavior behavior = MappingBehavior.Inherit )
			: base( name: name, behavior: behavior )
		{
			this.Parent = parent;
		}
	}
}
