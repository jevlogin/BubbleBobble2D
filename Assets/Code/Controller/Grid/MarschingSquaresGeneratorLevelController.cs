using UnityEngine;
using UnityEngine.Tilemaps;


namespace WORLDGAMEDEVELOPMENT
{
    public sealed class MarschingSquaresGeneratorLevelController : MonoBehaviour
    {
        #region Fields
        
        private SquareGrid _squareGrid;
        private Tilemap _tilemapGround;
        private Tile _tileGround; 

        #endregion

        public void GenerateGrid(int[,] map, float squareSize)
        {
            _squareGrid = new SquareGrid(map, squareSize);
        }

        public void DrawTilesOnMap(Tilemap tilemapGround, Tile tileGround)
        {
            if (_squareGrid == null)
            {
                return;
            }

            _tilemapGround = tilemapGround;
            _tileGround = tileGround;

            for (int x = 0; x < _squareGrid.Squares.GetLength(0); x++)
            {
                for (int y = 0; y < _squareGrid.Squares.GetLength(1); y++)
                {
                    DrawTileInControlNode(_squareGrid.Squares[x, y].TopLeft.IsActive, _squareGrid.Squares[x, y].TopLeft.Position);
                    DrawTileInControlNode(_squareGrid.Squares[x, y].TopRight.IsActive, _squareGrid.Squares[x, y].TopRight.Position);
                    DrawTileInControlNode(_squareGrid.Squares[x, y].BottomLeft.IsActive, _squareGrid.Squares[x, y].BottomLeft.Position);
                    DrawTileInControlNode(_squareGrid.Squares[x, y].BottomRight.IsActive, _squareGrid.Squares[x, y].BottomRight.Position);
                }
            }

        }

        private void DrawTileInControlNode(bool isActive, Vector3 position)
        {
            if (isActive)
            {
                var positionTile = new Vector3Int((int)position.x, (int)position.y);
                _tilemapGround.SetTile(positionTile, _tileGround);
            }
        }
    }
}