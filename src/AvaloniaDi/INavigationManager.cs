namespace AvaloniaDi;

public interface INavigationManager
{
	string CurrentRoute { get; }
	object? CurrentRouteParams { get; }
	void NavigateTo(string route, object? routeParams = null);
}