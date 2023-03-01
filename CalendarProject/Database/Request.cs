using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using CalendarProject.Models;
using System.Collections.ObjectModel;
using System.Collections;
using CalendarProject.Views;

namespace CalendarProject.Database
{
    public class Request
    {
        private string GetConnection(string path)
        {
            DatabaseConnection connection = new DatabaseConnection();

            using (StreamReader reader = new StreamReader(path))
            {
                string json = reader.ReadLine();
                connection = JsonSerializer.Deserialize<DatabaseConnection>(json);
            }

            return connection.ConnectionString;
        }

        public ObservableCollection<Users> UsersSelect(string query)
        {
            ObservableCollection<Users> users = new ObservableCollection<Users>();

            string connectionString = GetConnection(@"..\Connection\ConnectionJSON.json");
            MySqlConnection mySqlConnection = new MySqlConnection(connectionString);
            mySqlConnection.Open();

            MySqlCommand mySqlCommand = new MySqlCommand(query, mySqlConnection);
            MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();

            while (mySqlDataReader.Read())
            {
                users.Add(new Users()
                {
                    Id = Convert.ToInt32(mySqlDataReader[0]),
                    Name = Convert.ToString(mySqlDataReader[1]),
                    UserLogin = Convert.ToString(mySqlDataReader[2]),
                    UserPassword = Convert.ToString(mySqlDataReader[3])
                });
            }

            mySqlDataReader.Close();
            mySqlConnection.Close();

            return users;
        }

        public void UserInsert(string name, string login, string password)
        {
            string query = $"INSERT INTO Users (Name, UserLogin, UserPassword) VALUES ('{name}', '{login}', '{password}')";
            string connectionString = GetConnection(@"..\Connection\ConnectionJSON.json");
            MySqlConnection mySqlConnection = new MySqlConnection(connectionString);
            mySqlConnection.Open();

            MySqlCommand mySqlCommand = new MySqlCommand(query, mySqlConnection);
            MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();

            mySqlDataReader.Close();
            mySqlConnection.Close();
        }

        public ObservableCollection<Events> EventsSelect(string query)
        {
            ObservableCollection<Events> events = new ObservableCollection<Events>();

            string connectionString = GetConnection(@"..\Connection\ConnectionJSON.json");
            MySqlConnection mySqlConnection = new MySqlConnection(connectionString);
            mySqlConnection.Open();

            MySqlCommand mySqlCommand = new MySqlCommand(query, mySqlConnection);
            MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();

            while (mySqlDataReader.Read())
            {
                events.Add(new Events()
                {
                    Id = Convert.ToInt32(mySqlDataReader[0]),
                    Theme = Convert.ToString(mySqlDataReader[1]),
                    Date = Convert.ToString(mySqlDataReader[2]),
                    UserId = Convert.ToInt32(mySqlDataReader[3])
                });
            }

            mySqlDataReader.Close();
            mySqlConnection.Close();

            return events;
        }

        public void EventInsert(string theme, string date, int userId)
        {
            string query = $"INSERT INTO Events (EventTheme, EventDate, UserId) VALUES ('{theme}', '{date}', '{userId}')";
            string connectionString = GetConnection(@"..\Connection\ConnectionJSON.json");
            MySqlConnection mySqlConnection = new MySqlConnection(connectionString);
            mySqlConnection.Open();

            MySqlCommand mySqlCommand = new MySqlCommand(query, mySqlConnection);
            MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();

            mySqlDataReader.Close();
            mySqlConnection.Close();
        }

        public void EventUpdate(string theme, string date, int eventId)
        {
            string query = $"UPDATE Events SET EventTheme='{theme}', EventDate='{date}' WHERE Id='{eventId}'";
            string connectionString = GetConnection(@"..\Connection\ConnectionJSON.json");
            MySqlConnection mySqlConnection = new MySqlConnection(connectionString);
            mySqlConnection.Open();

            MySqlCommand mySqlCommand = new MySqlCommand(query, mySqlConnection);
            MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();

            mySqlDataReader.Close();
            mySqlConnection.Close();
        }

        public void EventsDelete(int eventId)
        {
            string query = $"DELETE FROM Events WHERE Id='{eventId}'";
            string connectionString = GetConnection(@"..\Connection\ConnectionJSON.json");
            MySqlConnection mySqlConnection = new MySqlConnection(connectionString);
            mySqlConnection.Open();

            MySqlCommand mySqlCommand = new MySqlCommand(query, mySqlConnection);
            MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();

            mySqlDataReader.Close();
            mySqlConnection.Close();
        }
    }
}
