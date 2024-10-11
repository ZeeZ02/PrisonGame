using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrisonGame
{
    public class PrintLoopedLists
    {
        public static List<string> Run(List<Box> boxes)
        {
            List<string> loopList = new List<string>();
            foreach (Box box in boxes)
            {
                if (!box.taken)
                {
                    Box currentBox = box;
                    bool breakLoop = false;
                    string listedloopString = $"{currentBox.number} -> ";
                    var startnumber = box.number;
                    currentBox.taken = true;
                    //Box nextBox = boxes.Single(x => x.number == box.numberInside);
                    do
                    {



                        //Select the next box where the numberInside is equal to the number
                        Box nextBox = boxes.Single(x => x.number == currentBox.numberInside);

                        if (nextBox.number != startnumber)
                        {


                            listedloopString += $"{nextBox.number} -> ";
                            nextBox.taken = true;
                            currentBox = nextBox;
                        }
                        else
                        {
                            breakLoop = true;
                            listedloopString += $"{nextBox.number}";
                        }
                    }
                    while (!breakLoop);

                    loopList.Add(listedloopString);

                }
            }

            //TODO make somehting cool before return. 

            return loopList;

        }

    }
}
