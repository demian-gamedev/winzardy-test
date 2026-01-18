using Entitas;
using UnityEngine;

namespace Systems
{
    public class DeathSystem : IExecuteSystem {
    
        private readonly GameContext _context;
        private readonly IGroup<GameEntity> _living;

        public DeathSystem(Contexts contexts) {
            _context = contexts.game;
            _living = _context.GetGroup(GameMatcher.Health);
        }

        public void Execute() {
            foreach (var e in _living.GetEntities()) {
                if (e.health.Current <= 0 && !e.isDead) {
                    Die(e);
                }
            }
        }

        private void Die(GameEntity e) {
            e.isDead = true;

            if (e.isPlayer) {
                _context.isInputBlocked = true;
                _context.isGameOver = true; 
            }
            else if (e.isEnemy) {
                TrySpawnCoin(e.position.Value);
                e.isDestroyed = true; 
            }
        }

        private void TrySpawnCoin(Vector3 pos) {
            if (Random.value <= _context.gameConfig.Value.CoinDropChance) {
                var coin = _context.CreateEntity();
                coin.isCoin = true;
                coin.AddPosition(pos);
                coin.AddResource(_context.assetLibrary.CoinPrefab);
            }
        }
    }
}