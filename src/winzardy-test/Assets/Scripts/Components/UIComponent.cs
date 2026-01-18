using Entitas;
using Entitas.CodeGeneration.Attributes;
using TMPro;
using View;

namespace Components
{
    [Game, Unique]
    public class UIComponent : IComponent {
        public HUD Value;
    }
    [Game]
    public class HealthBarComponent : IComponent {
        public TextMeshProUGUI Value;
    }
}