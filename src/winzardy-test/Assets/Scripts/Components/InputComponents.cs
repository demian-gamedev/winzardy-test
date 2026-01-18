using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

namespace Components
{
    [Game, Unique]
    public class InputComponent : IComponent {
        public Vector2 MoveAxes;
    }

    [Game, Unique]
    public class InputBlockedComponent : IComponent {
    }
}