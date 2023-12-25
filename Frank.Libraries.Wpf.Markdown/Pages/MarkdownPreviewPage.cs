using System.Windows;
using System.Windows.Controls;

namespace Frank.Libraries.Wpf.Pages;

public class MarkdownPreviewPage : Page
{
    private readonly WebBrowser _viewer = new();
    
    public MarkdownPreviewPage()
    {
        Content = _viewer;
    }
    
    public string Markdown
    {
        get => (string)GetValue(MarkdownProperty);
        set => SetValue(MarkdownProperty, value);
    }

    public DependencyProperty MarkdownProperty { get; set; }

    private async void FileContextOnSaved(string obj)
    {
        if (obj is null) return;
        UpdatePreview();
    }

    private async void FileContextOnSelectedChanged() => UpdatePreview();

    public async void UpdatePreview()
    {
        var html = Markdig.Markdown.ToHtml(Markdown);
        _viewer.NavigateToString(html);
    }
}