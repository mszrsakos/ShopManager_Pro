using SQLite;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ShopManagerPro.Models
{
    [Table("Termekek")]
    public class Termek
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Nev { get; set; }

        public decimal Ar { get; set; }

        public int Mennyiseg { get; set; }

        public string Marka { get; set; }

        public double Suly { get; set; } = 0;



        public Termek()
        {

        }

        public override string ToString()
        {
            return $"{Nev} - {Ar:N0} Ft";
        }
    }
}
