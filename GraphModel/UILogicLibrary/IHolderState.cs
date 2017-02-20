using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UILogicLibrary
{
    public interface IHolderState
    {
        AbstractState State
        {
            get; set;
        }
    }
}
