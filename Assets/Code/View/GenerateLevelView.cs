using UnityEngine;
using UnityEngine.Tilemaps;


namespace WORLDGAMEDEVELOPMENT
{
    public sealed class GenerateLevelView : MonoBehaviour
    {
        #region Fields
        [SerializeField] private Tilemap _tilemap;
        [SerializeField] private Tile _tileDirt;
        [SerializeField] private int _widthMap;
        [SerializeField] private int _heightMap;
        [SerializeField] private int _factorSmooth;
        [SerializeField, Range(0, 100)] private int _randomFillPrecent;

        #endregion

        
        #region Properties
        
        public Tilemap Tilemap => _tilemap;
        public Tile TileDirt => _tileDirt;
        public int WidthMap => _widthMap;
        public int HeightMap => _heightMap;
        public int FactorSmooth => _factorSmooth;
        public int RandomFillPrecent => _randomFillPrecent; 

        #endregion
    }
}