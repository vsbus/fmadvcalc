namespace fmCalculationLibrary.MeasureUnits
{
    public struct fmUnit
    {
        private double coef;
        public double Coef
        {
            get { return coef; }
            set { coef = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value;}
        }
        private string name;

        public fmUnit(string name, double coef)
        {
            this.name = name;
            this.coef = coef;
        }
    }
}