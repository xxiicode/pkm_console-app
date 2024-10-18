using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases_pkm
{
    internal class Gengar : Pokemon
    {
        private static Random random = new Random();
        //Constructor
        public Gengar(int nivel, int vida) : base("Gengar", "Fantasma", nivel, vida)
        {
        }
        public override void Atacar(Pokemon enemigo)
        {
            int daño = random.Next(10, 18);
            EscribirLinea($"{Nombre} usa Lenguetazo");
            enemigo.RecibirAtaque(daño);
        }
        public override void Hablar()
        {
            EscribirLinea("Genga Gengar!");
        }
    }
}
