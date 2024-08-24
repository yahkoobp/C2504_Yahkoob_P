using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test2
{
    interface IEmergencyResponder
    {
        void RespondToEmergency();

    }

    class CareProvider : IEmergencyResponder
    {
        public int ProviderId { get; set; }
        public string ProviderName { get; set; }
        public virtual void RespondToEmergency() { }

        public virtual void ProvideCare()
        {
            Console.WriteLine("Care provided...");
        }

    }


    class Nurse : CareProvider, IEmergencyResponder
    {
        public string ShiftTiming { get; set; }
        public override void ProvideCare()
        {
            Console.WriteLine($"Care provided by {this}");
        }
        public override void RespondToEmergency()
        {
            Console.WriteLine($"Responded to emergency by nurse with {this}");
        }

        public void Read()
        {
            Console.WriteLine("Enter the id for nurse");
            ProviderId = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the name of the nurse");
            ProviderName = Console.ReadLine();
            Console.WriteLine("Enter the time shift for the nurse");
            ShiftTiming = Console.ReadLine();
        }

        public override string ToString()
        {
            return $"The nurse with shift timing {Environment.NewLine}" +
                $"ID : {ProviderId} {Environment.NewLine}" +
                $"Name : {ProviderName} {Environment.NewLine}" +
                $"shift timings {ShiftTiming}";
        }

    }
    class Doctor : CareProvider, IEmergencyResponder
    {
        public string Specialization { get; set; }
        public override void ProvideCare()
        {
            Console.WriteLine($"Care provided by {this}");
        }
        public override void RespondToEmergency()
        {
            Console.WriteLine($"Responded to critical situations by doctor {this}");
        }

        public void Read()
        {
            Console.WriteLine("Enter the id for doctor");
            ProviderId = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the name of the doctor");
            ProviderName = Console.ReadLine();
            Console.WriteLine("Enter the specialization for the doctor");
            Specialization = Console.ReadLine();
        }

        public override string ToString()
        {
            return $"The doctor with {Environment.NewLine}" +
                $"ID : {ProviderId} {Environment.NewLine}" +
                $"Name : {ProviderName} {Environment.NewLine}" +
                $"specialzation {Specialization}";
        }

    }
    internal class Program
    {
        enum CareProviderType
        {
            Doctor = 1,
            Nurse = 2
        }

        static void SimulateEmergency(CareProvider[] providers)
        {
            for (int i = 0; i < providers.Length; i++)
            {
                providers[i].RespondToEmergency();
            }
        }

        static void DisplayCareProvided(CareProvider[] providers)
        {
            for (int i = 0; i < providers.Length; i++)
            {
                providers[i].ProvideCare();
            }
        }

        static void Run()
        {
            CareProviderType Ptype;
            CareProvider provider;
            Console.WriteLine("Enter the number of care providers");
            int N = int.Parse(Console.ReadLine());
            CareProvider[] providers = new CareProvider[N];
            for (int i = 0; i < N; i++)
            {
                provider = null;
                Console.WriteLine("1.Doctor ----- 2.Nurse");
                Ptype = (CareProviderType)int.Parse(Console.ReadLine());
                switch (Ptype)
                {
                    case CareProviderType.Doctor:
                        Doctor doc = new Doctor();
                        provider = doc;
                        doc.Read();
                        providers[i] = provider;
                        break;

                    case CareProviderType.Nurse:
                        Nurse nur = new Nurse();
                        provider = nur;
                        nur.Read();
                        providers[i] = provider;
                        break;
                }
            }

            SimulateEmergency(providers);
            DisplayCareProvided(providers);
        }

        static void Main(string[] args)
        {
           Run();
        }
    }
}
