using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UglyFramework.Anim;
using Microsoft.Xna.Framework;
using System.Xml.Serialization;
using System.IO;

namespace UglyFramework.Character
{
    /// <summary>
    /// Stany w jakich charakter moze sie znajdowac
    /// </summary>
    public enum CharacterState
    {
        /// <summary>
        /// Charakter zwrocony w lewo
        /// </summary>
        FaceLeft,

        /// <summary>
        /// charakter zwrocony w prawo
        /// </summary>
        FaceRigth,

        /// <summary>
        /// charakter kucniety w i patrzy w lewo
        /// </summary>
        DuckLeft,

        /// <summary>
        /// charakter kucniety w i patrzy w prawo
        /// </summary>
        DuckRigth,

        /// <summary>
        /// umiera patrzac w lewo
        /// </summary>
        DyingLeft,

        /// <summary>
        /// umiera patrzac w prawo
        /// </summary>
        DyingRigth,

        /// <summary>
        /// biegnie w lewo
        /// </summary>
        RunningLeft,

        /// <summary>
        /// biegnie w prawo
        /// </summary>
        RunningRigth,

        /// <summary>
        /// Skacze w lewo
        /// </summary>
        JumpingLeft,

        /// <summary>
        /// Skacze w prawo
        /// </summary>
        JumpingRigth,

        /// <summary>
        /// kuca w lewo
        /// </summary>
        DuckingLeft,

        /// <summary>
        /// kuca w prawo
        /// </summary>
        DuckingRigth,

        /// <summary>
        /// wisi na linie
        /// </summary>
        Hang,

        /// <summary>
        /// wisi i idzie w gore
        /// </summary>
        HangingUp,

        /// <summary>
        /// wisi i idzie w dol
        /// </summary>
        HangingDown,

        /// <summary>
        /// charakter obraca sie 
        /// </summary>
        Rotating,

        FallingLeft,
        FallingRigth
    }

    public class BasicCharacter
    {
        protected GameBase m_game;
        protected CharacterState m_characterState;
        protected Vector2 m_characterSpeed;

        protected bool m_flipCharacter;

        [XmlIgnore]
        public GameBase Game
        {
            get { return m_game; }
            set { m_game = value; }
        }

        public SerializableDictionary<CharacterState, AnimationSet> Animations
        {
            get;
            set;
        }

        public Animation CharacterAnimation
        {
            get;
            set;
        }

        public CharacterState CharacterState
        {
            get
            {
                return m_characterState;
            }
            set
            {
                m_characterState = value;
                if (Animations.ContainsKey(value))
                {
                    CharacterAnimation.CurrentAnimation = Animations[value];
                }

                switch (value)
                {
                    case CharacterState.DuckingLeft:
                    case CharacterState.DuckLeft:
                    case CharacterState.DyingLeft:
                    case CharacterState.FaceLeft:
                    case CharacterState.JumpingLeft:
                    case CharacterState.RunningLeft:
                    {
                        m_flipCharacter = true;
                        break;
                    }
                    default:
                    {
                        m_flipCharacter = false;
                        break;
                    }
                }
            }
        }

        public BasicCharacter()
        {
            Animations = new SerializableDictionary<CharacterState, AnimationSet>();
        
        }

        public BasicCharacter(GameBase game)
        {
            m_game = game;
            Animations = new SerializableDictionary<CharacterState, AnimationSet>();
        }

        /// <summary>
        /// Override the base class LoadContent to load the texture. once it's
        /// loaded, calculate the origin.
        /// </summary>
        public virtual  void LoadContent()
        {
            CharacterAnimation.LoadContent(m_game);
        }

        public virtual  void Update(GameTime gameTime)
        {
            CharacterAnimation.Update(gameTime);
        }
       
        public virtual void Draw(GameTime gameTime)
        {
            CharacterAnimation.Render(Position, 0.0f, m_game.SpriteBatch, (m_flipCharacter) ? Microsoft.Xna.Framework.Graphics.SpriteEffects.FlipHorizontally : Microsoft.Xna.Framework.Graphics.SpriteEffects.None);
        }

        public Vector2 Position
        {
            get;
            set;
        }
    }
}
