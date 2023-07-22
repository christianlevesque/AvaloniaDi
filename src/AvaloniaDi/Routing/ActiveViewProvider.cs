using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;

namespace AvaloniaDi.Routing;

public partial class ActiveViewProvider : ObservableObject
{
	[ObservableProperty]
	private Control? _activeView;
}