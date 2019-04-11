using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using UnityEngine;

namespace Assets.Scripts
{
    [DataContract]
    public class Character
    {
        [DataMember]
        public string PrefabName { get; set; }
        [DataMember]
        public Vector3  posicion  { get; set; }
        [DataMember]
        public Quaternion rotation { get; set; }
        [DataMember]
        public bool seleccionada;

    }
}
