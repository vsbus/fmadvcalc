using System;
using FilterSimulation.fmFilterObjects;

namespace FilterSimulation
{
    public partial class fmFilterSimulationControl
    {
        static public fmFilterSimSuspension GetFirstChild(fmFilterSimProject prj)
        {
            return fmCurrentObjectsStruct.GetFirstChild(prj);
        }
        static public fmFilterSimSerie GetFirstChild(fmFilterSimSuspension sus)
        {
            return fmCurrentObjectsStruct.GetFirstChild(sus);
        }
        static public fmFilterSimulation GetFirstChild(fmFilterSimSerie serie)
        {
            return fmCurrentObjectsStruct.GetFirstChild(serie);
        }
    }
}