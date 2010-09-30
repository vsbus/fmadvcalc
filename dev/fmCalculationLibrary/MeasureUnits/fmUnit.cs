namespace fmCalculationLibrary.MeasureUnits
{
    public struct fmUnit
    {
        private double m_coef;
        public double Coef
        {
            get { return m_coef; }
            set { m_coef = value; }
        }
        public string Name
        {
            get { return m_name; }
            set { m_name = value;}
        }
        private string m_name;

        public fmUnit(string name, double coef)
        {
            m_name = name;
            m_coef = coef;
        }
    }
}