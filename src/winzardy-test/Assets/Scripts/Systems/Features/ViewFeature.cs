using Systems.Enemy;

namespace Systems.Features
{
    public class ViewFeature : Feature {
        public ViewFeature(Contexts contexts) {
            Add(new AddViewSystem(contexts));
            Add(new GameUISystem(contexts));
            Add(new EnemyHealthBarSystem(contexts));
        }
    }
}