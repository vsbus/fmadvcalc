using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using fmCalculationLibrary;

namespace FilterSimulation
{
    public partial class ParameterIntervalItem : UserControl
    {
        public ParameterIntervalItem()
        {
            InitializeComponent();
        }

        public fmValue MaxValue
        {
            get
            {
                return fmValue.StringToValue(maxValueTextBox.Text);
            }
        }

        public fmValue MinValue
        {
            get
            {
                return fmValue.StringToValue(minValueTextBox.Text);
            }
        }

        public string ParameterName
        {
            get{return parameterLabel.Text;}
            set{parameterLabel.Text = value;}
        }
    }
}
