using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Männel
{
    class Program
    {

        async static Task Main(string[] args)
        {
            Console.WriteLine("Soll ich dir Winken, dann gib W ein. Soll ich laufen, dann gib einen Buchstaben außer W/w ein.");
            if (Console.ReadLine().ToLower() == "w")
            {
                var input = string.Empty;
                while (input != "a")
                {
                    var winkerCancler = new CancellationTokenSource();
                    Task.Run(async () => await SetUpWinken(winkerCancler.Token));
                    Console.WriteLine("Drücke a um abzubrechen");
                    input = Console.ReadKey().KeyChar.ToString();
                    if(input == "a")
                    {
                        winkerCancler.Cancel();
                    }
                }
            }
            else
            {
                var splitedHumannormal = LoadArt4().Split(Environment.NewLine);
                for (int i = 0; i < 100; i++)
                {
                    await SetCourser(i, 0, splitedHumannormal);
                }

            }
            Console.ReadLine();
        }
        private async static Task SetCourser(int left, int top, string[]splitedHuman)
        {
            foreach (var humanPart in splitedHuman)
            {
                Console.SetCursorPosition(left, top);
                Console.Write(humanPart);
                top += 1;
            }

            await Task.Delay(1000 / 30);
        }
        public async static Task SetUpWinken(CancellationToken cancellationToken)
        {
            var splitedHumanrechts = LoadArt3().Split(Environment.NewLine);
            var splitedHumanmitte = LoadArt2().Split(Environment.NewLine);
            var splitedHumanlinks = LoadArt1().Split(Environment.NewLine);
            while(!cancellationToken.IsCancellationRequested)
            {
                for (int i = 0; i < 4; i++)
                {
                    if (i % 4 == 0)
                    {
                        Winken(splitedHumanlinks);
                    }
                    else if (i % 4 == 1 || i % 4 == 3)
                    {
                        Winken(splitedHumanmitte);
                    }
                    else if (i % 4 == 2)
                    {
                        Winken(splitedHumanrechts);

                    }
                }                
            }
        }

        private static void Winken(string[] human)
        {
            var top = 5;
            foreach (var humanPart in human)
            {
                Console.SetCursorPosition(0, top);
                Console.Write(humanPart);
                top++;
            }
            Thread.Sleep(1000 / 4);
        }
        public static string LoadArt1()
        {
            string path1 = @"Männel V2\Männel Idel links.txt";
            string humanlinks = File.ReadAllText(path1);
            return humanlinks;
        }

        public static string LoadArt2()
        {

            string path2 = @"Männel V2\Männel Idel mitte.txt";
            string humanmitte = File.ReadAllText(path2);
            return humanmitte;

        }

        public static string LoadArt3()
        {

            string path3 = @"Männel V2\Männel Idel rechts.txt";
            string humanrechts = File.ReadAllText(path3);
            return humanrechts;
        }
        public static string LoadArt4()
        {
            string path4 = @"Männel V2\Männel Idel Normal.txt";
            string humannormal = File.ReadAllText(path4);
            return humannormal;
        }

    }








}
