using Core.Repoisitory;
using Core.Service;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace infra.Service
{
    public class GenericService<TModel> : IGenericService<TModel>
    {
        public IGenericRepoisitory<TModel> _genericRepoisitory;
        public GenericService(IGenericRepoisitory<TModel> genericRepoisitory)
        {
            _genericRepoisitory = genericRepoisitory;
        }
        public async Task<T> GenericCRUD<T>(string action,TModel model )
        {
            return await _genericRepoisitory.GenericCRUD<T>(action,model);
        }
    }
}
