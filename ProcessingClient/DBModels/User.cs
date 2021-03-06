﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmulationProcessing.dbmodels
{
    [Table("Users")]
    class User
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime Created { get; set; }

        public DateTime Updated { get; set; }

        public virtual ICollection<AccessProvider> AccessProvider { get; set; }

    }
}
