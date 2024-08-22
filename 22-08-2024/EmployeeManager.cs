using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManager
{
    internal class Program
    {
        enum AddressType
        {
            PermanentAddress,
            CurrentAddress
        }
        class PhoneNumber
        {
            public long Phonenumber { get; set; }
            //public PhoneNumber(long phoneNumber)
            //{
            //    this.Phonenumber = phoneNumber; 
            //}
            public override string ToString()
            {
                return $"{Phonenumber}";
            }
        }
        class Exeperience
        {
            public string CompanyName { get; set; }
            public string Website { get; set; }
            public string Address { get; set; }
            public int ExperienceInYears { get; set; }

            //public Exeperience(string companyName, string website, string address, int experienceInYears)
            //{
            //    CompanyName = companyName;
            //    Website = website;
            //    Address = address;
            //    ExperienceInYears = experienceInYears;
            //}

            public override string ToString()
            {
                return $"{CompanyName} {Website} {Address} {ExperienceInYears}";
            }
        }

        class Country
        { 
            public string Name { get; set; }
            public string Code { get; set; }
            //public Country(string name, string code)
            //{
            //    Name = name;
            //    Code = code;
            //}

            public override string ToString()
            {
                return $"{Name} {Code}";
            }
        }

        class Address
        {
            public AddressType Addresstype {  get; set; }
            public string FullAddress { get; set; }
            public Country country {  get; set; }
            //public Address(AddressType addresstype, string fullAddress, Country country)
            //{
            //    Addresstype = addresstype;
            //    FullAddress = fullAddress;
            //    this.country = country;
            //}

            public override string ToString()
            {
                return $"{FullAddress} {country}";
            }
        }

        class Employee
        {
            public string Name { get; set; }
            public string Email { get; set; }
            public Address[] Address { get; set; }
            public Exeperience[] Experience { get; set; }
            public PhoneNumber[] PhoneNumber { get; set; }
            //public Employee(string name, string email, Address address, Exeperience experience, PhoneNumber phoneNumber)
            //{
            //    Name = name;
            //    Email = email;
            //    Address = address;
            //    Experience = experience;
            //    PhoneNumber = phoneNumber;
            //}

            public override string ToString()
            {
                return $"Name : {Name} Email : {Email} Address : {Address} Experiences : {Experience} phoneNumber : {PhoneNumber}";
            }
        }

        static void Main(string[] args)
        {
            Employee employee = new Employee
            {
                Name = "John",
                Email = "john@gmail.com",
                Address = new Address[]
                { 
                  new Address()
                {
                    Addresstype = AddressType.CurrentAddress,
                    FullAddress = "full address",
                    country = new Country()
                    {
                        Name = "India",
                        Code = "+91"
                    }
                },new Address()
                {
                    Addresstype = AddressType.PermanentAddress,
                    FullAddress = "full address",
                    country = new Country()
                    {
                        Name = "India",
                        Code = "+91"
                    }
                }
                },
                Experience = new Exeperience[]
                {
                    new Exeperience()
                    {
                        CompanyName = "Quest",
                        Website = "quest@gmail.com",
                        Address = "trivandrum",
                        ExperienceInYears = 4
                    },
                    new Exeperience()
                    {
                        CompanyName = "UST",
                        Website = "ust@gmail.com",
                        Address = "trivandrum",
                        ExperienceInYears = 2
                    }
                },
                PhoneNumber = new PhoneNumber[]
                {
                    new PhoneNumber()
                    {
                        Phonenumber = 9876543212
                    },
                    new PhoneNumber()
                    {
                        Phonenumber = 6276543212
                    }

                }


            };

            Console.WriteLine($"Employee details  {employee.Experience[0]}");

        }
    }
}
