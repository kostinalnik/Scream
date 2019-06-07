using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Client
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            chatTextBlock.Inlines.Add(new Bold(new Run("Первое сообщение") { FontWeight = FontWeights.Bold}));
            chatTextBlock.Inlines.Add(new LineBreak());
            chatTextBlock.Inlines.Add(new LineBreak());
            chatTextBlock.Inlines.Add(new Run("Второе сообщение ") { Foreground = Brushes.Blue });
            chatTextBlock.Inlines.Add(new LineBreak());
            chatTextBlock.Inlines.Add(new LineBreak());
            chatTextBlock.Inlines.Add(new Bold(new Run("Третье сообщение") { FontWeight = FontWeights.Bold }));
            chatTextBlock.Inlines.Add(new LineBreak());
            chatTextBlock.Inlines.Add(new LineBreak());
            chatTextBlock.TextAlignment = TextAlignment.Right;
            chatTextBlock.Inlines.Add(new Run("Четвертое сообщение "));
            chatTextBlock.Inlines.Add(new LineBreak());
            chatTextBlock.Inlines.Add(new LineBreak());
            chatTextBlock.Inlines.Add(new Italic(new Run(":)))")));
            chatTextBlock.Inlines.Add(new LineBreak());
            chatTextBlock.Inlines.Add(new LineBreak());
            chatTextBlock.TextAlignment = TextAlignment.Left;
        }

        private void bSend_Click(object sender, RoutedEventArgs e)

        {
            chatTextBlockSend.Inlines.Add(new LineBreak());
            chatTextBlockSend.Inlines.Add(new LineBreak());
            chatTextBlockSend.TextAlignment = TextAlignment.Right;
            chatTextBlockSend.Inlines.Add(new Run(tbMessage.Text));
        }
    }
}
