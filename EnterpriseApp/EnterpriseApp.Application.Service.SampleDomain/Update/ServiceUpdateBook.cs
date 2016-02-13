using EnterpriseApp.Domain.SampleDomain.Service.Update;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnterpriseApp.Domain.SampleDomain.Entity;
using EnterpriseApp.Domain.Shared.ValueObject;

namespace EnterpriseApp.Application.Service.SampleDomain.Update
{
    public class ServiceUpdateBook : IServiceUpdateBook
    {
        public Author GetById(int id)
        {
            throw new NotImplementedException();
        }

        public OperationResult Update(Author entity)
        {
            throw new NotImplementedException();
        }
    }
}
