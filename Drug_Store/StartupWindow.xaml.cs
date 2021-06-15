using System;
using System.Windows;
using System.Windows.Input;

namespace Drug_Store
{
    /// <summary>
    /// Логика взаимодействия для StartupWindow.xaml
    /// </summary>
    public partial class StartupWindow : Window
    {
        public StartupWindow()
        {
            InitializeComponent();
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                DragMove();
            }
            catch (Exception)
            {
                //throw;
            }
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            UserView userView = new();

            userView.Show();
            this.Close();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void InfoButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
