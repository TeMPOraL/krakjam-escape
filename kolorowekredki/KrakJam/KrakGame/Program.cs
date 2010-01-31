using System;

namespace KrakGame
{
    static class Program
    {
        static KrakGame m_game;
        public static KrakGame Game
        {
            get
            {
                return m_game;
            }
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using (m_game = new KrakGame())
            {
                m_game.Run();
            }
        }
    }
}

