using System;

namespace Dickman_Logan_GameChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            Game g = new Game();
            g.Init();
            while (g.Update())
            {
                //game is running
            }
        }//turns, bosses, etc
    }
}
