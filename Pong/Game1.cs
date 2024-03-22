using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Pong
{
    public class Game1 : Game
    {
        private GameRenderer _gameRenderer;
        private World _world;

        public Game1()
        {
            _gameRenderer = new GameRenderer(this);
            _world = new World();
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            _gameRenderer.Initialize();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _gameRenderer.LoadContent();
            _world.Initialize();
        }


        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape) || Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                Exit();
            }

            _world.UpdateAllEntities(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _world.RenderAllEntities(_gameRenderer);

            base.Draw(gameTime);
        }
    }
}
