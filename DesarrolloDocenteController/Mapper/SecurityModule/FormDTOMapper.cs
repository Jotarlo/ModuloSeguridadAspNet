using DesarrolloDocenteController.DTO.SecurityModule;
using DesarrolloDocenteModel.DbModel.SecurityModule;
using DesarrolloDocenteModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesarrolloDocenteController.Mapper.SecurityModule
{
    public class FormDTOMapper : MapperBase<FormDbModel, FormDTO>
    {
        /// <summary>
        /// Method to map the FormDbModel object to FormDTO
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public override FormDTO MapperT1T2(FormDbModel input)
        {
            return new FormDTO()
            {
                Id = input.Id,
                Name = input.Name,
                Url = input.Url,
                IsSelectedByUser = input.IsSelectedByUser
            };
        }

        public override IEnumerable<FormDTO> MapperT1T2(IEnumerable<FormDbModel> input)
        {
            foreach (var item in input)
            {
                yield return MapperT1T2(item);
            }
        }

        public override FormDbModel MapperT2T1(FormDTO input)
        {
            return new FormDbModel()
            {
                Id = input.Id,
                Name = input.Name,
                Url = input.Url
            };
        }

        public override IEnumerable<FormDbModel> MapperT2T1(IEnumerable<FormDTO> input)
        {
            foreach (var item in input)
            {
                yield return MapperT2T1(item);
            }
        }
    }
}
