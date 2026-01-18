using Entitas;

namespace Systems.Movement
{
    public class SyncPositionSystem : IExecuteSystem {
    
        private readonly IGroup<GameEntity> _viewEntities;

        public SyncPositionSystem(Contexts contexts) {
            _viewEntities = contexts.game.GetGroup(GameMatcher.AllOf(
                GameMatcher.View,
                GameMatcher.Position
            ));
        }

        public void Execute() {
            foreach (var entity in _viewEntities.GetEntities()) {
                entity.ReplacePosition(entity.view.Value.transform.position);
            }
        }
    }
}