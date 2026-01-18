using Configs;
using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

namespace Components
{
    [Game, Unique]
    public class GameConfigComponent : IComponent {
        public GameConfig Value;
    }
    [Game, Unique]
    public class AssetLibraryComponent : IComponent {
        public GameObject PlayerPrefab;
        public GameObject EnemyPrefab;
        public GameObject ProjectilePrefab;
        public GameObject CoinPrefab;
    }
}