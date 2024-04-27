using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FussballProj.Lib
{
    public class Sqliterepository : IRepository
    {
        #region path
        string _path = string.Empty;

        public Sqliterepository(string path)
        {
            _path = path;
        }
        #endregion
        #region addMethod
        public bool Add(Entry entry)
        {
            try
            {
                using (var context = new EntriesContext(_path))
                {
                    context.Add(entry);
                    Save();
                }
                return true;
            }
            catch (Exception ex)
            {

                System.Diagnostics.Debug.WriteLine(ex.Message);
                return false;
            }
        }
        #endregion

        #region deleteMehtod
        public bool Delete(Entry entry)
        {
            try
            {
                using (var context = new EntriesContext(_path))
                {
                    context.Database.ExecuteSqlRaw("DELETE FROM Entries WHERE Id={0}", entry.Id);
                }
                return true;
            }
            catch (Exception ex)
            {

                System.Diagnostics.Debug.WriteLine(ex.Message);
                return false;
            }
        }
        #endregion

        #region findMethod
        public Entry? find(string id)
        {
            try
            {
                using (var context = new EntriesContext(_path))
                {
                    var find = (from entry in context.Entries
                                where entry.Id == id
                                select entry).FirstOrDefault(); // erstes Element oder null
                    return find;
                }
            }
            catch (Exception ex)
            {

                System.Diagnostics.Debug.WriteLine(ex.Message);
                return null;
            }
        }
        #endregion
        #region getallMehtod
        public List<Entry> GetAll()
        {
            try
            {
                using (var context = new EntriesContext(_path))
                {
                    // filter
                    // var to = "Salzburg";
                    // var entries = context.Entries.FromSql($"SELECT * FROM Entries WHERE To={to}").ToList();

                    // alle fahrten
                    var entries = context.Entries.FromSql($"SELECT * FROM Entries").ToList();
                    return entries;
                }

            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                return new List<Entry>();
            }
        }
        #endregion

        #region saveMethod
        public bool Save()
        {
            try
            {
                using (var context = new EntriesContext(_path))
                {
                    context.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                return false;
            }
        }
        #endregion

        #region update Method
        public bool Update(Entry entry)
        {
            try
            {
                using (var context = new EntriesContext(_path))
                {
                    context.Entry(entry).State = EntityState.Modified;
                    Save();
                }
                return true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                return false;
            };
        }
        #endregion
    }
}
