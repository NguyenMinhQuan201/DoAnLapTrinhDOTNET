using Models.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.SendContact
{
    public class ContactDao
    {
        LipstickDbContext _context = null;
        public ContactDao()
        {
            _context = new LipstickDbContext();
        }
        public int Insert(LienHe entity)
        {
            _context.LienHes.Add(entity);
            _context.SaveChanges();
            return entity.ID;
        }
    }
}
