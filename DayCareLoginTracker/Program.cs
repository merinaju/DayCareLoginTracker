using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Validation;

namespace DayCareLoginTracker
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*******Welcome to LittleImpressions DayCare********");
            string option = "";
            Parent parent;
            do
            {
                Console.WriteLine("1.Register a new student");
                Console.WriteLine("2.Parent Login");
                Console.WriteLine("3.Print StudentDetails");
                Console.WriteLine("0.Exit");
                option = Console.ReadLine();
                switch (option)
                {
                    case "1":
                        try
                        {
                            parent = VerifyParent();
                            Console.WriteLine("Please enter the name of the student");
                            var name = Console.ReadLine();
                            Console.WriteLine("Please enter the age");
                            var age = int.Parse(Console.ReadLine());
                            Console.WriteLine("Please enter the gender of the student");
                            Console.WriteLine("1. Male");
                            Console.WriteLine("2.female");
                            var gendertype = Console.ReadLine();
                            Gender typeofgender = Gender.female;
                            if (gendertype == "male")
                            {
                                typeofgender = Gender.male;
                            }
                            var student1 = DayCare.RegisterStudent(parent, name, age, typeofgender);
                            Console.WriteLine("Name of the student{0}", name);
                            Console.WriteLine("Age of the student{0}", age);
                            Console.WriteLine("Gender of the student{0}", typeofgender);
                        }
                        catch (ArgumentNullException ax)
                        {
                            Console.WriteLine("Failed {0}", ax.ParamName);
                        }
                        catch (DbEntityValidationException dx)
                        {
                            Console.WriteLine("Failed to create an account", dx.Message);
                        }
                        catch (Exception)
                        {

                        }

                        break;
                    case "2":
                        break;
                    case "3":
                        break;
                    case "0":
                        break;
                    default:
                        break;
                }




            }
            while (option != "0");
        }
        private static Parent VerifyParent()

        {
            Console.WriteLine("what is your email address");
            var emailaddress = Console.ReadLine();
            var parent = DayCare.FindParent(emailaddress);
            if (parent == null)
            {
                Console.WriteLine("Please enter the name of the Parent");
                var parentname = Console.ReadLine();
                Console.WriteLine("Please enter phone number");
                var phonenumber = Console.ReadLine();
                Console.WriteLine("Please enter the street address");
                var streetaddress = Console.ReadLine();
                parent = DayCare.CreateParent(parentname,phonenumber,streetaddress,emailaddress);
            }

            return parent;
        }
    }
}
