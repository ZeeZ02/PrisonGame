using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PrisonGame
{
    public class Game
    {
        private Random rng = new Random();
        public bool GameStart()
        {
            List<Prisoner> prisoners = new List<Prisoner>();

            for (int i = 1; i <= 100; i++)
            {
                Prisoner prisoner = new Prisoner(i);
                prisoners.Add(prisoner);
            }

            //foreach (var prisoner in prisoners)
            //{
            //    Console.WriteLine(prisoner.prisonerNumber);
            //}

            List<Box> boxes = new List<Box>();

            for (int i = 1; i <= 100; i++)
            {
                Box box = new Box(i);
                boxes.Add(box);
            }

            ////Insert random numbers into the boxes. Uniq numbers form 1 to 100 into each. 
            //Random rand = new Random();
            //var ints = Enumerable.Range(1, 100)
            //    .Select(i => new Tuple<int, int>(rand.Next(101), i))
            //    .OrderBy(i => i.Item1)
            //    .Select(i => i.Item2).ToList();

            List<int> ints = Enumerable.Range(1, 100).ToList();

            int n = ints.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                int value = ints[k];
                ints[k] = ints[n];
                ints[n] = value;
            }

            int numberCount = 0;
            foreach (Box box in boxes)
            {
                box.numberInside = ints[numberCount];
                numberCount++;
            }

            /*
            Console.WriteLine("Unorder list");
            int numberRow = 1;
            foreach (var intNumber in ints)
            {
                Console.WriteLine(numberRow + ": " + intNumber.ToString());
                numberRow++;
            }
            */

            //Console.WriteLine("Orderd List");
            //ints.Sort();
            //int numberRow = 1;
            //foreach (var intNumber in ints)
            //{
            //    Console.WriteLine(numberRow + ": " + intNumber.ToString());
            //    numberRow++;
            //}

            //var numberofboxes = boxes.Count;
            //var numberofints = ints.Count;
            //var intshoundred = ints[100];
            //var numberofboxes2 = boxes[100];

            for (int i = 1; i < boxes.Count; i++)
            {
                boxes[i].numberInside = ints[i];
            }
            /*
            Console.WriteLine("What number are in the boxes:");
            foreach (var box in boxes)
            {
                Console.WriteLine("Box number " + box.number + " has the number " + box.numberInside);
            }
            */



            var returnList = PrintLoopedLists.Run(boxes);

            foreach (var list in returnList)
            {
                Console.WriteLine(list.ToString());
            }

            Console.WriteLine($"The are {returnList.Count} number of loops");
            Console.WriteLine($"\n");
            var longestLoop = returnList.OrderByDescending(S => S.Length).First();
            int numbersInLoop = Regex.Matches(longestLoop, "->").Count();
            Console.WriteLine($"The longest loop is {longestLoop}\n which is {numbersInLoop++} numbers long");
            Console.WriteLine($"");

            if( numbersInLoop > 50 )
            {
                Console.WriteLine("The prisoner did NOT find his number");
                return false;
            }
            else
            {
                Console.WriteLine("The prisoner DID find his number");
                return true;
            }

            
        }
    }
}
