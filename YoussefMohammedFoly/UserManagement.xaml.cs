using System.Windows;
using System.Windows.Controls;
using YoussefMohammedFoly;

namespace YoussefMohammedFoly
{
    /// <summary>
    /// Interaction logic for TeacherWindow.xaml
    /// </summary>
    public partial class UserManagement : Window
    {
        TaskContext taskContext = new TaskContext();
        public static int Userloginid;

        public UserManagement() //W_4
        {
            InitializeComponent();
            DisplayData();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            Task obj1 = new Task();
            obj1.title = Title.Text;
            obj1.description = Description.Text;
            obj1.status = Status.Text;
            obj1.userid = int.Parse(IdTextBox.Text);
            taskContext.Tasks.Add(obj1);
            taskContext.SaveChanges();

            MessageBox.Show("Task has been added successfully");
            DisplayData();
        }



        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            Task Obj2 = new Task();
            Obj2.taskid = int.Parse(TaskId.Text);
            Task tasks = taskContext.Tasks.Find(Obj2.taskid);
            if (tasks != null)
            {
                taskContext.Tasks.Remove(tasks);
                taskContext.SaveChanges();
                MessageBox.Show("task deleted successfully.");
            }
            else
            {
                MessageBox.Show("task not found.");
            }
            DisplayData();
        }


        void DisplayData()
        {
            DataGrid1.ItemsSource = taskContext.Tasks.ToList();
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

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            Task Obj3 = new Task();
            Obj3.taskid = int.Parse(TaskId.Text);
            Task tasks = taskContext.Tasks.Find(Obj3.taskid);
            if (tasks != null)
            {
                tasks.title = Title.Text;
                tasks.description = Description.Text;

                tasks.status = Status.Text;
                taskContext.SaveChanges();

                DisplayData();
                MessageBox.Show("task updated successfully.");
            }
            else
            {
                MessageBox.Show("task not found.");
            }
        }

        private void TasksIdTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
