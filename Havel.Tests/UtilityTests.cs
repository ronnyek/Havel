using Xunit;
using Havel.Utility;

public class UtilityTests
{
	[Fact]
	public void BracketedDelimiter()
	{
		Assert.Equal( Common.DelimitIdentifier( "table_name", Havel.Mapping.DelimiterFormat.Bracketed ), "[table_name]" );
	}

	[Fact]
	public void QuotedDelimiter()
	{
		Assert.Equal( Common.DelimitIdentifier( "table_name", Havel.Mapping.DelimiterFormat.Quoted ), "\"table_name\"" );
	}

	[Fact]
	public void NoDelimiter()
	{
		Assert.Equal( Common.DelimitIdentifier( "table_name", Havel.Mapping.DelimiterFormat.None ), "table_name" );
	}

	[Fact]
	public void UndefinedDelimiter()
	{
		Assert.Equal( Common.DelimitIdentifier( "table_name" ), "table_name" );
	}

	[Fact]
	public void IdentityFormat()
	{
		Assert.Throws<Havel.Exceptions.MappingException>( () => Common.GetIdentityFormat( typeof( System.Decimal ) ) );
	}
}
