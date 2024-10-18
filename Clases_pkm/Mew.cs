using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases_pkm
{
    internal class Mew : Pokemon
    {
        private static Random random = new Random();
        //Constructor
        public Mew(int nivel, int vida) : base("Mew", "Psiquico", nivel, vida)
        {
        }
        //Metodos
        public override void Atacar(Pokemon enemigo)
        {
            int daño = random.Next(15, 30);
            EscribirLinea($"{Nombre} usa Psicoataque");
            enemigo.RecibirAtaque(daño);
        }
        public override void Hablar()
        {
            EscribirLinea("Mewwwww!");

        }    
    }
}

