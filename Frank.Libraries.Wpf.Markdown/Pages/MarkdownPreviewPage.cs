using System.Windows;
using System.Windows.Controls;

namespace Frank.Libraries.Wpf.Markdown.Pages;

public class MarkdownPreviewPage : Page
{
    private readonly WebBrowser _viewer = new();
    
    public MarkdownPreviewPage()
    {
        Content = _viewer;
    }
    
    public string Markdown
    {
        get => (string)GetValue(MarkdownProperty ?? throw new InvalidOperationException());
        set => SetValue(MarkdownProperty ?? throw new InvalidOperationException(), value);
    }

    public DependencyProperty? MarkdownProperty { get; set; }

    public async void UpdatePreview()
    {
        var html = Markdig.Markdown.ToHtml(Markdown);
        _viewer.NavigateToString(html);
    }
}