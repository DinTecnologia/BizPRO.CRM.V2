using System;

namespace BizPRO.CRM.V2.Core.Comum
{
    public class DB
    {
        private static DateTime _data;

        public static string ObterString(object item)
        {
            return Equals(item, DBNull.Value) ? string.Empty : item.ToString();
        }

        public static long ObterLong(object item)
        {
            return Equals(item, DBNull.Value) ? 0 : long.Parse(item.ToString());
        }

        public static bool ObterBoleano(object item)
        {
            return !Equals(item, DBNull.Value) && bool.Parse(item.ToString());
        }

        public static DateTime ObterData(object item)
        {
            DateTime.TryParse(item.ToString(), out _data);
            return _data;
        }
    }
}