using ReactiveUI.Fody.Helpers;

namespace SPA_Avalonia.Desktop.ViewModels.ContentViewModels;

public class HomeContentViewModel : ContentViewModelBase
{
    [Reactive] public string Content { get; set; }
    public HomeContentViewModel()
    {
        Title = "Home";
        
        Content = """
                  Равным образом, дальнейшее развитие различных форм деятельности играет важную роль в формировании вывода текущих активов. 
                  Повседневная практика показывает, что высокое качество позиционных исследований способствует подготовке и реализации своевременного выполнения сверхзадачи. 
                  Имеется спорная точка зрения, гласящая примерно следующее: некоторые особенности внутренней политики лишь добавляют фракционных разногласий и преданы социально-демократической анафеме.
                  """;
    }
}