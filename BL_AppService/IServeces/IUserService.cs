﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace BL_AppService.IServeces
{
    public interface IUserService
    {
        List<UserDTO> GetAll();
        UserDTO GetById(string password);

    }
}