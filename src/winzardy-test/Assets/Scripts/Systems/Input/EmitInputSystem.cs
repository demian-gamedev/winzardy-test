using Entitas;
using UnityEngine;

namespace Systems.Input
{
    public class EmitInputSystem : IExecuteSystem {
    
        private readonly GameContext _gameContext; 

        public EmitInputSystem(Contexts contexts) {
            _gameContext = contexts.game;
        }

        public void Execute() {
            var x = UnityEngine.Input.GetAxisRaw("Horizontal");
            var y = UnityEngine.Input.GetAxisRaw("Vertical");
        
            var inputVector = new Vector2(x, y);

            if (inputVector.sqrMagnitude > 1) {
                inputVector.Normalize();
            }

            _gameContext.ReplaceInput(inputVector);
        }
    }
}