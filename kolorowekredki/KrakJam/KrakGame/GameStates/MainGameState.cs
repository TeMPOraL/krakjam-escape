using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UglyFramework.GameStateManager;
using Microsoft.Xna.Framework;
using KrakGame.GameObjects;
using UglyFramework;
using System.IO;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace KrakGame.GameStates
{
    public class MainGameState : GameState
    {
        Level m_mapLevel;

        GameBase m_baseGame;
        GameStateManager myManager;

        public MainGameState(GameBase baseGame, GameStateManager gsm) : base(baseGame, gsm)
        {
            m_baseGame = baseGame;
            myManager = gsm;
        }


        public override void LoadContent()
        {
            

            m_mapLevel = Level.Load(Path.Combine("Map", "level1.xml"), m_baseGame);
            m_mapLevel.LoadContent();

            //m_mapLevel = Level.Load("simpleLevel.xml");
            //this.Components.Add(m_mapLevel);
        }
        public override void UnloadContent()
        {
        }
        public override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                m_baseGame.Exit();  //FIXME

            m_mapLevel.Update(gameTime);

            
        }
        public override void Draw(GameTime gameTime)
        {

            if (m_mapLevel != null && m_mapLevel.Player != null)
                Program.Game.TranslationMatrix = Matrix.CreateTranslation(-m_mapLevel.Player.Position.X + Program.Game.Camera.Width / 2, -m_mapLevel.Player.Position.Y + Program.Game.Camera.Height / 2, 0);
           
            m_baseGame.GraphicsDevice.Clear(Color.CornflowerBlue);
            m_mapLevel.Draw(gameTime);
        }
    }
}
