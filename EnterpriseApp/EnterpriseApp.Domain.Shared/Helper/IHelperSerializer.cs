using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseApp.Domain.Shared.Helper
{
    public interface IHelperSerializer
    {

        string SerializeObjectWithXMLFormatter(object o);

        byte[] DeSerializeObjectWithXMLFormatter(object o);

    }

}
