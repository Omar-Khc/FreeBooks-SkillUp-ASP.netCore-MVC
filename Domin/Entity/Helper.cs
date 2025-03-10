﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domin.Entity
{
    public class Helper
    {
        public const string PathImageuser = "/Images/Users/";
        public const string PathSaveImageuser = "Images/Users";


        public const string Success = "Success";
        public const string Error = "Error";

        public const string MsgType = "msgType";
        public const string Title = "title";
        public const string Msg = "msg";

        public const string Save = "Save";
        public const string Update = "Update";
        public const string Delete = "Delete";

       


        public enum eCurrentState
        {
            Active = 1,
            Delete = 0
        }

        public enum Roles
        {
            SuperAdmin,
            Admin,
            Basic
        }

        public enum PermissionModuleName
        {
            Home,
            Accounts,
            Roles,
            Registers,
            Categories
        }

    }
}
