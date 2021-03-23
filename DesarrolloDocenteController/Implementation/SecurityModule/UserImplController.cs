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
        public UserImplController()
        {
            model = new UserImplModel();
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
            if(response == 1)
            {
                new Notifications().SendEmail("User Registration", "Content...", dto.Email, "test@desarrollodocente.ucaldas.edu.co");
            }
            return response;
        }

        public int RecordUpdate(UserDTO dto)
        {
            UserDTOMapper mapper = new UserDTOMapper();
            UserDbModel dbModel = mapper.MapperT2T1(dto);
            dbModel.Password = new Encrypt().CreateMD5(dbModel.Password);
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
    }
}
