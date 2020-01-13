using System;
using System.Collections.Generic;
using System.Text;

namespace StarWarsApp.Models
{
    public class StarshipModel
    {
        public string Name { get; set; }
        public int Passengers { get; set; }
        public string[] Pilots { get; set; }
    }
}
