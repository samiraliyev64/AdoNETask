using System;
using System.Data.SqlClient;

namespace AdoNETask
{
    class Program
    {
        private const string connectionStr = "Server=DESKTOP-RDTCD9S;Database=Groups;Integrated Security=true";
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Menyu :\n\n1.Select All\n2.Insert\n3.Update\n4.Delete\n");
                Console.Write("Menyudan secim edin : ");
                int input = Convert.ToInt32(Console.ReadLine());
                switch (input)
                {
                    case 1:
                        Console.WriteLine("\n");
                        SelectAll();
                        Console.WriteLine("\n");
                        break;
                    case 2:
                        Insert();
                        break;
                    case 3:
                        Console.Write("ID :");
                        int idInput = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Name : ");
                        string nameInput = Console.ReadLine();
                        Update(idInput, nameInput);
                        break;
                    case 4:
                        Console.Write("ID : ");
                        int idInputDelete = Convert.ToInt32(Console.ReadLine());
                        Delete(idInputDelete);
                        break;
                    default:
                        Console.WriteLine("Daxil etdiyiniz input menyuda yoxdur");
                        break;
                }
            }
          
        }

        public static void SelectAll()
        {
            SqlConnection newConnection = new SqlConnection(connectionStr);
            newConnection.Open();

            string selectAllquery = "SELECT * FROM FirstGroup";
            SqlCommand newCommand = new SqlCommand(selectAllquery, newConnection);
            SqlDataReader result = newCommand.ExecuteReader();

            while (result.Read())
            {
                Console.WriteLine($"{result[0]},{result[1]},{result[2]}");
            }
            newConnection.Close();
        }


        public static void Insert()
        {
            SqlConnection newConnection = new SqlConnection(connectionStr);
            newConnection.Open();

            Console.Write("Name : ");
            string name = Console.ReadLine();
            Console.Write("Max Size : ");
            int count = Convert.ToInt32(Console.ReadLine());

            string insertQuery = $"INSERT INTO FirstGroup VALUES('{name}', {count})";
            SqlCommand newCommand = new SqlCommand(insertQuery, newConnection);
            try
            {
                var result = newCommand.ExecuteNonQuery();

            }
            catch (Exception)
            {

                Console.WriteLine("bele adda qrup var");
            }
            newConnection.Close();

        }

        public static void Update(int id, string Name)
        {
            SqlConnection newConnection = new SqlConnection(connectionStr);
            newConnection.Open();

            string updateQuery = $"UPDATE FirstGroup SET [Name] = '{Name}' WHERE Id = {id}";
            SqlCommand newCommand = new SqlCommand(updateQuery, newConnection);
            int result = newCommand.ExecuteNonQuery();

            newConnection.Close();
        }


        public static void Delete(int id)
        {
            SqlConnection newConnection = new SqlConnection(connectionStr);
            newConnection.Open();

            string deleteQuery = $"DELETE FROM FirstGroup WHERE Id = {id}";
            SqlCommand newCommand = new SqlCommand(deleteQuery, newConnection);
            int result = newCommand.ExecuteNonQuery();
            newConnection.Close();
        }
    }
}
