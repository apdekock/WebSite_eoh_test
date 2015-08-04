using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using WebSite_eoh_test;

/// <summary>
/// Summary description for UserAccess
/// </summary>
public class UserAccess
{
    public static bool IsAdmin(string userId)
    {
        UserManager userManager = new UserManager();
        var isInRole = userManager.IsInRole(userId, "Admin");
        return isInRole;
    }
}
