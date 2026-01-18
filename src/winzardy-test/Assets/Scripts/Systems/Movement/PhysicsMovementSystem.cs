using Entitas;

namespace Systems.Movement
{
    public class PhysicsMovementSystem : IExecuteSystem {
    
        private readonly IGroup<GameEntity> _movers;

        public PhysicsMovementSystem(Contexts contexts) {
            _movers = contexts.game.GetGroup(GameMatcher.AllOf(
                GameMatcher.Direction,
                GameMatcher.Speed,
                GameMatcher.Rigidbody
            ));
        }

        public void Execute() {
            foreach (var e in _movers.GetEntities()) {
                var rb = e.rigidbody.Value;
                var velocity = e.direction.Value * e.speed.Value;
            
                velocity.y = rb.linearVelocity.y; 
            
                rb.linearVelocity = velocity;
            }
        }
    }
}