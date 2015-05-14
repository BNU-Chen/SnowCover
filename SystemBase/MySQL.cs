using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using MySql.Data.MySqlClient;

namespace SystemBase
{
    public class MySQL
    {
        private string serverName = "";
        private string catalog = "";
        private string userName = "";
        private string password = "";

        private MySqlConnection connection;
        

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }

        public string Catalog
        {
            get { return catalog; }
            set { catalog = value; }
        }

        public string ServerName
        {
            get { return serverName; }
            set { serverName = value; }
        }
        

        private MySQL()
        {

        }
        private MySQL(string server, string catalog, string username, string password)
        {
            this.serverName = server;
            this.catalog = catalog;
            this.userName = username;
            this.password = password;

            string myConnectionString;

            myConnectionString = "server=" + server + ";uid=" + username + ";" + "pwd=" + password + ";database=" + catalog + ";";

            try
            {
                connection = new MySql.Data.MySqlClient.MySqlConnection(myConnectionString);
            }
            catch { }
        }

        public static void TestConnection(string server,string catalog,string username,string password)
        {

            MySql.Data.MySqlClient.MySqlConnection conn  = null;
            string myConnectionString;

            myConnectionString = "server="+server+";uid="+username+";" +"pwd="+password+";database="+catalog+";";

            try
            {
                conn = new MySql.Data.MySqlClient.MySqlConnection();
                conn.ConnectionString = myConnectionString;
                conn.Open();
                MessageBox.Show("数据库连接成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show("数据库连接失败！\n"+ex.Message,"提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }                
            }
        }

        private void SetConnectionInfo(string server,string catalog,string username,string password)
        {
            this.serverName = server;
            this.catalog = catalog;
            this.userName = username;
            this.password = password;

            string myConnectionString;

            myConnectionString = "server="+server+";uid="+username+";" +"pwd="+password+";database="+catalog+";";

            try
            {
                connection = new MySql.Data.MySqlClient.MySqlConnection();
                connection.ConnectionString = myConnectionString;
            }
            catch { }
        }

        //open connection to database
        private bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                //When handling errors, you can your application's response based 
                //on the error number.
                //The two most common error numbers when connecting are as follows:
                //0: Cannot connect to server.
                //1045: Invalid user name and/or password.
                switch (ex.Number)
                {
                    case 0:
                        MessageBox.Show("Cannot connect to server.  Contact administrator");
                        break;

                    case 1045:
                        MessageBox.Show("Invalid username/password, please try again");
                        break;
                }
                return false;
            }
        }

        //Close connection
        private bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        //Select statement
        public List<string>[] Select(string query)
        {
            if (query == "")
            {
                return null;
            }

            //Create a list to store the result
            List<string>[] list = new List<string>[3];
            list[0] = new List<string>();
            list[1] = new List<string>();
            list[2] = new List<string>();

            try
            {
                //Open connection
                if (this.OpenConnection() == true)
                {
                    //Create Command
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    //Create a data reader and Execute the command
                    MySqlDataReader dataReader = cmd.ExecuteReader();

                    //Read the data and store them in the list
                    while (dataReader.Read())
                    {
                        list[0].Add(dataReader["id"] + "");
                        list[1].Add(dataReader["name"] + "");
                        list[2].Add(dataReader["age"] + "");
                    }

                    //close Data Reader
                    dataReader.Close();

                    //close Connection
                    this.CloseConnection();

                    //return list to be displayed
                    return list;
                }
                else
                {
                    return list;
                }
            }
            catch { }

            return list;
        }


        //Insert statement
        public void Insert(string query)
        {            
            if(query == "")
            {
                return;
            }

            try
            {
                //open connection
                if (this.OpenConnection() == true)
                {
                    //create command and assign the query and connection from the constructor
                    MySqlCommand cmd = new MySqlCommand(query, connection);

                    //Execute command
                    cmd.ExecuteNonQuery();

                    //close connection
                    this.CloseConnection();
                }
            }
            catch { }
        }

        //Update statement
        public void Update(string query)
        {
            if (query == "")
            {
                return;
            }

            try
            {
                //Open connection
                if (this.OpenConnection() == true)
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
                    this.CloseConnection();
                }
            }
            catch { }
        }

        //Delete statement
        public void Delete(string query)
        {
            if (query == "")
            {
                return;
            }
            try
            {
                if (this.OpenConnection() == true)
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.ExecuteNonQuery();
                    this.CloseConnection();
                }
            }
            catch { }
        }

        //Count statement
        public int Count()
        {
            string query = "SELECT Count(*) FROM tableinfo";
            int Count = -1;

            //Open Connection
            if (this.OpenConnection() == true)
            {
                //Create Mysql Command
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //ExecuteScalar will return one value
                Count = int.Parse(cmd.ExecuteScalar() + "");

                //close Connection
                this.CloseConnection();

                return Count;
            }
            else
            {
                return Count;
            }
        }

        //Backup
        public void Backup()
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
                string path;
                path = "C:\\MySqlBackup" + year + "-" + month + "-" + day + "-" + hour + "-" + minute + "-" + second + "-" + millisecond + ".sql";
                StreamWriter file = new StreamWriter(path);


                ProcessStartInfo psi = new ProcessStartInfo();
                psi.FileName = "mysqldump";
                psi.RedirectStandardInput = false;
                psi.RedirectStandardOutput = true;
                psi.Arguments = string.Format(@"-u{0} -p{1} -h{2} {3}",
                    userName, password, serverName, catalog);
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
                MessageBox.Show("Error , unable to backup! \n"+ex.Message);
            }
        }

        //Restore
        public void Restore()
        {
            try
            {
                //Read file from C:\
                string path;
                path = "C:\\MySqlBackup.sql";
                StreamReader file = new StreamReader(path);
                string input = file.ReadToEnd();
                file.Close();

                ProcessStartInfo psi = new ProcessStartInfo();
                psi.FileName = "mysql";
                psi.RedirectStandardInput = true;
                psi.RedirectStandardOutput = false;
                psi.Arguments = string.Format(@"-u{0} -p{1} -h{2} {3}",userName, password, serverName, catalog);
                psi.UseShellExecute = false;


                Process process = Process.Start(psi);
                process.StandardInput.WriteLine(input);
                process.StandardInput.Close();
                process.WaitForExit();
                process.Close();
            }
            catch (IOException ex)
            {
                MessageBox.Show("Error , unable to Restore!\n"+ex.Message);
            }
        }
        
    }
}
