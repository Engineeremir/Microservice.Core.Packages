﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservice.Core.Packages.Application.Requests;

public class PageRequest
{
    public int Page { get; set; }
    public int PageSize { get; set; }
}
