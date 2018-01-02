using MusicTheorySDK.Core;
using System;
using System.Collections.Generic;

namespace MusicTheorySDK.Utils
{
    public class IntervalFactory
    {
        public static List<Interval> CreateIntervals(string input)
        {
            string[] intervalStrings = input.Split(new char[] { ',', ' ', '\t', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            int[] intervals = new int[intervalStrings.Length];
            for (int i = 0; i < intervalStrings.Length; i++)
            {
                int parsedResult;
                if (Int32.TryParse(intervalStrings[i], out parsedResult))
                {
                    intervals[i] = parsedResult;
                }
            }
            return CreateIntervals(intervals);
        }

        public static List<Interval> CreateIntervals(int[] intervalValues)
        {
            List<Interval> intervals = new List<Interval>();
            foreach (int intervalValue in intervalValues)
            {
                intervals.Add(new Interval(intervalValue));
            }
            return intervals;
        }
    }
}
