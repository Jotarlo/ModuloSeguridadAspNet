using DesarrolloDocenteModel.DbModel.SecurityModule;
using DesarrolloDocenteModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesarrolloDocenteModel.Mapper.SecurityModule
{
    public class UserModelMapper : MapperBase<SEC_USER, UserDbModel>
    {
        public override UserDbModel MapperT1T2(SEC_USER input)
        {
            var roles = input.SEC_USER_ROLE.Select(x => x.SEC_ROLE);
            RoleModelMapper roleMapper = new RoleModelMapper();
            return new UserDbModel()
            {
                Id = input.ID,
                Name = input.NAME,
                Lastname = input.LASTNAME,
                Cellphone = input.CELLPHONE,
                Email = input.EMAIL,
                Password = input.USER_PASSWORD,
                Roles = roleMapper.MapperT1T2(roles),
                Token = input.SEC_SESSION.Where(x => x.TOKEN_STATUS).OrderByDescending(d => d.LOGIN_DATE).Select(x => x.TOKEN).FirstOrDefault()
            };
        }

        public override IEnumerable<UserDbModel> MapperT1T2(IEnumerable<SEC_USER> input)
        {
            foreach (var item in input)
            {
                yield return MapperT1T2(item);
            }
        }

        public override SEC_USER MapperT2T1(UserDbModel input)
        {
            return new SEC_USER()
            {
                ID = input.Id,
                NAME = input.Name,
                LASTNAME = input.Lastname,
                CELLPHONE = input.Cellphone,
                EMAIL = input.Email,
                USER_PASSWORD = input.Password
            };
        }

        public override IEnumerable<SEC_USER> MapperT2T1(IEnumerable<UserDbModel> input)
        {
            foreach (var item in input)
            {
                yield return MapperT2T1(item);
            }
        }
    }
}
