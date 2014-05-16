/***********************************************************************
<copyright file="DelimiterFormat.cs" company="Ikarii">
    Copyright © Ikarii 2014 All rights reserved.
    Author: Shawn Hall
</copyright>
***********************************************************************/
namespace Havel.Mapping
{
	/// <summary>
	/// Describes the formatting for identifiers used to escape table and column names.
	/// </summary>
	public enum DelimiterFormat
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
