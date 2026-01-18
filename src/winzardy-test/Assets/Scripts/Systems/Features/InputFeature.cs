using Systems.Input;

namespace Systems.Features
{
    public class InputFeature : Feature {
        public InputFeature(Contexts contexts) {
            Add(new EmitInputSystem(contexts));
            Add(new ProcessInputSystem(contexts));
        }
    }
}