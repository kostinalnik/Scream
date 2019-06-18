using Microsoft.AspNet.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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

        public String UserName { get; set; }
        public IHubProxy HubProxy { get; set; }
        const string ServerURI = "http://localhost:8443/signalr";
        public HubConnection Connection { get; set; }



        public MainWindow(string Username)
        {
            InitializeComponent();

            UserName = Username;
            bSend.IsEnabled = false;

            chatTextBlock.Inlines.Add("Hello " + Username);
            chatTextBlock.Inlines.Add(new LineBreak());

            if (!String.IsNullOrEmpty(Username))
            {
                ConnectAsync();
            }

            //chatTextBlock.Inlines.Add(new Bold(new Run("Первое сообщение") { FontWeight = FontWeights.Bold}));
            //chatTextBlock.Inlines.Add(new LineBreak());
            //chatTextBlock.Inlines.Add(new LineBreak());
            //chatTextBlock.Inlines.Add(new Run("Второе сообщение ") { Foreground = Brushes.Blue });
            //chatTextBlock.Inlines.Add(new LineBreak());
            //chatTextBlock.Inlines.Add(new LineBreak());
            //chatTextBlock.Inlines.Add(new Bold(new Run("Третье сообщение") { FontWeight = FontWeights.Bold }));
            //chatTextBlock.Inlines.Add(new LineBreak());
            //chatTextBlock.Inlines.Add(new LineBreak());
            //chatTextBlock.TextAlignment = TextAlignment.Right;
            //chatTextBlock.Inlines.Add(new Run("Четвертое сообщение "));
            //chatTextBlock.Inlines.Add(new LineBreak());
            //chatTextBlock.Inlines.Add(new LineBreak());
            //chatTextBlock.Inlines.Add(new Italic(new Run(":)))")));
            //chatTextBlock.Inlines.Add(new LineBreak());
            //chatTextBlock.Inlines.Add(new LineBreak());
            //chatTextBlock.TextAlignment = TextAlignment.Left;
        }

        private void bSend_Click(object sender, RoutedEventArgs e)

        {
            HubProxy.Invoke("Send", UserName, tbMessage.Text);
            tbMessage.Text = "";
            //chatTextBlockSend.Inlines.Add(new LineBreak());
            //chatTextBlockSend.TextAlignment = TextAlignment.Right;
            //chatTextBlockSend.Inlines.Add(new Run(tbMessage.Text));
        }

        private async void ConnectAsync()
        {
            Connection = new HubConnection(ServerURI);
            Connection.Closed += Connection_Closed;
            HubProxy = Connection.CreateHubProxy("MyHub");
            //Handle incoming event from server: use Invoke to write to console from SignalR's thread
            HubProxy.On<string, string>("AddMessage", (name, message) =>
                this.Dispatcher.Invoke(() =>
                    chatTextBlock.Inlines.Add(new Run((String.Format("{0}: {1}\r", name, message))))
                )
            );
            try
            {
                await Connection.Start();
            }
            catch (HttpRequestException)
            {
                chatTextBlock.Inlines.Add(new Bold(new Run("Unable to connect to server: Start server before connecting clients.") { FontWeight = FontWeights.Bold }));
                chatTextBlock.Inlines.Add(new LineBreak());
                return;
            }

            bSend.IsEnabled = true;
            chatTextBlock.Inlines.Add("Connected to server at " + ServerURI + "\r");
            chatTextBlock.Inlines.Add(new LineBreak());
        }

        void Connection_Closed()
        {
            var dispatcher = Application.Current.Dispatcher;
        }

        private void WPFClient_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (Connection != null)
            {
                Connection.Stop();
                Connection.Dispose();
            }
        }

    }
}
