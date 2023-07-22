using System;
using System.Linq;
using System.Reflection;
using Avalonia;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using AvaloniaDi.Routing;
using AvaloniaDi.Views;

namespace AvaloniaDi;

public class DiAppBuilder
{
	protected bool AppRegistered;
	protected bool WindowRegistered;
	protected Type? AppType;

	public IServiceCollection Services { get; }

	public IRouteManager RouteManager { get;  }

	protected DiAppBuilder()
	{
		Services = new ServiceCollection();
		RouteManager = new RouteManager();
	}

	public static DiAppBuilder Create()
		=> new ();

	public AppBuilder Build()
	{
		if (!WindowRegistered)
		{
			throw new InvalidOperationException($"You must register your Main Window instance using the {nameof(AddWindow)} method");
		}

		if (!AppRegistered)
		{
			throw new InvalidOperationException($"You must register your Application instance using the {nameof(AddApp)} method");
		}

		AddServices();
		var serviceProvider = Services.BuildServiceProvider();
		return AppBuilder.Configure(() => (Application)serviceProvider.GetRequiredService(AppType!));
	}

	public DiAppBuilder AddApp<TApp>()
		where TApp : Application
	{
		Services.AddSingleton<TApp>();
		AppType = typeof(TApp);
		AppRegistered = true;
		return this;
	}

	public DiAppBuilder AddWindow<TWindow>()
		where TWindow : SiteveyorMainWindow<MainWindowViewModel>
		=> AddWindow<TWindow, MainWindowViewModel>();

	public DiAppBuilder AddWindow<TWindow, TViewModel>()
		where TWindow : SiteveyorMainWindow<TViewModel>
		where TViewModel : MainWindowViewModel
	{
		Services.AddSingleton<TWindow>();

		Services.AddSingleton<TViewModel>();
		if (typeof(TViewModel) != typeof(MainWindowViewModel))
		{
			Services.AddSingleton<MainWindowViewModel>(sp => sp.GetRequiredService<TViewModel>());
		}

		WindowRegistered = true;

		return this;
	}

	protected void AddServices()
	{
		Services.TryAddSingleton<INavigationManager, NavigationManager>();
		Services.TryAddSingleton(RouteManager);

		Services.AddSingleton<ActiveViewProvider>();
	}

	public DiAppBuilder RegisterRoutesFromAssembly(Assembly targetAssembly)
	{
		var types = targetAssembly.GetExportedTypes();

		var routableViews = types.Where(t => t.IsDefined(typeof(RouteAttribute)));
		foreach (var view in routableViews)
		{
			var attribute = (Attribute.GetCustomAttribute(view, typeof(RouteAttribute)) as RouteAttribute)!;
			RouteManager.AddRoute(attribute.Route, view);
			Services.AddScoped(view);
		}

		var viewModels = types.Where(t => t.GetInterface(nameof(IViewModel)) != null);
		foreach (var viewModel in viewModels)
		{
			Services.AddScoped(viewModel);
		}

		return this;
	}
}