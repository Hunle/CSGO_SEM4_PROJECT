using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace DB
{
     public class SkinsRepository : BaseRepository
    {
        
        {
            public void Save(Skins skin)
            {
                if (skin.Id > 0)
                {
                    //its an update, it has an id
                    Skins existingSkin = Load(skin.Id);
                    existingSkin.Name = skin.Name;
                    existingSkin.Price = skin.Price;
                    existingSkin.State = skin.State;
                    
                }
                else
                {
                    context.Skin.Add(skin);
                }
                context.SaveChanges();
            }

            public Skins Load(int id)
            {
                return context.Skin.Where(x => x.Id == id).FirstOrDefault();
                //return context.Developers.FirstOrDefault(x => x.Id == id);
            }

            public List<Skins> LoadAll()
            {
                return context.Skin.ToList();
            }

            public void Delete(int id)
            {
                Skins skinToDelete = Load(id);
                context.Skin.Remove(skinToDelete);
                context.SaveChanges();
            }
        }
    }
}
}
