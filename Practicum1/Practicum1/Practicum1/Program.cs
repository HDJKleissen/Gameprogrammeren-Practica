using System;

namespace Practicum1
{
#if WINDOWS || XBOX
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using (Practicum1 game = new Practicum1())
            {
                game.Run();
            }
        }
    }
#endif
}

