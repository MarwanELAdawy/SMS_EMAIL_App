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
            case "100":
                ConvertedResponse = "Missing parameters (not exist or empty) Username + password.";
                break;
            case "110":
                ConvertedResponse = "Account not exist (wrong username or password). ";
                break;
            case "111":
                ConvertedResponse = "The account not activated.";
                break;
            case "112":
                ConvertedResponse = "Blocked account. ";
                break;
            case "113":
                ConvertedResponse = "Not enough balance.";
                break;
            case "114":
                ConvertedResponse = "The service not available for now";
                break;
            case "115":
                ConvertedResponse = "The sender not available (if user have no opened sender). ";
                break;
            case "116":
                ConvertedResponse = "Invalid sender name.";
                break;
            case "120":
                ConvertedResponse = "Invalid phone number.";
                break;
            default:
                ConvertedResponse = "Success";
                break;
        }
        return ConvertedResponse;
    }

    public static string ConvertTamyozResponseCode(string response)
    {
        string ConvertedResponse = "";
        switch (response)
        {
            case "100":
                ConvertedResponse = "Success";
                break;
            case "101":
                ConvertedResponse = "Not Complete";
                break;
            case "102":
                ConvertedResponse = "Invalid User Name";
                break;
            case "103":
                ConvertedResponse = "Invalid Password";
                break;
            case "104":
                ConvertedResponse = "No Balance";
                break;
            case "105":
                ConvertedResponse = "No Balance / Not Sufficient Balance";
                break;
            case "106":
                ConvertedResponse = "Sender Name Not Valid";
                break;
            case "107":
                ConvertedResponse = "Sender Name Blocked";
                break;
            case "108":
                ConvertedResponse = "No Valid Mobile Number";
                break;
            case "109":
                ConvertedResponse = "Cannot send more than 5 blocks";
                break;
            case "110":
                ConvertedResponse = "Try Again";
                break;
            case "111":
                ConvertedResponse = "Transmission Is Closed";
                break;
            case "112":
                ConvertedResponse = "Message Has Blocked Words";
                break;
            case "113":
                ConvertedResponse = "Account Not Active";
                break;
            case "114":
                ConvertedResponse = "Account Stopped";
                break;
            case "115":
                ConvertedResponse = "Number Is Not Active";
                break;
            case "116":
                ConvertedResponse = "Email Not Valid";
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

    public static string StringToHexCode(string input) {
        string output = "";
        foreach (char c in input)
        {
            int value = (int)c;
            string hex = value.ToString("X4");
            output += hex;
        }
        return output;
    }
}