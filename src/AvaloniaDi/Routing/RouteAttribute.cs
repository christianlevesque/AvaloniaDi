using System;

namespace AvaloniaDi.Routing;

[AttributeUsage(AttributeTargets.Class)]
public class RouteAttribute : Attribute
{
	public string Route { get; }

	public RouteAttribute(string route)
	{
		Route = route;
	}
}