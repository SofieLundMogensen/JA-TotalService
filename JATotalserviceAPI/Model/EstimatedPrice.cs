using System;
using System.Collections.Generic;
using System.Text;

namespace ModelLayer
{
    public class EstimatedPrice
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int estimatedTime { get; set; }
        public List<Tuple<Material, int>> materials { get; set; }
    }
}
