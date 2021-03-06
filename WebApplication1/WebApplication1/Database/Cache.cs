﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.Database
{
    public class Cache
    {
        public Dictionary<string, string> last_msg = new Dictionary<string, string>();
       public static Mutex gen_lock=new Mutex();
        public Dictionary<string, Object> Storage = new Dictionary<string, object>();
        public Dictionary<string, string> role_map = new Dictionary<string, string>()
        {
            { "/Main/MainIndex","Admin,User" },
             { "/Main/MangAuctions","Admin" },
                          { "/Main/ApproveMsg","Admin,User" },
                            { "/Main/TichurSuppCreate","Admin,User" },
                             { "/Main/TichurExisting","Admin,User" },
                              { "/Main/MangUsers","Admin" },
                               { "/Main/MangSuppliers","Admin" },
            {"/Main/MangClusetrs","Admin"  },
                                 { "/Main/MangUnits","Admin" },
                                  { "/Main/UnAuthError","Admin,User" },
            {"/Main/EditOrAddUser","Admin" },
            {"/Main/EditOrAddAuction" ,"Admin"    },
             {"/Main/EditOrAddClusetr" ,"Admin"    },
              {"/Main/EditOrAddUnit" ,"Admin"    },
               {"/Main/EditOrAddSupplier" ,"Admin"    },
            { "/Main/TichurCancel" ,"Admin"  },
    };
     
    }
}



