using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data;
namespace wcfgllib
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "Ilibjobs" in both code and config file together.
    [ServiceContract]
    public interface Ilibjobs
    {
        [OperationContract]
        DataSet GetJobs();

        [OperationContract]
        Job GetJobInfo(int jobid);

        [OperationContract]
        void AddJob(Job j);
    }
}
