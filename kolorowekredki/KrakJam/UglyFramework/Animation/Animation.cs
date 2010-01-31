using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Collections;
using System.Xml.Serialization;
using System.IO;
using System.Windows.Forms;

namespace UglyFramework.Anim
{
    public delegate void AnimationEnded();

    public class Animation
    {
        protected AnimationSet m_currentAnimation;

        [XmlIgnore]
        public  AnimationEnded AnimEnd = delegate { };
        /// <summary>
        /// aktualna klatka animacji
        /// </summary>
        protected int m_currentAnimationFrame;
      
        protected Vector2 m_animationTileSize;

        protected float m_animationSpeed;

        /// <summary>
        /// ile milisekund minelo ?
        /// </summary>
        int m_updateTime;
     
        protected Vector2 m_animationTileHalf;


        /// <summary>
        /// rozmiar pojedynczej klatki animacji
        /// </summary>
        public Vector2 AnimationTileSize
        {
            get { return m_animationTileSize; }
            set
            {
                m_animationTileSize = value;
                m_animationTileHalf = value / 2.0f;
            }
        }

        /// <summary>
        /// Co ile milisekund mamy zmieniac klatke animacji ?
        /// </summary>
        public float AnimationSpeed
        {
            get { return m_animationSpeed; }
            set { m_animationSpeed = value; }
        }

        /// <summary>
        /// uzywany przy rotationa origin - chcemy obracac wokol srodka obrazka
        /// </summary>
        public Vector2 AnimationTileHalf
        {
            get { return m_animationTileHalf; }
            set { m_animationTileHalf = value; }
        }

        public Animation()
        {
        }

        public Animation(Vector2 animationTileSize,float animationSpeed)
        {
            m_animationTileSize = animationTileSize;
            m_animationTileHalf = animationTileSize / 2.0f;
            m_animationSpeed = animationSpeed;
        }

        public string TextureFile
        {
            get;
            set;
        }

        /// <summary>
        /// aktualnie wyswietlana animacjia
        /// </summary>
        [XmlIgnore]
        public AnimationSet CurrentAnimation
        {
            get
            {
                return m_currentAnimation;
            }
            set
            {
                m_currentAnimation = value;
                m_currentAnimationFrame = 0;
                m_updateTime = 0;
            }
        }

        [XmlIgnore]
        public Texture2D AnimationTexture
        {
            get;
            protected set;
        }

        public void LoadContent(Game game)
        {
            AnimationTexture = game.Content.Load<Texture2D>( TextureFile);
        }

        /// <summary>
        /// aktualizuje klatki animacji
        /// </summary>
        /// <param name="time"></param>
        public void Update(GameTime time)
        {
            if(m_currentAnimation == null) return;

            m_updateTime += time.ElapsedGameTime.Milliseconds;
            if (m_updateTime > m_animationSpeed)
            {
                ++m_currentAnimationFrame;
                if (m_currentAnimationFrame >= m_currentAnimation.FrameCount)
                {
                    m_currentAnimationFrame = 0;
                    AnimEnd();
                }
                m_updateTime = 0;
            }
        }

        public void Render(Vector2 position, float rotation,  SpriteBatch spriteBatch, SpriteEffects effects)
        {
            if(m_currentAnimation == null) return;
           
            Rectangle animationTile = new Rectangle(
                            (int)((m_currentAnimationFrame + m_currentAnimation.FrameStartNumber) * m_animationTileSize.X),
                            0,
                            (int)m_animationTileSize.X,
                            (int)m_animationTileSize.Y);

            spriteBatch.Begin(SpriteBlendMode.AlphaBlend, SpriteSortMode.BackToFront, SaveStateMode.SaveState);
            spriteBatch.Draw(AnimationTexture,
                new Rectangle((int)position.X, (int)position.Y, (int)m_animationTileSize.X, (int)m_animationTileSize.Y)
                , animationTile, Color.White, rotation, m_animationTileHalf, effects, 0);
            spriteBatch.End();
        }

        public void Render(Vector2 position, SpriteBatch spriteBatch)
        {
            Render(position,0.0f, spriteBatch, SpriteEffects.None);
        }
    }
}
