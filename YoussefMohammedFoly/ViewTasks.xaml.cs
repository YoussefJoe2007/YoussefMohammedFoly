using System.Windows;
using YoussefMohammedFoly;

namespace YoussefMohammedFoly
{
    public partial class ViewTasks : Window
    {
        TaskContext task = new TaskContext();

        public ViewTasks() //W_4
        {
            InitializeComponent();
            ShowUncompletedTasks();
            ShowCompletedTasks();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow login = new MainWindow();
            login.Show();
            this.Close();
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Logout successful.");
            this.Close();
        }

        void ShowUncompletedTasks()
        {
            int ID = MainWindow.loginid;
            Grid1.ItemsSource = task.Tasks.Where(t => (t.status == "In Progress" || t.status == "Pending") && t.userid == ID).ToList();
        }

        void ShowCompletedTasks()
        {
            int ID = MainWindow.loginid;
            Grid2.ItemsSource = task.Tasks.Where(t => t.status == "Completed" && t.userid == ID).ToList();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            Task obj = new Task();
            obj.taskid = int.Parse(TaskIdTextBox.Text);
            Task result = task.Tasks.Find(obj.taskid);

            if (result != null)
            {
                result.status = StatusComboBox.Text;
                task.SaveChanges();
                ShowUncompletedTasks();
                ShowCompletedTasks();
                MessageBox.Show("Task saved successfully.");
            }
            else
            {
                MessageBox.Show("Task not found.");
            }
        }
    }
}
