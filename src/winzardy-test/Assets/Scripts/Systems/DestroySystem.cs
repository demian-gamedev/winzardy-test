using Entitas;
using UnityEngine;
using View;

namespace Systems
{
    public class DestroySystem : ICleanupSystem {

        private readonly IGroup<GameEntity> _group;

        public DestroySystem(Contexts contexts) {
            _group = contexts.game.GetGroup(GameMatcher.Destroyed);
        }

        public void Cleanup() {
            foreach (var e in _group.GetEntities()) {
                if (e.hasView) {
                    var viewScript = e.view.Value.GetComponent<GameEntityView>();
                    if (viewScript != null) viewScript.Link(null);
                
                    Object.Destroy(e.view.Value);
                }
                e.Destroy();
            }
        }
    }
}