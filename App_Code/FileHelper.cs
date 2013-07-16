using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Collections;

public class FileHelper
{
    public static string GetFilePath(string name)
    {
        var path = HttpContext.Current.Server.MapPath(Path.Combine("~/Uploads/", name));
        return path;
    }

    public static Hashtable SaveFile(HttpPostedFile postedFile)
    {
        var timeStamp = DateTimeHelper.ToTimeStamp();
        var fileName = timeStamp + "_" + Path.GetFileName(postedFile.FileName);
        var filePath = FileHelper.GetFilePath(fileName);
        postedFile.SaveAs(filePath);
        Hashtable _hash = new Hashtable();
        _hash.Add("FileName", fileName);
        _hash.Add("FilePath", filePath);
        return _hash;
    }
}