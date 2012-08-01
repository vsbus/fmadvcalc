namespace fmCalculationLibrary
{
    public class fmRange
    {
        public double MinValue { get; set; }

        public double MaxValue { get; set; }

        public fmRange(double min, double max)
        {
            MinValue = min;
            MaxValue = max;
        }

        public fmRange()
        {
            MinValue = 0;
            MaxValue = 1;
        }
    }
}
