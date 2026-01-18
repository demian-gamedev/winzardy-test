using System.Collections.Generic;
using Entitas;

namespace Systems
{
    public class CollisionSystem : ReactiveSystem<GameEntity> {
    
        private readonly GameContext _context;

        public CollisionSystem(Contexts contexts) : base(contexts.game) {
            _context = contexts.game;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) {
            return context.CreateCollector(GameMatcher.Collision);
        }

        protected override bool Filter(GameEntity entity) {
            return entity.hasCollision;
        }

        protected override void Execute(List<GameEntity> entities) {
            foreach (var e in entities) {
                var source = e.collision.Source;
                var target = e.collision.Target;

                if (source != null && target != null && source.isEnabled && target.isEnabled) {
                    HandleCollision(source, target);
                }
            }
        }

        private void HandleCollision(GameEntity source, GameEntity target) {

            if (source.isProjectile && target.isEnemy) {
                if (target.hasHealth && source.hasDamage) {
                    var newHp = target.health.Current - source.damage.Value;
                    target.ReplaceHealth(newHp, target.health.Max);
                }
                source.isDestroyed = true; 
            }
        
            if (source.isPlayer && target.isCoin) {
                var wallet = _context.scoreEntity; 
                if (wallet != null) {
                    wallet.ReplaceScore(wallet.score.Value + 1);
                } else {
                    _context.SetScore(1);
                }
                target.isDestroyed = true;
            }
        
            if (source.isCoin && target.isPlayer) {
                var wallet = _context.scoreEntity; 
                if (wallet != null) {
                    wallet.ReplaceScore(wallet.score.Value + 1);
                } else {
                    _context.SetScore(1);
                }
                source.isDestroyed = true; 
            }
        }
    }
}