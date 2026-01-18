using Entitas;

namespace Components
{
    [Game]
    public class ProjectileComponent : IComponent {
    }

    [Game]
    public class DamageComponent : IComponent {
        public float Value;
    }

    [Game]
    public class CooldownComponent : IComponent {
        public float Value;
    }

    [Game]
    public class LifetimeComponent : IComponent {
        public float Value;
    }

    [Game]
    public class CollisionComponent : IComponent {
        public GameEntity Source;
        public GameEntity Target;
    }
}