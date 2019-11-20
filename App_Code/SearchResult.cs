using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for SearchResult
/// </summary>
public class SearchResult
{
    public static List<SearchResult> lstSearchResults = new List<SearchResult>();

    public static List<SearchResult> lstFilteredResults = new List<SearchResult>();

    public static string selectedReultFullAddress;

    public string resultName { get; private set; }
    public string resultLocation { get; private set; }
    public string resultDescription { get; private set; }
    public string resultPrice { get; private set; }

    public int resultID { get; private set; }

    public string resultimage1 { get; private set; }
    public string resultimage2 { get; private set; }
    public string resultimage3 { get; private set; }
    public string backgroundCheckResult { get; private set; }

    public string resultFullAddress { get; private set; }
    public string propertyTitle { get; private set; }
    public string hostBio { get; private set; }


    public List<string> lstPropertyBadges { get; private set; }


    public SearchResult(int resultID, string resultName, string resultLocation, string resultDescription, double resultPrice, 
        string resultimage1, string resultimage2, string resultimage3, string backgroundCheckResult)
    {
        this.resultName = resultName;
        this.resultLocation = resultLocation;
        this.resultDescription = resultDescription;
        this.resultPrice = "$" + resultPrice + "/Month";
        this.resultID = resultID;
        this.resultimage1 = resultimage1;
        this.resultimage2 = resultimage2;
        this.resultimage3 = resultimage3;
        this.backgroundCheckResult = backgroundCheckResult;
    }
    //public SearchResult(int resultID, string resultName, string resultLocation, string resultDescription, double resultPrice,
    //    string resultimage1, string resultimage2, string resultimage3, string backgroundCheckResult, string hostBio, string propertyTitle)
    //{
    //    this.resultName = resultName;
    //    this.resultLocation = resultLocation;
    //    this.resultDescription = resultDescription;
    //    this.resultPrice = "$" + resultPrice + "/Month";
    //    this.resultID = resultID;
    //    this.resultimage1 = resultimage1;
    //    this.resultimage2 = resultimage2;
    //    this.resultimage3 = resultimage3;
    //    this.backgroundCheckResult = backgroundCheckResult;
    //    this.hostBio = hostBio;
    //    this.propertyTitle = propertyTitle;
    //}

    public SearchResult(int resultID, string resultName, string resultLocation, string propertyTitle, string resultDescription, double resultPrice
        , string resultimage1, string resultimage2, string resultimage3, string backgroundCheckResult, List<string> lstPropertyBadges, string hostBio)
    {
        this.resultName = resultName;
        this.resultLocation = resultLocation;
        this.resultDescription = resultDescription;
        this.resultPrice = "$" + resultPrice + "/Month";
        this.resultID = resultID;
        this.resultimage1 = resultimage1;
        this.resultimage2 = resultimage2;
        this.resultimage3 = resultimage3;
        this.backgroundCheckResult = backgroundCheckResult;
        this.propertyTitle = propertyTitle;
        this.lstPropertyBadges = lstPropertyBadges;
        this.hostBio = hostBio;

    }

    public void setFullAddress(string resultFullAddress)
    {
        this.resultFullAddress = resultFullAddress;
    }

}