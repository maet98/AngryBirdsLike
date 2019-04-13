using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Assets
{
    [DataContract]
    public class Score
    {
        [DataMember]
        public int estrellas { get; set; }
        [DataMember]
        public string nombre { get; set; }
        [DataMember]
        public string nivel { get; set; }

        public Score(int estrellas, string nombre, string nivel)
        {
            this.nivel = nivel;
            this.estrellas = estrellas;
            this.nombre = nombre;
        }
    }
}
