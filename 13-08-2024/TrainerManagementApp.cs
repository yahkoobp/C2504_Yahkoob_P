//Trainer Management App

//1.Trainer class

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramingFundamentalsProject.TrainerApp
{
    internal class Trainer
    {
        public int id;
        public string name;
        public string skill;
        public string place;

        public Trainer(int _id, string _name, string _skill, string _place)
        {
            id = _id;
            name = _name;
            skill = _skill;
            place = _place;
        }

        public override string ToString()
        {
            return $"[id={id},name={name},skill={skill},place={place}]";
        }
    }
}


//2.TrainerDAO Class

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramingFundamentalsProject.TrainerApp
{
    internal class TrainerDAO
    {
        private string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=TrainerManagement;Integrated Security=True";

        // Create a new Trainer
        public void Create(Trainer trainer)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Trainers (Name, Place, Skill) VALUES (@Name, @Place, @Skill)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Name", trainer.name);
                cmd.Parameters.AddWithValue("@Place", trainer.place);
                cmd.Parameters.AddWithValue("@Skill", trainer.skill);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // Read a Trainer by ID
        public Trainer Read(int id)
        {
            Trainer trainer = null;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT Id, Name, Place, Skill FROM Trainers WHERE Id = @Id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", id);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    trainer = new Trainer((int)reader["Id"], reader["Name"].ToString(),
                         reader["Place"].ToString(), reader["Skill"].ToString());
                }
            }
            return trainer;
        }

        // Update a Trainer
        public void Update(Trainer trainer)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "UPDATE Trainers SET Name = @Name, Place = @Place, Skill = @Skill WHERE Id = @Id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", trainer.id);
                cmd.Parameters.AddWithValue("@Name", trainer.name);
                cmd.Parameters.AddWithValue("@Place", trainer.place);
                cmd.Parameters.AddWithValue("@Skill", trainer.skill);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // Delete a Trainer by ID
        public void Delete(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Trainers WHERE Id = @Id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", id);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // List all Trainers
        public List<Trainer> ListAll()
        {
            List<Trainer> trainers = new List<Trainer>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT Id, Name, Place, Skill FROM Trainers";
                SqlCommand cmd = new SqlCommand(query, conn);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Trainer trainer = new Trainer((int)reader["Id"], reader["Name"].ToString(),
                         reader["Place"].ToString(), reader["Skill"].ToString());
                    trainers.Add(trainer);
                }
            }
            return trainers;
        }
    }
}

//3.TrainerUI Class

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramingFundamentalsProject.TrainerApp
{
    internal class TrainerUI
    {
        private TrainerDAO trainerDAO = new TrainerDAO();

        public void CreateTrainer()
        {
            Console.Write("Enter Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter Place: ");
            string place = Console.ReadLine();
            Console.Write("Enter Skill: ");
            string skill = Console.ReadLine();

            Trainer trainer = new Trainer(0, name, place, skill);

            trainerDAO.Create(trainer);
            Console.WriteLine("Trainer created successfully.");
        }

        public void ReadTrainer()
        {
            Console.Write("Enter Trainer ID: ");
            int id = int.Parse(Console.ReadLine());

            Trainer trainer = trainerDAO.Read(id);
            if (trainer != null)
            {
                Console.WriteLine($"ID: {trainer.id}");
                Console.WriteLine($"Name: {trainer.name}");
                Console.WriteLine($"Place: {trainer.place}");
                Console.WriteLine($"Skill: {trainer.skill}");
            }
            else
            {
                Console.WriteLine("Trainer not found.");
            }
        }

        public void UpdateTrainer()
        {
            Console.Write("Enter Trainer ID: ");
            int id = int.Parse(Console.ReadLine());

            Trainer trainer = trainerDAO.Read(id);
            if (trainer != null)
            {
                Console.Write("Enter new Name: ");
                trainer.name = Console.ReadLine();
                Console.Write("Enter new Place: ");
                trainer.place = Console.ReadLine();
                Console.Write("Enter new Skill: ");
                trainer.skill = Console.ReadLine();

                trainerDAO.Update(trainer);
                Console.WriteLine("Trainer updated successfully.");
            }
            else
            {
                Console.WriteLine("Trainer not found.");
            }
        }

        public void DeleteTrainer()
        {
            Console.Write("Enter Trainer ID: ");
            int id = int.Parse(Console.ReadLine());

            trainerDAO.Delete(id);
            Console.WriteLine("Trainer deleted successfully.");
        }

        public void ListAllTrainers()
        {
            List<Trainer> trainers = trainerDAO.ListAll();
            foreach (Trainer trainer in trainers)
            {
                Console.WriteLine($"ID: {trainer.id}, Name: {trainer.name}, Place: {trainer.place}, Skill: {trainer.skill}");
            }
        }
    }
}


//4.TrainerMenu Class

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramingFundamentalsProject.TrainerApp
{
    internal class TrainerMenu
    {
        public static void Menu()
        {
            TrainerUI ui = new TrainerUI();
            bool running = true;

            while (running)
            {
                Console.WriteLine("\nTrainer Management System");
                Console.WriteLine("1. Create Trainer");
                Console.WriteLine("2. Read Trainer");
                Console.WriteLine("3. Update Trainer");
                Console.WriteLine("4. Delete Trainer");
                Console.WriteLine("5. List All Trainers");
                Console.WriteLine("6. Exit");

                Console.Write("Choose an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ui.CreateTrainer();
                        break;
                    case "2":
                        ui.ReadTrainer();
                        break;
                    case "3":
                        ui.UpdateTrainer();
                        break;
                    case "4":
                        ui.DeleteTrainer();
                        break;
                    case "5":
                        ui.ListAllTrainers();
                        break;
                    case "6":
                        running = false;
                        Console.WriteLine("Exiting...");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
    }
}


//5.Program.cs (driver code)

using System;
using System.Collections.Generic;

using System.Text;
using System.Threading.Tasks;


using ProgramingFundamentalsProject.TrainerApp;
namespace ProgramingFundamentalsProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TrainerMenu.Menu();
            Console.ReadKey();
        }


    }
}
