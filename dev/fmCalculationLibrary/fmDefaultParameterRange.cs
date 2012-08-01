namespace fmCalculationLibrary
{
    public class fmDefaultParameterRange : fmRange
    {
        public bool IsInputed { get; set; }

        public fmDefaultParameterRange()
        {
            IsInputed = false;
        }
        public fmDefaultParameterRange(double min, double max) : base(min, max) 
        {
            IsInputed = false;
        }
        public fmDefaultParameterRange (double min, double max, bool isInputed) : base(min, max)
        {
            IsInputed = isInputed;
        }
    }
}
