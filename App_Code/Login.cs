using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Login
/// </summary>
public class Login
{
    public String username { get; private set; }
    public String password { get; private set; }

    public Login(String username, String password)
    {
        this.username = username;
        this.password = password;
    }
}