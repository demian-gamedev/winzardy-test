using System;
using Entitas.VisualDebugging.Unity.Editor;
using UnityEditor;

namespace Editor
{
    public class InterfaceTypeDrawer : ITypeDrawer {
    
        public bool HandlesType(Type type) {
            return type.IsInterface;
        }

        public object DrawAndGetNewValue(Type memberType, string memberName, object value, object target) {
            EditorGUILayout.LabelField(memberName, $"{memberType.Name} (Active)");
            return value;
        }
    }
}