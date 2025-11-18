using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Impianto_Industriale.Program;

namespace Impianto_Industriale
{
    class Cparticelle
    {
        public event ErroreMisurazioneParticelleEventHandler ErroreRilevato;
        public int NumParticelle { get; private set; }
        int Max;
        Random random = new Random();
        public Cparticelle( int max)
        {
            Max = max;
        }

        public int Measure()
        {
            NumParticelle = random.Next(Max);
            if (NumParticelle > 4500)
            {
                CErroreMisurazioneParticelleEventArgs argomenti = new CErroreMisurazioneParticelleEventArgs(NumParticelle, DateTime.Now);
                ParticelleAnomaleRilevate(argomenti);
            }
            return NumParticelle;
        }

        protected void ParticelleAnomaleRilevate(CErroreMisurazioneParticelleEventArgs e)
        {
            ErroreMisurazioneParticelleEventHandler Handler = ErroreRilevato;
            if (Handler != null)
            {
                Handler(this, e);
            }
        }
    }
}
