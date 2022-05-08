using Models.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using DoAnLapTrinhDOTNET.Common;

namespace Models.UserRegistration
{
    public class UserRegisDao
    {

        LipstickDbContext _context = null;
        public UserRegisDao()
        {
            _context = new LipstickDbContext();
        }
        public int Insert(NguoiDung entity)
        {
            _context.NguoiDungs.Add(entity);
            _context.SaveChanges();
            var changePass = _context.NguoiDungs.Where(x => x.UserName == entity.UserName).FirstOrDefault();
            changePass.PassWord = Encryptor.MD5Hash(changePass.PassWord);
            _context.SaveChanges();
            return entity.ID;
        }
        public bool CheckUserName(string userName)
        {
            return _context.NguoiDungs.Count(x => x.UserName == userName) > 0;
        }
        
    }
}
