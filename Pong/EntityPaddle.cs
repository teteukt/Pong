
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Pong
{
    public class EntityPaddle : Entity
    {
        public EntityPaddle(World world, Vector2 initialPosition = new Vector2()) : base(world, initialPosition, new Vector2(10, 100)) { }

        public bool controlledByPlayer { get; set; }


        public override void Initialize()
        {

        }

        public override void Render(GameRenderer gameRenderer)
        {
            Vector2 position = Position;
            Vector2 size = Size;
            gameRenderer.DrawRect(position.X, position.Y, size.X, size.Y, Color.White);
        }


        public override void Update(GameTime gameTime)
        {
            if (controlledByPlayer)
            {
                bool upPressed = Keyboard.GetState().IsKeyDown(Keys.W);
                bool downPressed = Keyboard.GetState().IsKeyDown(Keys.S);

                if (upPressed)
                {
                    SetMotion(new Vector2(0, -1));
                }
                else if (downPressed)
                {
                    SetMotion(new Vector2(0, 1));
                }
                else
                {
                    SetMotion(new Vector2(0, 0));
                }
            }
            else
            {
                float positon = 0;
                positon += World.Rogerio.Position.Y;
                if(positon + _size.Y > GameRenderer.GetWindowHeight()){
                    OnCollideBottom();
                    positon = GameRenderer.GetWindowHeight() - _size.Y;
                }

                SetPosition(new Vector2(GameRenderer.GetWindowWidth() - 10, positon));
            }
        }



    }
}
