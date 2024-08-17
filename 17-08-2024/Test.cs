using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class Medication
    {
        public string MedicationID{get; set;}
        public int DosagePerDay { get; set; }

        public Medication(string medicationID, int dosagePerDay)
        {
            MedicationID = medicationID;
            DosagePerDay = dosagePerDay;
        }

        public bool Equals(Medication other)
        {
            return this.DosagePerDay == other.DosagePerDay;
        }

        public bool NotEquals(Medication other)
        {
            return this.DosagePerDay != other.DosagePerDay;
        }

        public bool GreaterThan(Medication other)
        {
            return this.DosagePerDay > other.DosagePerDay;
        }

        public bool GreaterThanEquals(Medication other)
        {
            return this.DosagePerDay >= other.DosagePerDay;
        }

        public bool LessThan(Medication other)
        {
            return this.DosagePerDay < other.DosagePerDay;
        }

        public bool LessThanEquals(Medication other)
        {
            return this.DosagePerDay <= other.DosagePerDay;
        }


        public override string ToString()
        {
            return $"The medication with dosage {DosagePerDay}";
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Medication med1 = new Medication("M001", 170);
            Medication med2 = new Medication("M002", 170);

            if (med1.Equals(med2))
            {
                Console.WriteLine($"{med1} and {med2} has same daily dosage");
            }
            if (med1.NotEquals(med2))
            {
                Console.WriteLine($"{med1} and {med2} has not same daily dosage");
            }
            if (med1.GreaterThan(med2))
            {
                Console.WriteLine($"{med1} has higher daily dosage than {med2}");
            }
            if (med1.GreaterThanEquals(med2))
            {
                Console.WriteLine($"{med1} has higher or equal daily dosage than {med2}");
            }
            if (med1.LessThan(med2))
            {
                Console.WriteLine($"{med1} has lower daily dosage than {med2}");
            }
            if (med1.LessThanEquals(med2))
            {
                Console.WriteLine($"{med1} has lower or equal daily dosage than {med2}");
            }
        }
    }
}

/*
Output
The medication with dosage 150 and The medication with dosage 170 has not same daily dosage
The medication with dosage 150 has lower daily dosage than The medication with dosage 170
The medication with dosage 150 has lower or equal daily dosage than The medication with dosage 170
Press any key to continue . . .
*/
