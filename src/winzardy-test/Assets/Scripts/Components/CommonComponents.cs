using Entitas;
using UnityEngine;

namespace Components
{
    [Game]
    public class ViewComponent : IComponent {
        public GameObject Value;
    }

    [Game]
    public class ResourceComponent : IComponent {
        public GameObject Prefab;
    }

    [Game]
    public class PositionComponent : IComponent {
        public Vector3 Value;
    }
    [Game]
    public class RigidbodyComponent : IComponent {
        public Rigidbody Value;
    }

    [Game]
    public class DirectionComponent : IComponent {
        public Vector3 Value;
    }

    [Game]
    public class DestroyedComponent : IComponent {
    }
}