using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reactive;
using DynamicData.Binding;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using SPA_Avalonia.Desktop.ViewModels.ContentViewModels;

namespace SPA_Avalonia.Desktop.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public ObservableCollection<ContentItem> ContentItems { get; set; } =
    [
        new ContentItem() {
            ViewModel = new HomeContentViewModel()
        },
        new ContentItem() {
            ViewModel = new AboutContentViewModel() 
        },
        /*
        new ContentItem() {
            Title = "Contact",
            ViewModel = new ContactContentViewModel() 
        }*/
    ]; 
    [Reactive] public ContentItem? SelectedItem { get; set; }
    [Reactive] public ContentViewModelBase CurrentContentViewModel { get; set; }
    
    public ReactiveCommand<Unit, Unit> GoBackCommand { get; }

    private readonly Stack<ContentViewModelBase> _history = [];

    public MainWindowViewModel()
    {
        var selectedItemObservable = this.WhenValueChanged(vm => vm.SelectedItem);
        selectedItemObservable.Subscribe(ci =>
        {
            CurrentContentViewModel = ci is null
                ? ContentItems[0].ViewModel
                : ci.ViewModel;
        });
        selectedItemObservable
            .WhereNotNull()
            .Subscribe(ci => _history.Push(ci.ViewModel));
        
        GoBackCommand = ReactiveCommand.Create(
            () =>
        {
            if (_history.Count <= 1) return;
            
            _history.Pop();
            CurrentContentViewModel = _history.Peek();
        });
    }
}