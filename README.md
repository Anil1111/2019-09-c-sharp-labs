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
		
		
		
		
		
		
		
		
		
		
		

	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
