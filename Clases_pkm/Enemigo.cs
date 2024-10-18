using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases_pkm
{

    // Clases de Pokémon del enemigo
    internal class Rattata : Pokemon
    {
        private static Random random = new Random();
        public Rattata(int nivel, int vida) : base("Rattata", "Normal", nivel, vida) { }

        public override void Atacar(Pokemon enemigo)
        {
            int daño = random.Next(5, 15);
            Console.WriteLine($"{Nombre} usa Mordisco");
            enemigo.RecibirAtaque(daño);
        }

        public override void Hablar()
        {
            Console.WriteLine("¡RRRRRattata!");
        }
    }

    internal class Graveler : Pokemon
    {
        private static Random random = new Random();
        public Graveler(int nivel, int vida) : base("Graveler", "Roca/Tierra", nivel, vida) { }

        public override void Atacar(Pokemon enemigo)
        {
            int daño = random.Next(5, 15);
            Console.WriteLine($"{Nombre} usa Rodar");
            enemigo.RecibirAtaque(daño);
        }

        public override void Hablar()
        {
            Console.WriteLine("¡Gravelerrrr!");
        }
    }

    internal class Kadabra : Pokemon
    {
        private static Random random = new Random();
        public Kadabra(int nivel, int vida) : base("Kadabra", "Psíquico", nivel, vida) { }

        public override void Atacar(Pokemon enemigo)
        {
            int daño = random.Next(5, 15);
            Console.WriteLine($"{Nombre} usa Psíquico");
            enemigo.RecibirAtaque(daño);
        }

        public override void Hablar()
        {
            Console.WriteLine("¡Kadabra!");
        }
    }

    // Clase Enemigo
    public class Enemigo
    {
        private static Random random = new Random();
        public List<Pokemon> Pokemons { get; private set; }
        public int pokemonActualIndex;

        public Enemigo()
        {
            Pokemons = new List<Pokemon>
            {
                new Rattata(1, 30), // nivel y vida
                new Graveler(2, 40),
                new Kadabra(5, 65)
            };
            pokemonActualIndex = 0;
        }

        // Método para que el enemigo ataque al Pokémon del jugador
        public void Atacar(Pokemon jugadorPokemon)
        {
            // Obtener el Pokémon actual del enemigo
            Pokemon enemigoPokemon = Pokemons[pokemonActualIndex];

            // Realizar el ataque
            enemigoPokemon.Atacar(jugadorPokemon);
            }
        }
    }