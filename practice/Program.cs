
// Using System;

//     class Student
//     {
//         public string name;
//         public int age;

//         void dispaly()
//         {Console.WriteLine("Name: " + name);
//         Console.WriteLine("Age: " + age);}
//     }



// class MyProgram
// {
//     public static void Main(string[] args)
//     {
//         Student s1 = new Student();
//         s1.name = "Aastha";
//         s1.age = 21;
//         s1.display();
//     }
// }


// using System;


//     class MyProgram
//     {
//         public class Car
//     {
//         private int id;
//         private string name;


//         public Car(int a, string b)
//         {
//             Id = a;
//             Name = b;
//         }


//         public int Id
//         {
//             get{
//                 return id;
//             }       

//          set{
//                 if (Value > 0)
//                 {
//                     id = Value;
//                 }
//             }
//         }

//         public string Name
//         {
//             get{
//                 return name;
//             } 

//             set{
//                 if (Value != "")
//                 {
//                     name = Value;
//                 }
//             }
//         }

//     }
//     }



// using System;
// class Person
// {
//     private int age;

//     public Person(int a)
//     {
//         Age = a;
//     }

//     public int Age
//     {
//         get{ return age;}
//         set
//         {
//             if(value > 0)
//             {
//                 age = value;
//             }
//         }
//     }

//     public void display()
//     {
//         Console.WriteLine("Age:" +Age);
//     }
// }


// class MyProgram
// {
//     public static void Main(string[] args)
//     {
//         Person p1 = new Person(25);

//         p1.display();

//     }
// }


// using System;
// class BankAccount
// {
//     private double balance =0;



//     public void deposit(double b)
//     {
//         if(b > 0)
//         {
//             this .balance += b;
//         }
//         Console.WriteLine("Balance: " + balance);

//     }

//     public void withdraw(double b)
//     {
//         if(b > 0 && b <= balance)
//         {
//             balance -= b;
//         }
//         Console.WriteLine("Balance: " + balance);

//     }
// }

// using System;
// class BankAccount
// {
//     private double balance ;

//     public double Balance
//     {
//         get{return balance;}
//         set{balance = value;}
//     }
//     public BankAccount(double b)
//     {
//         if (b >= 0)
//         {
//             Balance = b;
//         }
//     }

//     public void deposit(double b)
//     {
//         if (b >= 0)
//         {
//             Balance += b;
//         }
//         Console.WriteLine("Balance: " + Balance);
//     }

//     public void Withdraw(double b)
//     {
//         if (b >= 0 && b <= Balance)
//         {
//             Balance -= b;
//         }
//         Console.WriteLine("Balance: " + Balance);
//     }
// }
// class MyProgram
// {
//     public static void Main(string[] args)
//     {
//         BankAccount account = new BankAccount(100);
//         account.deposit(1000);
//         account.Withdraw(500);
//     }
// }



// using System;
// class Student
// {
//     private int id;
//     private string name;


//     public int Id
//     {
//         get{return id;}
//         set
//         {
//             if (value < 0)
//             {
//                 Console.WriteLine("Not accepted");
//             }
//             else
//             {
//                 id = value;
//             }
//         }
//     }
//     public string Name
//     {
//         get{return name;}
//         set
//         {
//             if(value == "")
//             {
//                 Console.WriteLine("Not accepted");
//             }
//             else
//             {
//                 name = value;
//             }
//         }
//     }

//     public void display()
//     {
//         Console.WriteLine("ID: " + Id);
//         Console.WriteLine("Name: " + Name);
//     }
// }


// class MyProgram
// {
//     public static void Main(string[] args)
//     {
//         Student s1 = new Student(101, "Aastha");

//         s1.display();
//     }
// }



// using System;
// class Cart
// {
//     private double totalPrice;

//     public double TotalPrice
//     {
//         get{return totalPrice;}

//     }
//     public void AddItem(double price)
//     {
//         if(price > 0)
//         {
//             totalPrice += price;
//         }
//         Console.WriteLine("Total Price: " + totalPrice);
//     }
//     public void RemoveItem(double price)
//     {
//         if(price >0 && price <= totalPrice)
//         {
//             totalPrice -= price;
//         }
//         Console.WriteLine("Total Price: " + totalPrice);
//     }
// }

// class MyProgram
// {
//     public static void Main(string[] args)
//     {
//         Cart cart = new Cart();
//         cart.AddItem(100);
//         cart.AddItem(200);

//         cart.RemoveItem(50);

//     }
// }




// class Student
// {
//     private int marks;
//     public string name;

//     public Student(int m,string n)
//     {
//         if (m >= 0)
//         {
//             marks = m;
//         }
//         else
//         {
//             marks =0;
//         }

//         name = n;

//     }

//     public void setmarks(int m)
//     {
//         if (m >= 0)
//         {
//             marks = m;
//         }
//     }
//     public int getmarks()
//     {
//         return marks;
//     }

//     public void checkresult()
//     {
//         if (marks >= 50)
//         {
//             Console.WriteLine("pass");
//         }
//         else
//         {
//             Console.WriteLine("fail");
//         }
//     }
// }

// class MyProgram
//     {
//         public static void Main()
//         {
//             Student s1 = new Student(-89, "Aastha");
//             Console.WriteLine(s1.name);
//             Console.WriteLine(s1.getmarks());
//         }
//     }


// class Vehicle
// {
//     public void Start()
//     {
//         Console.WriteLine("vehicle started");
//     }
// }

// class Car : Vehicle
// {
//     public void Drive()
//     {
//         Console.WriteLine("car is driving");
//     }
// }

// class MyProgram
// {
//     public static void Main()
//     {
//         Car c1 = new Car();
//        c1.Start();
//         c1.Drive();
//     }
// }


// class Shape
// {
//     public virtual void Area()
//     {
//         Console.WriteLine("areaaa");
//     }
// }

// class Circle : Shape
// {
//     public override void Area()
//     {
//         Console.WriteLine("Area");
//     }
// }
// class Rectangle : Shape
// {
//     public override void Area()
//     {
//         Console.WriteLine("Areaa");
//     }
// }




//move all zeros to end
using System.Globalization;

// class Program
// {
//     public static void MoveZero(int[] nums)
//     {
//         int j =0;
//         for(int i = 0; i < nums.Length; i++)
//         {
//             if(nums[i] != 0)
//             {
//                 nums[j] = nums[i];
//                 j++;
//             }
//         }

//         while (j < nums.Length)
//         {
//             nums[j] = 0;
//             j++;
//         }
//     }

//     public static void Main()
//     {
//         int[] nums = {1,0,2,0,3,0};

//         MoveZero(nums);
//         foreach(int num in nums)
//         {
//             Console.Write(num +" ");
//         }
//     }
// }

//First non-repeating Character in a string


using System;
using System.Collections.Generic;

// class Program
// {
//     public static char f(string s)
//     {
//         Dictionary<char,int>freq = new Dictionary<char, int>();

//         foreach(char ch in s)
//         {
//             if (freq.ContainsKey(ch))
//             {
//                 freq[ch]++;
//             }
//             else
//             {
//                 freq[ch]=1;
//             }
//         }

//         foreach(char ch in s)
//         {
//             if(freq[ch] == 1)
//             {
//                 return ch;
//             }
            
//         }
//         return '$';
//     }

//     public static void Main()
//     {
//         string s = "abcabcde";
//         char ans = f(s);
//         Console.WriteLine(ans);

//     }
// }


//Palindrome check

// class Program
// {
//     static bool f(string s)
//     {
//         int i =0;
//         int j = s.Length-1;
//         while (i < j)
//         {
//             if (s[i] != s[j])
//             {
//                 return false;
//             }
//             else
//             {
//                 i++;
//                 j--;
//             }
//         }
//         return true;
//     }

//     static void Main()
//     {
//         string s = "abcda";
//         bool ans = f(s);
//         Console.WriteLine(ans);
//     }
// }


//Remove Duplicates from strings
// class Program
// {
//     static string f(string s)
//     {
//         HashSet<char> str = new HashSet<char>();
//         string result =" ";


//         foreach(char ch in s){
//             if (!str.Contains(ch))
//             {
//                 str.Add(ch);
//                 result += ch;
//             }
//         }
//         return result;
//     }

//     static void Main()
//     {
//         string s = "aabbccde";
//         string ans = f(s);
//         Console.WriteLine(ans);
//     }
// }



