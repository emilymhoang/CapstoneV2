using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Class1
/// </summary>
public class BadgeTenant
{
    public int TenantID { get; private set; }
    public string underGraduateBadge { get; private set; }
    public string graduateBadge { get; private set; }

    public BadgeTenant(int TenantID, string underGraduateBadge, string graduateBadge)
    {
        this.TenantID = TenantID;
        this.underGraduateBadge = underGraduateBadge;
        this.graduateBadge = graduateBadge;

    }
}