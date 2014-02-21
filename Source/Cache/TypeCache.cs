/***********************************************************************
<copyright file="TypeCache.cs" company="Ikarii">
    Copyright © Ikarii 2014 All rights reserved.
    Author: Shawn Hall
</copyright>
***********************************************************************/
namespace Havel.Cache
{
	using System;
	using System.Collections.Generic;

	internal sealed class TypeCache
	{
		private static readonly TypeCache m_instance = new TypeCache();

		private Dictionary<Type, TypeMap> m_stack;

		internal static TypeCache Instance
		{
			get { return ( m_instance ); }
		}

		internal Dictionary<Type, TypeMap> Stack
		{
			get { return ( this.m_stack ); }
		}

		private TypeCache()
		{
			this.m_stack = new Dictionary<Type, TypeMap>();
		}

		internal static void AddType( Type t, TypeMap o )
		{
			Instance.Stack.Remove( t );
			Instance.Stack.Add( t, o );
		}

		internal static bool ContainsType( Type t )
		{
			return ( Instance.Stack.ContainsKey( t ) );
		}

		internal static TypeMap GetType( Type t )
		{
			return ( Instance.Stack [ t ] );
		}

		internal static void RemoveType( Type t )
		{
			if( Instance.Stack.ContainsKey( t ) )
			{
				Instance.Stack.Remove( t );
			}
		}
	}
}
