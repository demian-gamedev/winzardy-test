using Systems.Camera;
using Systems.Movement;

namespace Systems.Features
{
    public class MovementFeature : Feature {
        public MovementFeature(Contexts contexts) {
            Add(new PhysicsMovementSystem(contexts));
            Add(new ProjectileSystem(contexts));
            Add(new SyncPositionSystem(contexts));
            Add(new CameraFollowSystem(contexts));
        }
    }
}