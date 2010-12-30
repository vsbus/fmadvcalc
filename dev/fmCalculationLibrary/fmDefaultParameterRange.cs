using System;
using System.Collections.Generic;
using System.Text;

namespace fmCalculationLibrary
{
    public class fmDefaultParameterRange : fmRange
    {
        private bool m_inputed;
        public bool IsInputed
        {
            get { return m_inputed; }
            set { m_inputed = value; }
        }
        public fmDefaultParameterRange() : base()
        {
            m_inputed = false;
        }
        public fmDefaultParameterRange(double min, double max) : base(min, max) 
        {
            m_inputed = false;
        }
        public fmDefaultParameterRange (double min, double max, bool isInputed) : base(min, max)
        {
            m_inputed = isInputed;
        }
    }
}
