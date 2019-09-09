using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Just_Do_It_12_Rabbit_Explosion
{
    class RealRabbit
    {
        public string Name;
        public int Age;
        public int MinBirthAge;
        public string DOB;
        public bool IsCanProduceTree;

        List<RealRabbit> rabbits;

        public RealRabbit()
        {
            Init("Bob", 0, 3, true);
        }

        public RealRabbit(string name, int age, int birth_age, bool IsCanProduceTree)
        {
            Init(name, age, birth_age, IsCanProduceTree);
        }

        private void Init(string name, int age, int birth_age, bool IsCanProduceTree)
        {
            rabbits = new List<RealRabbit>();
            this.Name = name;
            this.Age = age;
            this.MinBirthAge = birth_age;
            this.IsCanProduceTree = IsCanProduceTree;
        }

        private void Birthday()
        {
            Age++;
        }

        public void AttemptBirth(string name, int age, int birth_age, bool IsCanProduceTree)
        {
            Birthday();

            if (birth_age >= 0)
            {
                if (Age < MinBirthAge)
                    return;
            }

            if (this.IsCanProduceTree)
            {
                for (int i = 0; i < rabbits.Count; i++)
                    rabbits[i].AttemptBirth(name, age, birth_age, IsCanProduceTree);
            }

            var rabbit = new RealRabbit(name, 0, birth_age, IsCanProduceTree);
            rabbit.DOB = DateTime.Now.ToString();
            rabbits.Add(rabbit);
        }

        public int GetRabbitCount()
        {
            int total = 0;

            for (int i = 0; i < rabbits.Count; i++)
                total += rabbits[i].GetRabbitCount();

            return total + 1;//+1 for self
        }
    }
}
