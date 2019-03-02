using System;
using System.Text;

namespace ProtectClient.Core.Protect
{
    /// <summary>
    /// Защита с помощью ключа активации(RSA)
    /// </summary>
    public class KeyProtectRsa : BaseProtect
    {
        private byte[] privateKey;
        private byte[] publicKey;
        private byte[] recognizedText;

        public KeyProtectRsa()
        {
            privateKey = null;
            publicKey = null;

            String instanceNumber = "1"; //Порядковый номер прогарммы
            String randomString = "5u>0uaW2"; //последовательность слайчаных символов

            recognizedText = Encoding.ASCII.GetBytes($"{instanceNumber} - {randomString}");
        }

        public override void init()
        {
            throw new NotImplementedException();
        }

        public override bool validate()
        {
            throw new NotImplementedException();
        }

        public String getProductNum()
        {
            return Encoding.ASCII.GetString(publicKey);
        }

        public bool activate(String encryptedText)
        {
            byte[] rawEncryptedText = Encoding.ASCII.GetBytes(encryptedText);
            
            return false;
        }
    }
}