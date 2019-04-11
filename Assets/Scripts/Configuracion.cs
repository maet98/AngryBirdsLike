using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    [DataContract]
    public class Configuracion : MonoBehaviour
    {
        [DataMember]
        public bool Sonido { get; set; }
        [DataMember]
        public bool Music { get; set; }
        [DataMember]
        public string nombre { get; set; }
    }
}
