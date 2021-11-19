using System;
using System.Collections.Generic;

namespace ChapterFourteen
{

    class Ch14
    {
        class GenericList<T>
        {
            private List<T> elementList;
            private T[] elementArray;

            public List<T> ElementList { get => elementList; set => elementList = value; }
            public T[] ElementArray { get => elementArray; set => elementArray = value; }

            public GenericList(int capacity)
            {
                elementList = new List<T>();
                elementArray = new T[capacity];
            }

            private void UpdateArray()
            {
                if (ElementArray.Length < ElementList.Count)
                {
                    ElementArray = new T[ElementList.Count];
                }
                for(int i = 0; i <= ElementList.Count - 1; i++)
                {
                    ElementArray[i] = ElementList[i];
                }
            }

            public void AddItem(T item)
            {
                elementList.Add(item);
                UpdateArray();
            }
            public T AccessByIndex(int index)
            {
                return ElementArray[index];
            }

            public void RemoveByIndex(int index)
            {
                ElementList.RemoveAt(index);
                UpdateArray();
            }

            public void InsertAtIndex(int index, T value)
            {
                ElementList.Insert(index, value);
                UpdateArray();
            }

            public void ClearList()
            {
                ElementList.Clear();
                ElementArray = new T[0];
            }

            public int SearchByValue(T value)
            {
                return ElementList.BinarySearch(value);
            }
            public override string ToString()
            {
                string returnString = "";

                foreach (T item in ElementList)
                {
                    returnString += item + "\n";
                }

                return returnString;
            }
        }


        class Student
        {
            static private int studentCounter = 0;
            private string name;
            private string course;
            private string subject;
            private string university; 
            private string email; 
            private string phone;

            public Student()
            {

            }

            public Student(string name, string email, string phone): this(name, null, null, null, email, phone)
            {

            }

            public Student(string name, string course, string subject, string university, string email, string phone)
            {
                this.Name = name;
                this.Email = email;
                this.Phone = phone;
                this.Course = course;
                this.Subject = subject;
                this.University = university;

                studentCounter += 1;
            }


            public string Name { get => name; set => name = value; }
            public string Course { get => course; set => course = value; }
            public string Subject { get => subject; set => subject = value; }
            public string University { get => university; set => university = value; }
            public string Email { get => email; set => email = value; }
            public string Phone { get => phone; set => phone = value; }

            override public string ToString()
            {
                return ("Student Name: " + name +
                    "\nEmail: " + Email +
                    "\nPhone: " + Phone +
                    "\nCourse: " + Course + 
                    "\nSubject: " + Subject +
                    "\nUniversity: " + University);
            }
        }

        class StudentTest
        {

            static Student student1;
            static Student student2;

            public static Student Student1 { get => student1; }
            public static Student Student2 { get => student2;  }

            public static void CreateStaticStudents()
            {
                student1 = new Student("Bob", "The Maths", "Math", "U of B", "Bob@mail.com", "666-4269");
                student2 = new Student("Tom", "Advanced The Maths", "Math", "U of B", "Tom@mail.com", "666-5555");
            }

            public static void PrintStaticStudents()
            {
                Console.WriteLine(Student1);
                Console.WriteLine(Student2);
            }

            public bool PrintStudentInfoTest()
            {
                Student testStudent = new Student("Bob", "The Maths", "Math", "U of B", "Bob@mail.com", "666-4269");
                string expectedResult = ("Student Name: Bob" +
                    "\nEmail: Bob@mail.com" +
                    "\nPhone: 666-4269" +
                    "\nCourse: The Maths" +
                    "\nSubject: Math" +
                    "\nUniversity: U of B");

                string actualResult = testStudent.ToString();

                Console.WriteLine("Student ToString Test");
                return expectedResult == actualResult;
            }
        }

        class Phone
        {

            private static Phone nokiaN95 = new Phone("nokiaN95", "Nokia", 50m);
            private string model;
            private string manufacturer;
            private decimal price;
            private string owner;
            private Battery battery;
            private Screen screen;
            private List<Call> callHistory;
             

            public string Model { get => model; set => model = value; }
            public string Manufacturer { get => manufacturer; set => manufacturer = value; }
            public decimal Price { get => price; set => price = value; }
            public string Owner { get => owner; set => owner = value; }
            public Battery Battery { get => battery; set => battery = value; }
            public Screen Screen { get => screen; set => screen = value; }
            public List<Call> CallHistory { get => callHistory; set => callHistory = value; }
            public Phone NokiaN95 { get => nokiaN95; set => nokiaN95 = value; }

            public Phone()
            {

            }

            public Phone(string model, string manu, decimal price): this(model, manu, null, price, null, null)
            {
              
            }

            public Phone(string model, string manu, string owner, decimal price, Battery battery, Screen screen)
            {
                this.Model = model;
                this.Manufacturer = manu;
                this.Owner = owner;
                this.Price = price;
                this.Battery = battery;
                this.Screen = screen;
                callHistory = new List<Call>();
            }

            public void AddCall(Call newCall)
            {
                callHistory.Add(newCall);

            }

            public void RemoveCall(Call callToRemove)
            {
                callHistory.Remove(callToRemove);
            }

            public void ClearCalls()
            {
                this.callHistory.Clear();
            }

            public decimal CalculateCalls(decimal price)
            {
                decimal total = 0;
                foreach (Call call in this.callHistory)
                {
                    total += (call.Duration * price);
                }

                return total;
            }
            public static void PrintNokia()
            {
                Console.WriteLine("Model: " + nokiaN95.Model + "\nManufacturer: " + nokiaN95.Manufacturer + "\nPrice: " + nokiaN95.Price);
            }
             
            override public string ToString()
            {
                return ("Model: " + Model + "\nManufacturer: " + Manufacturer + "\nPrice: " + Price + "\nOwner: " + Owner + "\n" + battery.ToString() + "\n" + Screen.ToString());
            }
        }

        class Battery
        {
            private enum batteryType { LiIon, NiMH, NiCd };
            
            private string model;
            private double hours;
            private int idle;

            public string Model { get => model; set => model = value; }
            public double Hours { get => hours; set => hours = value; }
            public int Idle { get => idle; set => idle = value; }

            public Battery()
            {

            }

            public Battery (string model): this (model, 0, 0)
            {
                
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
            public Screen(double size): this(size, null)
            {
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
            

            public PhoneHistoryTest()
            {
                
            }



            public bool AddNewCallTest()
            {
                Phone testPhone = new Phone("s10", "Samsung", "Bob", 500m, null, null);
                Call newCall = new Call(15, DateTime.Parse("11/11 10 AM"));

                testPhone.AddCall(newCall);

                Console.WriteLine("Testing Add New Call to Call History");
                return testPhone.CallHistory.Contains(newCall);
            }

            public bool RemoveCallTest()
            {
                Phone testPhone = new Phone("s10", "Samsung", "Bob", 500m, null, null);
                Call newCall = new Call(15, DateTime.Parse("11/11 10 AM"));
                testPhone.AddCall(newCall);

                testPhone.RemoveCall(newCall);

                Console.WriteLine("Testing Removing A Call From Call History");
                return !testPhone.CallHistory.Contains(newCall);
            }

            public bool CalculateCallCostTest()
            {
                decimal expectedResult = 3.70m;
                Phone testPhone = new Phone("s10", "Samsung", "Bob", 500m, null, null);
                Call newCall = new Call(10, DateTime.Parse("11/11 10 AM"));
                testPhone.AddCall(newCall);

                decimal actualResult = testPhone.CalculateCalls(0.37m);

                Console.WriteLine("Testing Call Cost Calculation");
                return actualResult == expectedResult;
            }

        }

        static void TestGenericList()
        {
            GenericList<string> testList = new GenericList<string>(5);

            testList.AddItem("a");
            testList.AddItem("b");
            testList.AddItem("c");
            testList.AddItem("d");
            testList.AddItem("e");

            Console.WriteLine(testList.AccessByIndex(1));
            Console.WriteLine(testList.SearchByValue("b"));
            Console.WriteLine(testList);

            testList.AddItem("f");

            Console.WriteLine(testList);

            testList.InsertAtIndex(2, "3");
            testList.RemoveByIndex(0);

            Console.WriteLine(testList);
            
        }

        
        static void TestStudentClasses()
        {
            StudentTest studentTester = new StudentTest();

            StudentTest.CreateStaticStudents();
            StudentTest.PrintStaticStudents();
            //Console.WriteLine(studentTester.PrintStudentInfoTest());

        }

        static void TestPhone()
        {
            PhoneHistoryTest callTest = new PhoneHistoryTest();

            //Console.WriteLine(callTest.AddNewCallTest());
            //Console.WriteLine(callTest.RemoveCallTest());
            //Console.WriteLine(callTest.CalculateCallCostTest());
            //Phone.PrintNokia();
            

        }

        static void Main(string[] args)
        {
            //TestStudentClasses();
            //TestPhone();
            TestGenericList();
        }
    }
}
