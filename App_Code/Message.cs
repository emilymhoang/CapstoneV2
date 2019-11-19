using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Message
/// </summary>
public class Message
{
    public static List<Message> lstHostMessages = new List<Message>();

    public static List<Message> lstTenantMessages = new List<Message>();
    public int tenantID { get; private set; }
    public String message { get; private set; }

    public int hostID { get; private set; }
    public DateTime messageDate { get; private set; }
    public string lastUpdatedBy { get; private set; }
    public DateTime lastUpdated { get; private set; }

    public string recieverName { get; private set; }

    public string tenantName { get; private set; }

    public Message(int tenantID, int hostID, String message, string lastUpdatedBy)
    {
        this.hostID = hostID;
        this.messageDate = DateTime.Now;
        this.lastUpdated = DateTime.Now;
        this.tenantID = tenantID;
        this.message = message;
        this.lastUpdatedBy = lastUpdatedBy;
        this.recieverName = string.Empty;

    }

    public void setRecieverName(string recieverName)
    {
        this.recieverName = recieverName;
    }

    public void setMessageDate(DateTime messageDate)
    {
        this.messageDate = messageDate;
    }

    public void setTenantName(string tenantName)
    {
        this.tenantName = tenantName;
    }

}
