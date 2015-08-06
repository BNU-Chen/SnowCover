using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Forms;
using System.IO;
using System.Data;
using System.Diagnostics;
using MySql.Data.MySqlClient;

namespace SystemBase
{
    public class MySQL
    {
        public static MySqlConnection GetMySQLConnection(string server, string catalog, string username, string password)
        {
            MySqlConnection connection = null;
            //this.serverName = server;
            //this.catalog = catalog;
            //this.userName = username;
            //this.password = password;

            string myConnectionString;

            myConnectionString = "server=" + server + ";uid=" + username + ";" + "pwd=" + password + ";database=" + catalog + ";";

            try
            {
                connection = new MySql.Data.MySqlClient.MySqlConnection(myConnectionString);
            }
            catch { }
            return connection;
        }
        //测试连接数据库
        public static MySqlConnection TestConnection(string server, string catalog, string username, string password)
        {
            MySql.Data.MySqlClient.MySqlConnection conn = null;
            string myConnectionString;

            myConnectionString = "server=" + server + ";user=" + username + ";" + "password=" + password + ";database=" + catalog + ";";

            try
            {
                conn = new MySql.Data.MySqlClient.MySqlConnection();
                conn.ConnectionString = myConnectionString;
                conn.Open();
                //MessageBox.Show("数据库连接成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch //(MySql.Data.MySqlClient.MySqlException ex)
            {
                //MessageBox.Show("数据库连接失败！\n" + ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
            return conn;
        }


        //Close connection
        public static bool CloseConnection(MySqlConnection connection)
        {
            try
            {

                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        //Select statement
        public static DataTable Select(string query, MySqlConnection connection)
        {
            if (query == "")
            {
                return null;
            }
            if (connection == null)
            {
                return null;
            }

            if (connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }

            DataTable dt = new DataTable();

            try
            {
                //Open connection
                if (connection != null)
                {
                    //Create Command
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    //Create a data reader and Execute the command
                    MySqlDataReader dataReader = cmd.ExecuteReader();

                    dt.Load(dataReader);

                    ////Read the data and store them in the list
                    //int index = 0;
                    
                    //while (dataReader.Read())
                    //{
                    //    for (int c = 0; c < dataReader.FieldCount; c++)
                    //    {
                    //        object obj = dataReader[c];
                    //        string str = "";
                    //        if(obj is string )
                    //        {
                    //            str = (string)obj;
                    //        }
                    //        else if(obj is int)
                    //        {
                    //            str = obj.ToString();
                    //        }
                    //        else if(obj is double)
                    //        {
                    //            str = obj.ToString();
                    //        }

                    //        list[index].Add(str);
                    //    }
                    //    index++;
                    //}

                    //close Data Reader
                    dataReader.Close();

                    //close Connection
                    CloseConnection(connection);

                    //return list to be displayed
                    return dt;
                }
            }
            catch(MySqlException ex) {
                MessageBox.Show(ex.Message);
            }

            return dt;
        }

        //Insert statement
        public static void Insert(string query, MySqlConnection connection)
        {
            if (query == "")
            {
                return;
            }
            if (connection == null)
            {
                return;
            }
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }

            try
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //Execute command
                cmd.ExecuteNonQuery();

                //close connection
                CloseConnection(connection);
            }
            catch { }
        }

        //Update statement
        public static void Update(string query, MySqlConnection connection)
        {
            if (query == "")
            {
                return;
            }
            if (connection == null)
            {
                return;
            }
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
            try
            {
                //create mysql command
                MySqlCommand cmd = new MySqlCommand();
                //Assign the query using CommandText
                cmd.CommandText = query;
                //Assign the connection using Connection
                cmd.Connection = connection;

                //Execute query
                cmd.ExecuteNonQuery();

                //close connection
                CloseConnection(connection);

            }
            catch { }
        }

        //Delete statement
        public static void Delete(string query, MySqlConnection connection)
        {
            if (query == "")
            {
                return;
            }
            if (connection == null)
            {
                return;
            }
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
            try
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                CloseConnection(connection);
            }
            catch { }
        }

        //Count statement 
        /* 注：这一块代码有点问题，待改 by:wucan */
        public static int Count(MySqlConnection connection)
        {
            string query = "SELECT Count(*) FROM tableinfo";
            int Count = -1;
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
            try
            {
                //Create Mysql Command
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //ExecuteScalar will return one value
                Count = int.Parse(cmd.ExecuteScalar() + "");

                //close Connection
                CloseConnection(connection);
            }
            catch
            {
                Count = -1;
            }
            return Count;
        }

        //Backup
        public static void Backup(string folderPath, string server, string catalog, string username, string password)
        {
            try
            {
                DateTime Time = DateTime.Now;
                int year = Time.Year;
                int month = Time.Month;
                int day = Time.Day;
                int hour = Time.Hour;
                int minute = Time.Minute;
                int second = Time.Second;
                int millisecond = Time.Millisecond;

                //Save file to C:\ with the current date as a filename
                if (!Directory.Exists(folderPath))
                {
                    return;
                }
                string path;
                path = folderPath + "\\MySqlBackup" + year + "-" + month + "-" + day + "-" + hour + "-" + minute + "-" + second + "-" + millisecond + ".sql";
                StreamWriter file = new StreamWriter(path);


                ProcessStartInfo psi = new ProcessStartInfo();
                psi.FileName = "mysqldump";
                psi.RedirectStandardInput = false;
                psi.RedirectStandardOutput = true;
                psi.Arguments = string.Format(@"-u{0} -p{1} -h{2} {3}",
                    username, password, server, catalog);
                psi.UseShellExecute = false;

                Process process = Process.Start(psi);

                string output;
                output = process.StandardOutput.ReadToEnd();
                file.WriteLine(output);
                process.WaitForExit();
                file.Close();
                process.Close();
            }
            catch (IOException ex)
            {
                MessageBox.Show("Error , unable to backup! \n" + ex.Message);
            }
        }

        //Restore
        public static void Restore(string path, string server, string catalog, string username, string password)
        {
            try
            {
                //Read file from 
                if (!File.Exists(path))
                {
                    return;
                }
                StreamReader file = new StreamReader(path);
                string input = file.ReadToEnd();
                file.Close();

                ProcessStartInfo psi = new ProcessStartInfo();
                psi.FileName = "mysql";
                psi.RedirectStandardInput = true;
                psi.RedirectStandardOutput = false;
                psi.Arguments = string.Format(@"-u{0} -p{1} -h{2} {3}", username, password, server, catalog);
                psi.UseShellExecute = false;


                Process process = Process.Start(psi);
                process.StandardInput.WriteLine(input);
                process.StandardInput.Close();
                process.WaitForExit();
                process.Close();
            }
            catch (IOException ex)
            {
                MessageBox.Show("Error , unable to Restore!\n" + ex.Message);
            }
        }
    }
}
