using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repoisitory
{
    public interface IGenericRepoisitory<TModel>
    {
        public Task<T> GenericCRUD<T>(string action,TModel model);
    }
}
