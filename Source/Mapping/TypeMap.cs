/***********************************************************************
<copyright file="TypeMap.cs" company="Ikarii">
    Copyright © Ikarii 2014 All rights reserved.
    Author: Shawn Hall
</copyright>
***********************************************************************/

namespace Havel.Mapping
{
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Linq;
	using System.Linq.Expressions;

	/// <summary>
	/// A <see cref="T:Havel.Mapping.TypeMap" /> is a representation of a class that defines how properties in a class relate to a relational database objects.  
	/// </summary>
	public class TypeMap
	{
		/// <summary>
		/// Gets the <see cref="T:System.Type" /> of object the <see cref="T:Havel.Mapping.TypeMap" /> is mapping.
		/// </summary>
		public Type Type { get; protected set; }
	}
}
