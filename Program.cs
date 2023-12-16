using System.Collections.Concurrent;

namespace Lab_2_Threads
{
    internal class Program
    {
        //Creates a ConcurrentDictionary where threads can all share and update value
        static ConcurrentDictionary<string, bool> winnerOrNot = new ConcurrentDictionary<string, bool>();
        static void Main(string[] args)
        {
            Car car1 = new Car("Reuben");
            Car car2 = new Car("Mimmi");

            DateTime startingTime = DateTime.Now;
            Thread thread1 = new Thread(() => RaceFunctions.StartRacing(car1, startingTime, winnerOrNot));
            Thread thread2 = new Thread(() => RaceFunctions.StartRacing(car2, startingTime, winnerOrNot));

            thread1.Start();
            thread2.Start();

            Console.WriteLine("Press ENTER to see status of the cars");

            //While loop to continue seeing status of cars as long as there are still cars in the race
            //By checking if ConcurrentDictionary is empty or if there is a winner
            while (winnerOrNot.IsEmpty || winnerOrNot.Values.Contains(true))
            {
                Console.ReadLine();
                Console.WriteLine($"{car1.Name} has speed {car1.Speed} and has driven {car1.DrivenLength:0.##} km.");
                Console.WriteLine($"{car2.Name} has speed {car2.Speed} and has driven {car2.DrivenLength:0.##} km.");
                Console.WriteLine();
            }

            thread1.Join();
            thread2.Join();
        }
    }
}
