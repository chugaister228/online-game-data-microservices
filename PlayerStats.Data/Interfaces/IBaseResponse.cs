﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayerStats.Data.Interfaces
{
    public interface IBaseResponse<T>
    {
        T Data { get; set; }
    }
}
