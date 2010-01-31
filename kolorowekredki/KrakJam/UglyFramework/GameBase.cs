using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace UglyFramework
{
    public class GameBase : Microsoft.Xna.Framework.Game
    {
        protected GraphicsDeviceManager m_graphics;
        protected SpriteBatch m_spriteBatch;

        protected MouseState m_previousMouseState;
        protected MouseState m_currentMouseState;
        protected KeyboardState m_previousKeyboardState;
        protected KeyboardState m_currentKeyboardState;

        protected MouseCursor m_mouseCursor;
        public MouseCursor MouseCursor
        {
            get
            {
                return m_mouseCursor;
            }
        }


        protected Rectangle m_camera;
        protected Rectangle m_oldCamera;
        protected Vector2 m_cameraDirectionMovement;

        public Vector2 CameraDirectionMovement
        {
            get { return m_cameraDirectionMovement; }
        }
        
        public Rectangle Camera
        {
            get
            {
                return m_camera;
            }
        }

        public MouseState CurrentMouseState
        {
            get { return m_currentMouseState; }
        }

        public KeyboardState CurrentKeyboardState
        {
            get
            {
                return m_currentKeyboardState;
            }
        }

        public bool IsKeyPressed(Keys key)
        {
            return m_previousKeyboardState.IsKeyDown(key) && m_currentKeyboardState.IsKeyUp(key);
        }

        public SpriteBatch SpriteBatch
        {
            get { return m_spriteBatch; }
        }

        public GameBase()
        {

            m_graphics = new PerfHUDDeviceManager(this);
            Content.RootDirectory = "Content";
           
            m_mouseCursor = new MouseCursor(this,"cursor");
            Components.Add(m_mouseCursor);
        }

        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            m_spriteBatch = new SpriteBatch(GraphicsDevice);
            m_camera.X = 0;
            m_camera.Y = 0;
            m_camera.Width = GraphicsDevice.PresentationParameters.BackBufferWidth;
            m_camera.Height = GraphicsDevice.PresentationParameters.BackBufferHeight;
            
            base.LoadContent();
        }

        protected override void Update(GameTime gameTime)
        {
            HandleInput();
          
            base.Update(gameTime);
        }

        private void HandleInput()
        {
            m_previousKeyboardState = m_currentKeyboardState;
            m_currentKeyboardState = Keyboard.GetState();

            m_previousMouseState = m_currentMouseState;
            m_currentMouseState = Mouse.GetState();
        }
    }
}
