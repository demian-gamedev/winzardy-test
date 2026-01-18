using Entitas;
using UnityEngine;

namespace Systems.Player
{
    public class PlayerShootingSystem : IExecuteSystem {

        private readonly GameContext _context;
        private readonly IGroup<GameEntity> _enemies;

        public PlayerShootingSystem(Contexts contexts) {
            _context = contexts.game;
            _enemies = _context.GetGroup(GameMatcher.AllOf(GameMatcher.Enemy, GameMatcher.Position));
        }

        public void Execute() {
            var player = _context.playerEntity;
            if (player == null || player.isDead) return;

            float dt = Time.deltaTime;
            player.cooldown.Value -= dt;

            if (player.cooldown.Value <= 0) {
                var target = GetClosestEnemy(player.position.Value);
            
                if (target != null) {
                    SpawnProjectile(player.position.Value, target.position.Value);
                    player.ReplaceCooldown(_context.gameConfig.Value.FireRate);
                }
            }
        }

        private GameEntity GetClosestEnemy(Vector3 playerPos) {
            GameEntity closest = null;
            float minDistSqr = float.MaxValue;

            foreach (var e in _enemies.GetEntities()) {
                if (e.isDead) continue;

                float distSqr = (e.position.Value - playerPos).sqrMagnitude;
                if (distSqr < minDistSqr) {
                    minDistSqr = distSqr;
                    closest = e;
                }
            }
            return closest;
        }

        private void SpawnProjectile(Vector3 from, Vector3 to) {
            var config = _context.gameConfig.Value;
            var dir = (to - from).normalized;

            var e = _context.CreateEntity();
            e.isProjectile = true;
            e.AddPosition(from);
            e.AddDirection(dir);
            e.AddSpeed(config.ProjectileSpeed);
            e.AddDamage(config.ProjectileDamage);
            e.AddLifetime(config.ProjectileLifetime);
            e.AddResource(_context.assetLibrary.ProjectilePrefab);
        }
    }
}