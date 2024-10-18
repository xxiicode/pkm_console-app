using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases_pkm
{
    public abstract class Pokemon
    {
        private static Random random = new Random();
        private static int BayasRestantes = 3;

        public static void EscribirLinea(string text, int delay = 10)
        {
            foreach (char c in text)
            {
                Console.Write(c);
                Thread.Sleep(delay);
            }
            Console.WriteLine();
        }

        //Atributos
        public string? Nombre { get; set; }
        public string? Tipo { get; set; }
        public int? Nivel { get; set; }
        public int Vida { get; private set; }

        //Constructor
        public Pokemon(string nombre, string tipo, int nivel, int vida)
        {
            Nombre = nombre;
            Tipo = tipo;
            Nivel = nivel;
            Vida = vida;
        }

        //Metodos
        public abstract void Atacar(Pokemon enemigo);

        public void RecibirAtaque(int PuntosDeDaño)
        {
            Vida -= PuntosDeDaño;
            if (Vida <= 0)
            {
                EscribirLinea($"{Nombre} fue derrotado\n");
            } else
            {
                EscribirLinea($"{Nombre} recibio {PuntosDeDaño} puntos de daño");
                EscribirLinea($"{Nombre} ahora tiene {Vida} puntos de vida\n");
            }
        }

        public virtual void MostrarInformacion()
        {
            EscribirLinea($"{Nombre} ({Tipo}) - Nivel: {Nivel}, Vida: {Vida}");
        }

        public abstract void Hablar();

        public void ComerBaya()
        {
            
            if (BayasRestantes >= 1)
            {
                int curacion = random.Next(3, 25);
                EscribirLinea($"El pkm come una baya, se cura {curacion}");
                Vida += curacion;
                Hablar();
                EscribirLinea($"{Nombre} ahora tiene {Vida} puntos de vida \n");
                BayasRestantes -= 1;
            }
            else
            {
                EscribirLinea("No tienes mas ballas");
            }
        }
        public int ObtenerBayasRestantes()
        {
            return BayasRestantes;
        }
    }
}
