using Core.Domain;
using Core.Repoisitory;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace infra.Repoisitory
{
    public class GenericRepoisitory<TModel> : IGenericRepoisitory<TModel>
    {
        private readonly IDBContext _context;

        public GenericRepoisitory(IDBContext context)
        {
            _context = context;
        }
        public async Task<T> GenericCRUD<T>(string action,TModel model)
        {
            try
            {
                List<string> actionR = new List<string>() { "GETALL", "GETBYID", "GETBYNAME" , "GETBYCARDNUMBER" };
                List<string> actionCUD = new List<string>() { "INSERT", "UPDATE", "DELETE" };
                var parameters = new DynamicParameters();
                if (model != null)
                {
                    dynamic dynamicModel = model;
                     parameters = GetValue(model);
                }
                parameters.Add("P_ACTION" , action ,DbType.String, direction: ParameterDirection.Input);

                if (actionR.Contains(action))
                {
                    IEnumerable<TModel> resualt = await _context.dbConnection.QueryAsync<TModel>(typeof(TModel).Name + "_PACKAGE." + typeof(TModel).Name + "_CRUD", parameters, commandType: CommandType.StoredProcedure);
                    if (action == "GETALL")
                        return (dynamic)resualt.ToList();
                    return (dynamic)resualt.FirstOrDefault();
                }
                else if (actionCUD.Contains(action))
                {

                    var resualt = await _context.dbConnection.ExecuteAsync(typeof(TModel).Name + "_PACKAGE." + typeof(TModel).Name + "_CRUD", parameters, commandType: CommandType.StoredProcedure);
                    return (resualt > 0) ? (dynamic)$"0 Row {action}" : (dynamic)$"1 Row {action}";
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }


            return (dynamic)null;
        }

        private DynamicParameters GetValue(object obj)
        {
            var parameters = new DynamicParameters();
            var props = obj.GetType().GetProperties().Select(x => new
            { x.Name, values = x.GetValue(obj), type = x.PropertyType.Name, fulltype = x.PropertyType.FullName }).Where(x => x.values != null).ToList();
            foreach (var prop in props)
            {
                DbType MyStatus;
                if (prop.fulltype.Contains(nameof(DateTime)))
                {
                    MyStatus = DbType.DateTime;
                }
                else if (prop.fulltype.Contains("Nullable`1"))
                {
                    MyStatus = DbType.Int32;
                }
                else
                {
                    MyStatus = (DbType)Enum.Parse(typeof(DbType), prop.type, true);
                }
                parameters.Add("P_" + prop.Name.ToUpper(), prop.values, dbType: MyStatus, direction: ParameterDirection.Input);
            }


            return parameters;
        }
    }
}
