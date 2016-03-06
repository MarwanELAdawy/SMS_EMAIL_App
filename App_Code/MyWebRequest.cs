using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.IO;
using System.Text;

/// <summary>
/// Summary description for MyWebRequest
/// </summary>
public class MyWebRequest
{
    private WebRequest request;
    private Stream dataStream;

    private string status;

    public String Status
    {
        get
        {
            return status;
        }
        set
        {
            status = value;
        }
    }

    public MyWebRequest(string url)
    {
        request = WebRequest.Create(url);
    }

    public MyWebRequest(string url, string method)
        : this(url)
    {

        if (method.Equals("GET") || method.Equals("POST"))
        {
            request.Method = method;
        }
        else
        {
            throw new Exception("Invalid Method Type");
        }
    }

    public MyWebRequest(string url, string method, string data)
        : this(url, method)
    {
        string postData = data;
        byte[] byteArray = Encoding.UTF8.GetBytes(postData);
        request.ContentType = "application/x-www-form-urlencoded";
        request.ContentLength = byteArray.Length;
        dataStream = request.GetRequestStream();
        dataStream.Write(byteArray, 0, byteArray.Length);
        dataStream.Close();
    }

    public string GetResponse()
    {
        WebResponse response = request.GetResponse();
        this.Status = ((HttpWebResponse)response).StatusDescription;
        dataStream = response.GetResponseStream();
        StreamReader reader = new StreamReader(dataStream);
        string responseFromServer = reader.ReadToEnd();
        reader.Close();
        dataStream.Close();
        response.Close();
        //responseFromServer = StringHelper.StripString(responseFromServer);
        //responseFromServer = responseFromServer;
        return responseFromServer;
    }

}