using DesarrolloDocente.Mapper.SecurityModule;
using DesarrolloDocente.Models.SecurityModule;
using DesarrolloDocenteController.DTO.SecurityModule;
using DesarrolloDocenteController.Implementation.SecurityModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DesarrolloDocente.Helpers
{
    public static class Menu
    {
        private static UserImplController controller = new UserImplController();
        public static IEnumerable<FormModel> GetMenuForms(int userId) 
        {
            IEnumerable<FormDTO> dtoList = controller.GetRoleFormsByUser(userId);
            FormModelMapper mapper = new FormModelMapper();
            IEnumerable<FormModel> list = mapper.MapperT1T2(dtoList);
            return list;
        }


        public static bool ValidateUserInForm(int userId, int formId)
        {
            return controller.ValidateUserInForm(userId, formId);
        }
    }
}