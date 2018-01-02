using MusicTheorySDK.Utils;

namespace MusicTheorySDK.Core
{
    public class Interval
    {
        //for now, each step is a semitone
        public int Steps { get; set; }
        public Intervals Name { get { return GetIntervalName(); } }
        public Interval(int semitones)
        {
            Steps = semitones;
        }

        private Intervals GetIntervalName()
        {
            Intervals intervalName = Intervals.PerfectUnison;
            switch(Steps)
            {
                case 1:
                    intervalName = Intervals.MinorSecond;
                    break;
                case 2:
                    intervalName = Intervals.MajorSecond;
                    break;
                case 3:
                    intervalName = Intervals.MinorThird;
                    break;
                case 4:
                    intervalName = Intervals.MajorThird;
                    break;
                case 5:
                    intervalName = Intervals.PerfectFourth;
                    break;
                case 6:
                    intervalName = Intervals.AugmentedFourth;
                    break;
                case 7:
                    intervalName = Intervals.PerfectFifth;
                    break;
                case 8:
                    intervalName = Intervals.MinorSixth;
                    break;
                case 9:
                    intervalName = Intervals.MajorSixth;
                    break;
                case 10:
                    intervalName = Intervals.MinorSeventh;
                    break;
                case 11:
                    intervalName = Intervals.MajorSeventh;
                    break;
                case 12:
                    intervalName = Intervals.PerfectOctave;
                    break;
            }
            return intervalName;
        }
    }
}
