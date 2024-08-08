using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOLayer.TableDTO
{
    public class GetTableDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }
        public int TableFor { get; set; }
    }
}
