using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mindterm_65011212068
{
    internal class ComboboxMyItems
    {
        public int value { get; set; }
        public string name { get; set; }
        public ComboboxMyItems(int value, string name)
        {
            this.value = value;
            this.name = name;
        }
        public override string ToString()
        {
            return name;
        }
    }
}
