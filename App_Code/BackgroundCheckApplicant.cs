﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for BackgroundCheckApplicant
/// </summary>
public class BackgroundCheckApplicant
{
    public static List<BackgroundCheckApplicant> lstBackgroundCheckApplicants = new List<BackgroundCheckApplicant>();
    public string resultName { get; private set; }
    public string resultPhone { get; private set; }
    public string resultEmail { get; private set; }
    public string resultImageV2 { get; private set; }
    public string applicantType { get; private set; }

    public int userID { get; private set; }
    public BackgroundCheckApplicant(String resultName, String resultPhone, String resultEmail, String resultImageV2, String applicantType)
    {
        this.resultName = resultName;
        this.resultEmail = resultEmail;
        this.resultPhone = resultPhone;
        this.resultName = resultName;
        this.resultImageV2 = resultImageV2;
    }
}