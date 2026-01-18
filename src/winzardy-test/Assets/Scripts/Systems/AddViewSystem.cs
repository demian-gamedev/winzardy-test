using System.Collections.Generic;
using Entitas;
using TMPro;
using UnityEngine;
using View;

namespace Systems
{
    public class AddViewSystem : ReactiveSystem<GameEntity> {
    
        private readonly Contexts _contexts;

        public AddViewSystem(Contexts contexts) : base(contexts.game) {
            _contexts = contexts;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) {
            return context.CreateCollector(GameMatcher.Resource);
        }

        protected override bool Filter(GameEntity entity) {
            return entity.hasResource && !entity.hasView;
        }

        protected override void Execute(List<GameEntity> entities) {
            foreach (var entity in entities) {
                var prefab = entity.resource.Prefab;
                var pos = entity.hasPosition ? entity.position.Value : Vector3.zero;

                GameObject go = Object.Instantiate(prefab, pos, Quaternion.identity);

                var viewScript = go.GetComponent<GameEntityView>();
                if (viewScript != null) {
                    viewScript.Link(entity);
                }

                entity.AddView(go);
            
                var healthText = go.GetComponentInChildren<TextMeshProUGUI>();
                if (healthText != null) {
                    entity.AddHealthBar(healthText);
                }

                if (entity.hasPosition) {
                    go.transform.position = entity.position.Value;
                }
                
                var rb = go.GetComponent<Rigidbody>();
                if (rb != null) {
                    entity.AddRigidbody(rb);
                }
            }
        }
    }
}