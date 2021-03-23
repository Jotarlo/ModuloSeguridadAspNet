using DesarrolloDocenteModel.DbModel.SecurityModule;
using DesarrolloDocenteModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesarrolloDocenteModel.Mapper.SecurityModule
{
    public class RoleModelMapper : MapperBase<SEC_ROLE, RoleDbModel>
    {
        public override RoleDbModel MapperT1T2(SEC_ROLE input)
        {
            return new RoleDbModel()
            {
                Id = input.ID,
                Name = input.NAME,
                Description = input.DESCRIPTION,
                Removed = input.REMOVED
            };
        }

        public override IEnumerable<RoleDbModel> MapperT1T2(IEnumerable<SEC_ROLE> input)
        {
            foreach (var item in input)
            {
                yield return MapperT1T2(item);
            }
        }

        public override SEC_ROLE MapperT2T1(RoleDbModel input)
        {
            return new SEC_ROLE()
            {
                ID = input.Id,
                NAME = input.Name,
                DESCRIPTION = input.Description,
                REMOVED = input.Removed
            };
        }

        public override IEnumerable<SEC_ROLE> MapperT2T1(IEnumerable<RoleDbModel> input)
        {
            foreach (var item in input)
            {
                yield return MapperT2T1(item);
            }
        }
    }
}
