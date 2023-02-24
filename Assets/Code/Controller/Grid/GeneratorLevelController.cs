using System;
using UnityEngine;
using UnityEngine.Tilemaps;


namespace WORLDGAMEDEVELOPMENT
{
    public sealed class GeneratorLevelController : IAwake
    {
        private const int COUNT_WALL = 4;

        private Tilemap _tileMapGround;
        private Tile _tileGround;
        private int _widthMap;
        private int _heightMap;
        private int _factorSmooth;
        private int _randomFillPrecent;

        private int[,] _map;

        public GeneratorLevelController(GenerateLevelView levelView)
        {
            _tileMapGround = levelView.Tilemap;
            _tileGround = levelView.TileDirt;
            _widthMap = levelView.WidthMap;
            _heightMap = levelView.HeightMap;
            _factorSmooth = levelView.FactorSmooth;
            _randomFillPrecent = levelView.RandomFillPrecent;

            _map = new int[_widthMap, _heightMap];
        }

        private void GenerateLevel()
        {
            RandomFillLevel();
            for (var i = 0; i < _factorSmooth; i++)
            {
                SmoothMap();
            }
            DrawTilesOnMap();
        }

        private void DrawTilesOnMap()
        {
            if (_map == null)
            {
                return;
            }
            for (int x = 0; x < _widthMap; x++)
            {
                for (int y = 0; y < _heightMap; y++)
                {
                    var positionTile = new Vector3Int(-_widthMap/2 + x, -_heightMap/2 + y);
                    if (_map[x,y] == 1)
                    {
                        _tileMapGround.SetTile(positionTile, _tileGround);
                    }
                }
            }
        }

        private void SmoothMap()
        {
            for (var x = 0; x < _widthMap; x++)
            {
                for (int y = 0; y < _heightMap; y++)
                {
                    var neighbourWallTiles = GetSurroundingWallCount(x, y);
                    if (neighbourWallTiles > COUNT_WALL)
                    {
                        _map[x, y] = 1;
                    }
                    else if (neighbourWallTiles < COUNT_WALL)
                    {
                        _map[x, y] = 0;
                    }
                }
            }
        }

        private int GetSurroundingWallCount(int gridX, int gridY)
        {
            var wallCount = 0;
            for (int neighbourX = gridX - 1; neighbourX <= gridX +1; neighbourX++)
            {
                for (int neighbourY = gridY - 1; neighbourY <= gridY + 1; neighbourY++)
                {
                    if (neighbourX >= 0 && neighbourX < _widthMap && neighbourY >= 0 && neighbourY < _heightMap)
                    {
                        if (neighbourX != gridX || neighbourY != gridY)
                        {
                            wallCount += _map[neighbourX, neighbourY];
                        }
                        else
                        {
                            wallCount++;
                        }
                    }
                }
            }
            return wallCount;
        }

        private void RandomFillLevel()
        {
            var seed = Time.time.ToString();
            var pseudoRandom = new System.Random(seed.GetHashCode());

            for (var x = 0; x < _widthMap; x++)
            {
                for (var y = 0; y < _heightMap; y++)
                {
                    if (x == 0 || x == _widthMap - 1 || y == 0 || y == _heightMap - 1)
                    {
                        _map[x, y] = 1;
                    }
                    else
                    {
                        _map[x, y] = (pseudoRandom.Next(0, 100) < _randomFillPrecent) ? 1 : 0;
                    }
                }
            }
        }

        public void Awake()
        {
            GenerateLevel();
        }
    }
}