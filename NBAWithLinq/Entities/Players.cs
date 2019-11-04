using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace NBAWithLinq.Entities
{
    public class Players
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public Position Position { get; set; }

        public override string ToString()
        {
            return Id
                + ", "
                + Name
                + ", "
                + Price.ToString("F2", CultureInfo.InvariantCulture)
                + ", "
                + Position.Name
                + ", "
                + Position.Tier;
        }
    }
}
