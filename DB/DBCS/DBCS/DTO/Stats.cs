using DBCS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBCS.DTO
{
    class Stats
    {
        public Dictionary<Facultate, List<StudentM>> Studenti { get; set; }

    }
}
