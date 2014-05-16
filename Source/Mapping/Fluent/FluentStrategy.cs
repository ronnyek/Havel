/***********************************************************************
<copyright file="FluentStrategy.cs" company="Ikarii">
    Copyright © Ikarii 2014 All rights reserved.
    Author: Shawn Hall
</copyright>
***********************************************************************/
namespace Havel.Mapping.Fluent
{
	public class FluentStrategy
	{
	}
}


/*
 * 
 * This adapter should allow something like this.
 * var adapter = new FluentAdapter<MyType>();
 * var map = adapter.Setup( type => 
 *					{
 *						PrimaryKey = type.Id,
 *						Columns = new ColumnList[]
 *						{
 *							new Column( type.Name ),
 *							new Column( type.Email )
 *						}
 *					} )
 *					.ToMap();
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
*/