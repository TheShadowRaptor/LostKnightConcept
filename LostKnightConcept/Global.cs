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

        private const int mapRenderSizeDataX = 15;
        private const int mapRenderSizeDataY = 30;

        public string winFile;
        public string mapFile;
        public string titleFile;
        public string gameoverFile;

        public int mapRenderSizeX;
        public int mapRenderSizeY;

        public Global()
        {
            winFile = winData;
            mapFile = mapData;
            titleFile = titleData;
            gameoverFile = gameoverData;

            mapRenderSizeX = mapRenderSizeDataX;
            mapRenderSizeY = mapRenderSizeDataY;
        }
    }
}
