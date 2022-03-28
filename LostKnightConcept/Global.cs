using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LostKnightConcept
{
    class Global
    {
        private const string winData = "Win.txt";
        private const string mapData = "Map.txt";
        private const string titleData = "Title.txt";
        private const string gameoverData = "Gameover.txt";

        public string winFile;
        public string mapFile;
        public string titleFile;
        public string gameoverFile;

        public Global()
        {
            winFile = winData;
            mapFile = mapData;
            titleFile = titleData;
            gameoverFile = gameoverData;
        }
    }
}
