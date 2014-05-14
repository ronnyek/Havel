/***********************************************************************
<copyright file="IdentifierFormat.cs" company="Ikarii">
	Copyright © Ikarii, LLC. 2012 All rights reserved.
	Author: Shawn Hall
</copyright>
***********************************************************************/
namespace Havel.Adapters
{
	/// <summary>
	/// Describes the formatting for identifiers used to escape table and column names.
	/// </summary>
	public enum IdentifierFormat
	{
		/// <summary>
		/// Quoted identifer, pads name in quotes.
		/// </summary>
		Quoted,

		/// <summary>
		/// Bracketed identifer, pads name in brackets. Not supported by some providers.
		/// </summary>
		Bracketed,

		/// <summary>
		/// No identifier, does not pad name.  Reserved and non-standard words will generate SQL errors
		/// without an identifier.
		/// </summary>
		None
	}
}
