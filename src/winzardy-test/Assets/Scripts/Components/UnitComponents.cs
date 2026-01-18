using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace Components
{
    [Game, Unique]
    public class PlayerComponent : IComponent {
    }

    [Game]
    public class EnemyComponent : IComponent {
    }

    [Game]
    public class CoinComponent : IComponent {
    }

    [Game]
    public class HealthComponent : IComponent {
        public float Current;
        public float Max;
    }

    [Game]
    public class SpeedComponent : IComponent {
        public float Value;
    }

    [Game]
    public class DeadComponent : IComponent {
    }
}