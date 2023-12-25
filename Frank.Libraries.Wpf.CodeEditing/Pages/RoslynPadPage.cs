using System.Windows;
using System.Windows.Controls;

namespace Frank.Libraries.Wpf.Pages;

public class RoslynPadPage : Page
{
    private readonly RoslynPad.Editor.RoslynCodeEditor _roslynPadControl;
    
    public RoslynPadPage()
    {
        _roslynPadControl = new RoslynPad.Editor.RoslynCodeEditor() { };
        
        Content = _roslynPadControl;
    }
    
    public string Code
    {
        get => (string)GetValue(CodeProperty);
        set => SetValue(CodeProperty, value);
    }

    public DependencyProperty CodeProperty { get; set; }
    
    public void UpdatePreview()
    {
        _roslynPadControl.Text = Code;
    }
}
