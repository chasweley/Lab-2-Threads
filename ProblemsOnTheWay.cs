using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2_Threads
{
    //Class for problems that the car can have when racing
    internal static class ProblemsOnTheWay
    {
        //Methods to pause driving for a specified time depending on problem
        public static void EmptyGas(Car car)
        {
            Console.WriteLine($"{car.Name} ran out of gas, stopping for 30 seconds!");
            Thread.Sleep(30000);
        }
        public static void FlatTire(Car car)
        {
            Console.WriteLine($"{car.Name} got a flat tire, stopping for 20 seconds!");
            Thread.Sleep(20000);
        }

        public static void BirdOnWindShield(Car car)
        {
            Console.WriteLine($"{car.Name} hit a bird and need to wash their wind shield, stopping for 10 seconds!");
            Thread.Sleep(10000);
        }

        public static void EngineFailure(Car car)
        {
            car.Speed--;
            Console.WriteLine($"{car.Name} is having an engine failure and is slowing down... The speed is now {car.Speed}.");
        }

        //Method to randomly give car problem, each problem has different probability of happening
        public static void GenerateProblem(Car car)
        {
            Random random = new Random();
            int randomNr = random.Next(1, 51);

            //Probability 1/50
            if (randomNr == 1)
            {
                EmptyGas(car);
            }
            //Probability 2/50
            else if (randomNr <= 3)
            {
                FlatTire(car);
            }
            //Probability 5/50
            else if (randomNr <= 8)
            {
                BirdOnWindShield(car);
            }
            //Probability 10/50
            else if (randomNr <= 18)
            {
                EngineFailure(car);
            }
        }
    }
}
