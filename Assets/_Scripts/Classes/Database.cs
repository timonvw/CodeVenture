using System;
using MySql.Data;
using System.Security.Cryptography;
using System.Text;
//using System.Data;
using System.Diagnostics;
using System.Runtime.Remoting.Messaging;
using MySql.Data.MySqlClient;
using UnityEngine;

namespace CodeVenture
{
    public class Database
    {
      /*  private MySqlConnection connection;
        private string DBHost = "studmysql01.fhict.local";
        private string DBName = "dbi392109";
        private string DBUser = "dbi392109";
        private string DBPass = "Koekje123";

        private int userID;

        public Database()
        {
            connection = new MySqlConnection("Server=" + DBHost + ";Database=" + DBName + ";Uid=" + DBUser + ";Pwd=" + DBPass + ";");
        }

        public bool CheckCredentials(string username, string password)
        {
            connection.Open();

            password = Helper.GenerateSHA512String(password);
            UnityEngine.Debug.Log(password);

            MySqlCommand command = new MySqlCommand("SELECT EXISTS (SELECT * FROM user WHERE email = @username AND password = @password ) as result", connection);
            command.Parameters.Add("@username", MySqlDbType.VarChar).Value = username;
            command.Parameters.Add("@password", MySqlDbType.VarChar).Value = password;
            MySqlDataReader reader = command.ExecuteReader();

            reader.Read();
            bool result = reader.GetBoolean("result");
            reader.Close();
            connection.Close();

            if (result)
            {
                userID = GetId(username);
            }

            return result;
        }

        private int GetId(string email)
        {
            connection.Open();

            MySqlCommand command = new MySqlCommand("SELECT user_id as result FROM user WHERE email = @email", connection);
            command.Parameters.Add("@email", MySqlDbType.VarChar).Value = email;
            MySqlDataReader reader = command.ExecuteReader();

            reader.Read();
            int result = reader.GetInt32("result");
            reader.Close();
            connection.Close();

            return result;
        }

        public bool SameClassroom(int userID, int teacherID)
        {
            connection.Open();

            MySqlCommand teacher_command = new MySqlCommand("SELECT classroom_id as result FROM teacher WHERE teacher_id = @teacher_id", connection);
            teacher_command.Parameters.Add("@teacher_id", MySqlDbType.VarChar).Value = teacherID;
            MySqlDataReader teacherReader = teacher_command.ExecuteReader();

            teacherReader.Read();
            int teacherResult = teacherReader.GetInt32("result");
            teacherReader.Close();
            connection.Close();
            
            MySqlCommand user_command = new MySqlCommand("SELECT classroom_id as result FROM user WHERE user_id = @user_id");
            user_command.Parameters.Add("user_id", MySqlDbType.VarChar).Value = userID;
            MySqlDataReader userReader = user_command.ExecuteReader();

            userReader.Read();
            int userResult = userReader.GetInt32("result");
            userReader.Close();
            connection.Close();

            if (teacherResult == userResult)
            {
                return true;
            }
            return false;

        }
        //ophalen, opslaan*/
    }
}
