﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartEntity.RequestEntity
{
    public class LoginRequestEntity
    {
        public string LoginUserName { get; set; }
        public string LoginPwd { get; set; }
        public string IsRemeberPwd { get; set; }
    }
}
