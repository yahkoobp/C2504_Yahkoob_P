using log4net;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;

namespace Week4AssessmentApp
{
    public class ServerException : Exception
    {
        public ServerException(string message) : base(message) { }
    }
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

    public class VitalSignsServices
    {
        private static string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Week4AssessmentApp;Integrated Security=True;";

        public static void Read(VitalSigns[] vitalSigns)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "SELECT PatientID, HeartRate, BloodPressure , Temperature FROM VitalSigns";
                    SqlCommand cmd = new SqlCommand(query, conn);

                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();


                    for (int i = 0; i < vitalSigns.Length; i++)
                    {
                        if (!reader.Read())
                        {
                            throw new ServerException("[0101]Server Errror.");//throw error
                        }
                        vitalSigns[i] = new VitalSigns
                        {
                            PatientID = (int)reader["PatientID"],
                            HeartRate = (int)reader["HeartRate"],
                            BloodPressure = reader["BloodPressure"].ToString(),
                            Temperature = (int)reader["HeartRate"]
                        };
                    }
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
        public static void Sort(VitalSigns[] vitalSigns)
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
        public static VitalSigns FindMinimum(VitalSigns[] vitalSigns)
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
        public static VitalSigns FindSecondMax(VitalSigns[] vitalSigns)
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
    internal class Program
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(Program));
        static void Main(string[] args)
        {
            
        VitalSigns[] vitalSigns = new VitalSigns[3];
            try
            {
                VitalSignsServices.Read(vitalSigns);
            }
            catch (ServerException  ex) 
            {
                log.Error($"{ex.Message}");
            }


            Console.WriteLine("List of Patients\n");  // to display all patients
           
            for (int i = 0; i < 3; i++)
            {
                log.Info($"{vitalSigns[i]}");
            }
          


            Console.WriteLine("The patient with lowest heartrate is\n");
            VitalSigns minHeart = VitalSignsServices.FindMinimum(vitalSigns);
            log.Info(minHeart);

            Console.WriteLine("The patient with second largest temperature is\n");
            VitalSigns secMax = VitalSignsServices.FindSecondMax(vitalSigns);
            log.Info(secMax);

            Console.WriteLine("The List of patients after sorting by blood pressure is\n");
            VitalSignsServices.Sort(vitalSigns);
            for (int i = 0; i < 3; i++)
            {
                log.Info($"{vitalSigns[i]}");
            }

        }
    }
}


//Unit tests
//FindSecondMaxTest
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Week4AssessmentApp;

namespace Week4AssessmentAppTests
{
    [TestClass]
    public class FindSecondMaxTest
    {
        [TestMethod]
        public void FindSecondMax_Test()
        {
            VitalSigns[] vitalSigns = new VitalSigns[3];
            VitalSignsServices.Read(vitalSigns);
            VitalSigns expected = new VitalSigns
            {
                PatientID = 100,
                HeartRate = 72,
                BloodPressure = "120/80",
                Temperature = 72
            };

            VitalSigns actual = VitalSignsServices.FindSecondMax(vitalSigns);
            Assert.AreEqual(expected.ToString(), actual.ToString());
        }
    }
}

// FindMinimumTest
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Week4AssessmentApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week4AssessmentApp.Tests
{
    [TestClass()]
    public class VitalSignsServicesTests
    {
        [TestMethod()]
        public void FindMinimumTest()
        {
            VitalSigns[] vitalSigns = new VitalSigns[3];
            VitalSignsServices.Read(vitalSigns);
            VitalSigns expected = new VitalSigns
            {

                 PatientID = 101,
                 HeartRate = 70,
                 BloodPressure = "110/76",
                 Temperature = 70
            };
            VitalSigns actual = VitalSignsServices.FindMinimum(vitalSigns);
            Assert.AreEqual(expected.ToString(), actual.ToString());
        }
    }
}

//TestSorting

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Week4AssessmentApp;

namespace Week4AssessmentAppTests
{
    [TestClass]
    public class TestSorting
    {
        [TestMethod]
        public void Test_Sorting()
        {
            VitalSigns[] vitalSigns = new VitalSigns[3];
            VitalSignsServices.Read(vitalSigns);
            VitalSigns expected = new VitalSigns
            {
                PatientID = 100,
                HeartRate = 72,
                BloodPressure = "110/76",
                Temperature = 72
            };
            VitalSignsServices.Sort(vitalSigns);
            VitalSigns actual = vitalSigns[0];
            Assert.AreEqual(expected.ToString(), actual.ToString());
        }
    }
}

