using System;
using System.Collections.Generic;

namespace Clases_pkm
{
    internal class Program
    {
        public static void EscribirLinea(string text, int delay = 10)
        {
            foreach (char c in text)
            {
                Console.Write(c);
                Thread.Sleep(delay);
            }
            Console.WriteLine();
        }


        private static void Main(string[] args)
        {
            // Crear Pokémon del jugador
            List<Pokemon> pokemonsDelJugador = new List<Pokemon>
            {
                new Pikachu(1, 25),
                new Gengar(1, 30),
                new Mew(1, 40)
            };

            // Crear un enemigo
            Enemigo enemigo = new Enemigo();


            // Iniciar la batalla
            Console.WriteLine(@"                                  ,'\     
    _.----.        ____         ,'  _\   ___    ___     ____
_,-'       `.     |    |  /`.   \,-'    |   \  /   |   |    \  |`.
\      __    \    '-.  | /   `.  ___    |    \/    |   '-.   \ |  |
 \.    \ \   |  __  |  |/    ,','_  `.  |          | __  |    \|  |
   \    \/   /,' _`.|      ,' / / / /   |          ,' _`.|     |  |
    \     ,-'/  /   \    ,'   | \/ / ,`.|         /  /   \  |     |
     \    \ |   \_/  |   `-.  \    `'  /|  |    ||   \_/  | |\    |
      \    \ \      /       `-.`.___,-' |  |\  /| \      /  | |   |
       \    \ `.__,'|  |`-._    `|      |__| \/ |  `.__,'|  | |   |
        \_.-'       |__|    `-._ |              '-.|     '-.| |   |
                                `'                            '-._|v.0.2");

            EscribirLinea("¡Bienvenido a la batalla Pokémon del Gimnasio 14\n");

            // Seleccionar Pokémon
            EscribirLinea("Elige tu Pokémon:");
            for (int i = 0; i < pokemonsDelJugador.Count; i++)
            {
                EscribirLinea($"{i + 1}. {pokemonsDelJugador[i].Nombre}");
            }

            int pokemonElejidoIndex;
            while (true)
            {
                Console.Write("Selecciona el número de tu Pokémon: ");
                if (int.TryParse(Console.ReadLine(), out pokemonElejidoIndex) && pokemonElejidoIndex > 0 && pokemonElejidoIndex <= pokemonsDelJugador.Count)
                {
                    break;
                }
                EscribirLinea("Selección inválida. Intenta de nuevo.");
            }

            Pokemon pokemonActivo = pokemonsDelJugador[pokemonElejidoIndex - 1];

            EscribirLinea($"Has elegido a {pokemonActivo.Nombre} para luchar.");
            pokemonActivo.Hablar();
            Pokemon pokemonEnemigo = enemigo.Pokemons[enemigo.pokemonActualIndex];
            EscribirLinea($"El enemigo ha elegido a {pokemonEnemigo.Nombre} para luchar.");
            pokemonEnemigo.Hablar();

            // Simulación de combate
            while (true)
            {
                // Mostrar menú de acciones
                EscribirLinea("\n¿Qué deseas hacer?");
                EscribirLinea("1. Atacar");
                EscribirLinea($"2. Comer Baya({pokemonActivo.ObtenerBayasRestantes()})");
                EscribirLinea("3. Cambiar Pokémon");

                int accion;
                while (true)
                {
                    Console.Write("Selecciona una acción: ");
                    if (int.TryParse(Console.ReadLine(), out accion) && accion >= 1 && accion <= 3)
                    {
                        break;
                    }
                    EscribirLinea("Selección inválida. Intenta de nuevo.");
                }

                // Ejecutar acción
                if (accion == 1) // Atacar
                {
                    pokemonActivo.Atacar(enemigo.Pokemons[enemigo.pokemonActualIndex]);

                    // Verificar si el Pokémon enemigo fue derrotado
                    if (enemigo.Pokemons[enemigo.pokemonActualIndex].Vida <= 0)
                    {
                        EscribirLinea($"{enemigo.Pokemons[enemigo.pokemonActualIndex].Nombre} ha sido derrotado.");
                        enemigo.pokemonActualIndex++; // Cambiar al siguiente Pokémon

                        // Verificar si hay más Pokémon para usar
                        if (enemigo.pokemonActualIndex >= enemigo.Pokemons.Count)
                        {
                            EscribirLinea("¡El enemigo ha perdido todos sus Pokémon! ¡Has ganado!");
                            EscribirLinea("¡Felicidades, toca una tecla para cerrar el programa");
                            Console.ReadKey();
                            break;
                        }
                        else
                        {
                            EscribirLinea($"El enemigo cambia a {enemigo.Pokemons[enemigo.pokemonActualIndex].Nombre}.");
                        }
                    }
                }
                else if (accion == 2) // ComerBalla
                {
                    pokemonActivo.ComerBaya();
                }
                else if (accion == 3) // Cambiar Pokémon
                {
                    EscribirLinea("Elige tu nuevo Pokémon:");
                    for (int i = 0; i < pokemonsDelJugador.Count; i++)
                    {
                        EscribirLinea($"{i + 1}. {pokemonsDelJugador[i].Nombre} - Vida: {pokemonsDelJugador[i].Vida}");
                    }

                    while (true)
                    {
                        Console.Write("Selecciona el número de tu nuevo Pokémon: ");
                        if (int.TryParse(Console.ReadLine(), out pokemonElejidoIndex) && pokemonElejidoIndex > 0 && pokemonElejidoIndex <= pokemonsDelJugador.Count)
                        {
                            if (pokemonsDelJugador[pokemonElejidoIndex - 1].Vida > 0)
                            {
                                pokemonActivo = pokemonsDelJugador[pokemonElejidoIndex - 1];
                                EscribirLinea($"Has cambiado a {pokemonActivo.Nombre}.");
                                break;
                            }
                            else
                            {
                                EscribirLinea("Este Pokémon está derrotado. Elige otro.");
                            }
                        }
                        else
                        {
                            EscribirLinea("Selección inválida. Intenta de nuevo.");
                        }
                    }
                }

                // El enemigo ataca al Pokémon del jugador
                enemigo.Atacar(pokemonActivo);
                // Verificar si el Pokémon del jugador fue derrotado
                if (pokemonActivo.Vida <= 0)
                {
                    EscribirLinea($"{pokemonActivo.Nombre} ha sido derrotado.");
                    // Verificar si quedan más Pokémon
                    bool hayPokemonVivo = false;
                    foreach (var pkm in pokemonsDelJugador)
                    {
                        if (pkm.Vida > 0)
                        {
                            hayPokemonVivo = true;
                            break;
                        }
                    }

                    if (!hayPokemonVivo)
                    {
                        EscribirLinea("¡Has perdido! No te quedan Pokémon.");
                        EscribirLinea("¡Game Over!, toca una tecla para cerrar");
                        Console.ReadKey();
                        break; // Terminar la batalla
                    }

                    // Ofrecer la opción de cambiar Pokémon
                    EscribirLinea("Selecciona un nuevo Pokémon:");
                    for (int i = 0; i < pokemonsDelJugador.Count; i++)
                    {
                        if (pokemonsDelJugador[i].Vida > 0)
                        {
                            EscribirLinea($"{i + 1}. {pokemonsDelJugador[i].Nombre} - Vida: {pokemonsDelJugador[i].Vida}");
                        }
                    }

                    while (true)
                    {
                        Console.Write("Selecciona el número de tu nuevo Pokémon: ");
                        if (int.TryParse(Console.ReadLine(), out pokemonElejidoIndex) && pokemonElejidoIndex > 0 && pokemonElejidoIndex <= pokemonsDelJugador.Count)
                        {
                            if (pokemonsDelJugador[pokemonElejidoIndex - 1].Vida > 0)
                            {
                                pokemonActivo = pokemonsDelJugador[pokemonElejidoIndex - 1];
                                EscribirLinea($"Has cambiado a {pokemonActivo.Nombre}.");
                                break;
                            }
                            else
                            {
                                EscribirLinea("Este Pokémon está derrotado. Elige otro.");
                            }
                        }
                        else
                        {
                            EscribirLinea("Selección inválida. Intenta de nuevo.");
                        }
                    }
                }
            }
        }
    }
}
            

                // Imprimir el estado de los Pokémon

