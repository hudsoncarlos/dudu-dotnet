using System.Security.Cryptography;

namespace Criptografia.Simetrica;

public class CriptografiaSimetrica
{
    public void Execute(string nomeArquivo, string mensagem)
    {
        try
        {
            using FileStream fileStream = new(nomeArquivo, FileMode.OpenOrCreate);

            using Aes aes = Aes.Create();

            byte[] key =
            {
                0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08,
                0x09, 0x10, 0x11, 0x12, 0x13, 0x14, 0x15, 0x16
            };
            aes.Key = key;

            byte[] iv = aes.IV;
            fileStream.Write(iv, 0, iv.Length);

            using CryptoStream cryptoStream = new(
                fileStream,
                aes.CreateEncryptor(),
                CryptoStreamMode.Write);

            // Por padrão, o StreamWriter usa codificação UTF-8.
            // Para alterar a codificação do texto, passe a codificação desejada como segundo parâmetro.
            // Por exemplo, novo StreamWriter(cryptoStream, Encoding.Unicode).
            using StreamWriter encryptWriter = new(cryptoStream);

            //encryptWriter.WriteLine("Hello World!");
            encryptWriter.WriteLine(mensagem);

            Console.WriteLine("O arquivo foi criptografado.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"A criptografia falhou. {ex}");
        }
    }
}