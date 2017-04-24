using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CodeFirstNewDatabaseSample
{
    class Program
    {
        static void Main(string[] args)
        {
            Database dba;
            try
            {
                dba = new Database();
                MessageBox.Show("Database connection was created");
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.StackTrace);
                MessageBox.Show("Error opening database connection: " + e.Message);
                Environment.Exit(1);
            }
           
            using (var db = new BloggingContext())
            {
                
                // Create and save a new Blog 
                Console.Write("Enter a name for a new Blog: "); 
                var name = Console.ReadLine(); 
 
                var blog = new Blog { Name = name }; 
                db.Blogs.Add(blog); 
                db.SaveChanges(); 
 
                // Display all Blogs from the database 
                var query = from b in db.Blogs 
                    orderby b.Name 
                    select b; 
 
                Console.WriteLine("All blogs in the database:"); 
                foreach (var item in query) 
                { 
                    Console.WriteLine(item.Name); 
                } 
 
                Console.WriteLine("Press any key to exit..."); 
                Console.ReadKey(); 
            } 
        } 
        }
    }

    public class Blog
    {
        public int BlogId { get; set; }
        public string Name { get; set; }

        public virtual List<Post> Posts { get; set; }
    }

    public class Post
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public int BlogId { get; set; }
        public virtual Blog Blog { get; set; }
    }

    public class BloggingContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }
    }
    class Database
    {
        SqlConnection conn;

        public Database()
        {
            conn = new SqlConnection(@"Server=tcp:alireza-abbott.database.windows.net,1433;Initial Catalog=MediaManager;
Persist Security Info=False;User ID=dbadmin;Password=Alirezal2017;MultipleActiveResultSets=False;
Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

            conn.Open();
        }


    }

