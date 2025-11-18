using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Impianto_Industriale.Program;

namespace Impianto_Industriale
{
    class CTermometro
    {
        public event ErroreMisurazioneTemperaturaEventHandler ErroreRilevato;
        public int temperatura { get; private set; }
        int Min;
        int Max;
        Random random = new Random();
        public CTermometro(int min, int max)
        {
            Min = min;
            Max = max;
        }

        public int Measure()
        {
            temperatura = random.Next(Min, Max);

            if(temperatura > 350 || temperatura<50)
            {
                CErroreMisurazioneTemperaturaEventArgs argomenti = new CErroreMisurazioneTemperaturaEventArgs(temperatura, DateTime.Now);
                TemperaturaAnomalaRilevata(argomenti);
            }
            return temperatura;
        }

        protected void TemperaturaAnomalaRilevata(CErroreMisurazioneTemperaturaEventArgs e)
        {
            ErroreMisurazioneTemperaturaEventHandler handler = ErroreRilevato;
            if (handler != null)
            {
                handler(this, e);
            }
        }
    }
}
