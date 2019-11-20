using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Favorite
/// </summary>
public class Favorite
{
    public static List<Favorite> lstFavorites = new List<Favorite>();
    public static string selectedReultFullAddress;

    public string favName { get; private set; }
    public string favLocation { get; private set; }
    public string favDescription { get; private set; }
    public string favPrice { get; private set; }
    public string backgroundCheckResult { get; private set; }
    public string resultimage1 { get; private set; }
    public string resultimage2 { get; private set; }
    public string resultimage3 { get; private set; }
    public string resultFullAddress { get; private set; }
    public int resultID { get; private set; }
    public string propertyTitle { get; private set; }
    public String hostBio { get; private set; }

    public Favorite(int id, string favName, string favLocation, string favDescription, string favPrice, string backgroundCheckResult, string resultimage1, string resultimage2, string resultimage3, String hostBio, string propertyTitle)
    {
        this.favName = favName;
        this.favLocation = favLocation;
        this.favDescription = favDescription;
        this.favPrice = "$" + favPrice + "/Month";
        this.backgroundCheckResult = backgroundCheckResult;
        this.resultimage1 = resultimage1;
        this.resultimage2 = resultimage2;
        this.resultimage3 = resultimage3;
        this.resultID = id;
        this.hostBio = hostBio;
        this.propertyTitle = propertyTitle;
    }
    public void setFullAddress(string resultFullAddress)
    {
        this.resultFullAddress = resultFullAddress;
    }
}