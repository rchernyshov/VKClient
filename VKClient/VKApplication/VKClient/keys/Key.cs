using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VKClient.VKClasses
{
    public class Key
    {
        private static string ACCESS_TOKEN = "3543508335435083354350830a365118373354335435083568a1b28e1c91658a0bae049";
        private static string USER_ACCESS_TOKEN = "vk1.a.U1nqymS59GQXgiO6DxiYQa0CHxMHbn3z9nwWAAH8T3Ew4FJ_AUpG2HBd5IvlgA8BtutiPkHAFNTK41L7tADA8GcB49iiaYxWw2hnPrv2ZIpVmPjzCLoaFWFFyERqP2y2fGgZQZRhv-_aCuTb8m2XlrhD43ucNLZ-SIEqaLvHERudl6zDkgJT3BZWjg0aCAjbThbwYFWKpBD-InKv2MXcWw";
        private static string VERSION = "5.131";
        private static string SECURE_KEY = "nfTEtwsgMdvDUXihAwwt";
        private static string IDApplication = "51529908";

        public static string GetACCESS_TOKEN()
        { 
            return ACCESS_TOKEN;
        }
        public static string GetUSER_ACCESS_TOKEN()
        {
            return USER_ACCESS_TOKEN;
        }
        public static string GetVERSION()
        {
            return VERSION;
        }
        public static string GetSECURE_KEY()
        {
            return SECURE_KEY;
        }
        public static string GetIDApplication()
        {
            return IDApplication;
        }
    }
}
