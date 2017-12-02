using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CVIMS.Entity.Context;
using CVIMS.Entity.Lookup;

namespace CVIMS.Api.Infrastructure.Lookup
{
    public interface ILookupRepository
    {
        IEnumerable<LookupModel> GetLookups();
    }
    public class LookupRepository : ILookupRepository
    {
        private readonly CVIMSContextRO _contextRo;

        public LookupRepository(CVIMSContextRO contextRo)
        {
            _contextRo = contextRo;
        }

        public IEnumerable<LookupModel> GetLookups()
        {
            var lookups = new List<LookupModel>();


            foreach (var entity in _contextRo.Model.GetEntityTypes())
            {
                var name = entity.Name;
                var type = entity.ClrType;
                if (name.EndsWith("_lkp"))
                {

                    var dbObject = (IEnumerable<ILookup>)
                       typeof(DbContext).GetMethod("Set", Type.EmptyTypes)
                       .MakeGenericMethod(type)
                       .Invoke(_contextRo, null);

                    lookups.Add(new LookupModel()
                    {
                        Name = name.Split('.').Last(),
                        Values = dbObject
                    });
                }
            }

            return lookups;
        }
    }
}
