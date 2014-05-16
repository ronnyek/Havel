/***********************************************************************
<copyright file="IdentityGeneratorType.cs" company="Ikarii">
    Copyright © Ikarii 2014 All rights reserved.
    Author: Shawn Hall
</copyright>
***********************************************************************/
namespace Havel.Mapping
{
	public enum IdentityGeneratorType
	{
		/// <summary>
		/// Havel attempts to use underlying database mechanisms to generate appropriate identity values.
		/// <see cref="T:System.Int32"/> and <see cref="T:System.Int64"/> indentities will expect the underlying
		/// database to handle the mechanics of identity generation and incrementation. <see cref="T:System.Guid"/> 
		/// will use database mechanics like newid() in Microsoft SQL Server. 
		/// </summary>
		Native,
		/// <summary>
		/// Havel will attempt to generate an appropriate identity value internally.
		/// </summary>
		Internal,
		/// <summary>
		/// Havel will use a defined function to generate an identity value.
		/// </summary>
		External
	}
}
