using System;
using System.Security.Cryptography;
using System.Text;


namespace OpenSquare.Core.Utils
{

    public class Cryptography
    {
        public string CypherValueByProjectConfiguration(string value, string saltValue)
        {
            saltValue = (saltValue == null) ? string.Empty : saltValue;
                string strSenhaHash = "";
                SHA512 alg = SHA512.Create();

                if (saltValue.Length > 0)
                    value = string.Concat(saltValue.Substring(0, 18), value, saltValue.Substring(18));

                byte[] result = alg.ComputeHash(Encoding.ASCII.GetBytes(value));
                byte[] arrSenhaHash = alg.ComputeHash(result);

                //Convertendo para hexa
                foreach (byte b in result)
                {
                    strSenhaHash += String.Format("{0:x2}", b);
                }
                int qtd = Convert.ToInt32(strSenhaHash.Length);

                return strSenhaHash;
          
        }
    }
}

