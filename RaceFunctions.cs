using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2_Threads
{
    internal static class RaceFunctions
    {
        //Method for starting the race for each car
        public static void StartRacing(Car car, DateTime startingTime, ConcurrentDictionary<string, bool> winnerOrNot)
        {
            Console.WriteLine($"{car.Name} has started the race!");

            double raceLenghtKm = 5;

            CarRacing(car, startingTime, raceLenghtKm);

            FinishingRace(car, winnerOrNot);
        }

        //Method for car's progress during race
        public static void CarRacing(Car car, DateTime startingTime, double raceLength)
        {
            DateTime timeSinceLastProblemTry = startingTime;

            while (car.DrivenLength < raceLength)
            {
                
                DateTime currentTime = DateTime.Now;
                double speedPerSecond = car.Speed / 3600;
                double timeRacing = (currentTime - startingTime).TotalSeconds;

                car.DrivenLength = speedPerSecond * timeRacing;

                if ((currentTime - timeSinceLastProblemTry).TotalSeconds >= 30)
                {
                    ProblemsOnTheWay.GenerateProblem(car);
                    timeSinceLastProblemTry = currentTime;
                }
            }
        }
        //Method to handle cars finishing race and print who won.
        public static void FinishingRace(Car car, ConcurrentDictionary<string, bool> winnerOrNot)
        {
            //Create a key with value true if key doesn't already exist to see which car wins
            //All other cars who comes after updates value to false
            winnerOrNot.AddOrUpdate("winner", true, (key, oldValue) => false);
            
            //ConcurrentDictionary only has one key, use if-statement to check if value is true ie winner
            if (winnerOrNot.Values.Contains(true))
            {
                Console.WriteLine($"{car.Name} won!");
            }
            else
            {
                Console.WriteLine($"{car.Name} finished second!");
            }
        }


    }

}
