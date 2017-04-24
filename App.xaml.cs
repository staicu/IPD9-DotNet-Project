using System;
using System.Data.SqlClient;
using System.IO;
using System.Windows;
using System.Windows.Data;


namespace MediaManager
{

    public partial class app : Application
    {

        void AppStartup(object sender, StartupEventArgs args)
        {
            Database db;
            try
            {
                db = new Database();
                //MessageBox.Show("We are connected to the database");
                
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.StackTrace);
                MessageBox.Show("Error opening database connection: " + e.Message);
                Environment.Exit(1);
            }
            string strFn = "..\\..\\Photos\\pic2.jpg";
            FileInfo fiImage = new FileInfo(strFn);

            Window1 mainWindow = new Window1();
            mainWindow.Show();

            mainWindow.Photos = (PhotoList)(this.Resources["Photos"] as ObjectDataProvider).Data;
            mainWindow.Photos.Path = "..\\..\\Photos";

            mainWindow.ShoppingCart = (MediaList)(this.Resources["ShoppingCart"] as ObjectDataProvider).Data;
            
        }

    }
}