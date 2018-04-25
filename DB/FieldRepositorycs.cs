using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace DB
{
    class FieldRepositorycs
    {
        public class FieldRepository : BaseRepository
        {
            public void Save(Field field)
            {
                if (field.Id > 0)
                {
                    //its an update, it has an id
                    Field existingField = Load(field.Id);
                    existingField.Color = field.Color;
                    existingField.Number = field.Number;
                    
                }
                else
                {
                    context.Fields.Add(field);
                }
                context.SaveChanges();
            }

            public Field Load(int id)
            {
                return context.Fields.Where(x => x.Id == id).FirstOrDefault();
                //return context.Developers.FirstOrDefault(x => x.Id == id);
            }

            public List<Field> LoadAll()
            {
                return context.Fields.ToList();
            }

            public void Delete(int id)
            {
                Field fieldToDelete = Load(id);
                context.Fields.Remove(fieldToDelete);
                context.SaveChanges();
            }
        }
    }
}

