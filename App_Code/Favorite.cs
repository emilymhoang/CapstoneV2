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
    public string favName { get; private set; }
    public string favLocation { get; private set; }
    public string favDescription { get; private set; }
    public string favPrice { get; private set; }
    public string backgroundCheckResult { get; private set; }
    public string resultimage1 { get; private set; }
    public string resultimage2 { get; private set; }
    public string resultimage3 { get; private set; }


    public Favorite(string favName, string favLocation, string favDescription, string favPrice, string backgroundCheckResult, string resultimage1, string resultimage2, string resultimage3)
    {
        this.favName = favName;
        this.favLocation = favLocation;
        this.favDescription = favDescription;
        this.favPrice = "Price: $" + favPrice + "/Month";
        this.backgroundCheckResult = backgroundCheckResult;
        this.resultimage1 = resultimage1;
        this.resultimage2 = resultimage2;
        this.resultimage3 = resultimage3;
    }
}