using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Pokedex.Model
{
    public class Pokemon
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }
        public Type Type { get; set; }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }

    }
}
