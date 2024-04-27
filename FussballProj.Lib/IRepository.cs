using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FussballProj.Lib
{
    public interface IRepository
    {
        bool Add(Entry entry);

        bool Delete(Entry entry);

        bool Update(Entry entry);

        Entry? find(string id);

        bool Save();

        List<Entry> GetAll();
    }
}
