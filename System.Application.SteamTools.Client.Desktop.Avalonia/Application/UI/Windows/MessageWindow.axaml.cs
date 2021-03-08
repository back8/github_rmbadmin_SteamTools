using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace System.Application.UI.Windows
{
    public class MessageWindow : FluentWindow
    {
        public MessageWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
