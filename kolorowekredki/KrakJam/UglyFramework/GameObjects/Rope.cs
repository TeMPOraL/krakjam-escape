using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UglyFramework;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Xml.Serialization;

namespace KrakGame.GameObjects
{
    public class Rope : BaseGameObject
    {
        Vector2 m_position;

        public Rope()
        {

        }

        #region IBaseGameObject Members

        public override Vector2 WorldPosition
        {
            get;
            set;
        }

        #endregion

        #region IBaseGameObject Members


        public string Texture
        {
            get;
            set;
        }

        public ObjectType Type
        {
            get;
            set;
        }

        #endregion

        #region IBaseGameObject Members

        public override void LoadComponent(GameBase game)
        {
            
        }

        public override void Draw(GameTime gameTime, SpriteBatch batch)
        {
             
        }

        public override void Update(GameTime gameTime)
        {
        }

        #endregion
    }
}
