using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Assets
{ 
    [DataContract]
    public class HighScore
    {
        [DataMember]
        public List<Score> scores { get; set; }

        public HighScore()
        {
            scores = new List<Score>();
        }
    }
}
