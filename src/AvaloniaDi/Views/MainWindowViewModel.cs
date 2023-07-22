using CommunityToolkit.Mvvm.ComponentModel;
using AvaloniaDi.Routing;

namespace AvaloniaDi.Views;

public partial class MainWindowViewModel : ObservableObject
{
	public ActiveViewProvider ActiveViewProvider { get; }

	/// <inheritdoc />
	public MainWindowViewModel(ActiveViewProvider activeViewProvider)
	{
		ActiveViewProvider = activeViewProvider;
	}
}