using System.Windows.Controls;

namespace Frank.Libraries.Wpf.Inputs.Boxes;

public class ButtonInputGroup : GroupBox
{
    private readonly StackPanel _content = new();

    public ButtonInputGroup(string header)
    {
        Header = header;
        base.Content = _content;
    }

    public void AddButton(ButtonInput buttonInput) => _content.Children.Add(buttonInput);
}