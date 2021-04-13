using DesarrolloDocenteController.DTO.SecurityModule;
using DesarrolloDocenteController.Mapper.SecurityModule;
using DesarrolloDocenteModel.DbModel.SecurityModule;
using DesarrolloDocenteModel.Implementation.SecurityModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesarrolloDocenteController.Implementation.SecurityModule
{
    public class RoleImplController
    {
        private RoleImplModel model;
        public RoleImplController()
        {
            model = new RoleImplModel();
        }

        /// <summary>
        /// Creción de un registro
        /// </summary>
        /// <param name="dto">información DTO</param>
        /// <returns>1: OK, 2: Excepción, 3. Ya existe</returns>
        public int RecordCreation(RoleDTO dto)
        {
            RoleDTOMapper mapper = new RoleDTOMapper();
            RoleDbModel dbModel = mapper.MapperT2T1(dto);
            return model.RecordCreation(dbModel);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public int RecordUpdate(RoleDTO dto)
        {
            RoleDTOMapper mapper = new RoleDTOMapper();
            RoleDbModel dbModel = mapper.MapperT2T1(dto);
            return model.RecordUpdate(dbModel);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public int RecordRemove(RoleDTO dto)
        {
            RoleDTOMapper mapper = new RoleDTOMapper();
            RoleDbModel dbModel = mapper.MapperT2T1(dto);
            return model.RecordRemove(dbModel);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public IEnumerable<RoleDTO> RecordList(string filter)
        {
            var list = model.RecordList(filter);
            RoleDTOMapper mapper = new RoleDTOMapper();
            return mapper.MapperT1T2(list);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public RoleDTO RecordSearch(int id)
        {
            var record = model.RecordSearch(id);

            if (record == null)
            {
                return null;
            }
            RoleDTOMapper mapper = new RoleDTOMapper();
            return mapper.MapperT1T2(record);
        }

        public IEnumerable<FormDTO> RecordFormList()
        {
            var list = model.RecordFormList();
            FormDTOMapper mapper = new FormDTOMapper();
            return mapper.MapperT1T2(list);
        }

        public IEnumerable<FormDTO> RecordFormListByRole(int roleId)
        {
            var list = model.RecordFormListByRole(roleId);
            FormDTOMapper mapper = new FormDTOMapper();
            return mapper.MapperT1T2(list);
        }

        ///
        public bool AssignForms(List<int> formsList, int roleId)
        {
            return model.AssignForms(formsList, roleId);
        }
    }
}
