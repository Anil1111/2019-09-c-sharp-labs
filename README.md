# 2019-09-c-sharp-labs
Labs built and run while learning C#

## OOP Object Orientated Programming

Traditional computing has been LINEAR PROGRAMMING where code starts at line 1 and runs to the end

	OK but when GUI invented, screen objects appeared
	
		Button => Click (event) => Method (function) (event 'handler')
		
		OBJECT			EVENT				METHOD (CODE)
		
		
	Object looks like this
	
	{
		id:1,									field:value (key/value pairs)
		name:"bob"
		dob:"10/10/2001"
		likes: ["strawberries", "pizza"]
	
	}
	
	Array [1,2,3]
	
	String "some text"
	
		Whole number 	integer
		Decimal			float 32bits / double 64bits / decimal type 128bits
		
		Char 'f'
		

## Creating Basic Objects

Class = Template = Blueprint for creating an object

	class Mammal {
		int height;
		int weight;
		int length;
		string type;
	}
	
	var m01 = new Mammal();
	m01.height = 400;
	
	
## Method

Method = Function

	Call a Method to get something done
	
		Let's GROW OUR DOG
		
			Grow(){
			
				Age = Age + 1;
				Height = Height + 10;
			}
	
	
	```cs
	class Dog
    {
        public string Name;
        public int Age;
        public int Height;

        public void Grow()
        {
            Age = Age + 1;
            Height = Height + 10;
        }
    }
	```


## Private and Public fields

```cs

	class Program
    {
        static void Main(string[] args)
        {
            var person01 = new Person();
            person01.Name = "Fantasia";
            person01.setNINO("ABC123");

            Console.WriteLine(person01.GetNINO());
        }
    }

    class Person
    {
        private string NINO;
        public string Name;

        //Getter and Setter methods to read / write data
        public string GetNINO() { return NINO; }
        public void setNINO(string nino) { NINO = nino; }
    }

```


## Fields and Properties

In a class we can have
		
		fields		- tend to be private			private string NINO;
		
					- convention camelCase			private
		
		
		
		
		
```cs

class Program
    {
        static void Main(string[] args)
        {
            var rabbit = new Rabbit();
            rabbit.Name = "Cute01";
            rabbit.Age = 5;
            //
            //rabbit._bloodType...//invalid
        }
    }


    class Rabbit
    {
        private int _bloodType;//field
        private int _age;
        public string Name { get { return ""; } set {  } } //AUTO-IMPLEMENTED PROPERTY
        public int Age
        {
            get
            {
                return this.Age;
            }
            set
            {
                if (value > 0)
                    this._age = value;//value is c# keyword
            }
        }
    }
```


## Creating Multiple Objects

Array written [1,2,3] has FIXED SIZE

List written List<int>() has VARIABLE SIZE and we can use this to ADD items to a list

	//create a lab
	
	//count from 1 to 10
	
	//create rabbits
	
	//name = "Rabbit" + 0 + i   Rabbit01, Rabbit02
	//age = i;
	//add to list of rabbits
	//print out list at the end
	
	
```cs
    class Program
    {
        static void Main(string[] args)
        {
            // create a lab

            // count 1 to 10

            // create Rabbits

            // name = "Rabbit" + 0 + i    Rabbit01, Rabbit02,  
            // age = i
            // add to list of rabbits
            // print out list at end 


            List<Rabbit> rabbits = new List<Rabbit>();

            for(int i = 1; i <= 10; i++)
            {
                rabbits.Add(new Rabbit(String.Format("Rabbit{0:D2}", i), i));
            }

            for(int i = 0; i < 10; i++)
            {
                Console.WriteLine(rabbits[i].Name);
            }
        }
    }

    class Rabbit
    {
        public string Name { get; set; }
        public int Age { get; set; }

 
        public Rabbit(string name, int age)
        {
            Name = name;
            Age = age;
        }
    }
```


## Methods in more detail

	convention	name is PascalCase			void DoThis(){}
	parameters	passed IN					void DoThis(int x, string y){}
	return		passed OUT					string DoThis(){ return "hi"; }
	optional	passed IN					void DoThis(int x = 1000}
												//if 'x' is missing then x = 1000;
												
	out paramters pass OUT					void DoThis(int x, int y, out int z)
	
```cs
OutParamters(10, 10, out int a);
Console.WriteLine($"out parameter was {a}");
			
static void OutParamters(int x, int y, out int z)
{
	z = x * y;//will return this as 'z'
}
```
-------------------------------------------------------	

	Tuple is a fancy new variable from C#
		(int x, string y, bool z) is now a cutom data type!!
		
		
```cs
static (int x, string y, bool z) TupleMethod()
        {
            return (10, "hi", false);
        }
```
-------------------------------------------------------
												
```cs
    class Program
    {
        static void Main(string[] args)
        {
            DoThis();
            DoThisAswell();

            var mammal = new Mammal();
            mammal.GetOlder();

            //Method INSIDE method
            void DoThis()
            {
                Console.WriteLine("Do this...");
            }
        }

        static void DoThisAswell()
        {
            Console.WriteLine("Do this aswell...");
        }
    }

    class Mammal
    {
        public int Age { get; set; }
        public void GetOlder() { Age++; }
    }
```


## OOP Review

```cs
class MyClass{

	private field _y;
	
	public property z {get; set;}
	
	public void Method01(int param1, string param2, out string a, bool param4 = false){}
	
	(int x, string y) Tuple - on-the-fly data type
		
}
```

class			blueprint / template
instance		object created from a class
new				var instance01 = new MyCLass();		'new' calls a special method, 'constructor'
var				auto data-type
C#				Strongly typed : all types verified at COMPILE TIME
					Javascript		Loosely typed : data type NOT VERIFIED UNTIL RUNTIME
'dynamic'		keyword - turns data type same as Javascript
Constructor		first function called when object is created

```cs
            object o = 10;

            Console.WriteLine(o);
            Console.WriteLine(o.GetType());

            o = "a string";

            Console.WriteLine(o);
            Console.WriteLine(o.GetType());

            o = new int[1, 2, 3];

            Console.WriteLine(o);
            Console.WriteLine(o.GetType());



            dynamic obj2 = 10;

            Console.WriteLine(obj2);
            Console.WriteLine(obj2.GetType());

            obj2 = "a string";

            Console.WriteLine(obj2);
            Console.WriteLine(obj2.GetType());

            obj2 = new int[1, 2, 3];

            Console.WriteLine(obj2);
            Console.WriteLine(obj2.GetType());
```

## Naming

camelCaseLikeThis		private fields

PascalCaseLikeThis

	1) Method (Verb e.g. DoThis())
	2) Class names (Noun)
	3) Properties : public string Name{get; set;} Name is PascalCase
	
_privateField	underscore prefix : clearly tell everyone it's private

SQL_column_name_like_this_snake_case

File names and Folder names and Paths to folder

		C:\Parent\Child\file1.txt		Path
		
			Aoid spaces always
			
			"Strings with spaces always enclosed with quotes"
			
HTML-web-page-always-write-like-this-kebab-case.html

	%20 means some has put a space in html page (not good!)
	
	
## Constructor

```cs

Class MyClass{

	private string _NINO;
	public string MyName {get;set;}
	public string DateOfBirth {get;set;}
}

	//instantiate
	
	var myClass = new MyClass();	//new keyword : invoking (calling) a special method called the 'constructor'
	
									//CONSTRUCTOR : use it when constructing a new object

```
		

Constructors are not inherited





## Constructor summary

Constructors just help us to create new I?NSTANCES with MINIMUM of HARD WORK
They are NOT INHERITED
Default one is BLANK and is present initially. Must add it in if we create our own constructor.


## Overloading

Method01(){}

Method01(int x){}

Method01(string y){}

Method01(int x, string y){}



## Interviews

Interviews : favourite question
	
	What are the 4 pillars of OOP?
	
		1. Inheritance		Parent => Child\file	class Child : Parent{}
		2. Encapsulation	private keyword to hide NINO data / engineChassis
		3. Abstraction		Public Getter/Setter methods to access and manipulate private data
			
			Picture
			
				Driver			Accelerator Pedal				Encapsulated Combustion Engine
				
				
				driver is 'abstracted' away from engine by middle layer (accelerator pedal)
				
				instance		public get/set					private field
								 property
																

		4. Polymorphism
		
		
		
## Polymorphism
		
	Picture : Family
	
			Parents : virtual HaveAParty(){ //Invite friends : dinner party }
			
			Child5yrs : override HaveAParty() { //bouncy castle }
				override ==> child can optionally replace method with own version
			
			Child 10yrs : override HaveAParty() //Quasar
			
			Child18yrs : override HaveAParty //Evening out
		
		Minor side note : two keywords with similar uses here
			a) override
			b) new
		
		
```cs

	static void Main(string[] args)
	{
		var p = new Parent(40, "Bob");
		p.Add();
		p.Add();
		Console.WriteLine(p.GetDescriptions());

		var c = new Child(10, "Jimmy");
		c.Add();
		Console.WriteLine(c.GetDescriptions());
	}

    class Parent
    {
        public int Age;
        public string Name;

        public Parent() { }

        public Parent(int age, string name)
        {
            this.Age = age;
            this.Name = name;
        }

        public virtual void Add()
        {
            Age++;
        }

        public virtual string GetDescriptions()
        {
            return $"I am a PARENT and Number is: {Age} and Description is: {Name}";
        }
    }

    class Child : Parent
    {
        public Child(int age, string name) : base(age, name)
        {
        }

        public override void Add()
        {
            Age += 40;
            base.Add();
        }

        public override string GetDescriptions()
        {
            return $"I am a CHILD and I am now older than my parent: Age is: {Age} and Name is: {Name}";
        }
    }

```


## Rabbit Explosion

```cs

class Rabbit{
	string Name;
	int Age;
}

```

List<Rabbit> rabbits;

Thread.Sleep(200);	//1.5 secs

Loop

Every loop, create new rabbit and add to list of rabbits

Set population limit and see how many iterations it takes to reach populaion limit

This will be version 1 and will be a LINEAR RELATIONSHIP EG 50 iterations to reach


## Rabbit explosion Version 2

Let us now model real world growth where the population of rabbits can increase exponentially










## Working with Files

```cs
Console.WriteLine("\n\n ======  save on multiple lines =======");
File.WriteAllText("multipleLines.txt", "some\ndata\non\ndifferent\nlines");
Console.WriteLine(File.ReadAllText("multipleLines.txt"));

Console.WriteLine("\n\n ======  save on multiple lines better way =======");
File.WriteAllText("multipleLines2.txt", "some" + Environment.NewLine + "data" + Environment.NewLine + "on" +
	Environment.NewLine + "different" + Environment.NewLine + "lines");
Console.WriteLine(File.ReadAllText("multipleLines2.txt"));

Console.WriteLine("\n\n ======  save arrays to multiple lines =======");
string[] myArray = new string[] { "some", "data", "in", "multiple", "lines" };
File.WriteAllLines("multiLineFile.txt", myArray);
var outputArray = File.ReadAllLines("multiLineFile.txt");
Array.ForEach(outputArray, item => Console.WriteLine(item));

Console.WriteLine("\n\n ======  Logging =======");

for (int i = 0; i < 10; i++)
{
	File.AppendAllText("myLogFile.log", $"Event happened at time {DateTime.Now}" + Environment.NewLine);
	Console.WriteLine($"Logged {i} lines");
	System.Threading.Thread.Sleep(300);
}
Console.WriteLine(File.ReadAllText("myLogFile.log"));
```
		
## Stopwatch

```cs

var s = new Stopwatch();

Console.WriteLine("Stopwatch started...");
s.Start();

int counter = 0;
for (int i = 0; i < 100_000_000; i++)
	counter++;

s.Stop();
Console.WriteLine("Stopwatch stopped...");
Console.WriteLine(s.Elapsed);
Console.WriteLine(s.ElapsedMilliseconds);
Console.WriteLine(s.ElapsedTicks);
```


## Rabbit Tests

Let's add some tests to our Rabbit Explosion app

```cs

public void TestRabbitExplosion(int populationLimit, int expectedYears)
{
	//arrange

	//act
	var actualYears = lab_just_do_it_rabbit_explosion.Rabbit_Exponentional_Growth(populationLimit);
	Assert.AreEqual(expectedYears, actualYears.years);
	//
}
		
```


# OOP Continued

## Abstract Classes

So far we have

class Mercedes{
	private int _privateField;		//field
	
	public string Name {get;set;}	//property (Public, provides the Abstraction layer in OOP 4 pillars)
	
	public void DoThis(){}			//method
	
	public Mercedes(){}				//constructor
}

var instance = new Mercedes(); //instance = new object from class

a normal class is called a 'CONCRETE' class because we can create REAL OBJECTS (INSTANCES) from it

## Mind picture for Abstract Classes

Think about a holiday in planning

	abstract class Holiday{
		
		public /* abstract */ void TravelPlans(){}
		
		public void PlacesToVisit(){ cw("This list is now complete"); }
		
		public void Activities(){ cw("All activities all planned out"); }
					
								 |---- CODE IMPLEMENTATION -------------|
	}
	
	One method has NO CODE IMPLEMENTATION (NO CODE 'BODY')
	
		This method is 'ABSTRACT' because it exists but has no code implementation
		
			public abstract void TravelPlans();
	
	
	Solution is to derive a SUB-CLASS and INHERIT from ABSTRACT class
		
		PARENT : ABSTRACT		public abstract void TravelPlans();
		
		CHILD :					public override void TravelPlans(){}
		
```cs
class Program
{
	static void Main(string[] args)
	{
		var h = new HolidayWithTravel();
		h.Travel();
	}
}

abstract public class Holiday
{
	public abstract void Travel();

	public void Places() { Console.WriteLine("Visiting Vienna, Salzburg"); }

	public void Activities() { Console.WriteLine("Skiiing, Walking, Fishing"); }
}

public class HolidayWithTravel : Holiday
{
	public override void Travel() { Console.WriteLine("By Train, Eurostar, then hire a car"); }
}
```
	
## Sealed Classes

When dealing with security, it might not be a good idea that people can inherit from a secure class but then introduce vulnerabilities.

Think car engine : seal inside secure chassis so amateurs don't mess up the engine and cause accidents.

Think CPU : discourage overclocking

public sealed class Security{

}

//class CannotInherit : Security { }

//cannot inherit from sealed classes

## Extending a Sealed Class

string is a sealed class with lots of methods like this one
string s = "hello world";

```cs
if (s.StartsWith("hello"))
{
	Console.WriteLine("world");
}
```

Imagine we want our own custom string method

Let's build one

```cs
public static class AddingToStrings{
	public static void AmazingExtraStringMEthod(this string s){
		s = s + "--->add your comment";
	}
}
```


```cs
static void Main(string[] args)
{
	string s = "hello world";
	if (s.StartsWith("hello"))
	{
		Console.WriteLine("world");
	}

	Console.WriteLine(s.AmazingExtraStringMethod());
}
			
			
public static class AddingToStrings
{
	public static string AmazingExtraStringMethod(this string s)
	{
		s = s + "---> add your comment";
		return s;
	}

	public static string AmazingExtraStringMethod(this HolidayWithTravel s)
	{
		return "---> add your comment";
	}
}
```



# WPF application

With this course we are going to have 3 areas of learning
	
	CONSOLE	: MOST OF LEARNING HERE!! CORE WORK
	
	WPF		: SCREEN WHICH CAN PLACE OBJECTS EG : CRUDE APP
	
				GOAL 1) BUSINESS INTERFACE
					 2) CANVAS : SIMPLE IMAGES FOR GAME (CRUDE)
					 
			 ((WINDOWS FORMS WERE BEFORE WPF))
					 
	WEBSITES : FOCUS ON BUSINESS STYLE APPLICATION
				FUNCTIONING DATA ETC
					A) ASP REGULAR WEBSITE
					B) MVC WEBSITE
					
					
WPF Windows Presentation Foundation

	xml skeleton for GUI
	C# code behind
	
		XML is a TEXT FILE into which we can put MEANINGFUL, STRUCTURED DATA
			Extensible Markup Language
			
			<root>
				<row>
				<col attributes="dataherealso">data</col>
				</row>
				<row>
				<col attributes="dataherealso">data</col>
				</row>
				<row>
				<col attributes="dataherealso">data</col>
				</row>
			
			</root>
			
		Microsoft LOVE XML.
		
		Everyone else loves JSON.

	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
