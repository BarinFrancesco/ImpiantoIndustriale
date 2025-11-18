using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Impianto_Industriale.Program;

namespace Impianto_Industriale
{
    class CErroreMisurazioneTemperaturaEventArgs : EventArgs
    {
        
        public int temperatura { get; set; }
        public DateTime orario { get; set; }

        public CErroreMisurazioneTemperaturaEventArgs(int temperature, DateTime date)
        {
            temperatura = temperature;
            orario = date;
        }

    }

    class CErroreMisurazioneParticelleEventArgs : EventArgs
    {
        public int Nparticelle { get; set; }
        public DateTime orario { get; set; }

        public CErroreMisurazioneParticelleEventArgs(int value, DateTime date)
        {
            Nparticelle = value;
            orario = date;
        }

 
    }
}
