/***********************************************************************
<copyright file="MappingException.cs" company="Ikarii">
    Copyright © Ikarii 2014 All rights reserved.
    Author: Shawn Hall
</copyright>
***********************************************************************/
namespace Havel.Exceptions
{
	using System;

	/// <summary>
	/// Represents an error that occurs during mapping operations in Persist. 
	/// </summary>
	public class MappingException : Exception
	{
		/// <summary>
		/// Initializes a new <see cref="T:MappingException"/> with the specified message.
		/// </summary>
		/// <param name="message">Detailed message of error.</param>
		public MappingException( string message ) : base( message ) { }

		/// <summary>
		/// Initializes a new <see cref="T:MappingException"/> with the specified message.
		/// </summary>
		/// <param name="message">Detailed message of error.</param>
		/// <param name="innerException">The inner <see cref="T:Exception"/> generated resulting in this exception.</param>
		public MappingException( string message, Exception innerException ) : base( message, innerException ) { }
	}
}
