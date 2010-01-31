using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using UglyFramework;

namespace KrakGame
{
    class Background
    {
        private GameBase m_game;
        private Texture2D m_textureBack;
        private Texture2D m_textureFore;
        private string m_textureBackFilename;
        private string m_textureForeFilename;
        private Vector2 m_positionBack = new Vector2(0.0f, 0.0f);
        private Vector2 m_positionFore = new Vector2(0.0f, 0.0f);
        private float m_widthBack;
        private float m_widthFore;

        public Background(GameBase game, string textureBF, string textureFF)
        {
            m_game = game;
            m_textureBackFilename = textureBF;
            m_textureForeFilename = textureFF;
        }

        public void LoadContent()
        {
            m_textureBack = m_game.Content.Load<Texture2D>(m_textureBackFilename);
            m_textureFore = m_game.Content.Load<Texture2D>(m_textureForeFilename);
            m_widthBack = m_textureBack.Width;
            m_widthFore = m_textureFore.Width;
        }

        public void Update(GameTime gameTime)
        {
           
            m_positionBack.X = Program.Game.TranslationMatrix.Translation.X * 0.3f % m_widthBack;
            m_positionFore.X = Program.Game.TranslationMatrix.Translation.X * 0.6f % m_widthFore;

            if (Program.Game.CurrentLevel != null && Program.Game.CurrentLevel.Player.CharacterState == UglyFramework.Character.CharacterState.Hang)
            {
                m_positionBack.Y = Program.Game.TranslationMatrix.Translation.Y * 0.3f % m_widthBack;
                m_positionBack.Y = Program.Game.TranslationMatrix.Translation.Y * 0.3f % m_widthBack;
            }
            
        }

        public void Draw(GameTime gameTime)
        {
            m_game.SpriteBatch.Begin(SpriteBlendMode.AlphaBlend, SpriteSortMode.BackToFront, SaveStateMode.SaveState);
            m_game.SpriteBatch.Draw(m_textureBack, m_positionBack, null, Color.White, 0.0f, new Vector2(0.0f, 0.0f), 1.0f, SpriteEffects.None, 1.0f);
            if (m_positionBack.X < 0.0f)
            {
                m_game.SpriteBatch.Draw(m_textureBack, new Vector2(m_positionBack.X + m_widthBack, m_positionBack.Y),
                    null, Color.White, 0.0f, new Vector2(0.0f, 0.0f), 1.0f, SpriteEffects.None, 1.0f);
            }
            else
            {
                m_game.SpriteBatch.Draw(m_textureBack, new Vector2(m_positionBack.X - m_widthBack, m_positionBack.Y),
                    null, Color.White, 0.0f, new Vector2(0.0f, 0.0f), 1.0f, SpriteEffects.None, 1.0f);
            }
            m_game.SpriteBatch.Draw(m_textureFore, m_positionFore, null, Color.White, 0.0f, new Vector2(0.0f, 0.0f), 1.0f, SpriteEffects.None, 0.95f);
            if (m_positionFore.X < 0.0f)
            {
                m_game.SpriteBatch.Draw(m_textureFore, new Vector2(m_positionFore.X + m_widthFore, m_positionFore.Y),
                    null, Color.White, 0.0f, new Vector2(0.0f, 0.0f), 1.0f, SpriteEffects.None, 0.95f);
            }
            else
            {
                m_game.SpriteBatch.Draw(m_textureFore, new Vector2(m_positionFore.X - m_widthFore, m_positionFore.Y),
                    null, Color.White, 0.0f, new Vector2(0.0f, 0.0f), 1.0f, SpriteEffects.None, 0.95f);
            }
            m_game.SpriteBatch.End();
        }
    }
}
