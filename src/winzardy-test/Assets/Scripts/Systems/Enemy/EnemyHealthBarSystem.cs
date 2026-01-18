using Entitas;

namespace Systems.Enemy
{
    public class EnemyHealthBarSystem : IExecuteSystem {
    
        private readonly IGroup<GameEntity> _group;

        public EnemyHealthBarSystem(Contexts contexts) {
            _group = contexts.game.GetGroup(GameMatcher.AllOf(
                GameMatcher.Health, 
                GameMatcher.HealthBar
            ));
        }

        public void Execute() {
            foreach (var e in _group.GetEntities()) {
                e.healthBar.Value.text = ((int)e.health.Current).ToString();
            }
        }
    }
}