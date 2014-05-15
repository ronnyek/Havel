/***********************************************************************
<copyright file="IMappingProvider.cs" company="Ikarii">
    Copyright © Ikarii 2014 All rights reserved.
    Author: Shawn Hall
</copyright>
***********************************************************************/
namespace Havel.Mapping
{
	using System;

	/// <summary>
	/// Defines the interface for creating a <see cref="TypeMap"/> for persistence operations.
	/// </summary>
	public interface IMappingStrategy
	{
		/// <summary>
		/// Maps the defined <see cref="T:System.Type"/> to the supplied <see cref="ObjectTypeMap"/>.
		/// </summary>
		/// <param name="t"><see cref="T:System.Type"/> to map.</param>
		/// <param name="po"><see cref="T:Have.Adapters.TypeMap"/> instance to populate with mappings.</param>
		void MapByType( Type t, TypeMap otm );

		/// <summary>
		/// Determines if a <see cref="T:Type"/> can be mapped by this provider.
		/// </summary>
		/// <param name="t"><see cref="T:Type"/> to test.</param>
		/// <returns><see langword="True" /> if type can be mapped.</returns>
		bool CanMapByType( Type t );
	}
}
