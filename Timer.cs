using System;
using System.Diagnostics;
using System.IO;

namespace Project4
{
    internal class Timer
    {
        public static Stopwatch startTimer()
        {
            Console.WriteLine("A task starts now....");
            Stopwatch stopwatch = Stopwatch.StartNew();
            return stopwatch;
        }

        public static void timeResult(Stopwatch stopwatch)
        {
            stopwatch.Stop();
            long ticksPerMicrosecond = 1000000L;
            double duration = (double)stopwatch.ElapsedTicks * ticksPerMicrosecond / Stopwatch.Frequency;
            Console.WriteLine("Duration: " + duration + " Microseconds");
        }


        public static void timeResultTesting(string sortMethod, Stopwatch stopwatch, string timesFile)
        {
            stopwatch.Stop();
            long ticksPerMicrosecond = 1000000L;
            double duration = (double)stopwatch.ElapsedTicks * ticksPerMicrosecond / Stopwatch.Frequency;

            using (StreamWriter write = File.AppendText(timesFile))
            {
                write.WriteLine(sortMethod + duration);
            }
        }
    }
}
