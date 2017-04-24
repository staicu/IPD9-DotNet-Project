using System;
using System.Data.SqlClient;
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
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.StackTrace);
                MessageBox.Show("Error opening database connection: " + e.Message);
                Environment.Exit(1);
            }

            Window1 mainWindow = new Window1();
            mainWindow.Show();

            mainWindow.Photos = (PhotoList)(this.Resources["Photos"] as ObjectDataProvider).Data;
            mainWindow.Photos.Path = "..\\..\\Photos";

            mainWindow.ShoppingCart = (MediaList)(this.Resources["ShoppingCart"] as ObjectDataProvider).Data;
            
        }

    }
}