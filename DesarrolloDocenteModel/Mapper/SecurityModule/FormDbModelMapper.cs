using DesarrolloDocenteModel.DbModel.SecurityModule;
using DesarrolloDocenteModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesarrolloDocenteModel.Mapper.SecurityModule
{
    public class FormDbModelMapper : MapperBase<SEC_FORM, FormDbModel>
    {
        /// <summary>
        /// Method to map the SEC_FORM object to FormDbModel
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public override FormDbModel MapperT1T2(SEC_FORM input)
        {
            return new FormDbModel()
            {
                Id = input.ID,
                Name = input.NAME,
                Url = input.URL
            };
        }

        public override IEnumerable<FormDbModel> MapperT1T2(IEnumerable<SEC_FORM> input)
        {
            foreach (var item in input)
            {
                yield return MapperT1T2(item);
            }
        }

        public override SEC_FORM MapperT2T1(FormDbModel input)
        {
            return new SEC_FORM()
            {
                ID = input.Id,
                NAME = input.Name,
                URL = input.Url
            };
        }

        public override IEnumerable<SEC_FORM> MapperT2T1(IEnumerable<FormDbModel> input)
        {
            foreach (var item in input)
            {
                yield return MapperT2T1(item);
            }
        }
    }
}
