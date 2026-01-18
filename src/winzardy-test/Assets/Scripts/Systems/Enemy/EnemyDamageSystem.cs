using Entitas;
using UnityEngine;

namespace Systems.Enemy
{
    public class EnemyDamageSystem : IExecuteSystem {
    
        private readonly GameContext _context;
        private readonly IGroup<GameEntity> _enemies;

        public EnemyDamageSystem(Contexts contexts) {
            _context = contexts.game;
            _enemies = _context.GetGroup(GameMatcher.AllOf(
                GameMatcher.Enemy, 
                GameMatcher.Position, 
                GameMatcher.Damage
            ));
        }

        public void Execute() {
            var player = _context.playerEntity;
            if (player == null || player.isDead || !player.hasPosition) return;

            float dt = Time.deltaTime;
            float dmgPerSec = _context.gameConfig.Value.EnemyDamagePerSecond;
            float rangeSqr = Mathf.Pow(_context.gameConfig.Value.EnemyAttackDistance, 2);

            foreach (var enemy in _enemies.GetEntities()) {
                float distSqr = (enemy.position.Value - player.position.Value).sqrMagnitude;

                if (distSqr <= rangeSqr) {
                    float damage = enemy.damage.Value * dt;
                
                    var newHealth = player.health.Current - damage;
                    player.ReplaceHealth(newHealth, player.health.Max);
                }
            }
        }
    }
}