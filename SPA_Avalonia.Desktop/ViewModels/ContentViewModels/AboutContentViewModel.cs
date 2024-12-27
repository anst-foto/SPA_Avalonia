using ReactiveUI.Fody.Helpers;

namespace SPA_Avalonia.Desktop.ViewModels.ContentViewModels;

public class AboutContentViewModel : ContentViewModelBase
{
    [Reactive] public string About { get; set; }

    public AboutContentViewModel()
    {
        Title = "About";
        
        About = "This is a simple application that shows how to use ReactiveUI.Fody to create a MVVM application.";
    }
}