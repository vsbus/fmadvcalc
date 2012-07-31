namespace fmCalculationLibrary
{
    public class fmRange
    {
        private double m_minValue;
        private double m_maxValue;
        
        public double MinValue
        {
            get { return m_minValue; }
            set { m_minValue = value; }
        }
        public double MaxValue
        {
            get { return m_maxValue; }
            set { m_maxValue = value; }
        }
        
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
