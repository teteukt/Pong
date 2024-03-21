using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Pong
{
    class World
    {
        private List<Entity> entities = new();

        public void Initialize()
        {
            EntityPaddle playerPaddle = new(this);
            playerPaddle.controlledByPlayer = true;
            EntityPaddle opponentPaddle = new(this, new Vector2(GameRenderer.GetWindowWidth() - 10, 0));

            entities.Add(playerPaddle);
            entities.Add(opponentPaddle);

            Rogerio rogerio = new(this, new Vector2(GameRenderer.GetWindowWidth() / 2, GameRenderer.GetWindowHeight() / 2));
            rogerio.onTouchWall = delegate (Rogerio rogerio)
            {
                OnRogerioTouchWall(rogerio);
                return rogerio;
            };
            entities.Add(rogerio);
        }

        private void OnRogerioTouchWall(Rogerio rogerio)
        {

        }

        public void UpdateAllEntities(GameTime gameTime)
        {
            for (int i = 0; i < entities.Count; i++)
            {
                if (entities[i].Dead)
                {
                    entities.RemoveAt(i);
                }
                else
                {
                    entities[i].PreUpdate(gameTime);
                    getEntityCollidedEntities(entities[i]).ForEach(e =>
                    {
                        e.OnCollidedByEntity(entities[i]);
                    });
                }
            }
        }

        public void RenderAllEntities(GameRenderer gameRenderer)
        {
            for (int i = 0; i < entities.Count; i++)
            {
                if (!entities[i].Dead)
                {
                    entities[i].Render(gameRenderer);
                }
            }
        }

        public List<Entity> getEntitiesIn(Rectangle rectangle)
        {
            List<Entity> collidedEntities = new();

            foreach (Entity entity in entities)
            {
                if (rectangle.Intersects(entity.Bounds()))
                {
                    collidedEntities.Add(entity);
                }
            }

            return collidedEntities;
        }

        public List<Entity> getEntityCollidedEntities(Entity target)
        {
            List<Entity> collidedEntities = getEntitiesIn(target.Bounds());
            collidedEntities = collidedEntities.Where(entity => entity != target).ToList();
            return collidedEntities;
        }
    }
}
