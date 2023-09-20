using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeFriend
{
    internal class CoffeQueue
    {

        private Queue<Person> coffeQue = new Queue<Person>();


        //Add person to the queue
        public void Enqueue(Person person)
        {
            coffeQue.Enqueue(person);
        }

        //Removes the first person in the quue
        public Person Dequeue()
        {
            return coffeQue.Dequeue();
        }

        public void Rotate()
        {
            if(coffeQue.Count > 1)
            {
                var firstPerson = coffeQue.Dequeue();
                coffeQue.Enqueue(firstPerson);
            }
        }

        public override string ToString()
        {
            return string.Join(", ", coffeQue);
        }
    }
}
