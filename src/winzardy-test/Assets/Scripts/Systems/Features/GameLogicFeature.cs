using Systems.Enemy;
using Systems.Player;

namespace Systems.Features
{
    public class GameLogicFeature : Feature {
        public GameLogicFeature(Contexts contexts) {
            Add(new PlayerInitSystem(contexts));
            Add(new EnemySpawnSystem(contexts));
            Add(new EnemyChasingSystem(contexts));
        }
    }
}