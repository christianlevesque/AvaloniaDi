using System;
using System.Collections.Generic;
using AvaloniaDi.Exceptions;

namespace AvaloniaDi.Routing;

public class RouteManager : IRouteManager
{
	protected Dictionary<string, Type> Routes { get; } = new ();

	/// <inheritdoc />
	public IRouteManager AddRoute(string route, Type viewType)
	{
		Routes.Add(route, viewType);
		return this;
	}

	public Type GetRouteType(string route)
	{
		if (!Routes.TryGetValue(route, out var routeType))
		{
			throw new InvalidRouteException($"Unable to locate view with route {route}.");
		}

		return routeType;
	}
}