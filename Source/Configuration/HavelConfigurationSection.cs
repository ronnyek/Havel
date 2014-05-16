/***********************************************************************
<copyright file="HavelConfigurationSection.cs" company="Ikarii">
    Copyright © Ikarii 2014 All rights reserved.
    Author: Shawn Hall
</copyright>
***********************************************************************/
namespace Havel.Configuration
{
	using System;
	using System.Web;
	using System.Configuration;
	using System.Reflection;

	using Havel.Mapping;
	using Havel.Extensions.Internal;

	public class HavelConfigurationSection : ConfigurationSection
	{
		/// <summary>
		/// Default <see cref="T:System.Data.DbConnection"/> that Havel will use when one is not explicitly
		/// defined during instantiation of a <see cref="T:Havel.Providers.IPersistentProvider"/>.
		/// </summary>
		[ConfigurationProperty( "defaultConnection", DefaultValue = "", IsRequired = false )]
		public string DefaultConnection
		{
			get { return ( string )this[ "defaultConnection" ]; }
			set { this[ "defaultConnection" ] = value; }
		}

		/// <summary>
		/// <see cref="T:Havel.Logging.ILoggingProvider"/> Havel will use
		/// for logging events.
		/// </summary>
		[ConfigurationProperty( "loggingProvider", DefaultValue = null, IsRequired = false )]
		public Type LoggingProvider
		{
			get { return ( Type )this[ "loggingProvider" ]; }
			set { this[ "loggingProvider" ] = value; }
		}

		/// <summary>
		/// Logger Havel will use in the case of a <see cref="Havel.Logging.EventType.Trace"/> event.
		/// </summary>
		[ConfigurationProperty( "traceLogger", DefaultValue = "", IsRequired = false )]
		public string TraceLogger
		{
			get { return ( string )this[ "traceLogger" ]; }
			set { this[ "traceLogger" ] = value; }
		}

		/// <summary>
		/// Logger Havel will use in the case of a <see cref="Havel.Logging.EventType.Warn"/> event.
		/// </summary>
		[ConfigurationProperty( "warnLogger", DefaultValue = "", IsRequired = false )]
		public string WarnLogger
		{
			get { return ( string )this[ "warnLogger" ]; }
			set { this[ "warnLogger" ] = value; }
		}

		/// <summary>
		/// Logger Havel will use in the case of a <see cref="Havel.Logging.EventType.Error"/> event.
		/// </summary>
		[ConfigurationProperty( "errorLogger", DefaultValue = "", IsRequired = false )]
		public string ErrorLogger
		{
			get { return ( string )this[ "errorLogger" ]; }
			set { this[ "errorLogger" ] = value; }
		}

		/// <summary>
		/// Logger Havel will use in the case of a <see cref="Havel.Logging.EventType.Fatal"/> event.
		/// </summary>
		[ConfigurationProperty( "fatalLogger", DefaultValue = "", IsRequired = false )]
		public string FatalLogger
		{
			get { return ( string )this[ "fatalLogger" ]; }
			set { this[ "fatalLogger" ] = value; }
		}

		/// <summary>
		/// Default logger to use for all message types if one isn't specified.
		/// </summary>
		[ConfigurationProperty( "defaultLogger", DefaultValue = "", IsRequired = false )]
		public string DefaultLogger
		{
			get { return ( string )this[ "defaultLogger" ]; }
			set { this[ "defaultLogger" ] = value; }
		}

		/// <summary>
		/// Explicitly set the use of object cache.  Default is false.
		/// </summary>
		[ConfigurationProperty( "useObjectCache", DefaultValue = false, IsRequired = false )]
		public bool UseObjectCache
		{
			get { return ( bool )this[ "useObjectCache" ]; }
			set { this[ "useObjectCache" ] = value; }
		}

		/// <summary>
		/// Explicitly set the use of type cache. Default is true.  It is highly recommended to leave this value set to true.
		/// </summary>
		[ConfigurationProperty( "useTypeCache", DefaultValue = true, IsRequired = false )]
		public bool UseTypeCache
		{
			get { return ( bool )this[ "useTypeCache" ]; }
			set { this[ "useTypeCache" ] = value; }
		}

		/// <summary>
		/// Delimiter to decorate identifiers with when creating SQL statements.  Default is <see cref="Havel.Mapping.DelimiterFormat.Bracketed"/>
		/// </summary>
		[ConfigurationProperty( "useIdentifiers", DefaultValue = DelimiterFormat.Bracketed, IsRequired = false )]
		public DelimiterFormat UseIdentifiers
		{
			get { return ( DelimiterFormat )this[ "useIdentifiers" ]; }
			set { this[ "useIdentifiers" ] = value; }
		}

		/// <summary>
		/// Default <see cref="T:Havel.Configuration.NamingConvention"/> to use for column and table names.
		/// </summary>
		[ConfigurationProperty( "namingConvention", DefaultValue = typeof( Havel.Configuration.NamingConvention ), IsRequired = false )]
		public Type NamingConvention
		{
			get { return ( Type )this[ "namingConvention" ]; }
			set { this[ "namingConvention" ] = value; }
		}

		/// <summary>
		/// Default <see cref="T:Havel.Mapping.IMappingStrategy"/> to use when one isn't explicitly set in an operation.
		/// Default value is <see cref="T:Havel.Mapping.Annotation.AnnotationStrategy"/>.
		/// </summary>
		[ConfigurationProperty( "defaultMappingStrategy", DefaultValue = typeof( Mapping.Annotation.AnnotationStrategy ), IsRequired = false )]
		public Type DefaultMappingStrategy
		{
			get { return ( Type )this[ "defaultMappingStrategy" ]; }
			set { this[ "defaultMappingStrategy" ] = value; }
		}

		/// <summary>
		/// Default <see cref="T:Havel.Providers.IPersistenceProvider"/> to use when one isn't explicitly set in an operation.
		/// Default is <see cref="T:Havel.Providers.MsSqlPersistenceProvider"/>.
		/// </summary>
		[ConfigurationProperty( "defaultPersistenceProvider", DefaultValue = typeof( Providers.MsSqlPersistenceProvider ), IsRequired = false )]
		public Type DefaultPersistenceProvider
		{
			get { return ( Type )this[ "defaultPersistenceProvider" ]; }
			set { this[ "defaultPersistenceProvider" ] = value; }
		}

		/// <summary>
		/// Defines the folder which contains type maps usable by <see cref="T:Havel.Mapping.IMappingStrategy"/> classes in the
		/// <see cref="N:Havel.Mapping.Xml"/> namespace. Default value is "maps".
		/// </summary>
		[ConfigurationProperty( "xmlMapFolder", DefaultValue = "maps", IsRequired = false )]
		public string XmlMapFolder
		{
			get { return ( string )this[ "xmlMapFolder" ]; }
			set { this[ "xmlMapFolder" ] = value; }
		}

	}
}
