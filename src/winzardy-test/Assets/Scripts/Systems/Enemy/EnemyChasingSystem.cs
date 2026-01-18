using Entitas;
using UnityEngine;

namespace Systems.Enemy
{
    public class EnemyChasingSystem : IExecuteSystem {
    
        private readonly GameContext _context;
        private readonly IGroup<GameEntity> _enemies;

        public EnemyChasingSystem(Contexts contexts) {
            _context = contexts.game;
        
            _enemies = _context.GetGroup(GameMatcher.AllOf(
                GameMatcher.Enemy, 
                GameMatcher.Position, 
                GameMatcher.Direction,
                GameMatcher.Speed
            ));
        }

        public void Execute() {
            var player = _context.playerEntity;
        
            if (player == null || !player.hasPosition || player.isDead) {
                foreach (var e in _enemies.GetEntities()) {
                    e.ReplaceDirection(Vector3.zero);
                }
                return;
            }

            var playerPos = player.position.Value;
        
            float stopDistance = _context.gameConfig.Value.EnemyAttackDistance;
            float stopDistanceSqr = stopDistance * stopDistance;

            foreach (var enemy in _enemies.GetEntities()) {
                var enemyPos = enemy.position.Value;
            
                var vectorToPlayer = playerPos - enemyPos;
            
                if (vectorToPlayer.sqrMagnitude > stopDistanceSqr) {
                    enemy.ReplaceDirection(vectorToPlayer.normalized);
                } else {
                    enemy.ReplaceDirection(Vector3.zero);
                }
            }
        }
    }
}