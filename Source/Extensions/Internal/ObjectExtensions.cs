/***********************************************************************
<copyright file="ObjectExtensions.cs" company="Ikarii">
    Copyright © Ikarii 2014 All rights reserved.
    Author: Shawn Hall
</copyright>
***********************************************************************/
namespace Havel.Extensions.Internal
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;

	public static class ObjectExtensions
	{
		internal static bool Null( this Object o )
		{
			return ( o == null );
		}

		internal static bool NotNull( this Object o )
		{
			return ( o != null );
		}

		internal static bool NotEquals( this Object o, object obj )
		{
			return ( !o.Equals( obj ) );
		}
	}
}
