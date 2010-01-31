using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UglyFramework.Character;
using UglyFramework;
using System.Xml.Serialization;
using System.IO;
using Microsoft.Xna.Framework;
using KrakGame.GameObjects;
using Microsoft.Xna.Framework.Input;

namespace KrakGame.Characters
{


    public class Monkey : BasicCharacter
    {
         
      
        public Monkey()
        {
            
        }

        public Monkey(GameBase game)
            : base(game)
        {
          
        }

        public void AnimEnded()
        {
            switch (this.CharacterState)
            {
                case CharacterState.JumpingLeft:
                case CharacterState.DuckingRigth:
                    CharacterState = CharacterState.FaceRigth;
                    break;
            }
        }

        /// <summary>
        /// Override the base class LoadContent to load the texture. once it's
        /// loaded, calculate the origin.
        /// </summary>
        public override void LoadContent()
        {
            base.LoadContent();
            CharacterState = CharacterState.RunningRigth;
            this.CharacterAnimation.AnimEnd += new UglyFramework.Anim.AnimationEnded(AnimEnded); 
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            CharacterAnimation.Render(new Vector2(m_game.Camera.Width / 2,m_game.Camera.Height / 2), 0.0f, m_game.SpriteBatch, (m_flipCharacter) ? Microsoft.Xna.Framework.Graphics.SpriteEffects.FlipHorizontally : Microsoft.Xna.Framework.Graphics.SpriteEffects.None);
            //base.Draw(gameTime);
        }

        /// <summary>
        /// serializacja do pliku
        /// </summary>
        /// <param name="file"></param>
        public void Serialize(string file)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Monkey));
            Stream stream = File.Open(file, FileMode.Create);
            serializer.Serialize(stream, this);
            stream.Close();
        }

        /// <summary>
        /// deserializacja 
        /// </summary>
        /// <returns></returns>
        public static Monkey Deserialize(string file, GameBase game)
        {
            Monkey basicCharacter;
            XmlSerializer serializer = new XmlSerializer(typeof(Monkey));
            Stream stream = File.Open(file, FileMode.Open);
            basicCharacter = (Monkey)serializer.Deserialize(stream);
            basicCharacter.Game = game;

            stream.Close();
            return basicCharacter;

        }
    }
}
