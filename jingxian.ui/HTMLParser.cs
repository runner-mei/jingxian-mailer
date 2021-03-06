using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Schema;

namespace jingxian
{
	public class HTMLHelper
	{
		//static XmlDocument xdf = new XmlDocument();


		public static string UnXMLize(string str)
		{
			if(str==null) return null;
			if(str.Length==0) return " ";
			str=str.Replace("&lt;", "<");
			str=str.Replace("&gt;", ">");
			str=str.Replace("&amp;", "&");
			str=str.Replace("&apos;", "'");
			str=str.Replace("&quot;", "\"");
			str=str.Replace("&lsquo;", "‘");
			str=str.Replace("&rsquo;", "’");
			str=str.Replace("&sbquo;", "‚");
			str=str.Replace("&ldquo;", "“");
			str=str.Replace("&rdquo;", "”");
			str=str.Replace("&bdquo;", "„");
			str=str.Replace("&trade;", "™");
			return str;
		}

		public static string XMLize(string str)
		{
			if(str == null || str.Length == 0) 
				return " ";
			str=str.Replace("<", "&lt;");
			str=str.Replace(">", "&gt;");
			str=str.Replace("&", "&amp;");
			str=str.Replace("'", "&apos;");
			str=str.Replace("\"", "&quot;");
			return str;
		}

        public static void GenerateSubstringWithTooltip(System.Text.StringBuilder sb, string str, int count)
        {
            if (string.IsNullOrEmpty(str))
            {
                sb.Append("");
                return;
            }

            if (str.Length <= count)
            {
                sb.Append(XMLize(str));
                return;
            }

            sb.Append("<tooltip text='");
            sb.Append(XMLize(str));
            sb.Append("'>");
            sb.Append(HTMLHelper.XMLize(GenerateSubstring(str, count)));
            sb.Append("</tooltip>");
        }

        public static string GenerateSubstring(string str, int count)
        {
            if (str == null)
                return "";

            return (str.Length > count) ? (XMLize(str.Substring(0, count)) + "...") : XMLize(str);
        }
	}
}
