using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class SmsSender
{
    public static string Send(string phone, string message)
    {
        MyWebRequest myRequest = new MyWebRequest("http://www.jawalbsms.ws/api.php/sendsms?", "POST", "user=acig111&pass=1234&to=" + phone + "&message=" + message + "&sender=Acig");
        return myRequest.GetResponse();
    }
}