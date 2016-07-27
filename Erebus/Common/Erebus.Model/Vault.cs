﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erebus.Model
{
    public class Vault : PersistableObject
    {
        public virtual ICollection<Group> Groups { get; set; }
    }
}