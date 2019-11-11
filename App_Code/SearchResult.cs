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
    public string resultName { get; private set; }
    public string resultLocation { get; private set; }
    public string resultDescription { get; private set; }
    public double resultPrice { get; private set; }

    public int resultID { get; private set; }

    public SearchResult(int resultID, string resultName, string resultLocation, string resultDescription, double resultPrice)
    {
        this.resultName = resultName;
        this.resultLocation = resultLocation;
        this.resultDescription = resultDescription;
        this.resultPrice = resultPrice;
        this.resultID = resultID;
    }
}