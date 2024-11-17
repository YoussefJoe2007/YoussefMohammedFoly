using System.Windows;
using System.Windows.Controls;
using YoussefMohammedFoly;

namespace YoussefMohammedFoly //W_4
{
    public partial class MainWindow : Window
    {
        TaskContext context = new TaskContext();
        public static int loginid;

        public MainWindow()
        {
            InitializeComponent();
            //new UserManagement().Show();
            //new ViewTasks().Show();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameTextBox.Text;
            string password = PasswordBox.Password;
            var user = context.Users.FirstOrDefault(u => u.name == username && u.password == password);

            if (user != null)
            {
                loginid = user.userid;

                if (user.role == "Employee")
                {
                    MessageBox.Show("Login successful as Employee");
                    new ViewTasks().Show();
                    this.Close();
                }
                else if (user.role == "Manager")
                {
                    MessageBox.Show("Login successful as Manager");
                    new UserManagement().Show();
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Invalid credentials");
            }
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Logout successful.");
            this.Close();
        }
    }
}
