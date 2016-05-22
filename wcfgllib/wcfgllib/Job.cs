using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization; // 

namespace wcfgllib
{
    [DataContract]
    public class Job
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public int minlvl { get; set; }
        [DataMember]
        public int maxlvl { get; set; }

    }
}
