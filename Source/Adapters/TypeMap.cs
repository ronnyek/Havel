/***********************************************************************
<copyright file="TypeMap.cs" company="Ikarii">
    Copyright © Ikarii 2014 All rights reserved.
    Author: Shawn Hall
</copyright>
***********************************************************************/

namespace Havel.Adapters
{
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Linq;
	using System.Linq.Expressions;

	/// <summary>
	/// A <see cref="T:TypeMap" /> represents a relationship map between a class <see cref="T:Type" /> and the database.  The <see cref="T:TypeMap" />
	/// creates a "map" of the defined <see cref="T:Type" /> and is used by Persist to describe the object in database operations. 
	/// </summary>
	public class TypeMap
	{
		/// <summary>
		/// Gets the <see cref="T:Type" /> of object the <see cref="T:TypeMap" /> is mapping.
		/// </summary>
		public Type Type { get; protected set; }
	}
}
