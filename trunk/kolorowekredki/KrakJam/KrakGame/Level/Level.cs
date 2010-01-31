using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using UglyFramework;
using UglyFramework.Character;
using System.Xml.Serialization;
using System.IO;
using System.Windows.Forms;
using Microsoft.Xna.Framework.Graphics;
using KrakGame.Characters;
using DemoBaseXNA;

namespace KrakGame
{
    public enum LevelState
    {
        NotFlipped,
        Flipped,
        Flipping
    }

    public class Level
    {
        Monkey m_playerCharacter;
        Background m_levelBackground;
        GameBase m_gameBase;
        PhysicsSimulatorView m_debugView;

        #region map basic data

        string m_mapBackgroundLayer1;
        string m_mapBackgroundLayer2;
        string m_playerCharacterDescription;

        List<BaseGameObject> m_mapObjects;
        List<MapTile> m_mapTiles;

        LevelState m_levelState;
        #endregion

        #region Get / set 

        [XmlIgnore]
        public GameBase Game
        {
            get { return m_gameBase; }
            set { m_gameBase = value; }
        }

        public List<MapTile> MapTiles
        {
            get { return m_mapTiles; }
            set { m_mapTiles = value; }
        }

        public List<BaseGameObject> MapObjects
        {
            get { return m_mapObjects; }
            set { m_mapObjects = value; }
        }

        [XmlIgnore]
        public Monkey Player
        {
            get { return m_playerCharacter; }
            set { m_playerCharacter = value; }
        }

        [XmlIgnore]
        public LevelState LevelState
        {
            get { return m_levelState; }
            set
            {
                m_levelState = value;
            }
        }

        public string MapBackgroundLayer1
        {
            get { return m_mapBackgroundLayer1; }
            set { m_mapBackgroundLayer1 = value; }
        }

        public string MapBackgroundLayer2
        {
            get { return m_mapBackgroundLayer2; }
            set { m_mapBackgroundLayer2 = value; }
        }

        public string PlayerCharacterDescription
        {
            get { return m_playerCharacterDescription; }
            set { m_playerCharacterDescription = value; }
        }

        #endregion

        public Level()
        {
           
        }

        public Level(GameBase game)
        {
            m_gameBase = game;
            m_levelState = LevelState.NotFlipped;
            MapObjects = new List<BaseGameObject>();
            MapTiles = new List<MapTile>();

           
        }

        #region Serializacja / deserializacja 

        internal static Level Load(string p,GameBase game)
        {
            Level level;
            XmlSerializer serializer = new XmlSerializer(typeof(Level));
            Stream stream = File.Open(p, FileMode.Open);
            level = (Level)serializer.Deserialize(stream);
            level.Game = game;
            return level;
        }

        public void Save(string file)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Level));
            Stream stream = File.Open(file, FileMode.Create);
            serializer.Serialize(stream, this);
            stream.Close();
        }

        #endregion

        #region DrawableGameComponent overrides

        public  void Draw(GameTime gameTime)
        {
            m_levelBackground.Draw(gameTime);

            m_gameBase.SpriteBatch.Begin( SpriteBlendMode.None, SpriteSortMode.BackToFront, SaveStateMode.SaveState,Program.Game.TranslationMatrix);
            
            foreach (BaseGameObject gameObject in m_mapObjects)
            {
                gameObject.Draw(gameTime,m_gameBase.SpriteBatch);
            }

            m_gameBase.SpriteBatch.End();


            m_gameBase.SpriteBatch.Begin(SpriteBlendMode.AlphaBlend, SpriteSortMode.BackToFront, SaveStateMode.SaveState, Program.Game.TranslationMatrix);
          
            foreach (MapTile tiles in m_mapTiles)
            {
                tiles.Draw(gameTime, m_gameBase.SpriteBatch);
            }

            m_gameBase.SpriteBatch.End();

            Player.Draw(gameTime);
            //m_debugView.Draw(m_gameBase.SpriteBatch);
        }

        public  void Update(GameTime gameTime)
        {
            m_levelBackground.Update(gameTime);
            Player.Update(gameTime);
           
            foreach (BaseGameObject gameObject in m_mapObjects)
            {
                gameObject.Update(gameTime);
            }

            foreach (MapTile tiles in m_mapTiles)
            {
                tiles.Update(gameTime);
            }

            HandleInput();
        }

        private void HandleInput()
        {
             
        }

        public void LoadContent()
        {
             

            m_levelBackground = new Background(m_gameBase, m_mapBackgroundLayer1,m_mapBackgroundLayer2);
            m_levelBackground.LoadContent();

            Player = Monkey.Deserialize(Path.Combine("Map",m_playerCharacterDescription),m_gameBase);
            Player.LoadContent();
            Player.Position = new Vector2(100, 200);
            Player.CharacterState = CharacterState.RunningRigth;

            foreach (BaseGameObject gameObject in m_mapObjects)
            {
                gameObject.LoadComponent(m_gameBase);
            }


            foreach (MapTile tiles in m_mapTiles)
            {
                tiles.LoadComponent(m_gameBase);
                tiles.TileTexture = m_gameBase.Content.Load<Texture2D>(tiles.TextureFile);
            }
        }

        #endregion
    }
}
