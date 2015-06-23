using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace BricachocBo
{
    [DataContract]
    public class Tva
   {
       [DataMember]
       public int Code { get; set; }
       
       [DisplayFormat(DataFormatString = "{0:F3}")]
        [DataMember]
        public decimal Taux { get; set; }
   
   }
}