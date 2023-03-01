using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
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
using CalendarProject.Database;
using CalendarProject.Models;
using CalendarProject.Views;
using MySql.Data.MySqlClient;

namespace CalendarProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static Request request = new Request();

        public static ObservableCollection<Users> users = new ObservableCollection<Users>();
        public static ObservableCollection<Events> events = new ObservableCollection<Events>();

        public static int curUserId;
        public static string curUserName;

        public MainWindow()
        {
            InitializeComponent();

            FrameManager.Frame = mainFrame;
            FrameManager.Frame.Navigate(new LoginRegisterPage());
        }
    }
}
