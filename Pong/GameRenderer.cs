using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Pong
{
    class GameRenderer
    {
        private Game _game;
        private static GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Texture2D _texture;

        public GameRenderer(Game game)
        {
            _game = game;
            _graphics = new GraphicsDeviceManager(game);
        }

        public static int GetWindowWidth()
        {
            return _graphics.PreferredBackBufferWidth;
        }

        public static int GetWindowHeight()
        {
            return _graphics.PreferredBackBufferHeight;
        }

        public void Initialize()
        {
            _texture = new Texture2D(_game.GraphicsDevice, 1, 1);
            _texture.SetData(new Color[] { Color.DarkSlateGray });
        }

        public void LoadContent()
        {
            _spriteBatch = new SpriteBatch(_game.GraphicsDevice);
        }

        public void DrawRect(int x, int y, int width, int height, Color color)
        {
            _spriteBatch.Begin();
            _spriteBatch.Draw(_texture, new Rectangle(x, y, width, height), color);
            _spriteBatch.End();
        }

        public void DrawRect(float x, float y, float width, float height, Color color)
        {
            DrawRect((int)x, (int)y, (int)width, (int)height, color);
        }
    }
}
