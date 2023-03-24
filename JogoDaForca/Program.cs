using System.Xml;

namespace JogoDaForca
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] palavras = new string[30]{ "ABACATE", "ABACAXI", "ACEROLA", "AÇAÍ", "ARAÇA", "ABACATE", "BACABA", "BACURI", "BANANA", "CAJÁ", "CAJÚ", "CARAMBOLA", "CUPUAÇU", "GRAVIOLA", "GOIABA", "JABUTICABA", "JENIPAPO", "MAÇÃ", "MANGABA", "MANGA", "MARACUJÁ", "MURICI", "PEQUI", "PITANGA", "PITAYA", "SAPOTI", "TANGERINA", "UMBU", "UVA", "UVAIA" };
            Random numeroAleatorio = new Random();
            int gerarNumero = numeroAleatorio.Next(0,palavras.Length);                     
            int chances = 0, tentativas = 1, contadorLetraRepetida = 0;           
            string palavraEscolhida = palavras[gerarNumero];
            string underlines = "";
            char chuteUsuario;
            char[] resultado = underlines.PadLeft(palavraEscolhida.Length, '_').ToCharArray();
            bool errou;

            while(chances < 5)
            {
                Console.Clear();
                Console.WriteLine("------------------------");
                Console.WriteLine("     Jogo Da Forca!     ");
                Console.WriteLine("------------------------");
                Console.WriteLine("  ______________________");
                Console.WriteLine("   |/             |     ");
                Console.WriteLine("   |              |     ");
                Console.WriteLine("   |              {0}   ", (chances >= 1 ? "o" : " "));
                Console.WriteLine("   |             {0}    ", (chances >= 2 ? "/x\\" : " "));
                Console.WriteLine("   |              {0}   ", (chances >= 3 ? "x" : "  "));
                Console.WriteLine("   |             {0}    ", (chances >= 4 ? "/ \\" : " "));
                Console.WriteLine("   |                    ");
                Console.WriteLine("   |                    ");
                Console.WriteLine("   |                    ");
                Console.WriteLine(" __|\\____              ");
                Console.WriteLine($"\n\nA palavra secreta é: {new string (resultado)}");
                Console.WriteLine($"Lembre-se, a palavra sorteada tem {palavraEscolhida.Length} letras.");
                Console.WriteLine($"Você errou {chances} de 5.");
                Console.WriteLine($"Qual é seu {tentativas}° chute?");
                chuteUsuario = char.ToUpper(Convert.ToChar(Console.ReadLine()));

                errou = true;
                contadorLetraRepetida = 0;
                for (int i = 0; i < palavraEscolhida.Length; i++)
                {
                    if(chuteUsuario == resultado[i] && contadorLetraRepetida == 0)
                    {
                        Console.WriteLine($"A letra {chuteUsuario} já foi utilizada antes!");
                        contadorLetraRepetida++;
                        tentativas--;
                        Console.ReadLine();                      
                    }
                    if (chuteUsuario == palavraEscolhida[i])
                    {
                        resultado[i] = chuteUsuario;
                        errou = false;
                    }                                      
                }               
                if (errou)
                {
                    Console.WriteLine($"A letra {chuteUsuario} não existe dentro da palavra aleatória.\nEsse foi o erro N° {chances + 1} de 5.");
                    chances++;
                    Console.ReadLine();
                }
                if (resultado.SequenceEqual(palavraEscolhida.ToCharArray()))
                {
                    Console.WriteLine($"A palavra é {new string(resultado)}");
                    Console.WriteLine("Parabéns! Você acertou a palavra!");
                    Console.ReadLine();
                    break;
                }
                tentativas++;
            }
        }
    }
}