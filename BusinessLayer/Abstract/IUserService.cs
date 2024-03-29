﻿using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IUserService
    {
        List<User> GetList();
        User GetBySha256(string sha256);
        void UserAdd(User user);
        User GetByID(int id);
        void UserDelete(User user);
        void UserUpdate(User user);
    }
}
