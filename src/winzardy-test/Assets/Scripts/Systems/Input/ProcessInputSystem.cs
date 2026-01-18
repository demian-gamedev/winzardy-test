using Entitas;
using UnityEngine;

namespace Systems.Input
{
    public class ProcessInputSystem : IExecuteSystem {
    
        private readonly GameContext _context;
        private readonly IGroup<GameEntity> _players;

        public ProcessInputSystem(Contexts contexts) {
            _context = contexts.game;
            _players = _context.GetGroup(GameMatcher.Player);
        }

        public void Execute() {
            var moveInput = _context.input.MoveAxes;

            var dir = new Vector3(moveInput.x, 0, moveInput.y);

            foreach (var player in _players.GetEntities()) {
                if (_context.isInputBlocked || player.isDead) {
                    player.ReplaceDirection(Vector3.zero);
                } else {
                    player.ReplaceDirection(dir);
                }
            }
        }
    }
}