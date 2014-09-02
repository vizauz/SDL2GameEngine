using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenTK;

namespace SDL2GameEngine
{
    class TileLayer : Layer
    {

        int                 _numColumns;
        int                 _numRows;
        int                 _tileSize;
        Vector2d            _position;
        Vector2d            _velocity;
        //List<List<int>>     _tilesIDs = new List<List<int>>();
        int[,]              _tilesIDs;
        List<Tileset>       _tilesets = new List<Tileset>();

        public int TileSize { get { return _tileSize; } set { _tileSize = value; } }
        

        public TileLayer(int tileSize, List<Tileset> tilesets)
        {
            _tileSize = tileSize;
            _tilesets = tilesets;
            _numColumns = Game.Instance.Width / _tileSize;
            _numRows = Game.Instance.Height / _tileSize;
        }

        public override void Render()
        {
            int x = (int)(_position.X / _tileSize);
            int y = (int)(_position.Y / _tileSize);
            int x2 = (int)_position.X % _tileSize;
            int y2 = (int)_position.Y % _tileSize;

            for (int i = 0; i < _numRows; i++)
            {
                for (int j = 0; j < _numColumns; j++)
                {
                    int id = _tilesIDs[i, j + x];
                    if (id == 0) continue;

                    Tileset tileset = GetTilesetByID(id);

                    id--;

                    TextureManager.Instance.DrawTile(
                        tileset._name,
                        tileset._margin,
                        tileset._spacing,
                        (j * _tileSize) - x2,
                        (i * _tileSize) - y2,
                        _tileSize, _tileSize,
                        (id - (tileset._firstGridID - 1)) / tileset._numColumns,
                        (id - (tileset._firstGridID - 1)) % tileset._numColumns,
                        Game.Instance.Renderer
                        );
                }
            }

        }

        public override void Update()
        {
            //_velocity.X = 1;
            _position += _velocity;
        }

        public void SetTileIDs(int[,] data)
        {
            _tilesIDs = data;
        }

        public Tileset GetTilesetByID(int id)
        {
            for (int i = 0; i < _tilesets.Count; i++)
            {
                if (i + 1 < _tilesets.Count)
                {
                    if (id >= _tilesets[i]._firstGridID && id < _tilesets[i + 1]._firstGridID)
                    {
                        return _tilesets[i];
                    }
                }
                else
                {
                    return _tilesets[i];
                }
            }

            Tileset t = new Tileset();
            return t;
        }
    }
}
