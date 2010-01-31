using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Net;
using Microsoft.Xna.Framework.Storage;
using UglyFramework;
using KrakGame.GameObjects;
using UglyFramework.Character;
using System.IO;
using UglyFramework.GameStateManager;
using KrakGame.GameStates;
 

namespace KrakGame
{
    public enum Gamemode
    {
        IntroScreen,    //intro screen - who we are and what the game is about

        MainGameplay,   //the main game - platform mode

        GameOver_Lost,  //"player has lost the game" screen

        GameOver_Won,   //"player has won the game" screen

        HighScores      //hi-score screen

    }


    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class KrakGame : GameBase
    {
        Level m_mapLevel;

        Matrix m_translationMatrix;
               
        GameStateManager gameStateManager;


        public Matrix TranslationMatrix
        {

            get
            {
                return m_translationMatrix;
            }
            set
            {
                m_translationMatrix = value;
            }
        }

        public Level CurrentLevel
        {
            get { return m_mapLevel; }
        }

        public KrakGame()
            : base()
        {
            gameStateManager = new GameStateManager(this);
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            gameStateManager.RegisterNewState(new MainGameState(this, gameStateManager), "main");
            gameStateManager.RegisterNewState(new IntroGameState(this, gameStateManager), "intro");
            gameStateManager.ChangeState("main");

            base.LoadContent();
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            gameStateManager.Update(gameTime);
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
 
           
            GraphicsDevice.Clear(Color.CornflowerBlue);
          
 
            gameStateManager.Draw(gameTime);
 
            base.Draw(gameTime);
        }

        //Used by game estat
        public void SetGameLevel(Level newLevel)
        {
            m_mapLevel = newLevel;
        }
    }
}
