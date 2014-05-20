/***********************************************************************
<copyright file="DelimiterFormat.cs" company="Ikarii">
    Copyright © Ikarii 2014 All rights reserved.
    Author: Shawn Hall
</copyright>
***********************************************************************/
namespace Havel.Mapping
{
	using System;

	/// <summary>
	/// Enum describing cascading behavior for related objects in a persistent operation.
	/// </summary>
	[Flags]
	public enum Cascade
	{
		/// <summary>
		/// No cascading updates or deletes should occur.
		/// </summary>
		None = 0,

		/// <summary>
		/// Only cascading deletes should occur.
		/// </summary>
		Delete = 1,

		/// <summary>
		/// Only cascading updates should occur.
		/// </summary>
		Update = 2,

		/// <summary>
		/// Both cascading updates and deletes should occur.
		/// </summary>
		All = Delete | Update
	}
}
