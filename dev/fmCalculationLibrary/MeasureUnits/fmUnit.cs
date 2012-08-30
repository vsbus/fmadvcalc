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

        private string m_name;
        public string Name
        {
            get { return m_name; }
            set { m_name = value;}
        }

        private bool m_isUS;
        public bool IsUs
        {
            get { return m_isUS; }
            set { m_isUS = value; }
        }

        public fmUnit(string name, double coef)
        {
            m_name = name;
            m_coef = coef;
            m_isUS = false;
        }

        public fmUnit(string name, double coef, bool isUS)
        {
            m_name = name;
            m_coef = coef;
            m_isUS = isUS;
        }
    }
}