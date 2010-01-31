using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using UglyFramework;
using UglyFramework.HelperClasses;

namespace KrakGame
{
    public class TerrainTile
    {
        public Vector2 position;
        public Vector2 dimmensions; //dimmensions of sprite (for drawing)

        public float rotation;
        public bool collideWithPlayer; 

        public Texture2D myGfx;

       

        public TerrainTile()
        {
           

            collideWithPlayer = false;
        }

        public void RegisterToPhysicsEngine()
        {

        }
    }

    public class TerrainLayer : DrawableGameComponent
    {
        public List<TerrainTile> terrain;
        public List<BaseGameObject> gameObjects;

        public double parallaxDistance;

        GameBase gameBase;  //little Cargo Cult Science of mine... :P

        public TerrainLayer(GameBase game) : base(game)
        {
            terrain = new List<TerrainTile>();
            gameObjects = new List<BaseGameObject>();

            gameBase = game;
        }

        public override void Update(GameTime gameTime)
        {
            //TODO update
            foreach (TerrainTile terr in terrain)
            {
                //update
            }

            foreach (BaseGameObject obj in gameObjects)
            {
                //update
            }

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            //gameBase.SpriteBatch.Begin(SpriteBlendMode.AlphaBlend, SpriteSortMode.BackToFront, SaveStateMode.SaveState);

            //gameBase.SpriteBatch.Draw(m_cursorTexture, new Vector2(m_game.CurrentMouseState.X, m_game.CurrentMouseState.Y), Color.CornflowerBlue);

            //TODO use parallax value
            foreach (TerrainTile terr in terrain)
            {
                //FIXME FIXME FIXME NEW RECTANGLE
                gameBase.SpriteBatch.Draw(terr.myGfx, new Rectangle((int)terr.position.X, (int)terr.position.Y, (int)terr.dimmensions.X, (int)terr.dimmensions.Y) , Color.White);
            }

          //  gameBase.SpriteBatch.End();
            base.Draw(gameTime);
        }

        public void PlugToPhysics()
        {
            foreach (TerrainTile tile in terrain)
            {
                tile.RegisterToPhysicsEngine();
            }
        }

    }

    public class GameMap : DrawableGameComponent
    {
        //data

        List<TerrainLayer> terrain;

        //dictionary - for named access to terrain
        Dictionary<string, TerrainTile> namedTerrainObjects;

        //dictionary - for named access to objects
        Dictionary<string, TerrainTile> namedGameObjects;

        GameBase gameBase;

        string bgName;  //TODO: convert to texture object?


        //stuff

        public GameMap(GameBase game) : base(game)
        {
            namedTerrainObjects = new Dictionary<string, TerrainTile>();
            namedGameObjects = new Dictionary<string, TerrainTile>();
            terrain = new List<TerrainLayer>();

            gameBase = game;
        }

        protected override void LoadContent()
        {
            //TODO load proper content ?
            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            //TODO update
            foreach (TerrainLayer terr in terrain)
            {
                //update
            }

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            gameBase.SpriteBatch.Begin(SpriteBlendMode.AlphaBlend, SpriteSortMode.BackToFront, SaveStateMode.SaveState);

            //m_game.SpriteBatch.Draw(m_cursorTexture, new Vector2(m_game.CurrentMouseState.X, m_game.CurrentMouseState.Y), Color.CornflowerBlue);

            foreach(TerrainLayer terrLayer in terrain)
            {
                terrLayer.Draw(gameTime);
            }

            gameBase.SpriteBatch.End();
            base.Draw(gameTime);
        }


        public void PlugToPhysics()
        {
            foreach (TerrainLayer layer in terrain)
            {
                layer.PlugToPhysics();
            }
        }


        public static GameMap LoadFromFile(string mapName, GameBase gameBase)
        {
            //TODO ?? or nothing todo?
            MapData map = MapData.DeserializeMap(mapName);

            GameMap realMap = new GameMap(gameBase);

            realMap.bgName = map.backgroundName;

            //loop through all level layers
            foreach (MapLayer layer in map.layers)
            {
                TerrainLayer lr = new TerrainLayer(gameBase);

                //loop through all terrain elements in current layer
                foreach (MapTerrainElement mte in layer.layerTerrain)
                {
                    TerrainTile tile = new TerrainTile();
                    tile.collideWithPlayer = mte.collideWithPlayer;
                   
                    tile.myGfx = Program.Game.Content.Load<Texture2D>(mte.terrainDetailType);
                    lr.terrain.Add(tile);
                }

                lr.parallaxDistance = layer.parallaxDistance;
                realMap.terrain.Add(lr);

                //TODO also add objects
                //foreach...
            }

            //TODO sort terrain layers by parallax ?
            return realMap;
        }
    }
}
