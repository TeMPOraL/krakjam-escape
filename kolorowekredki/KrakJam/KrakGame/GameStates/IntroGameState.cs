using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UglyFramework.GameStateManager;
using UglyFramework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace KrakGame.GameStates
{
    class IntroGameState : GameState
    {
        GameBase m_baseGame;
        GameStateManager myManager;

        //Intro screens
        Texture2D monkeyScreen;
        Texture2D titleScreen;
        Texture2D backgroundScreen;

        Vector2 monkeyScreenPos;
        Vector2 titleScreenPos;
        Vector2 backgroundScreenPos;

//        Vector2 backgroundScreenStartPos;
//        Vector2 backgroundScreenEndPos;
        Vector2 monkeyScreenStartPos;
        Vector2 monkeyScreenEndPos;
        float monkeyScreenStartTime;
        float monkeyScreenEndTime;
        float monkeyScreenSineStartTime;

        float amplitude;
        float frequency;
        float phase;

        Vector2 titleScreenStartPos;
        Vector2 titleScreenEndPos;
        float titleScreenStartTime;
        float titleScreenEndTime;


        float temporalAccumulator;

        float introEndTime;

        public IntroGameState(GameBase baseGame, GameStateManager gsm) : base(baseGame, gsm)
        {
            m_baseGame = baseGame;
            myManager = gsm;

            monkeyScreenPos = new Vector2(0.0f, 0.0f);
            titleScreenPos = new Vector2(0.0f, 0.0f);
            backgroundScreenPos = new Vector2(10.0f, 10.0f);

            monkeyScreenStartPos = new Vector2(-400f, 0.0f);
            monkeyScreenEndPos = new Vector2(40.0f, 40.0f);
            monkeyScreenStartTime = 2.0f;
            monkeyScreenEndTime = 5.0f;
            monkeyScreenSineStartTime = 7.0f;

            amplitude = 50.0f;
            frequency = 1.5f;
            phase = 0.0f;

            titleScreenStartPos = new Vector2(700.0f, 0.0f);
            titleScreenEndPos = new Vector2(0.0f, 0.0f);
            titleScreenStartTime = 0.5f;
            titleScreenEndTime = 5.0f;

            introEndTime = 15.0f;
        }

        public override void LoadContent()
        {
            monkeyScreen = Program.Game.Content.Load<Texture2D>("intro_monkeyScreen");
            titleScreen = Program.Game.Content.Load<Texture2D>("intro_titleScreen");
            backgroundScreen = Program.Game.Content.Load<Texture2D>("intro_backgroundScreen");
        }
        public override void UnloadContent()
        {
            monkeyScreen.Dispose();
            titleScreen.Dispose();
            backgroundScreen.Dispose();
        }
        public override void Update(GameTime gameTime)
        {
            temporalAccumulator += gameTime.ElapsedGameTime.Milliseconds / 1000.0f;

            Vector2.Lerp(ref monkeyScreenStartPos, ref monkeyScreenEndPos, Clamp((temporalAccumulator - monkeyScreenStartTime) / (monkeyScreenEndTime - monkeyScreenStartTime), 0.0f, 1.0f), out monkeyScreenPos);
            Vector2.Lerp(ref titleScreenStartPos, ref titleScreenEndPos, Clamp((temporalAccumulator - titleScreenStartTime) / (titleScreenEndTime- titleScreenStartTime), 0.0f, 1.0f), out titleScreenPos);

            if (temporalAccumulator > monkeyScreenSineStartTime)
            {
                monkeyScreenPos.Y = monkeyScreenEndPos.Y + amplitude * (float)Math.Sin(frequency * temporalAccumulator + phase);
            }

            if (temporalAccumulator > introEndTime)
            {
                myManager.ChangeState("main");
            }
        }
        public override void Draw(GameTime gameTime)
        {
            m_baseGame.GraphicsDevice.Clear(Color.CornflowerBlue);

            m_baseGame.SpriteBatch.Begin();

            m_baseGame.SpriteBatch.Draw(backgroundScreen, backgroundScreenPos, Color.White);    //fixme store position somewhere
            m_baseGame.SpriteBatch.Draw(titleScreen, titleScreenPos, Color.White);    //fixme store position somewhere
            m_baseGame.SpriteBatch.Draw(monkeyScreen, monkeyScreenPos, Color.White);    //fixme store position somewhere

            m_baseGame.SpriteBatch.End();
        }

        protected static float Clamp(float what, float min, float max)
        {
            return Math.Max(min, Math.Min(max, what));
        }
    }
}
