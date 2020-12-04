using System;

namespace Astrofinder
{
    /// <summary>
    /// 
    /// </summary>
    public class InteractiveClient
    {
        private ConsoleClient cc;
        private Handler handler;

        /// <summary>
        /// 
        /// </summary>
        public InteractiveClient()
        {
            cc = new ConsoleClient();
            handler = new Handler();
        }

        /// <summary>
        /// 
        /// </summary>
        public void MainLoop()
        {
            cc.StartingMessage();

            LoadNewFile();

            cc.MainMenu();

            while (true)
            {
                switch (cc.Input.ToLower())
                {
                    case "sp":
                        SearchPlanet();
                        continue;
                    case "ss":
                        SearchStar();
                        continue;
                    case "l":
                        LoadNewFile();
                        continue;
                    case "r":
                        cc.EndMessage();
                        break;
                    case "q":
                        cc.EndMessage();
                        break;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void LoadNewFile()
        {
            cc.LoadMessage();

            while (true)
            {
                // Very rudimentary.
                try
                {
                    handler.ReadFile(cc.Input);
                }
                catch (Exception i)
                {
                    cc.FileLoad(false);
                    continue;
                }

                cc.FileLoad(true);
                break;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void SearchPlanet()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        public void SearchStar()
        {
            
        }

    }
}