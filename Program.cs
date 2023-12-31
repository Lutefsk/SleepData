﻿// See https://aka.ms/new-console-template for more information
// ask for input
using System.Security.Cryptography.X509Certificates;

Console.WriteLine("Enter 1 to create data file.");
Console.WriteLine("Enter 2 to parse data.");
Console.WriteLine("Enter anything else to quit.");
// input response
string resp = Console.ReadLine();

if (resp == "1")
{
    // create data file
    // ask a question
    Console.WriteLine("How many weeks of data is needed?");
    // input the response (convert to int)
    int weeks = int.Parse(Console.ReadLine());
    // determine start and end date
    DateTime today = DateTime.Now;
    // we want full weeks sunday - saturday
    DateTime dataEndDate = today.AddDays(-(int)today.DayOfWeek);
    // subtract # of weeks from endDate to get startDate
    DateTime dataDate = dataEndDate.AddDays(-(weeks * 7));
    // random number generator
    Random rnd = new Random();
    // create file
    StreamWriter sw = new StreamWriter("data.txt");

    // loop for the desired # of weeks
    while (dataDate < dataEndDate)
    {
        // 7 days in a week
        int[] hours = new int[7];
        for (int i = 0; i < hours.Length; i++)
        {
            // generate random number of hours slept between 4-12 (inclusive)
            hours[i] = rnd.Next(4, 13);
        }
        // M/d/yyyy,#|#|#|#|#|#|#
    // Console.WriteLine($"{dataDate:M/d/yy},{string.Join("|", hours)}");
        sw.WriteLine($"{dataDate:M/d/yyyy},{string.Join("|", hours)}");        
        // add 1 week to date
        dataDate = dataDate.AddDays(7);
    }
    sw.Close();
}
else if (resp == "2")
{
    // TODO: parse data file
    string file = "data.txt";
    if (File.Exists(file))
 {
     StreamReader sr = new StreamReader(file);
     while (!sr.EndOfStream)
     {
       string line = sr.ReadLine();

       // TODO: Display sleep info
       string[] weeks = line.Split(",");
       if (weeks.Length >= 2)
       {
            DateTime date =  DateTime.Parse(weeks[0]);
            Console.WriteLine($"Week of {date:MMM} {date:dd}, {date:yyyy}");
            string[] sleepHoursStr = weeks[1].Split('|');

            if (sleepHoursStr.Length == 7)

            {
                Console.WriteLine($"--Su-- --Mo-- --Tu-- --We-- --Th-- --Fr-- --Sa--");

                for (int i = 0; i < 7; i++)
                {
                    Console.Write(sleepHoursStr[i].PadLeft(4) + "   ");
                }
                Console.WriteLine();            
            } 
       }
    }      
        sr.Close();
 }
        else        
            Console.WriteLine("File does not exist");
}   
