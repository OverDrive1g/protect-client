using System;
using System.Security.Cryptography;
using System.Text;

namespace ProtectClient.Core.Protect
{
    /// <summary>
    /// Защита с помощью ключа активации(RSA)
    /// </summary>
    public class KeyProtectRsa : BaseProtect
    {
        private byte[] publicKey;
        private byte[] exponent;
        
        private byte[] recognizedData;

        public KeyProtectRsa()
        {
            String instanceNumber = "1"; //Порядковый номер прогарммы
            String randomString = "5u>0uaW2"; //последовательность слайчаных символов

            recognizedData = Encoding.Unicode.GetBytes($"{instanceNumber} - {randomString}");
        }

        public override void init()
        {
            throw new NotImplementedException();
        }

        public override bool validate()
        {
            throw new NotImplementedException();
        }

        public RSAParameters getPublicKey()
        {
            RSACryptoServiceProvider provider = new RSACryptoServiceProvider();
            provider.ImportParameters(getCryptoParameters());
            return provider.ExportParameters(false);
        }

        private RSAParameters getPrivateKey()
        {
            RSACryptoServiceProvider provider = new RSACryptoServiceProvider();
            provider.ImportParameters(getCryptoParameters());
            return provider.ExportParameters(true);
        }

        public bool activate(byte[] encryptedText)
        {
            var cryptoProvider = new RSACryptoServiceProvider();
            cryptoProvider.ImportParameters(getPrivateKey());
            
            var decryptedString = cryptoProvider.Decrypt(encryptedText, false);
            
            return Encoding.Unicode.GetString(decryptedString) == Encoding.Unicode.GetString(recognizedData);
        }

        private static RSAParameters getCryptoParameters()
        {
            //FIXME очень захардкоженый код, над шот с этим делать
            return new RSAParameters
            {
                D = new byte[]{4,49,192,18,91,221,176,36,197,28,176,199,32,228,58,114,30,2,166,219,3,177,172,93,223,235,71,83,83,238,114,187,104,169,123,161,118,181,69,154,66,138,6,149,231,228,161,109,91,55,93,200,90,19,15,247,105,75,208,77,11,34,101,175,136,90,5,51,92,44,172,65,220,154,83,97,226,17,77,101,62,129,65,92,98,161,0,158,13,213,199,13,183,70,25,163,184,202,101,89,90,132,104,44,14,191,167,70,96,167,109,35,20,132,248,87,121,58,103,226,167,151,68,40,197,168,117,233},
                DP = new byte[]{3,176,129,211,114,94,8,136,199,146,208,14,106,100,4,43,24,190,8,61,1,130,45,252,247,41,178,194,9,58,248,99,104,59,58,224,234,67,32,189,106,167,55,24,99,197,106,123,198,41,103,44,147,88,159,222,163,234,1,151,84,182,118,179},
                DQ = new byte[]{117,139,181,61,98,35,215,158,48,34,94,90,193,75,136,125,167,37,40,219,184,190,250,37,218,95,21,240,10,125,191,9,75,79,212,175,45,56,236,206,64,225,56,182,24,97,127,51,158,183,8,203,80,82,191,184,17,172,11,35,208,203,46,175},
                Exponent = new byte[]{1,0,1},
                InverseQ = new byte[]{168,108,83,244,15,183,93,246,24,91,78,173,85,53,168,35,195,207,123,254,254,117,34,145,211,94,34,87,90,147,224,129,39,41,127,155,207,99,225,36,240,212,199,159,185,242,10,88,252,170,239,219,108,216,224,231,38,220,105,232,236,55,215,210},
                Modulus = new byte[]{153,145,14,154,114,253,255,199,139,129,215,237,238,190,249,193,181,189,195,153,100,127,1,240,5,226,183,111,41,40,35,187,214,93,220,97,149,252,156,173,237,188,21,186,143,243,154,116,203,47,233,19,183,67,130,127,192,99,196,160,171,138,69,128,141,161,166,104,202,224,197,193,187,206,18,123,138,65,50,245,168,59,22,55,48,23,132,71,123,119,30,205,234,177,255,237,123,87,250,192,98,250,113,87,104,100,92,158,248,175,143,139,242,197,6,31,227,52,171,32,77,110,133,143,37,21,185,181},
                P = new byte[]{198,174,233,123,132,159,163,49,224,92,122,67,104,55,58,236,53,63,26,23,129,157,222,149,151,205,235,84,89,102,200,85,244,90,175,119,22,240,3,122,237,213,8,246,75,175,178,215,29,232,76,252,28,220,73,12,93,136,106,76,161,237,201,51},
                Q = new byte[]{197,222,53,38,72,210,243,74,58,97,74,245,218,19,50,225,180,106,32,128,92,193,213,226,42,12,157,23,251,185,126,214,247,25,4,245,56,233,38,146,140,232,71,164,28,2,46,39,75,69,220,66,39,230,97,237,28,136,9,133,47,44,1,119},
            };
        }
    }
}