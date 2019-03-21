using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using Newtonsoft.Json;

namespace WcfService1
{
    public class BDDPreinscrit
    {
        public int id;
        public int IdPreinscrit;
        public string Nom;
        public string Prenom;
        public string Adresse;
        public int CodePostal;
        public string Ville;
        public string DateNaissance;
        public string Telephone;
        public string Email;
        public string Club;
        public string Ufolep;
    }
}