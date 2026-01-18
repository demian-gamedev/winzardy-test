using Entitas;
using UnityEngine;

namespace Systems.Player
{
    public class PlayerInitSystem : IInitializeSystem {
    
        private readonly Contexts _contexts;

        public PlayerInitSystem(Contexts contexts) {
            _contexts = contexts;
        }

        public void Initialize() {
            var config = _contexts.game.gameConfig.Value;
            var assets = _contexts.game.assetLibrary;

            var entity = _contexts.game.CreateEntity();

            entity.isPlayer = true;

            entity.AddHealth(config.PlayerMaxHealth, config.PlayerMaxHealth);
            entity.AddSpeed(config.PlayerSpeed);
            entity.AddPosition(Vector3.zero);
            entity.AddDirection(Vector3.forward);
        
            entity.AddCooldown(0); 

            entity.AddResource(assets.PlayerPrefab);
        }
    }
}