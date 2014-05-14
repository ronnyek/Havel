/***********************************************************************
<copyright file="AbstractAdapter.cs" company="Ikarii">
    Copyright © Ikarii 2014 All rights reserved.
    Author: Shawn Hall
</copyright>
***********************************************************************/
namespace Havel.Adapters
{
	using System;

	using Havel.Utility;

	public abstract class AbstractAdapter : IAdapter
	{
		/// <summary>
		/// The <see cref="T:TypeMap"/> being constructed.
		/// </summary>
		public TypeMap Context { get; protected set; }

		/// <summary>
		/// Maps the defined <see cref="T:Type"/> to the supplied <see cref="T:TypeMap"/>.
		/// </summary>
		/// <param name="t"><see cref="T:Type"/> to map.</param>
		/// <param name="otm"><see cref="T:TypeMap"/> instance to populate with mappings.</param>
		abstract public void MapByType( Type t, TypeMap otm );

		/// <summary>
		/// Creates new instance of a <see cref="T:IAdapter" /> based on the <see cref="Type" /> passed in.
		/// </summary>
		/// <param name="t"><see cref="T:Type"/> to create.</param>
		/// <returns><see cref="T:IAdapter" /></returns>
		/// <exception cref="T:System.Exception" />
		public static IAdapter GetInstance( Type t )
		{
			if( !Common.ImplementsInterface( t, typeof( IAdapter ) ) )
			{
				throw new Exception( "Type must implement IAdapter or extend AbstractAdapter to be created." );
			}
			return ( t.Assembly.CreateInstance( t.FullName ) as IAdapter );
		}

		/// <summary>
		/// Determines whether the passed in type can be mapped by this provider.
		/// </summary>
		/// <param name="t"><see cref="T:Type"/> to map.</param>
		/// <returns>Value indicating whther <typeparamref name="t"/> can be mapped by this adapter.</returns>
		public abstract bool CanMapByType( Type t );
	}
}
