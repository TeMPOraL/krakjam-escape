using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace UglyFramework.GameStateManager
{
    public class GameState
    {
        public GameState(GameBase game, GameStateManager gsm)
        {
        }
        public virtual void LoadContent()
        {
            throw new NotImplementedException("sry, not implemented - it's a pseudo-abstract class :P.");
        }
        public virtual void UnloadContent()
        {
            throw new NotImplementedException("sry, not implemented - it's a pseudo-abstract class :P.");
        }
        public virtual void Update(GameTime gameTime)
        {
            throw new NotImplementedException("sry, not implemented - it's a pseudo-abstract class :P.");
        }
        public virtual void Draw(GameTime gameTime)
        {
            throw new NotImplementedException("sry, not implemented - it's a pseudo-abstract class :P.");
        }
    }

    public class GameStateManager
    {
        Dictionary<string, GameState> gameStates;

        GameState currentState;
        GameBase m_baseGame;

        string nextState;

        public GameStateManager(GameBase game)
        {
            m_baseGame = game;
            currentState = null;
            gameStates = new Dictionary<string, GameState>();

            nextState = null;
        }

        void InitializeState(GameState state)
        {
            state.LoadContent();
        }

        void DeinitializeState(GameState state)
        {
            state.UnloadContent();
        }

        void RealChangeState(string stateName)
        {
            if (currentState != null)
            {
                DeinitializeState(currentState);
            }

            if (gameStates.ContainsKey(stateName))
            {
                currentState = gameStates[stateName];

                InitializeState(currentState);
            }
            else
            {
                throw new Exception("Missing state " + stateName);
            }

            //TODO exit state
        }

        public void RegisterNewState(GameState state, string name)
        {
            gameStates.Add(name, state);
        }

        public void ChangeState(string stateName)
        {
            nextState = stateName;
        }

        public void Update(GameTime gameTime)
        {
            if (nextState != null)
            {
                RealChangeState(nextState);
                nextState = null;
            }
            currentState.Update(gameTime);
        }

        public void Draw(GameTime gameTime)
        {
            currentState.Draw(gameTime);
        }
    }
}
