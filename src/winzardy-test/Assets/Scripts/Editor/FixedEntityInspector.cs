using System;
using System.Reflection;
using Entitas;
using Entitas.VisualDebugging.Unity;
using UnityEditor;
using UnityEngine;

namespace Editor
{
    // we need to override the default EntityBehaviour inspector
    // because the default one does not work in latest versions of Unity
    [CustomEditor(typeof(EntityBehaviour))]
    public class FixedEntityInspector : UnityEditor.Editor {
        public override void OnInspectorGUI() {
            var behaviour = (EntityBehaviour)target;
            var entity = behaviour.entity;

            if (entity == null) {
                EditorGUILayout.HelpBox("Entity is destroyed or not linked.", MessageType.Info);
                return;
            }

            EditorGUILayout.LabelField($"Entity Index: {entity.creationIndex}", EditorStyles.boldLabel);
            EditorGUILayout.LabelField($"Total Components: {entity.GetComponents().Length}");
        
            EditorGUILayout.Space();
            DrawComponents(entity);
        
            EditorGUILayout.Space();
            if (GUILayout.Button("Destroy Entity")) {
                entity.Destroy();
            }
        
            if (Application.isPlaying) {
                Repaint();
            }
        }

        private void DrawComponents(IEntity entity) {
            var components = entity.GetComponents();
        
            foreach (var component in components) {
                var type = component.GetType();
                string componentName = type.Name.Replace("Component", "");

                EditorGUILayout.BeginVertical(EditorStyles.helpBox);
            
                EditorGUILayout.LabelField(componentName, EditorStyles.boldLabel);
            
                var fields = type.GetFields(BindingFlags.Public | BindingFlags.Instance);
                foreach (var field in fields) {
                    object value = field.GetValue(component);
                    object newValue = DrawField(field.Name, value, field.FieldType);

                    if (newValue != null && !newValue.Equals(value)) {
                        field.SetValue(component, newValue);
                    }
                }

                EditorGUILayout.EndVertical();
                EditorGUILayout.Space(2);
            }
        }

        private object DrawField(string name, object value, Type type) {
            if (value == null && !type.IsValueType) {
                EditorGUILayout.LabelField(name, "null");
                return null;
            }

            if (type == typeof(int)) return EditorGUILayout.IntField(name, (int)value);
            if (type == typeof(float)) return EditorGUILayout.FloatField(name, (float)value);
            if (type == typeof(bool)) return EditorGUILayout.Toggle(name, (bool)value);
            if (type == typeof(string)) return EditorGUILayout.TextField(name, (string)value);
            if (type == typeof(Vector2)) return EditorGUILayout.Vector2Field(name, (Vector2)value);
            if (type == typeof(Vector3)) return EditorGUILayout.Vector3Field(name, (Vector3)value);
        
            if (typeof(UnityEngine.Object).IsAssignableFrom(type)) {
                return EditorGUILayout.ObjectField(name, (UnityEngine.Object)value, type, true);
            }

            EditorGUILayout.LabelField(name, value.ToString());
            return value;
        }
    }
}