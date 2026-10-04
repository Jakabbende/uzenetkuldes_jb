using System;
using System.Runtime.Serialization;

namespace Uzenetkuldo_jb.Models
{
    [DataContract]
    public class Uzenet
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Szoveg { get; set; }

        [DataMember]
        public DateTime KüldesiIdo { get; set; }

        [DataMember]
        public string UzenetTipus { get; set; }

        [DataMember]
        public string Telefon { get; set; }

        [DataMember]
        public string Email { get; set; }
    }
}