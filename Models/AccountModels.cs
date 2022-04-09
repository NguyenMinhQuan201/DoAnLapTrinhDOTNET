using Models.Common;
using Models.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class AccountModels
    {
        private LipstickDbContext _context = null;
        public AccountModels()
        {
            _context = new LipstickDbContext();
        }
        public bool Login(string userName, string passWord)
        {
            var mk = Encryptor.MD5Hash(passWord);
            var user = _context.NguoiDungs.Where(u => u.UserName == userName && u.PassWord == mk).Count();
            if (user == 0)
            {
                return false;
            }
            return true;
        }
    }
}
