// Copyright (C) TBC Bank. All Rights Reserved.

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using System.Xml.Linq;

namespace ItAcademy.Persistence
{
    public class ApplicationUser : IdentityUser
    {
            [Display(Name = "FullName")]
            public string FullName { get; set; }
    }
}
