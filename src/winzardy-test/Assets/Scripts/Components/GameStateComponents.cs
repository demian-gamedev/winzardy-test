using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace Components
{
    [Game, Unique]
    public class ScoreComponent : IComponent {
        public int Value;
    }

    [Game, Unique]
    public class SpawnTimerComponent : IComponent {
        public float Value;
    }

    [Game, Unique]
    public class GameOverComponent : IComponent {
    }
}