﻿using System.Security.Cryptography;
using System.Text;

namespace ApolloDb
{
    public class HashPassword
    {
        public static string Run(string password)
        {
            MD5 md5Hasher = MD5.Create();
            byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(password));

            var stringBuilder = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
                stringBuilder.Append(data[i].ToString("x2"));


            return stringBuilder.ToString();
        }
    }
}
