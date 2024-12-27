namespace SPA_Avalonia.Desktop.ViewModels;

public class ContentItem
{
    public required ContentViewModelBase ViewModel { get; init; }
    public string Title => ViewModel.Title;
}