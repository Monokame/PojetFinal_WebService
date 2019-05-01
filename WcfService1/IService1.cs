﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using MySql.Data.MySqlClient;

namespace WcfService1
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom d'interface "IService1" à la fois dans le code et le fichier de configuration.
    [ServiceContract]
    public interface IService1
    {

        /*[OperationContract]
        string GetData(int value);*/

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "Insert", RequestFormat =WebMessageFormat.Json)]
        void Insert(BDDPreinscrit preinscrit);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "InsertXbee")]
        string InsertXbee(Stream stream);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "InsertAlerte")]
        string InsertAlerte(Stream stream);



        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "Select")]
        Stream Select();

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "SelectAffichage")]
        Stream SelectAffichage();
        /*[OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);*/

    }


    // Utilisez un contrat de données comme indiqué dans l'exemple ci-après pour ajouter les types composites aux opérations de service.
    /*[DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }*/
}
