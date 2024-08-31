//program.cs
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;

namespace Week4AssessmentApp
{
   
    internal class Program
    {
        public static readonly ILog log = LogManager.GetLogger(typeof(Program));
        static void Main(string[] args)
        {
            VitalSignMenu.Menu();
            Console.ReadKey();
        }
    }
}

//VitalSigns.cs
using System;

namespace Week4AssessmentApp
{
    public class VitalSigns
    {
        public int PatientID { get; set; }
        public int HeartRate { get; set; }
        public string BloodPressure { get; set; }
        public double Temperature { get; set; }

        public override string ToString()
        {
            return $"PatientID : {PatientID} {Environment.NewLine}" +
                $"HeartRate : {HeartRate} {Environment.NewLine}" +
                $"BloodPressure : {BloodPressure} {Environment.NewLine}" +
                $"Temperature : {Temperature} {Environment.NewLine}";
        }
    }
}


//VitalSignMenu.cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week4AssessmentApp
{
    internal class VitalSignMenu
    {
        public static void Menu()
        {
            VitalSignUI ui = new VitalSignUI();
            bool running = true;

            while (running)
            {
                Console.WriteLine("\nPatient Management System");
                Console.WriteLine("1. Create VitalSign");
                Console.WriteLine("2. Read VitalSign");
                Console.WriteLine("3. Update VitalSign");
                Console.WriteLine("4. Delete vitalSign");
                Console.WriteLine("5. List All VitalSigns");
                Console.WriteLine("6. Exit");

                Console.Write("Choose an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ui.CreateVitalSign();
                        break;
                    case "2":
                        ui.ReadVitalSign();
                        break;
                    case "3":
                        ui.UpdateVitalSign();
                        break;
                    case "4":
                        ui.DeleteVitalSign();
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

//VitalSignUi.cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week4AssessmentApp
{
    internal class VitalSignUI
    {
        private VitalSignsServices vitalSignsServices = new VitalSignsServices();

        public void CreateVitalSign()
        {
            Console.Write("Enter PatientId ");
            int patientId = int.Parse(Console.ReadLine());
            Console.Write("Enter HeartRate: ");
            int HeartRate = int.Parse(Console.ReadLine());
            Console.Write("Enter BloodPressure: ");
            string BloodPressure = Console.ReadLine();
            Console.Write("Enter Temperature: ");
            int Temperature = int.Parse(Console.ReadLine());

            VitalSigns vitalSign = new VitalSigns 
            { 
                PatientID = patientId,
                HeartRate = HeartRate,
                BloodPressure = BloodPressure,
                Temperature = Temperature,
            };

            vitalSignsServices.Create(vitalSign);
            Console.WriteLine("Vital sign created successfully.");
        }

        public void ReadVitalSign()
        {
            Console.Write("Enter Patient ID: ");
            int id = int.Parse(Console.ReadLine());

            VitalSigns vitalSigns = vitalSignsServices.Read(id);
            if (vitalSigns != null)
            {
                Console.WriteLine($"PatientID: {vitalSigns.PatientID}");
                Console.WriteLine($"HeartRate: {vitalSigns.HeartRate}");
                Console.WriteLine($"BloodPressure: {vitalSigns.BloodPressure}");
                Console.WriteLine($"Temperature: {vitalSigns.Temperature}");
            }
            else
            {
                Console.WriteLine("Vital sign not found.");
            }
        }

        public void UpdateVitalSign()
        {
            Console.Write("Enter Patient ID: ");
            int id = int.Parse(Console.ReadLine());

            VitalSigns vitalSigns = vitalSignsServices.Read(id);
            if (vitalSigns != null)
            {
                Console.Write("Enter new PatientId ");
                int patientId = int.Parse(Console.ReadLine());
                Console.Write("Enter new HeartRate: ");
                int HeartRate = int.Parse(Console.ReadLine());
                Console.Write("Enter new BloodPressure: ");
                string BloodPressure = Console.ReadLine();
                Console.Write("Enter new Temperature: ");
                int Temperature = int.Parse(Console.ReadLine());

                VitalSigns vitalSign = new VitalSigns
                {
                    PatientID = patientId,
                    HeartRate = HeartRate,
                    BloodPressure = BloodPressure,
                    Temperature = Temperature,
                };

                vitalSignsServices.Update(vitalSign);
                Console.WriteLine("Vital sign updated successfully.");
            }
            else
            {
                Console.WriteLine("Vitalsign not found.");
            }
        }

        public void DeleteVitalSign()
        {
            Console.Write("Enter Pateint ID: ");
            int id = int.Parse(Console.ReadLine());

            vitalSignsServices.Delete(id);
            Console.WriteLine("Vital signs deleted successfully.");
        }

        public void ListAllTrainers()
        {
            List<VitalSigns> vitalsigns = vitalSignsServices.ListAll();
          
            foreach (VitalSigns vitalSign in vitalsigns)
            {
                Console.WriteLine($"PatientID: {vitalSign.PatientID}, HeartRate: {vitalSign.HeartRate}, BloodPressure: {vitalSign.BloodPressure}, Temperature: {vitalSign.Temperature}");
            }
        }
    }
}

//VitalSignServices.cs

using log4net;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Week4AssessmentApp
{
    public class ServerException : Exception
    {
        public ServerException(string message) : base(message) { }
    }
    public class VitalSignsServices
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(Program));

        private static string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Week4AssessmentApp;Integrated Security=True;";

        public void Create(VitalSigns vitalSign)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO VitalSigns (PatientID, HeartRate, BloodPressure ,Temperature) VALUES (@PatientID, @HeartRate, @BloodPressure , @Temperature)";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@PatientID", vitalSign.PatientID);
                    cmd.Parameters.AddWithValue("@HeartRate", vitalSign.HeartRate);
                    cmd.Parameters.AddWithValue("@BloodPressure", vitalSign.BloodPressure);
                    cmd.Parameters.AddWithValue("@Temperature", vitalSign.Temperature);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }

            }catch(SqlException ex)
            {
                log.Error(ex.Message);
            }
            catch(ServerException ex)
            {
                log.Error(ex.Message);
            }
            catch(Exception ex)
            {
                log.Error(ex.Message);
            }
            
        }

        public VitalSigns Read(int id)
        {
            VitalSigns vitalSign = null;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "SELECT PatientID, HeartRate, BloodPressure , Temperature FROM VitalSigns WHERE PatientID = @Id";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Id", id);

                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        vitalSign = new VitalSigns
                        {
                            PatientID = reader["PatientID"] != DBNull.Value ? (int)reader["PatientID"] : 0,
                            HeartRate = reader["HeartRate"] != DBNull.Value ? Convert.ToInt32(reader["HeartRate"]) : 0,
                            BloodPressure = reader["BloodPressure"] != DBNull.Value ? reader["BloodPressure"].ToString() : string.Empty,
                            Temperature = reader["Temperature"] != DBNull.Value ? Convert.ToInt32(reader["Temperature"]) : 0
                        };
                    }
                }
                return vitalSign;

            }
            catch (SqlException ex)
            {
                // Handle SQL exceptions
                //Console.WriteLine($"SQL Error: {ex.Message}");
                throw new ServerException($"[0102]Server Errror.{ex.Message}");//throw Error
            }
            catch (ServerException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                // Handle other exceptions
                //Console.WriteLine($"Error: {ex.Message}");
                throw new ServerException($"[0103]Server Errror.{ex.Message}");//throw Error
            }
        }

        public void Update(VitalSigns vitalSign)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "UPDATE VitalSigns SET PatientID = @PatientID, HeartRate = @HeartRate, BloodPressure = @BloodPressure ,Temperature = @Temperature WHERE PatientID = @PatientID";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@PatientID", vitalSign.PatientID);
                    cmd.Parameters.AddWithValue("@HeartRate", vitalSign.HeartRate);
                    cmd.Parameters.AddWithValue("@BloodPressure", vitalSign.BloodPressure);
                    cmd.Parameters.AddWithValue("@Temperature", vitalSign.Temperature);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }

            }
            catch (SqlException ex)
            {
                // Handle SQL exceptions
                //Console.WriteLine($"SQL Error: {ex.Message}");
                throw new ServerException($"[0102]Server Errror.{ex.Message}");//throw Error
            }
            catch (ServerException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                // Handle other exceptions
                //Console.WriteLine($"Error: {ex.Message}");
                throw new ServerException($"[0103]Server Errror.{ex.Message}");//throw Error
            }

        }

        public void Delete(int id)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "DELETE FROM VitalSigns WHERE PatientId = @Id";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Id", id);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }

            }
            catch (SqlException ex)
            {
                // Handle SQL exceptions
                //Console.WriteLine($"SQL Error: {ex.Message}");
                throw new ServerException($"[0102]Server Errror.{ex.Message}");//throw Error
            }
            catch (ServerException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                // Handle other exceptions
                //Console.WriteLine($"Error: {ex.Message}");
                throw new ServerException($"[0103]Server Errror.{ex.Message}");//throw Error
            }

        }

        public List<VitalSigns> ListAll()
        {
           
            try
            {
                List<VitalSigns> vitalSigns = new List<VitalSigns>();
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "SELECT PatientID, HeartRate, BloodPressure , Temperature FROM VitalSigns";
                    SqlCommand cmd = new SqlCommand(query, conn);

                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {

                        VitalSigns vitalSign = new VitalSigns
                        {
                            PatientID = reader["PatientID"] != DBNull.Value ? (int)reader["PatientID"] : 0,
                            HeartRate = reader["HeartRate"] != DBNull.Value ? Convert.ToInt32(reader["HeartRate"]) : 0,
                            BloodPressure = reader["BloodPressure"] != DBNull.Value ? reader["BloodPressure"].ToString() : string.Empty,
                            Temperature = reader["Temperature"] != DBNull.Value ? Convert.ToInt32(reader["Temperature"]) : 0
                        };
                        vitalSigns.Add(vitalSign);
                    }
                    return vitalSigns;
                }
            }
            catch (SqlException ex)
            {
                // Handle SQL exceptions
                //Console.WriteLine($"SQL Error: {ex.Message}");
                throw new ServerException($"[0102]Server Errror.{ex.Message}");//throw Error
            }
            catch (ServerException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                // Handle other exceptions
                //Console.WriteLine($"Error: {ex.Message}");
                throw new ServerException($"[0103]Server Errror.{ex.Message}");//throw Error
            }
        }

        public void Sort(VitalSigns[] vitalSigns)
        {
            int N = vitalSigns.Length;
            for (int i = 0; i < N - 1; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < N; j++)
                {
                    if (int.Parse(vitalSigns[j].BloodPressure.Split('/')[0]) < int.Parse(vitalSigns[minIndex].BloodPressure.Split('/')[0]))
                    {
                        minIndex = j;
                    }
                }

                if (minIndex != i)
                {
                    string temp = vitalSigns[i].BloodPressure;
                    vitalSigns[i].BloodPressure = vitalSigns[minIndex].BloodPressure;
                    vitalSigns[minIndex].BloodPressure = temp;
                }

            }
        }
        public VitalSigns FindMinimum(VitalSigns[] vitalSigns)
        {
            int minHeartRate = int.MaxValue;
            VitalSigns vitalSign = null;
            for (int i = 0; i < vitalSigns.Length; i++)
            {
                if (vitalSigns[i].HeartRate < minHeartRate)
                {
                    minHeartRate = vitalSigns[i].HeartRate;
                    vitalSign = vitalSigns[i];
                }
            }

            return vitalSign;
        }
        public VitalSigns FindSecondMax(VitalSigns[] vitalSigns)
        {
            double largest = double.MinValue;
            double secLargest = double.MinValue;
            VitalSigns secLargePatient = null;
            VitalSigns largestPatient = null;
            for (int i = 0; i < vitalSigns.Length; i++)
            {
                if (vitalSigns[i].Temperature > largest)
                {
                    secLargest = largest;
                    secLargePatient = largestPatient; 
                    largest = vitalSigns[i].Temperature;
                    largestPatient = vitalSigns[i]; 

                }

                else if (vitalSigns[i].Temperature > secLargest && vitalSigns[i].Temperature != largest)
                {
                    secLargest = vitalSigns[i].Temperature;
                    secLargePatient = vitalSigns[i];

                }

            }
            return secLargePatient;
        }
    }
}


