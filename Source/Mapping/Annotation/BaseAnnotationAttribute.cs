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
	public abstract class BaseAnnotationAttribute : Attribute
	{
		/// <summary>
		/// Gets or sets the Name of the storage device field to persist to.
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Gets or sets the <see cref="T:Havel.Mapping.MappingBehavior" /> the decorated property should use.
		/// </summary>
		public MappingBehavior Behavior { get; set; }

		/// <summary>
		/// 
		/// </summary>
		/// <param name="name"></param>
		/// <param name="behavior"></param>
		protected BaseAnnotationAttribute( string name = "", MappingBehavior behavior = MappingBehavior.Inherit )
		{
			this.Name = name;
			this.Behavior = behavior;
		}
	}
}
