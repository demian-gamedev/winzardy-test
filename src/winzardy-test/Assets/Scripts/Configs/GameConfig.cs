using UnityEngine;

namespace Configs
{
    [CreateAssetMenu(fileName = "GameConfig", menuName = "Configs/GameConfig")]
    public class GameConfig : ScriptableObject {
        public float PlayerSpeed = 5f;
        public float PlayerMaxHealth = 100f;
        public float FireRate = 1f;

        public float ProjectileDamage = 25f;
        public float ProjectileSpeed = 10f;
        public float ProjectileLifetime = 3f;

        public float EnemySpawnRate = 7f;
        public float EnemyHealth = 100f;
        public float EnemySpeed = 3f;
        public float EnemyDamagePerSecond = 5f;
        public float EnemyAttackDistance = 1.2f;

        [Range(0, 1)] public float CoinDropChance = 0.5f;
    }
}