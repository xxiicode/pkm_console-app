using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases_pkm
{
    internal class Pikachu : Pokemon
    {
        private static Random random = new Random();
        //Constructor
        public Pikachu(int nivel, int vida) : base("Pikachu", "Electrico", nivel, vida)
        {
        }
        public override void Atacar(Pokemon enemigo)
        {
            int daño = random.Next(5, 15);
            EscribirLinea($"{Nombre} usa Impactrueno");
            enemigo.RecibirAtaque(daño);
        }
        public override void Hablar()
        {
            EscribirLinea("Pika Pika!");
        }
    }
}
