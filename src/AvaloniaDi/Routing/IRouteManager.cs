using System;

namespace AvaloniaDi.Routing;

public interface IRouteManager
{
	/// <summary>
	/// Registers an app window as a route
	/// </summary>
	/// <param name="route">The route at which to register the view</param>
	/// <param name="viewType">The <see cref="Type"/> of the view</param>
	/// <returns><c>this</c></returns>
	IRouteManager AddRoute(string route, Type viewType);

	/// <summary>
	/// Gets the <see cref="Type"/> representing an application view route
	/// </summary>
	/// <param name="route">The route whose view to retrieve</param>
	/// <returns>the <see cref="Type"/> of the view</returns>
	Type GetRouteType(string route);
}