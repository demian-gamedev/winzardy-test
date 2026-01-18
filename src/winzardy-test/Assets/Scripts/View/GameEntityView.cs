using UnityEngine;

namespace View
{
    public class GameEntityView : MonoBehaviour {
        public GameEntity Entity { get; private set; }

        public void Link(GameEntity entity) {
            Entity = entity;
        }
    }
}