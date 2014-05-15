/***********************************************************************
<copyright file="HavelConfigurationSection.cs" company="Ikarii">
    Copyright © Ikarii, LLC. 2012 All rights reserved.
    Author: Shawn Hall
</copyright>
***********************************************************************/
namespace Havel.Configuration
{
	using System;
	using System.Web;
	using System.Configuration;
	using System.Reflection;

	using Havel.Adapters;
	using Havel.Extensions.Internal;

	public class HavelConfigurationSection : ConfigurationSection
	{
		/// <summary>
		/// Default <see cref="T:System.Data.DbConnection"/> that Persist will use when one is not
		/// explicitly set.
		/// </summary>
		[ConfigurationProperty( "defaultConnection", DefaultValue = "", IsRequired = false )]
		public string DefaultConnection
		{
			get { return ( string )this[ "defaultConnection" ]; }
			set { this[ "defaultConnection" ] = value; }
		}

		/// <summary>
		/// Default <see cref="T:Ikarii.Lib.Data.Alpaca.Logging.ILoggingProvider"/> Persist will use
		/// for logging events.
		/// </summary>
		[ConfigurationProperty( "loggingProvider", DefaultValue = null, IsRequired = false )]
		public Type LoggingProvider
		{
			get { return ( Type )this[ "loggingProvider" ]; }
			set { this[ "loggingProvider" ] = value; }
		}

		/// <summary>
		/// Type of logger to use for trace data.
		/// </summary>
		[ConfigurationProperty( "traceLogger", DefaultValue = "", IsRequired = false )]
		public string TraceLogger
		{
			get { return ( string )this[ "traceLogger" ]; }
			set { this[ "traceLogger" ] = value; }
		}

		/// <summary>
		/// Type of logger to use for warnings.
		/// </summary>
		[ConfigurationProperty( "warnLogger", DefaultValue = "", IsRequired = false )]
		public string WarnLogger
		{
			get { return ( string )this[ "warnLogger" ]; }
			set { this[ "warnLogger" ] = value; }
		}

		/// <summary>
		/// Type of logger to use for errors.
		/// </summary>
		[ConfigurationProperty( "errorLogger", DefaultValue = "", IsRequired = false )]
		public string ErrorLogger
		{
			get { return ( string )this[ "errorLogger" ]; }
			set { this[ "errorLogger" ] = value; }
		}

		/// <summary>
		/// Type of logger to use for fatal errors.
		/// </summary>
		[ConfigurationProperty( "fatalLogger", DefaultValue = "", IsRequired = false )]
		public string FatalLogger
		{
			get { return ( string )this[ "fatalLogger" ]; }
			set { this[ "fatalLogger" ] = value; }
		}

		/// <summary>
		/// Defaulty type of logger to use for all message types.
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
		/// Identifier format to use when creating SQL statements.  Default is <see cref="DelimiterFormat.Bracketed"/>
		/// </summary>
		[ConfigurationProperty( "useIdentifiers", DefaultValue = DelimiterFormat.Bracketed, IsRequired = false )]
		public DelimiterFormat UseIdentifiers
		{
			get { return ( DelimiterFormat )this[ "useIdentifiers" ]; }
			set { this[ "useIdentifiers" ] = value; }
		}

		/// <summary>
		/// Default <see cref="T:Mapping.Convention"/> to use when generating undefined field and table names.
		/// </summary>
		[ConfigurationProperty( "namingConvention", DefaultValue = typeof( Havel.Configuration.NamingConvention ), IsRequired = false )]
		public Type NamingConvention
		{
			get { return ( Type )this[ "namingConvention" ]; }
			set { this[ "namingConvention" ] = value; }
		}

		/// <summary>
		/// Default <see cref="T:Mapping.IMappingProvider"/> to use when one isn't explicitly set in an operation.
		/// Default value is <see cref="T:Mapping.AttributeMappingProvider"/>.
		/// </summary>
		[ConfigurationProperty( "defaultMappingProvider", DefaultValue = typeof( Adapters.Annotation.AnnotationAdapter ), IsRequired = false )]
		public Type DefaultMappingProvider
		{
			get { return ( Type )this[ "defaultMappingProvider" ]; }
			set { this[ "defaultMappingProvider" ] = value; }
		}

		/// <summary>
		/// Default <see cref="T:IPersistenceProvider"/> to use when one isn't explicitly set in an operation.
		/// Default is <see cref="T:MsSql.SqlPersistenceProvider"/>.
		/// </summary>
		[ConfigurationProperty( "defaultPersistenceProvider", DefaultValue = typeof( Providers.MsSqlPersistenceProvider ), IsRequired = false )]
		public Type DefaultPersistenceProvider
		{
			get { return ( Type )this[ "defaultPersistenceProvider" ]; }
			set { this[ "defaultPersistenceProvider" ] = value; }
		}

		/// <summary>
		/// Defines the folder which contains type maps usable by the <see cref="T:Mapping.XmlMappingProvider"/>.
		/// </summary>
		[ConfigurationProperty( "xmlMapFolder", DefaultValue = "Maps", IsRequired = false )]
		public string XmlMapFolder
		{
			get { return ( string )this[ "xmlMapFolder" ]; }
			set { this[ "xmlMapFolder" ] = value; }
		}

	}
}
