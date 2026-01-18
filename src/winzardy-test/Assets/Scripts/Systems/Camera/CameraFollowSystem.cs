using Entitas;
using UnityEngine;

namespace Systems.Camera
{
    public class CameraFollowSystem : IExecuteSystem {
    
        private readonly IGroup<GameEntity> _playerGroup;
        private readonly UnityEngine.Camera _camera;
        private readonly Vector3 _offset;

        public CameraFollowSystem(Contexts contexts) {
            _playerGroup = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Player, GameMatcher.Position));
        
            _camera = UnityEngine.Camera.main;
            if (_camera != null) {
                _offset = _camera.transform.position; 
            }
        }

        public void Execute() {
            if (_camera == null) return;

            var player = _playerGroup.GetSingleEntity();
        
            if (player != null) {
                _camera.transform.position = player.position.Value + _offset;
            }
        }
    }
}