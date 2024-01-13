using Criptografia.Assimetrica;
using Criptografia.Simetrica;
using System.Text;

public class Program
{
    private static async Task Main(string[] args)
    {
        //string nomeArquivo = $"LinkedIN {DateTime.Now:ddMMyyyyHHmmss}.txt";
        string nomeArquivo = "LinkedIN.txt";

        StringBuilder stringBuilder = new();

        stringBuilder.AppendLine("2ATV-RYWJ");
        stringBuilder.AppendLine("1K2P-XJ7E");
        stringBuilder.AppendLine("HJAZ-8S6J");
        stringBuilder.AppendLine("9B2U-MWY9");
        stringBuilder.AppendLine("P12Y-7XGR");
        stringBuilder.AppendLine("MSLX-HKUL");

        CriptografiaSimetrica criptografiaSimetrica = new();
        criptografiaSimetrica.Execute(nomeArquivo, stringBuilder.ToString());

        DescriptografiaSimetrica descriptografiaSimetricaSimetrica = new();
        string mensagemDescriptografada = await descriptografiaSimetricaSimetrica.Execute(nomeArquivo);

        Console.WriteLine(mensagemDescriptografada);
        Console.WriteLine("Resultado adicionado a área de transferência.");

        

        CriptografiaAssimetrica criptografiaAssimetrica = new();
        criptografiaAssimetrica.Execute();


        Console.ReadKey();
    }
}