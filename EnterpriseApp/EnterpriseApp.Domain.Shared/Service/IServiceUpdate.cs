using EnterpriseApp.Domain.Shared.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseApp.Domain.Shared.Service
{
    public interface IServiceUpdate<TPrimaryIdType, TType>
    {

        TType GetById(TPrimaryIdType id);

        OperationResult Update(TType entity);

    }

}
