using Newtonsoft.Json;
using System;
using System.Security.Cryptography;
using System.Text;

namespace Fiver.Api.Concurrency.Lib
{
    public static class HashFactory
    {
        public static string GetHash(object model)
        {
            string result = string.Empty;
            var json = JsonConvert.SerializeObject(model);
            var bytes = Encoding.UTF8.GetBytes(json);

            using (var hasher = MD5.Create())
            {
                var hash = hasher.ComputeHash(bytes);
                result = BitConverter.ToString(hash);
                result = result.Replace("-", "");
            }

            return result;
        }
    }
}
