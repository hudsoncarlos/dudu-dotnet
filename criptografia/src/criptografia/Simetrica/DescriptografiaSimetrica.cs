using System.Security.Cryptography;

namespace Criptografia.Simetrica;

public class DescriptografiaSimetrica
{
    public async Task<string> Execute(string nomeArquivo)
    {
        try
        {
            using FileStream fileStream = new(nomeArquivo, FileMode.OpenOrCreate);

            using Aes aes = Aes.Create();

            byte[] iv = new byte[aes.IV.Length];
            int numBytesToRead = aes.IV.Length;
            int numBytesRead = 0;
            while (numBytesToRead > 0)
            {
                int n = fileStream.Read(iv, numBytesRead, numBytesToRead);
                if (n == 0) break;

                numBytesRead += n;
                numBytesToRead -= n;
            }

            byte[] key =
            {
                0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08,
                0x09, 0x10, 0x11, 0x12, 0x13, 0x14, 0x15, 0x16
            };

            using CryptoStream cryptoStream = new(
               fileStream,
               aes.CreateDecryptor(key, iv),
               CryptoStreamMode.Read);

            // Por padrão, o StreamReader usa codificação UTF-8.
            // Para alterar a codificação do texto, passe a codificação desejada como segundo parâmetro.
            // Por exemplo, novo StreamReader(cryptoStream, Encoding.Unicode).
            using StreamReader decryptReader = new(cryptoStream);

            string decryptedMessage = await decryptReader.ReadToEndAsync();

            return decryptedMessage;
        }
        catch (Exception ex)
        {
            return $"A descriptografia falhou. {ex}";
        }
    }
}
