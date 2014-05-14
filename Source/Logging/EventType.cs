/***********************************************************************
<copyright file="EventType.cs" company="Ikarii">
    Copyright © Ikarii 2014 All rights reserved.
    Author: Shawn Hall
</copyright>
***********************************************************************/
namespace Havel.Logging
{
	using System;

	/// <summary>
	/// Describes the type of event that has occured in Persist.
	/// </summary>
	public enum EventType : byte
	{
		/// <summary>
		/// Trivial information useful for tracking and debugging.
		/// </summary>
		Trace = 0x00000002,

		/// <summary>
		/// Warnings that do not cause operations to fail but may be a cause for unexpected behavior.
		/// </summary>
		Warn = 0x00000003,

		/// <summary>
		/// Errors that were generated during a Persist operation.
		/// </summary>
		Error = 0x00000005,

		/// <summary>
		/// Unrecoverable error.
		/// </summary>
		Fatal = 0x00000007
	}
}
