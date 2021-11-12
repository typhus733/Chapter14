using System;
using System.Collections.Generic;

namespace ChapterFourteen
{
    class Ch14
    {
        class Student
        {
            private string name;
            private string course;
            private string subject;
            private string university; 
            private string email; 
            private string phone;

            public Student()
            {

            }

            public Student(string name, string email, string phone)
            {
                this.Name = name;
                this.Email = email;
                this.Phone = phone;
            }

            public Student(string name, string course, string subject, string university, string email, string phone)
            {
                this.Name = name;
                this.Email = email;
                this.Phone = phone;
                this.Course = course;
                this.Subject = subject;
                this.University = university;
            }


            public string Name { get => name; set => name = value; }
            public string Course { get => course; set => course = value; }
            public string Subject { get => subject; set => subject = value; }
            public string University { get => university; set => university = value; }
            public string Email { get => email; set => email = value; }
            public string Phone { get => phone; set => phone = value; }

            public void PrintStudentInfo()
            {
                Console.WriteLine("Student Name: {0}\n" +
                    "Email: {1}\n" +
                    "Phone: {2}\n" +
                    "Course: {3}\n" +
                    "Subject: {4}\n" +
                    "University: {5}", Name, Email, Phone, Course, Subject, University);
            }
        }

        class StudentTest
        {
            private Student student1;
            private Student student2;

            private Student Student1 { get => student1; set => student1 = value; }
            private Student Student2 { get => student2; set => student2 = value; }

            public StudentTest()
            {

            }

            public StudentTest( Student s1, Student s2)
            {
                Student1 = s1;
                Student2 = s2;
            }

            public void Prints()
            {
                Student1.PrintStudentInfo();
                Student2.PrintStudentInfo();
            }
        }

        class Phone
        {
            private string model;
            private string manufacturer;
            private decimal price;
            private string owner;
            private Battery battery;
            private Screen screen;
            private List<Call> callHistory = new List<Call>();
             

            public string Model { get => model; set => model = value; }
            public string Manufacturer { get => manufacturer; set => manufacturer = value; }
            public decimal Price { get => price; set => price = value; }
            public string Owner { get => owner; set => owner = value; }
            private Battery Battery { get => battery; set => battery = value; }
            private Screen Screen { get => screen; set => screen = value; }

            public Phone()
            {

            }

            public Phone(string model, string manu, string owner)
            {
                this.Model = model;
                this.Manufacturer = manu;
                this.Owner = owner;
            }

            public Phone(string model, string manu, string owner, decimal price, Battery battery, Screen screen)
            {
                this.Model = model;
                this.Manufacturer = manu;
                this.Owner = owner;
                this.Price = price;
                this.Battery = battery;
                this.Screen = screen;
            }

            public void AddCall()
            {
                try
                {
                    Console.WriteLine("Enter the call timestamp: ");
                    DateTime timestamp = DateTime.Parse(Console.ReadLine());
                    Console.WriteLine("Enter the call duration in minutes: ");
                    decimal duration = decimal.Parse(Console.ReadLine());
                    Call call = new Call(duration, timestamp);
                    this.callHistory.Add(call);
                }
                catch (FormatException f)
                {
                    Console.WriteLine("Invalid input entered");
                }

            }

            public void RemoveCall()
            {
                try
                {
                    Console.WriteLine("Enter the call timestamp to remove: ");
                    DateTime timestamp = DateTime.Parse(Console.ReadLine());
                    
                    for(int x = this.callHistory.Count-1; x > - 1; x--)
                    { 
                        if (this.callHistory[x].Date == timestamp.ToString("d") && this.callHistory[x].StartTime == timestamp.ToString("t"))
                        {
                            this.callHistory.RemoveAt(x);
                            Console.WriteLine("Call removed succesfully");
                        }
                    }
                }
                catch (FormatException f)
                {
                    Console.WriteLine("Invalid input entered");
                }

            }

            public void ClearCalls()
            {
                this.callHistory.Clear();
                Console.WriteLine("History cleared");
            }

            public void CalculateCalls(decimal price)
            {
                decimal total = 0;
                foreach (Call call in this.callHistory)
                {
                    total += (call.Duration * price);
                }

                Console.WriteLine("The total price for calls is {0:C2}", total);
            }

            override public string ToString()
            {
                return ("Model: " + Model + "\nManufacturer: " + Manufacturer + "\nPrice: " + Price + "\nOwner: " + Owner + "\n" + battery.ToString() + "\n" + Screen.ToString());
            }
        }

        class Battery
        {
            private string model;
            private double hours;
            private int idle;

            public string Model { get => model; set => model = value; }
            public double Hours { get => hours; set => hours = value; }
            public int Idle { get => idle; set => idle = value; }

            public Battery()
            {

            }

            public Battery (string model)
            {
                this.Model = model;
            }

            public Battery(string model, double hours, int idle)
            {
                this.Model = model;
                this.Hours = hours;
                this.Idle = idle;
            }

            override public string ToString()
            {
                return ("Battery Model: " + Model + "\nTalk Hours: " + Hours + "\nIdle Time: " + Idle);
            }
        }

        class Screen
        {
            private double size;
            private string colors;

            public double Size { get => size; set => size = value; }
            public string Colors { get => colors; set => colors = value; }

            public Screen()
            {

            }
            public Screen(double size)
            {
                this.Size = size;
            }
            public Screen(double size, string colors)
            {
                this.Size = size;
                this.Colors = colors;
            }


            override public string ToString()
            {
                return ("Screen Size: " + Size + "\nColors: " + Colors);
            }
        }

        class Call
        {
            private decimal duration;
            private string date;
            private string startTime;

            public Call (decimal duration, DateTime timestamp)
            {
                this.Duration = duration;
                this.Date = timestamp.ToString("d");
                this.StartTime = timestamp.ToString("t");
            }

            public decimal Duration { get => duration; set => duration = value; }
            public string Date { get => date; set => date = value; }
            public string StartTime { get => startTime; set => startTime = value; }
        }

        class PhoneHistoryTest
        {
            private Phone phone;

            public PhoneHistoryTest(Phone phone)
            {
                this.phone = phone;
            }

            public void Test()
            {
                phone.AddCall();
                phone.AddCall();
                phone.AddCall();
                phone.CalculateCalls(0.37m);
                phone.RemoveCall();
                phone.CalculateCalls(0.37m);
                phone.ClearCalls();
                phone.CalculateCalls(0m);

            }
        }


        static void TestStudentClasses()
        {

            Student student1 = new Student("a", "b", "c");
            Student student2 = new Student("bob", "the maths", "Math", "University of Pheonix", "bob@mail.com", "666-4269");

            StudentTest st = new StudentTest(student1, student2);

            st.Prints();

        }

        static void TestPhone()
        {
            Battery battery = new Battery("sg532532", 70.5, 15);
            Screen screen = new Screen(18.3, "Lots");
            Phone newPhone = new Phone("s500", "Samsung", "Bob", 50m, battery, screen);

            PhoneHistoryTest callTest = new PhoneHistoryTest(newPhone);
            callTest.Test();

        }

        static void Main(string[] args)
        {
            TestStudentClasses();
            TestPhone();   
        }
    }
}
