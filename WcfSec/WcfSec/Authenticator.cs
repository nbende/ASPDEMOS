using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ServiceModel;
using System.IdentityModel.Selectors;//
namespace WcfSec
{
    public class Authenticator : UserNamePasswordValidator
    {
        public override void Validate(string userName, string password)
        {
            if (userName != "scott" && password != "tiger")
            {
                throw new FaultException("Invalid user and/or password");
            }
        }

    }
}