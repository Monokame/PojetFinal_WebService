using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;

namespace WcfService1
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "Service1" dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez Service1.svc ou Service1.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public class Service1 : IService1
    {
        public string Insert(BDDPreinscrit bddpreinscrit)
        {
            BDDPreinscrit preinscrit = new BDDPreinscrit();
            return preinscrit.Insert(bddpreinscrit);
        }
        public string InsertXbee(BDDXbee bddxbee)
        {
            BDDXbee xbee = new BDDXbee();
            xbee.InsertXbee(bddxbee);
        }
        public string InsertAlerte(BDDAlerte bddalerte)
        {
            BDDAlerte alerte = new BDDAlerte();
            alerte.InsertAlerte(bddalerte);
        }

        public string InsertValidation(BDDValidation bddvalidation)
        {
            BDDValidation validation = new BDDValidation();
            validation.InsertValidation(bddvalidation);
        }

        //******SELECT******//

        public List<BDDPreinscrit> Select()
        {
            BDDPreinscrit preinscrit = new BDDPreinscrit();
            return preinscrit.SelectPreinscrit();
        }

        public List<BDDAffichage> SelectAffichage()
        {
            BDDAffichage affichage = new BDDAffichage();
            return affichage.SelectAffichage();
        }
    }
}
