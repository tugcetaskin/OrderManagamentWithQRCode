using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOLayer.TableDTO
{
    public class CreateTableDTO
    {
        public string Name { get; set; }
        public bool Status { get; set; }
        public int TableFor { get; set; }
    }
}
