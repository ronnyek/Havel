/***********************************************************************
<copyright file="IdentityFormat.cs" company="Ikarii">
    Copyright © Ikarii 2014 All rights reserved.
    Author: Shawn Hall
</copyright>
***********************************************************************/
namespace Havel.Mapping
{
	/// <summary>
	/// Describes the <see cref="T:Type"/> that represents the identity column of an object.
	/// </summary>
	public enum IdentityFormat
	{
		/// <summary>
		/// Represents an integer-based identity column.
		/// </summary>
		Integer,

		/// <summary>
		/// Represents a Guid-based identity column.
		/// </summary>
		Guid,

		/// <summary>
		/// Represents a string-based identity column.
		/// </summary>
		String,

		/// <summary>
		/// Represents an unkown type
		/// </summary>
		Unknown
	}
}
