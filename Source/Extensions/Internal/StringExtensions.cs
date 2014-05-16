/***********************************************************************
<copyright file="StringExtensions.cs" company="Ikarii">
    Copyright © Ikarii 2014 All rights reserved.
    Author: Shawn Hall
</copyright>
***********************************************************************/

namespace Havel.Extensions.Internal
{
	using System;
	using System.IO;
	using System.Text;
	using System.Linq.Expressions;
	using System.Reflection;
	using System.Security.Cryptography;

	using Havel.Configuration;
	using Havel.Utility;

	internal static class StringExtensions
	{
		/// <summary>
		/// Shortcut for String.Format( params object[] args )
		/// </summary>
		/// <param name="source"></param>
		/// <param name="args"></param>
		/// <returns></returns>
		public static string F( this String source, params object[] args )
		{
			return ( String.Format( source, args ) );
		}

		/// <summary>
		/// Adds the default <see cref="T:IdentifierFormat"/> to the passed in string.
		/// </summary>
		/// <param name="s"></param>
		/// <returns></returns>
		public static string AddSqlIdentifier( this String s )
		{
			return ( Common.DelimitIdentifier( s, Settings.UseIdentifiers ) );
		}
	}
}
