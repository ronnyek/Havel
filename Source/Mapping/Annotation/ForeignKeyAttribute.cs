/***********************************************************************
<copyright file="ForeignKeyAttribute.cs" company="Ikarii">
    Copyright © Ikarii 2014 All rights reserved.
    Author: Shawn Hall
</copyright>
***********************************************************************/
namespace Havel.Mapping.Annotation
{
	using System;

	[AttributeUsage( AttributeTargets.Property, AllowMultiple = false )]
	public class ForeignKeyAttribute : BaseAnnotationAttribute
	{
	}
}
