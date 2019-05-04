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
        /*public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }*/

        public void Insert(BDDPreinscrit bddpreinscrit)
        {
            BDDPreinscrit preinscrit = new BDDPreinscrit();
            preinscrit.Insert(bddpreinscrit);
        }
        public string InsertXbee(Stream stream)
        {
            SQLInsert insertSQL = new SQLInsert();
            StreamReader streamReader = new StreamReader(stream);
            string str = streamReader.ReadLine();
            str = insertSQL.InsertXbee(str);
            return str;
        }
        public string InsertAlerte(Stream stream)
        {
            SQLInsert insertSQL = new SQLInsert();
            StreamReader streamReader = new StreamReader(stream);
            string str = streamReader.ReadLine();
            str = insertSQL.InsertAlerte(str);
            return str;
        }


        //******SELECT******//
        public List<BDDPreinscrit> Select()
        {
            /*SQLSelect selectSQL = new SQLSelect();
            return selectSQL.SelectPreinscrit();*/
            BDDPreinscrit preinscrit = new BDDPreinscrit();
            return preinscrit.SelectPreinscrit();
        }

        public Stream SelectAffichage()
        {
            SQLSelect selectSQL = new SQLSelect();
            return selectSQL.SelectAffichage();
        }


    }
}
