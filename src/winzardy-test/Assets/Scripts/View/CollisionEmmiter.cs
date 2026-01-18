using UnityEngine;

namespace View
{
    public class CollisionEmitter : MonoBehaviour {
    
        private GameEntityView _selfView;

        private void Awake() {
            _selfView = GetComponent<GameEntityView>();
        }

        private void OnTriggerEnter(Collider other) {
            if (_selfView == null || _selfView.Entity == null) return;

            var otherView = other.GetComponent<GameEntityView>();
        
            if (otherView != null && otherView.Entity != null) {
            
                var context = Contexts.sharedInstance.game;
                var collisionEntity = context.CreateEntity();
            
                collisionEntity.AddCollision(_selfView.Entity, otherView.Entity);
            
                collisionEntity.isDestroyed = true; 
            }
        }
    
        private void OnCollisionEnter(Collision other) {
            if (_selfView == null || _selfView.Entity == null) return;
            var otherView = other.gameObject.GetComponent<GameEntityView>();
        
            if (otherView != null && otherView.Entity != null) {
                var context = Contexts.sharedInstance.game;
                var collisionEntity = context.CreateEntity();
                collisionEntity.AddCollision(_selfView.Entity, otherView.Entity);
                collisionEntity.isDestroyed = true; 
            }
        }
    }
}