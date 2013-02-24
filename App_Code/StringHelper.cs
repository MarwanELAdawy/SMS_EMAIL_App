using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

/// <summary>
/// Summary description for StringHelper
/// </summary>
public static class StringHelper
{
    public static string MD5Hash(string text)
    {
        MD5 md5 = new MD5CryptoServiceProvider();

        //compute hash from the bytes of text
        md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(text));

        //get hash result after compute it
        byte[] result = md5.Hash;

        StringBuilder strBuilder = new StringBuilder();
        for (int i = 0; i < result.Length; i++)
        {
            //change it into 2 hexadecimal digits
            //for each byte
            strBuilder.Append(result[i].ToString("x2"));
        }

        return strBuilder.ToString();
    }

    public static string ToSentenceCase(string str)
    {
        return Regex.Replace(str, "[a-z][A-Z]", m => m.Value[0] + " " + char.ToLower(m.Value[1]));
    }

    public static string ConvertResponseCode(string response)
    {
        string ConvertedResponse = "";
        switch (response)
        {
            case "0":
                ConvertedResponse = "Success";
                break;
            case "101":
                ConvertedResponse = "Parameter are missing";
                break;
            case "104":
                ConvertedResponse = "Username or password is missing or you account is on hold";
                break;
            case "105":
                ConvertedResponse = "Credits are not available";
                break;
            case "106":
                ConvertedResponse = "Wrong unicode";
                break;
            case "107":
                ConvertedResponse = "Blocked sender name";
                break;
            case "108":
                ConvertedResponse = "Missing sneder name";
                break;
            case "109":
                ConvertedResponse = "Forbidden word";
                break;
            case "1010":
                ConvertedResponse = "Wrong SMS content format or URL format is not correct or Mobile number is blocked";
                break;
            case "1011":
                ConvertedResponse = "Username is missing";
                break;
            case "1012":
                ConvertedResponse = "Password is missing";
                break;
            case "1013":
                ConvertedResponse = "Mobile number is missing";
                break;
            case "1014":
                ConvertedResponse = "Unicode type is missing";
                break;
            case "1015":
                ConvertedResponse = "SMS content is empty";
                break;
            case "1016":
                ConvertedResponse = "Sender name is empty";
                break;
            default:
                ConvertedResponse = response;
                break;
        }
        return ConvertedResponse;
    }

    public static string StripString(string input){
       var result = Regex.Replace(input, "<.+?>", string.Empty);
       result = result.Replace("\n", String.Empty);
       result = result.Replace("\r", String.Empty);
       result = result.Replace("\t", String.Empty);
       result = result.Trim();
       StringBuilder sb = new StringBuilder();
       foreach (char c in result) {
         if (c >= '0' && c <= '9') {
           sb.Append(c);
         }
       }
       return sb.ToString();
    }
}