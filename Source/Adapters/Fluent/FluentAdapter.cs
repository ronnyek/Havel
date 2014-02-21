using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Havel.Adapters.Fluent
{
	class FluentAdapter
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