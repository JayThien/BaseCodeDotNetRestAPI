using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDomain.Entities
{
    public enum Country
    {
        Vietnam,
        Thailand,
        HongKong,
        Philippines,
        CzechRepublic,
        Slovakia,
    }

    public static class CountryMapper
    {
        public static string ToCode(Country country)
        {
            switch(country)
            {
                case Country.Vietnam: return "vn";
                case Country.Thailand: return "th";
                case Country.HongKong: return "hk";
                case Country.Philippines: return "ph";
                case Country.CzechRepublic: return "cz";
                case Country.Slovakia: return "sl";
            }
            return "";
        }
    }
}
