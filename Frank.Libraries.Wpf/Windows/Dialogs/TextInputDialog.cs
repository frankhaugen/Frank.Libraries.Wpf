using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Frank.Libraries.Wpf.Windows.Dialogs;

public class TextInputDialog : Window
{
    private readonly TextBox _textInput;
    private readonly Button _okButton;
    public string ResponseText { get; private set; }

    public TextInputDialog(string windowTitle = "Input", string defaultText = "")
    {
        Title = windowTitle;
        Width = 300;
        Height = 150;
        WindowStartupLocation = WindowStartupLocation.CenterScreen;

        _textInput = new TextBox
        {
            Margin = new Thickness(10),
            Text = defaultText
        };
        _textInput.KeyDown += TextInput_KeyDown;
        
        _okButton = new Button
        {
            Content = "OK",
            Margin = new Thickness(10),
            IsDefault = true // Button responds to Enter key
        };
        _okButton.Click += OkButtonOnClick;
        
        Content = new StackPanel
        {
            Children =
            {
                _textInput,
                _okButton
            }
        };
    }

    private void TextInput_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.Key == Key.Enter)
        {
            _okButton.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
        }
    }

    private void OkButtonOnClick(object sender, RoutedEventArgs e)
    {
        ResponseText = _textInput.Text;
        DialogResult = true;
        Close();
    }
}
