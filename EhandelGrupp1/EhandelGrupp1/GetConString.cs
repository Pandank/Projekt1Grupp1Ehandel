using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace EhandelGrupp1
{
    public class GetConString
    {
        public static string GetCString()
        {
            var path = @"C:\temp\HiddenSettings.config";
            using (StreamReader reader = new StreamReader(path))
            {
                var conString = reader.ReadLine();
                return conString;
            }
        }


        public static string GetCpw()
        {
            var path = @"C:\temp\HiddenSettingsJustpw.config";
            using (StreamReader reader = new StreamReader(path))
            {
                var conString = reader.ReadLine();
                return conString;
            }
        }
    }
}