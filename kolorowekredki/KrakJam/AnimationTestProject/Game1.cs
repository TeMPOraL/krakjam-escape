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


using System.IO;
using System.Windows.Forms;
using UglyFramework.Character;

namespace AnimationTestProject
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : GameBase
    {
       
        BasicCharacter testCharacter;
        public Game1()
            : base()
        {
            //TestCharacter();
           // testCharacter = BasicCharacter.Deserialize("testCharacter.xml",this);
            testCharacter.CharacterState = CharacterState.DuckingLeft;
            testCharacter.Position = new Vector2(100, 100);
         
          // testAnim = new TestAnimation();
           
            //AnimationSet set = new AnimationSet(){ AnimationType = AnimationType.Walk, FrameCount = 4, FrameStartNumber= 0};
            //set.Serialize(Path.Combine(Application.StartupPath,"sample.txt"));
            //testDesc.Serialize(Path.Combine(Application.StartupPath,"sampleDesc.txt"));
        }

        private void TestCharacter()
        {
            BasicCharacter basicCharacter = new BasicCharacter();
            basicCharacter.Animations.Add(CharacterState.DuckingLeft, new UglyFramework.Anim.AnimationSet()
            {
                 FrameCount = 10,
                 FrameStartNumber = 0
            });

             basicCharacter.Animations.Add(CharacterState.DuckingRigth, new UglyFramework.Anim.AnimationSet()
            {
                 FrameCount = 10,
                 FrameStartNumber=0
            });

             basicCharacter.Animations.Add(CharacterState.DuckLeft, new UglyFramework.Anim.AnimationSet()
            {
                 FrameCount = 1,
                 FrameStartNumber=11
            });

             basicCharacter.Animations.Add(CharacterState.DuckRigth, new UglyFramework.Anim.AnimationSet()
            {
                 FrameCount = 1,
                 FrameStartNumber =11
            });

             basicCharacter.Animations.Add(CharacterState.DyingLeft, new UglyFramework.Anim.AnimationSet()
            {
                 FrameCount = 10,
                 FrameStartNumber= 12
            });

             basicCharacter.Animations.Add(CharacterState.DyingRigth, new UglyFramework.Anim.AnimationSet()
            {
                 FrameCount = 10,
                 FrameStartNumber =12
            });

             basicCharacter.Animations.Add(CharacterState.FaceLeft, new UglyFramework.Anim.AnimationSet()
            {
                 FrameCount = 1,
                 FrameStartNumber= 23
            });

             basicCharacter.Animations.Add(CharacterState.FaceRigth, new UglyFramework.Anim.AnimationSet()
            {
                 FrameCount = 1,
                 FrameStartNumber= 23
            });

            basicCharacter.Animations.Add(CharacterState.Hang, new UglyFramework.Anim.AnimationSet()
            {
                 FrameCount = 1,
                 FrameStartNumber=24
            });

             basicCharacter.Animations.Add(CharacterState.HangingDown, new UglyFramework.Anim.AnimationSet()
            {
                 FrameCount = 10,
                 FrameStartNumber =25
            });

             basicCharacter.Animations.Add(CharacterState.HangingUp, new UglyFramework.Anim.AnimationSet()
             {
                 FrameCount = 10,
                 FrameStartNumber = 25
             });

             basicCharacter.Animations.Add(CharacterState.JumpingLeft, new UglyFramework.Anim.AnimationSet()
             {
                 FrameCount = 10,
                 FrameStartNumber = 36
             });

             basicCharacter.Animations.Add(CharacterState.JumpingRigth, new UglyFramework.Anim.AnimationSet()
             {
                 FrameCount = 10,
                 FrameStartNumber = 36
             });

             basicCharacter.Animations.Add(CharacterState.Rotating, new UglyFramework.Anim.AnimationSet()
             {
                 FrameCount = 10,
                 FrameStartNumber = 47
             });

             basicCharacter.Animations.Add(CharacterState.RunningLeft, new UglyFramework.Anim.AnimationSet()
             {
                 FrameCount = 10,
                 FrameStartNumber = 58
             });

             basicCharacter.Animations.Add(CharacterState.RunningRigth, new UglyFramework.Anim.AnimationSet()
             {
                 FrameCount = 10,
                 FrameStartNumber = 58
             });

             basicCharacter.CharacterState = CharacterState.FaceLeft;
             basicCharacter.CharacterAnimation = new UglyFramework.Anim.Animation()
             {
                  AnimationSpeed = 30,
                   TextureFile = "basicTest.bmp",
                   AnimationTileSize = new Vector2(64,64)
             };

             //basicCharacter.Serialize(Path.Combine(Application.StartupPath, "basicCharacter.xml"));
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
            //testAnim.LoadContent(this);
           
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
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == Microsoft.Xna.Framework.Input.ButtonState.Pressed)
                this.Exit();

           // testAnim.Update(gameTime);
           //  testCharacter.Update(gameTime);

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            // m_spriteBatch.Begin(SpriteBlendMode.AlphaBlend, SpriteSortMode.BackToFront, SaveStateMode.SaveState);
            // testAnim.Render(new Vector2(100, 100), UglyFramework.Anim.AnimationType.Walk, m_spriteBatch);
            // testCharacter.Draw(gameTime);
           // m_spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
