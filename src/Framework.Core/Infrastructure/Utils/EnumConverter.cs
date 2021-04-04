using System;

namespace Framework.Core.Infrastructure.Utils
{
    public class EnumConverter
    { 
        /// <summary>
        /// Convert string value to enum type
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumValue"></param>
        /// <returns></returns>
        public static T StringToEnum<T>(string enumValue) where T : struct
        {
            try
            {
                T res = (T)Enum.Parse(typeof(T), enumValue);
                if (!Enum.IsDefined(typeof(T), res)) return default(T);
                return res;
            }
            catch
            {
                return default(T);
            }
        }
    }
}
