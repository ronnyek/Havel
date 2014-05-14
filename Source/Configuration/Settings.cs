/***********************************************************************
<copyright file="Settings.cs" company="Ikarii">
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

	using Havel.Adapters;
	using Havel.Extensions.Internal;
	using Havel.Logging;

	public class Settings
	{
		private static readonly Lazy<Settings> m_instance = new Lazy<Settings>( () => new Settings() );
		private enum RunningContext { Web, Executable }
		private HavelConfigurationSection m_configuration;

		internal static Settings Instance
		{
			get { return ( m_instance.Value ); }
		}


		/// <summary>
		/// Default <see cref="T:System.Data.DbConnection"/> that Persist will use when one is not
		/// explicitly set.
		/// </summary>
		public static string DefaultConnection
		{
			get { return ( Instance.m_configuration.DefaultConnection ); }
		}

		/// <summary>
		/// Default <see cref="T:Ikarii.Lib.Data.Alpaca.Logging.ILoggingProvider"/> Persist will use
		/// for logging events.
		/// </summary>
		public static Type LoggingProvider
		{
			get { return ( Instance.m_configuration.LoggingProvider ); }
		}

		/// <summary>
		/// Type of logger to use for trace data.
		/// </summary>
		public static string TraceLogger
		{
			get { return ( Instance.m_configuration.TraceLogger ); }
		}

		/// <summary>
		/// Type of logger to use for warnings.
		/// </summary>
		public static string WarnLogger
		{
			get { return ( Instance.m_configuration.WarnLogger ); }
		}

		/// <summary>
		/// Type of logger to use for errors.
		/// </summary>
		public static string ErrorLogger
		{
			get { return ( Instance.m_configuration.ErrorLogger ); }
		}

		/// <summary>
		/// Type of logger to use for fatal errors.
		/// </summary>
		public static string FatalLogger
		{
			get { return ( Instance.m_configuration.FatalLogger ); }
		}

		/// <summary>
		/// Defaulty type of logger to use for all message types.
		/// </summary>
		public static string DefaultLogger
		{
			get { return ( Instance.m_configuration.DefaultLogger ); }
		}

		/// <summary>
		/// Explicitly set the use of object cache.  Default is false.
		/// </summary>
		public static bool UseObjectCache
		{
			get { return ( Instance.m_configuration.UseObjectCache ); }
		}

		/// <summary>
		/// Explicitly set the use of type cache. Default is true.  It is highly recommended to leave this value set to true.
		/// </summary>
		public static bool UseTypeCache
		{
			get { return ( Instance.m_configuration.UseTypeCache ); }
		}

		/// <summary>
		/// Identifier format to use when creating SQL statements.  Default is <see cref="IdentifierFormat.Bracketed"/>
		/// </summary>
		public static IdentifierFormat UseIdentifiers
		{
			get { return ( Instance.m_configuration.UseIdentifiers ); }
		}

		/// <summary>
		/// Default <see cref="T:Mapping.Convention"/> to use when generating undefined field and table names.
		/// </summary>
		public static Type NamingConvention
		{
			get { return ( Instance.m_configuration.NamingConvention ); }
		}

		/// <summary>
		/// Default <see cref="T:Mapping.IMappingProvider"/> to use when one isn't explicitly set in an operation.
		/// Default value is <see cref="T:Mapping.AttributeMappingProvider"/>.
		/// </summary>
		public static Type DefaultMappingProvider
		{
			get { return ( Instance.m_configuration.DefaultMappingProvider ); }
		}

		/// <summary>
		/// Default <see cref="T:IPersistenceProvider"/> to use when one isn't explicitly set in an operation.
		/// Default is <see cref="T:MsSql.SqlPersistenceProvider"/>.
		/// </summary>
		public static Type DefaultPersistenceProvider
		{
			get { return ( Instance.m_configuration.DefaultPersistenceProvider ); }
		}

		/// <summary>
		/// Defines the folder which contains type maps usable by the <see cref="T:Mapping.XmlMappingProvider"/>.
		/// </summary>
		public static string XmlMapFolder
		{
			get { return ( Instance.m_configuration.XmlMapFolder ); }
		}


		/// <summary>
		/// 
		/// </summary>
		private Settings() 
		{
			this.m_configuration = GetConfigurationSection();
		}


		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		private static HavelConfigurationSection GetConfigurationSection()
		{
			var file = AppDomain.CurrentDomain.SetupInformation.ConfigurationFile;
			var result = new HavelConfigurationSection();
			var config = default( Configuration );
			var context = ( Assembly.GetEntryAssembly().Null() && HttpContext.Current.NotNull() ? RunningContext.Web : RunningContext.Executable );

			try
			{
				config = context.Equals( RunningContext.Web ) ?
					System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration( file ) :
					System.Configuration.ConfigurationManager.OpenExeConfiguration( file );
			}
			catch { }

			if( config.NotNull() )
			{
				foreach( ConfigurationSection section in config.Sections )
				{
					if( Type.GetType( section.SectionInformation.Type ) == typeof( Settings ) )
						result = ConfigurationManager.GetSection( section.SectionInformation.Name ) as HavelConfigurationSection;
				}
			}
			return ( result );
		}

		/// <summary>
		/// Returns an instance of <see cref="P:DefaultAdapter"/>.
		/// </summary>
		/// <returns></returns>
		public Adapters.IAdapter GetDefaultAdapter()
		{
			return ( Adapters.AbstractAdapter.GetInstance( DefaultMappingProvider ) );
		}

		/// <summary>
		/// Gets an instance of <see cref="P:NamingConvention"/>.
		/// </summary>
		/// <returns></returns>
		public Havel.Configuration.NamingConvention GetNamingConvention()
		{
			return ( Settings.NamingConvention.Assembly.CreateInstance( Settings.NamingConvention.FullName ) as Havel.Configuration.NamingConvention );
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="type"></param>
		/// <returns></returns>
		internal static string GetLogger( Logging.EventType type )
		{
			switch( type )
			{
				case EventType.Trace: return ( String.IsNullOrEmpty( Settings.TraceLogger ) ? Settings.DefaultLogger : Settings.TraceLogger );
				case EventType.Error: return ( String.IsNullOrEmpty( Settings.ErrorLogger ) ? Settings.DefaultLogger : Settings.ErrorLogger );
				case EventType.Warn: return ( String.IsNullOrEmpty( Settings.WarnLogger ) ? Settings.DefaultLogger : Settings.WarnLogger );
				case EventType.Fatal: return ( String.IsNullOrEmpty( Settings.FatalLogger ) ? Settings.DefaultLogger : Settings.FatalLogger );
				default: return ( Settings.DefaultLogger );
			}
		}
	}
}
