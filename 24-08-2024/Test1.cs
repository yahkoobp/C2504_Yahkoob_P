using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test1
{
    class VitalSigns
    {
        public int PatientID { get; set; }
        public int HeartRate { get; set; }
        public string BloodPressure { get; set; }
        public double Temperature { get; set; }

        public void Read()
        {
            Console.WriteLine("Enter PatientID");
            PatientID = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter HeartRate");
            HeartRate = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter BloodPressure");
            BloodPressure = Console.ReadLine();
            Console.WriteLine("Enter Temperature");
            Temperature = int.Parse(Console.ReadLine());
        }

        public override string ToString()
        {
            return $"PatientID : {PatientID} {Environment.NewLine}" +
                $"HeartRate : {HeartRate} {Environment.NewLine}" +
                $"BloodPressure : {BloodPressure} {Environment.NewLine}" +
                $"Temperature : {Temperature} {Environment.NewLine}";
        }
    }
    internal class Program
    {

        static VitalSigns LowestHeartRate(VitalSigns[] vitalSigns) //funtion to find patient Lowest heart rate
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

        static VitalSigns SecondLargestTemp(VitalSigns[] vitalSigns) // function to find patient with second largest temperature
        {
            double largest = double.MinValue;
            double secLargest = double.MinValue;
            VitalSigns secLargePatient = null;
            for (int i = 0;i < vitalSigns.Length; i++)
            {
                if (vitalSigns[i].Temperature > largest)
                {
                    secLargest = largest;
                    largest = vitalSigns[i].Temperature;
                    secLargePatient = vitalSigns[i];

                }

                else if (vitalSigns[i].Temperature > secLargest && vitalSigns[i].Temperature < largest)
                {
                    secLargest = vitalSigns[i].Temperature;
                    secLargePatient = vitalSigns[i];
                }

            }
            return secLargePatient;

        }


        static void SortBloodPressure(VitalSigns[] vitalSigns)  // function to sort patients by blood pressure
        {
            int N = vitalSigns.Length;
            for (int i = 0; i < N - 1; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < N; j++)
                {
                    if (int.Parse(vitalSigns[j].BloodPressure) < int.Parse(vitalSigns[minIndex].BloodPressure))
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
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the number of patients");
            int N = int.Parse(Console.ReadLine());
            VitalSigns[] vitalSigns = new VitalSigns[N];
            for (int i = 0; i < N; i++)
            {
                VitalSigns vit = new VitalSigns();
                Console.WriteLine($"Read data for patient {i+1}");
                vit.Read();
                vitalSigns[i] = vit;
            }


            Console.WriteLine("List of Patients\n");  // to display all patients
            for (int i = 0;i < N; i++)
            {
                Console.WriteLine($"{ vitalSigns[i]}");
            }

            Console.WriteLine("The patient with lowest heartrate is\n");
            VitalSigns lowHeartRatePatient = LowestHeartRate(vitalSigns);
            Console.WriteLine(lowHeartRatePatient);

            Console.WriteLine("The patient with second largest temperature is\n");
            VitalSigns secLargestTempPatient = SecondLargestTemp(vitalSigns);
            Console.WriteLine(secLargestTempPatient);

            Console.WriteLine("The List of patients after sorting by blood pressure is\n");
            SortBloodPressure(vitalSigns);
            for (int i = 0; i < N; i++)
            {
                Console.WriteLine($"{vitalSigns[i]}");
            }





        }
    }
}
