using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using KrakGame.GameObjects;
using Microsoft.Xna.Framework.Graphics;

namespace UglyFramework
{
    public enum ObjectType
    {
        Rope
    }

    [System.Xml.Serialization.XmlInclude(typeof(Rope))]
    public class BaseGameObject
    {
        Vector2 m_position;

        /// <summary>
        /// pozycja obiektu
        /// </summary>
       public  Vector2 Position
        {
            get
            {
                return m_position;
            }

            set
            {
                m_position = value;
                WorldPosition = value;
            }
        }

       /// <summary>
       /// pozycja obiektu
       /// </summary>
       public virtual Vector2 WorldPosition
       {
           get;
           set;
       }

       /// <summary>
       /// pozycja obiektu
       /// </summary>
       public  Vector2 CameraDirection
       {
           get;
           set;
       }

        /// <summary>
        /// textura przypisana obiektowi
        /// </summary>
        public string Texture
        {
            get;
            set;
        }

        /// <summary>
        /// Typ obiektu
        /// </summary>
        public ObjectType Type
        {
            get;
            set;
        }


        virtual public void LoadComponent(GameBase game)
        {
            throw new NotImplementedException();
        }

        public virtual void Draw(GameTime gameTime,SpriteBatch batch)
        {
            throw new NotImplementedException();
        }

        public virtual void Update(GameTime gameTime)
        {
            throw new NotImplementedException();
        }
    }

    //public class BaseGameObject
    //{
    //    //TODO
    //    // * Position
    //    // * Rotation
    //    // * Mass?
    //    // * Geometry
    //    // * Sprite

    //    // * Collidable (at all?)
    //    // * Collision group??

    //    public Vector2 Position
    //    {
    //        get;
    //        set;
    //    }
    //}
}
