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
using System.Windows.Shapes;

namespace Client.Views
{
    /// <summary>
    /// Логика взаимодействия для Login.xaml
    /// </summary>
    public partial class LoginView : Window
    {
        public LoginView()
        {
            InitializeComponent();
        }

        private void bLogin_Click(object sender, RoutedEventArgs e)
        {
            //string text = tbUsername.Text;
            //if (text != "")
            //{
            //    MessageBox.Show(text);
            //}

            MainWindow chatWindow = new MainWindow();
            chatWindow.Show();
        }

        private void bExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
