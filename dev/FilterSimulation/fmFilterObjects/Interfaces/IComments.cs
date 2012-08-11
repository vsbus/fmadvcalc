using System;
using System.Collections.Generic;
using System.Text;

namespace FilterSimulation.fmFilterObjects.Interfaces
{
    public interface IComments : IName
    {
        string GetComments();
        void SetComments(string comments);
    }

}
