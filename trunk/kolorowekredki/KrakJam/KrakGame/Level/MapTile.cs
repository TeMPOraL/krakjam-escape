using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using UglyFramework;
using System.Xml.Serialization;

namespace KrakGame
{
    public enum TileType
    {
        Wall,
        Spike
    }

    public class MapTile
    {
      

        public TileType TileType
        {
            get;
            set;
        }

        public Vector2 Position
        {
            get;
            set;
        }

        [XmlIgnore]
        public Vector2 WorldPosition
        {
            get;
            set;
        }

        public Vector2 TileSize
        {
            get;
            set;
        }

        public string TextureFile
        {
            get;
            set;
        }

        [XmlIgnore]
        public Texture2D TileTexture
        {
            get;
            set;
        }

        public MapTile()
        {
        }

        public void LoadComponent(GameBase game)
        {

        }

        public void Update(GameTime time)
        {
             
        }

        public void Draw(GameTime time,SpriteBatch batch)
        {
            batch.Draw(TileTexture, Position, null, Color.White,
                               0.0f,
                                new Vector2(TileTexture.Width / 2f, TileTexture.Height / 2f), 1,
                                SpriteEffects.None,
                                0);
        }
    }
}
