using System;
using System.Collections.Generic;
using System.IO;
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

namespace SchooolBase
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string username1 = "drowsy";
        private string password1 = "12345";

        private string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        public MainWindow()
        {
            InitializeComponent();
            LoadSavedLogins();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Можно заменить .Password на .SecurePassword чтобы не хранить пароль как ClearText в памяти
            if (PasswordInput.Password == password1 && UsernameInput.Text == username1)
            {
                MessageBox.Show("You have logged in!");
                if (RememberUsernameCheckBox.IsChecked == true)
                {
                    File.WriteAllText(System.IO.Path.Combine(docPath, "SavedUsername.txt"),UsernameInput.Text);
                } else
                {
                    File.WriteAllText(System.IO.Path.Combine(docPath, "SavedUsername.txt"), "");
                }
            } else
            {
                MessageBox.Show("Invalid Username or Password!");
            }
        }

        private void LoadSavedLogins()
        {
            string savedUsername=File.ReadAllText(System.IO.Path.Combine(docPath,"SavedUsername.txt"));
            if (savedUsername != "")
            {
                UsernameInput.Text = savedUsername;
                RememberUsernameCheckBox.IsChecked = true;
            }
        }
    }
}
