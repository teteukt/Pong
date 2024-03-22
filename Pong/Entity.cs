using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Pong
{
    public abstract class Entity
    {
        public World World { get; private set; }
        private Vector2 _position;
        public Vector2 _size { get; private set; }
        public Vector2 _motion;
        public bool Dead { get; private set; }
        public Vector2 Position { get { return _position; } }
        public Vector2 Size { get { return _size; } }

        public Entity(World world, Vector2 initialPosition, Vector2 size)
        {
            World = world;
            _position = initialPosition;
            _size = size;
            _motion = new Vector2();
        }

        public void SetPosition(Vector2 position)
        {
            _position = position;
        }

        public void SetMotion(Vector2 motion)
        {
            _motion = motion;
        }

        public void SetDead()
        {
            Dead = true;
        }

        public void PreUpdate(GameTime gameTime)
        {
            _position.X += _motion.X * (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            _position.Y += _motion.Y * (float)gameTime.ElapsedGameTime.TotalMilliseconds;

            if (_position.Y < 0)
            {
                OnCollideTop();
                _position.Y = 0;
            }

            if (_position.Y + _size.Y > GameRenderer.GetWindowHeight())
            {
                OnCollideBottom();
                _position.Y = GameRenderer.GetWindowHeight() - _size.Y;
            }

            if (_position.X < 0)
            {
                _position.X = 0;
                OnCollideLeft();
            }

            if (_position.X + _size.X > GameRenderer.GetWindowWidth())
            {
                _position.X = GameRenderer.GetWindowWidth() - _size.X;
                OnCollideRight();
            }

            Update(gameTime);
        }


        public Rectangle Bounds()
        {
            return new Rectangle((int)_position.X, (int)_position.Y, (int)_size.X, (int)_size.Y);
        }
        public virtual void OnCollideTop() { }
        public virtual void OnCollideBottom() { }
        public virtual void OnCollideLeft() { }
        public virtual void OnCollideRight() { }

        public abstract void Initialize();
        public abstract void Update(GameTime gameTime);
        public abstract void Render(GameRenderer gameRenderer);
        public virtual void OnCollidedByEntity(Entity other) { }
    }
}
