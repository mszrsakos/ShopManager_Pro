using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagerPro.Models
{

        public class Felhasznalo
        {
            [PrimaryKey, AutoIncrement]
            public int Id { get; set; }

            public string FhNev { get; set; }
            public string Email { get; set; }
            public string PasswordHash { get; set; }

            public string TeljesNev { get; set; }

            public DateTime Keszitve { get; set; }

            public bool Aktiv { get; set; }

            public string Szerep { get; set; }

        public Felhasznalo(string fhNev, string email, string passwordHash, string teljesNev DateTime keszitve, bool aktiv, string szerep)
        {
            FhNev = fhNev;
            Email = email;
            PasswordHash = passwordHash;
            teljesNev = teljesNev;
            Keszitve = keszitve;
            Aktiv = aktiv;
            Szerep = szerep;
        }

        public Felhasznalo()
        {
            Keszitve = DateTime.Now;
            Aktiv = true;
        }
        public string SzerepkorNev => Enum.GetName(typeof(Szerepkorok), Szerep) ?? "Ismeretlen";
        public override string ToString()
        {
            return $"{TeljesNev}";
        }

    }
}
