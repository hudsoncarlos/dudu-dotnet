using System.Security.Cryptography;

namespace Criptografia.Assimetrica;

public class CriptografiaAssimetrica
{
    public void Execute()
    {
        try
        {
            // Inicializa as matrizes de bytes com as informações da chave pública.
            byte[] modulus =
            {
                214,46,220,83,160,73,40,39,201,155,19,202,3,11,191,178,56,
                74,90,36,248,103,18,144,170,163,145,87,54,61,34,220,222,
                207,137,149,173,14,92,120,206,222,158,28,40,24,30,16,175,
                108,128,35,230,118,40,121,113,125,216,130,11,24,90,48,194,
                240,105,44,76,34,57,249,228,125,80,38,9,136,29,117,207,139,
                168,181,85,137,126,10,126,242,120,247,121,8,100,12,201,171,
                38,226,193,180,190,117,177,87,143,242,213,11,44,180,113,93,
                106,99,179,68,175,211,164,116,64,148,226,254,172,147
            };

            byte[] exponent = { 1, 0, 1 };

            // Cria valores para armazenar chaves simétricas criptografadas.
            byte[] encryptedSymmetricKey;
            byte[] encryptedSymmetricIV;

            // Cria uma nova instância da classe RSA.
            RSA rsa = RSA.Create();

            // Cria uma nova instância da estrutura RSAParameters.
            RSAParameters rsaKeyInfo = new()
            {
                // Defina rsaKeyInfo para os valores de chave pública.
                Modulus = modulus,
                Exponent = exponent
            };

            // Importa parâmetros-chave para rsa.
            rsa.ImportParameters(rsaKeyInfo);

            //Create a new instance of the default Aes implementation class.
            using Aes aes = Aes.Create();

            byte[] key =
            {
                0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08,
                0x09, 0x10, 0x11, 0x12, 0x13, 0x14, 0x15, 0x16
            };
            aes.Key = key;

            // Criptografa a chave simétrica e IV.
            encryptedSymmetricKey = rsa.Encrypt(aes.Key, RSAEncryptionPadding.Pkcs1);
            encryptedSymmetricIV = rsa.Encrypt(aes.IV, RSAEncryptionPadding.Pkcs1);


            //------------------------------------------------------------------------

            // Cria uma nova instância da classe RSA.
            //rsa = RSA.Create();

            // Exporta as informações da chave pública e envia-as para terceiros.
            // Espere que terceiros criptografem alguns dados e os enviem de volta.

            // Descriptografa a chave simétrica e IV.
            var symmetricKey = rsa.Decrypt(encryptedSymmetricKey, RSAEncryptionPadding.Pkcs1);
            var symmetricIV = rsa.Decrypt(encryptedSymmetricIV, RSAEncryptionPadding.Pkcs1);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"A criptografia falhou. {ex}");
        }
    }
}