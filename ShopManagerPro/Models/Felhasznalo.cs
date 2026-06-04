using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagerPro.Models
{

    //public class Felhasznalo
    //{
    //    [PrimaryKey, AutoIncrement]
    //    public int Id { get; set; }

    //    public string FhNev { get; set; }
    //    public string Email { get; set; }
    //    public string PasswordHash { get; set; }

    //    public string TeljesNev { get; set; }

    //    public DateTime Keszitve { get; set; }


    //    public string Szerep { get; set; }

    //public Felhasznalo(string fhNev, string email, string passwordHash, string teljesNev, DateTime keszitve,  string szerep)
    //{
    //    FhNev = fhNev;
    //    Email = email;
    //    PasswordHash = passwordHash;
    //    TeljesNev = teljesNev;
    //    Keszitve = keszitve;
    //    Szerep = szerep;
    //}

    //public Felhasznalo()
    //{
    //    Keszitve = DateTime.Now;

    //}
    //public string SzerepkorNev => Enum.GetName(typeof(Szerepkorok), Szerep) ?? "Ismeretlen";
    //public override string ToString()
    //{
    //    return $"{TeljesNev}";
    //}
    public class Felhasznalo
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string FhNev { get; set; }
        public string TeljesNev { get; set; }
        public string Jelszo { get; set; }
        public int Szerepkor { get; set; }

        public Felhasznalo()
        {
        }

        public string SzerepkorNev => Enum.GetName(typeof(Szerepkorok), Szerepkor) ?? "Ismeretlen";


        public Felhasznalo(string fhNev, string teljesNev, string jelszo, int szerepkor)
        {
            FhNev = fhNev;
            TeljesNev = teljesNev;
            Jelszo = jelszo;
            Szerepkor = szerepkor;
        }
    }
}

