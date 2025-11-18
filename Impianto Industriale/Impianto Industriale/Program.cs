using static System.Console;
namespace Impianto_Industriale
{
    internal class Program
    {
        public delegate void ErroreMisurazioneTemperaturaEventHandler(Object sender, CErroreMisurazioneTemperaturaEventArgs e);
        public delegate void ErroreMisurazioneParticelleEventHandler(Object sender, CErroreMisurazioneParticelleEventArgs e);

        static int ContoErroriTemperatura = 0;
        static int ContoErroriParticelle = 0;

        static void Main(string[] args)
        {
            Random random = new Random();

            CTermometro Termometro1 = new CTermometro(-50,500);
            Cparticelle Rilevatore1 = new Cparticelle(5000);

            Termometro1.ErroreRilevato += ErroreTermometro;
            Rilevatore1.ErroreRilevato += ErroreRilevatore;
            int count = 0;

            while (count < 150)
            {
                Termometro1.Measure();
                Rilevatore1.Measure();

                WriteLine("------------------------------------------------------------------------");
                WriteLine($"Valori dell'impianto: \nTemperatura {Termometro1.temperatura}° \nEsalazioni: {Rilevatore1.NumParticelle}ppm ");
                WriteLine("------------------------------------------------------------------------");
                Thread.Sleep(250);
                count++;
            }

            WriteLine($"Sono stati rilevati {ContoErroriTemperatura} errori nella misurazione della temperatura, e {ContoErroriParticelle} errori nella misurazione delle particelle");
            
        }

        static void ErroreTermometro(Object sender, CErroreMisurazioneTemperaturaEventArgs e)
        {
            ForegroundColor = ConsoleColor.Red;
            WriteLine($"È stata rilevata la temperatura anomala di {e.temperatura}°. {e.orario.Date} ore:{e.orario.Minute}");
            ResetColor();
            ContoErroriTemperatura++;
        }

        static void ErroreRilevatore(Object sender, CErroreMisurazioneParticelleEventArgs e)
        {
            ForegroundColor = ConsoleColor.Red;
            WriteLine($"È stato rilevato un valore anomalo di {e.Nparticelle}ppm. {e.orario.Date} ore:{e.orario.Minute}");
            ResetColor();
            ContoErroriParticelle++;
        }


    }
}