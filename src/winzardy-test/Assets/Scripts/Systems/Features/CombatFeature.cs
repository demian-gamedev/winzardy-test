using Systems.Enemy;
using Systems.Player;

namespace Systems.Features
{
    public class CombatFeature : Feature {
        public CombatFeature(Contexts contexts) {
            Add(new PlayerShootingSystem(contexts));
            Add(new CollisionSystem(contexts));
            Add(new EnemyDamageSystem(contexts));
            Add(new DeathSystem(contexts));
        }
    }
}