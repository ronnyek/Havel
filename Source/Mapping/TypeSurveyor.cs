/***********************************************************************
<copyright file="TypeSurveyor.cs" company="Ikarii">
    Copyright © Ikarii 2014 All rights reserved.
    Author: Shawn Hall
</copyright>
***********************************************************************/
namespace Havel.Mapping
{
	using System;

	public class TypeSurveyor
	{
		/// <summary>
		/// 
		/// </summary>
		public IMappingStrategy Strategy { get; private set; }

		/// <summary>
		/// 
		/// </summary>
		/// <param name="strategy"></param>
		public TypeSurveyor( IMappingStrategy strategy )
		{
			this.Strategy = strategy;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="type"></param>
		/// <returns></returns>
		public TypeMap Map( Type type )
		{
			//return ( this.Strategy.MapByType( t ) );
			return ( new TypeMap() );
		}

	}
}
