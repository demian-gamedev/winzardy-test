using Entitas;
using UnityEngine;

namespace Systems
{
    public class ProjectileSystem : IExecuteSystem {

        private readonly IGroup<GameEntity> _projectiles;

        public ProjectileSystem(Contexts contexts) {
            _projectiles = contexts.game.GetGroup(GameMatcher.AllOf(
                GameMatcher.Projectile, 
                GameMatcher.Position, 
                GameMatcher.Direction, 
                GameMatcher.Speed
            ));
        }

        public void Execute() {
            float dt = Time.deltaTime;

            foreach (var e in _projectiles.GetEntities()) {
                var displacement = e.direction.Value * e.speed.Value * dt;
                e.ReplacePosition(e.position.Value + displacement);

                if (e.hasView) {
                    e.view.Value.transform.position = e.position.Value;
                }

                if (e.hasLifetime) {
                    e.lifetime.Value -= dt;
                    if (e.lifetime.Value <= 0) {
                        e.isDestroyed = true;
                    }
                }
            }
        }
    }
}