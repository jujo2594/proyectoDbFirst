using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class CityDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int IdstateFk { get; set; }
        public List<CustomerDto> Customers { get; set; }
    }
}