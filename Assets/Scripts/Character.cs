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
    public class Character : MonoBehaviour
    {
        [DataMember]
        public string PrefabName { get; set; }
        [DataMember]
        public Vector3  posicion  { get; set; }
        [DataMember]
        public Vector3 rotation { get; set; }


    }
}
