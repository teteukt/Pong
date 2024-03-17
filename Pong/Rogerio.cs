using System;
using Microsoft.Xna.Framework;

#nullable enable
namespace Pong
{
    class Rogerio : Entity
    {
        public Func<Rogerio, Rogerio>? onTouchWall { private get; set; }

        public Rogerio(World world, Vector2 initialPosition) : base(world, initialPosition, new Vector2(32, 32)) {
            SetMotion(new Vector2(0.4F, 0.4F));
        }

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
            if (Position.X < 0)
            {
                onTouchWall?.Invoke(this);
            }

            if (Position.X + Size.X > GameRenderer.GetWindowWidth())
            {
                onTouchWall?.Invoke(this);
            }
        }

        public override void OnCollidedByEntity(Entity other) { 

            if(other is EntityPaddle)
            {
                _motion.X *= -1;
                
            }
        }

        public void Reset()
        {
            SetPosition(new Vector2(GameRenderer.GetWindowWidth() / 2, GameRenderer.GetWindowHeight() / 2));
        }

        public override void OnCollideBottom()
        {
            base.OnCollideBottom(); 
            _motion.Y *= -1;
        }

        public override void OnCollideTop()
        {
            base.OnCollideBottom();
            _motion.Y *= -1;
        }

        public override void OnCollideLeft()
        {
            base.OnCollideBottom();
            _motion.X *= -1;
            Reset();
        }

        public override void OnCollideRight()
        {
            base.OnCollideBottom();
            _motion.X *= -1;
            Reset();
        }
    }
}
