﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw2.Models
{
    public interface ICommand
    {
        void Execute();
        void UnExecute();
    }
}
