﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorFullStackCrud.Shared
{

    public class Transaction
    {
        public string? FromAddress { get; set; }
        public string? ToAddress { get; set; }
        public int Amount { get; set; }
    }
}
