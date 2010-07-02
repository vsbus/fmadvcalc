namespace fmCalculationLibrary
{
    public class fmRange
    {
        public bool isUnlimited;
        private double m_minValue;
        private double m_maxValue;
        
        public double minValue
        {
            get { return isUnlimited ? 0 : m_minValue; }
            set { m_minValue = value; }
        }
        public double maxValue
        {
            get { return isUnlimited ? 1e100 : m_maxValue; }
            set { m_maxValue = value; }
        }
        
        public fmRange(double min, double max)
        {
            isUnlimited = false;
            minValue = min;
            maxValue = max;
        }

        public fmRange()
        {
            isUnlimited = true;
        }
    }
}
