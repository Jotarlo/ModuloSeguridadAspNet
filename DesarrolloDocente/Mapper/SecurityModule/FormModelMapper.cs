using DesarrolloDocente.Models.SecurityModule;
using DesarrolloDocenteController.DTO.SecurityModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesarrolloDocente.Mapper.SecurityModule
{
    public class FormModelMapper : MapperBase<FormDTO, FormModel>
    {
        /// <summary>
        /// Method to map the FormDTO object to FormModel
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public override FormModel MapperT1T2(FormDTO input)
        {
            return new FormModel()
            {
                Id = input.Id,
                Name = input.Name,
                Url = input.Url,
                IsSelectedByUser = input.IsSelectedByUser
            };
        }

        public override IEnumerable<FormModel> MapperT1T2(IEnumerable<FormDTO> input)
        {
            foreach (var item in input)
            {
                yield return MapperT1T2(item);
            }
        }

        public override FormDTO MapperT2T1(FormModel input)
        {
            return new FormDTO()
            {
                Id = input.Id,
                Name = input.Name,
                Url = input.Url
            };
        }

        public override IEnumerable<FormDTO> MapperT2T1(IEnumerable<FormModel> input)
        {
            foreach (var item in input)
            {
                yield return MapperT2T1(item);
            }
        }
    }
}
