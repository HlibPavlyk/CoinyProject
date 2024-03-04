﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinyProject.Core.Domain.Entities
{
    public  class UserRole
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual User User { get; set; }

    }
}