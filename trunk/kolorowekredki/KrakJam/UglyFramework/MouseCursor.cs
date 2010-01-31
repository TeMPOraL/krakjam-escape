using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace UglyFramework
{
    public class MouseCursor : DrawableGameComponent
    {
        Texture2D m_cursorTexture;
        string m_cursortTextureFilename;
        GameBase m_game;
        
        public MouseCursor(GameBase game, string cursortTextureFilename)
            : base(game)
        {
            m_cursortTextureFilename = cursortTextureFilename;
            m_game = game;
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        /// <summary>
        /// Override the base class LoadContent to load the texture. once it's
        /// loaded, calculate the origin.
        /// </summary>
        protected override void LoadContent()
        {
            m_cursorTexture = Game.Content.Load<Texture2D>(m_cursortTextureFilename);
            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            m_game.SpriteBatch.Begin(SpriteBlendMode.AlphaBlend, SpriteSortMode.BackToFront, SaveStateMode.SaveState);
            m_game.SpriteBatch.Draw(m_cursorTexture, new Vector2(m_game.CurrentMouseState.X, m_game.CurrentMouseState.Y), null, Color.White, 0.0f, new Vector2(0.0f, 0.0f), 1.0f, SpriteEffects.None, 0.9f);
            m_game.SpriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
