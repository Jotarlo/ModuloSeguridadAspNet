using DesarrolloDocenteModel.DbModel.SecurityModule;
using DesarrolloDocenteModel.Mapper.SecurityModule;
using DesarrolloDocenteModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesarrolloDocenteModel.Implementation.SecurityModule
{
    public class RoleImplModel
    {
        /// <summary>
        /// Se agrega un nuevo registro a los roles
        /// </summary>
        /// <param name="dbModel">Representa un objeto con la información del rol</param>
        /// <returns>entero con la respuesta: 1. OK, 2. KO, 3. Ya existe</returns>
        public int RecordCreation(RoleDbModel dbModel)
        {
            using (DesarrolloDocenteBDEntities db = new DesarrolloDocenteBDEntities())
            {
                try
                {
                    // Verifica si existe un role con el nombre que se quiere crear el nuevo
                    if (db.SEC_ROLE.Where(x => x.NAME.ToUpper().Equals(dbModel.Name.ToUpper())).Count() > 0)
                    {
                        return 3;
                    }

                    RoleModelMapper mapper = new RoleModelMapper();
                    SEC_ROLE record = mapper.MapperT2T1(dbModel);

                    db.SEC_ROLE.Add(record);
                    db.SaveChanges();
                    return 1;
                }
                catch
                {
                    return 2;
                }
            }
        }

        /// <summary>
        /// Actualización de un registro
        /// </summary>
        /// <param name="dbModel"></param>
        /// <returns></returns>
        public int RecordUpdate(RoleDbModel dbModel)
        {
            using (DesarrolloDocenteBDEntities db = new DesarrolloDocenteBDEntities())
            {
                try
                {
                    var record = db.SEC_ROLE.Where(x => x.ID == dbModel.Id).FirstOrDefault();
                    if (record == null)
                    {
                        return 3;
                    }

                    record.NAME = dbModel.Name;
                    record.REMOVED = dbModel.Removed;

                    db.SaveChanges();
                    return 1;
                }
                catch
                {
                    return 2;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dbModel"></param>
        /// <returns></returns>
        public int RecordRemove(RoleDbModel dbModel)
        {
            using (DesarrolloDocenteBDEntities db = new DesarrolloDocenteBDEntities())
            {
                try
                {
                    var record = db.SEC_ROLE.Where(x => x.ID == dbModel.Id).FirstOrDefault();
                    if (record == null)
                    {
                        return 3;
                    }
                    //db.SEC_ROLE.Remove(record);

                    record.REMOVED = true;

                    db.SaveChanges();
                    return 1;
                }
                catch
                {
                    return 2;
                }
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public IEnumerable<RoleDbModel> RecordList(string filter)
        {
            using (DesarrolloDocenteBDEntities db = new DesarrolloDocenteBDEntities())
            {
                //var listaLambda = db.SEC_ROLE.Where(x => !x.REMOVED && x.NAME.ToUpper().Contains(filter.ToUpper())).ToList();

                var listaLinq = from role in db.SEC_ROLE
                                where !role.REMOVED && role.NAME.ToUpper().Contains(filter.ToUpper())
                                select role;

                RoleModelMapper mapper = new RoleModelMapper();
                var listaFinal = mapper.MapperT1T2(listaLinq);               

                return listaFinal.ToList();
            }
        }
    }
}
