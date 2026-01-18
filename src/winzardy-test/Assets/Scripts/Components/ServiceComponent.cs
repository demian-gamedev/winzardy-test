using Entitas;
using Entitas.CodeGeneration.Attributes;
using Services;

namespace Components
{
    [Game, Unique]
    public class CameraServiceComponent : IComponent {
        public ICameraService Value;
    }
}