﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace sat_business.Providers
{
    public class BaseProvider
    {
        public string APIKey { get; set; }

        public BaseProvider(string APIKey)
        {
            this.APIKey = APIKey;
        }
    }
}
