using DesarrolloDocenteController.DTO.SecurityModule;
using DesarrolloDocenteController.Mapper.SecurityModule;
using DesarrolloDocenteController.Services;
using DesarrolloDocenteModel.DbModel.SecurityModule;
using DesarrolloDocenteModel.Implementation.SecurityModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesarrolloDocenteController.Implementation.SecurityModule
{
    public class UserImplController
    {
        private UserImplModel model;
        private RoleImplModel roleModel;
        public UserImplController()
        {
            model = new UserImplModel();
            roleModel = new RoleImplModel();
        }

        public int RecordCreation(UserDTO dto)
        {
            UserDTOMapper mapper = new UserDTOMapper();
            UserDbModel dbModel = mapper.MapperT2T1(dto);
            Encrypt enc = new Encrypt();
            string randomPassword = enc.RandomString(10);
            string newPassword = enc.CreateMD5(randomPassword);
            dbModel.Password = newPassword;
            int response = model.RecordCreation(dbModel);
            // verify if the user was saved to send email
            if (response == 1)
            {
                String content = String.Format(@"Hola {0}, " +
                    "<br />Usted ha sido registrado en la plataforma de desarrollo docente. " +
                    "Sus credenciales de acceso son: <br /> " +
                    "<ul>" +
                    "<li>Usuario:{1}</li>" +
                    "<li>Contrasña: {2}</li>" +
                    "</ul>" +
                    "<br />Cordial saludo, <br />" +
                    "Su equipo de seguridad.", dto.Name, dto.Email, randomPassword);
                new Notifications().SendEmail("User Registration", content, dto.Name, dto.Email);
            }
            return response;
        }

        public int RecordUpdate(UserDTO dto)
        {
            UserDTOMapper mapper = new UserDTOMapper();
            UserDbModel dbModel = mapper.MapperT2T1(dto);
            return model.RecordUpdate(dbModel);
        }

        public int RecordRemove(UserDTO dto)
        {
            UserDTOMapper mapper = new UserDTOMapper();
            UserDbModel dbModel = mapper.MapperT2T1(dto);
            return model.RecordRemove(dbModel);
        }

        public IEnumerable<UserDTO> RecordList(string filter)
        {
            var list = model.RecordList(filter);
            UserDTOMapper mapper = new UserDTOMapper();
            return mapper.MapperT1T2(list);
        }

        public UserDTO Login(UserDTO dto)
        {
            UserDTOMapper mapper = new UserDTOMapper();
            UserDbModel dbModel = mapper.MapperT2T1(dto);
            dbModel.Password = new Encrypt().CreateMD5(dbModel.Password);
            var obj = model.Login(dbModel);
            return mapper.MapperT1T2(obj);
        }

        public int PasswordReset(string email)
        {
            Encrypt enc = new Encrypt();
            string randomPassword = enc.RandomString(10);
            string newPassword = enc.CreateMD5(randomPassword);
            var response = model.PasswordReset(email, newPassword);
            if (response == 1)
            {
                new Notifications().SendEmail("Password Reset", "Content...", email, "test@desarrollodocente.ucaldas.edu.co");
            }
            return response;
        }

        public int ChangePassword(string currentPassword, string newPassword, int userId)
        {
            string email = string.Empty;
            var response = model.ChangePassword(currentPassword, newPassword, userId, out email);
            if (response == 1)
            {
                new Notifications().SendEmail("Password changed", "Content...", email, "test@desarrollodocente.ucaldas.edu.co");
            }
            return response;
        }
        public UserDTO RecordSearch(int id)
        {
            var record = model.RecordSearch(id);

            if (record == null)
            {
                return null;
            }
            UserDTOMapper mapper = new UserDTOMapper();
            return mapper.MapperT1T2(record);
        }

        ///
        public bool AssignRoles(List<int> roleList, int userId)
        {
            return model.AssignRoles(roleList, userId);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public IEnumerable<RoleDTO> RecordListByUser(int userId)
        {
            var list = roleModel.RecordListByUser(userId);
            RoleDTOMapper mapper = new RoleDTOMapper();
            return mapper.MapperT1T2(list);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public IEnumerable<FormDTO> GetRoleFormsByUser(int userId)
        {
            IEnumerable<FormDbModel> dbModelList = model.GetRoleFormsByUser(userId);
            FormDTOMapper mapper = new FormDTOMapper();
            IEnumerable<FormDTO> list = mapper.MapperT1T2(dbModelList);
            return list;
        }


        public bool ValidateUserInForm(int userId, int formId)
        {
            return model.ValidateUserInForm(userId, formId);
        }
    }
}
