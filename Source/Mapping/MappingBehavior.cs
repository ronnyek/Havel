/***********************************************************************
<copyright file="MappingBehavior.cs" company="Ikarii">
    Copyright © Ikarii 2014 All rights reserved.
    Author: Shawn Hall
</copyright>
***********************************************************************/
namespace Havel.Mapping
{
	public enum MappingBehavior
	{
		/// <summary>
		/// Specifies the member should be inherited and used in Persist operations by subclasses.  This is the default behavior of a member.
		/// </summary>
		Inherit,
		/// <summary>
		/// Specifies that a member should be excluded when performing Persist operations on a subclass that inherits this member.
		/// </summary>
		Exclude,
		/// <summary>
		/// Specifies that the member should only be retrieved from the storage device and never persisted.
		/// </summary>
		ReadOnly
	}
}
