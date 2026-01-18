using Systems.Features;

namespace Systems
{
    public class GameSystems : Feature {
        public GameSystems(Contexts contexts) {
            Add(new InputFeature(contexts));
            Add(new GameLogicFeature(contexts));
            Add(new MovementFeature(contexts));
            Add(new CombatFeature(contexts));
            Add(new ViewFeature(contexts));
            Add(new DestroySystem(contexts));
        }
    }
}