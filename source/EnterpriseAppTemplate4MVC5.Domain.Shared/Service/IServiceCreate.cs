using EnterpriseAppTemplate4MVC5.Domain.Shared.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseAppTemplate4MVC5.Domain.Shared.Service
{
    public interface IServiceCreate<TPrimaryIdType, TType>
    {
        TType CreateNew();

        OperationResult Insert(TType entity);

    }

}
