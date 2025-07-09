using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Seguridad
{
    public static class Encriptador
    {
        private static readonly string clave = "clave-segura-123"; // debe tener 16, 24 o 32 caracteres
        public static string Encriptar(string textoPlano)
        {
            try
            {
                byte[] key = Encoding.UTF8.GetBytes(clave.PadRight(32).Substring(0, 32));
                using Aes aes = Aes.Create();
                aes.Key = key;
                aes.GenerateIV();
                byte[] iv = aes.IV;

                using var encryptor = aes.CreateEncryptor();
                using var ms = new MemoryStream();
                ms.Write(iv, 0, iv.Length); // almacenar IV al inicio
                using var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write);
                using var sw = new StreamWriter(cs);
                sw.Write(textoPlano);
                sw.Close();

                return Convert.ToBase64String(ms.ToArray());
            }
            catch (Exception ex)
            {

                throw new Exception("capa seguridad error al encriptar: "+ex.Message,ex);
            }
         
        }

        public static string Desencriptar(string textoEncriptado)
        {
            try
            {
                byte[] buffer = Convert.FromBase64String(textoEncriptado);
                byte[] key = Encoding.UTF8.GetBytes(clave.PadRight(32).Substring(0, 32));
                using Aes aes = Aes.Create();
                aes.Key = key;

                byte[] iv = new byte[16];
                Array.Copy(buffer, 0, iv, 0, iv.Length);
                aes.IV = iv;

                using var decryptor = aes.CreateDecryptor();
                using var ms = new MemoryStream(buffer, 16, buffer.Length - 16);
                using var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read);
                using var sr = new StreamReader(cs);
                return sr.ReadToEnd();
            }
            catch (Exception ex)
            {

                throw new Exception("capa seguridad error al desencriptar:"+ex.Message,ex);
            }
          
        }
    }
}

