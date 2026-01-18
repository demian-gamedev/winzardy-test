using Entitas;
using UnityEngine;

namespace Systems
{
    public class GameUISystem : IExecuteSystem {
    
        private readonly GameContext _context;

        public GameUISystem(Contexts contexts) {
            _context = contexts.game;
        }

        public void Execute() {
            if (!_context.hasUI) return;
            var ui = _context.uI.Value;

            var player = _context.playerEntity;
            if (player != null && player.hasHealth) {
                ui.HealthText.text = $"HP: {Mathf.Ceil(player.health.Current)}";
            } else {
                ui.HealthText.text = "HP: 0";
            }

            if (_context.hasScore) {
                ui.ScoreText.text = $"Coins: {_context.score.Value}";
            } else {
                ui.ScoreText.text = "Coins: 0";
            }

            if (_context.isGameOver && !ui.GameOverPanel.activeSelf) {
                ui.GameOverPanel.SetActive(true);
            }
        }
    }
}