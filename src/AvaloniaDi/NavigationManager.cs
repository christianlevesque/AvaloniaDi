using System;
using Avalonia.Controls;
using Microsoft.Extensions.DependencyInjection;
using AvaloniaDi.Routing;

namespace AvaloniaDi;

public class NavigationManager : INavigationManager
{
	protected readonly IServiceProvider Services;
	protected readonly IRouteManager RouteManager;
	protected readonly ActiveViewProvider ActiveViewModel;
	protected IServiceScope? ServiceScope;

	public NavigationManager(
		IServiceProvider services,
		IRouteManager routeManager,
		ActiveViewProvider activeViewModel)
	{
		Services = services;
		RouteManager = routeManager;
		ActiveViewModel = activeViewModel;
	}

	public string CurrentRoute { get; private set; } = string.Empty;

	public object? CurrentRouteParams { get; private set; }

	/// <inheritdoc />
	public void NavigateTo(string route, object? routeParams = null)
	{
		ServiceScope?.Dispose();
		ServiceScope = Services.CreateScope();
		var routeType = RouteManager.GetRouteType(route);
		ActiveViewModel.ActiveView = (UserControl)ServiceScope.ServiceProvider.GetRequiredService(routeType);
		CurrentRoute = route;
		CurrentRouteParams = routeParams;
	}
}