using Entitas;
using UnityEngine;

namespace Systems.Enemy
{
    public class EnemySpawnSystem : IInitializeSystem, IExecuteSystem {
    
        private readonly GameContext _context;

        public EnemySpawnSystem(Contexts contexts) {
            _context = contexts.game;
        }

        public void Initialize() {
            _context.SetSpawnTimer(_context.gameConfig.Value.EnemySpawnRate);
        }

        public void Execute() {
            var dt = Time.deltaTime;
            var timer = _context.spawnTimer.Value;
            timer -= dt;

            if (timer <= 0) {
                timer = _context.gameConfig.Value.EnemySpawnRate;
                SpawnEnemy();
            }

            _context.ReplaceSpawnTimer(timer);
        }

        private void SpawnEnemy() {
            if (!_context.hasCameraService) return;

            var config = _context.gameConfig.Value;
            var spawnPos = _context.cameraService.Value.GetPositionOutsideCamera(2.0f);

            var e = _context.CreateEntity();
            e.isEnemy = true;
            e.AddPosition(spawnPos);
            e.AddDirection(Vector3.zero);
            e.AddSpeed(config.EnemySpeed);
            e.AddHealth(config.EnemyHealth, config.EnemyHealth);
            e.AddDamage(config.EnemyDamagePerSecond);
            e.AddResource(_context.assetLibrary.EnemyPrefab);
        }
    }
}