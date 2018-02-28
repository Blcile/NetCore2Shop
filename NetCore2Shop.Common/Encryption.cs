using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace NetCore2Shop.Common
{
    public class Encryption
    {
        private const string ENCRYPT_KEY = "netcore2";

        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string EncryptText(string str)
        {
            return Encrypt(str, ENCRYPT_KEY);
        }

        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="str"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string EncryptText(string str, string key)
        {
            return Encrypt(str, key);
        }

        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string DecrpytText(string str)
        {
            return Decrpyt(str, ENCRYPT_KEY);
        }

        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="str"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string DecrpytText(string str, string key)
        {
            return Decrpyt(str, key);
        }

        /// <summary>
        /// 解密函数
        /// </summary>
        /// <param name="str"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        private static string Decrpyt(string str, string key)
        {
            byte[] byKey = { };
            byte[] IV = {0x01, 0x23, 0x45, 0x67, 0x89, 0xAB, 0xCD, 0xEF};
            byte[] inputByteArray = new byte[str.Length];

            byKey = Encoding.UTF8.GetBytes(key.Substring(0, 8));
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            inputByteArray = Convert.FromBase64String(str);
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(byKey, IV), CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            Encoding encoding = Encoding.UTF8;
            return encoding.GetString(ms.ToArray());
        }

        /// <summary>
        /// 加密函数
        /// </summary>
        /// <param name="str"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        private static string Encrypt(string str, string key)
        {
            byte[] byKey = { };
            byte[] IV = {0x01, 0x23, 0x45, 0x67, 0x89, 0xAB, 0xCD, 0xEF};

            byKey = Encoding.UTF8.GetBytes(key.Substring(0, 8));
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            byte[] inputByteArray = Encoding.UTF8.GetBytes(str);
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(byKey, IV), CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            return Convert.ToBase64String(ms.ToArray());
        }
    }
}
