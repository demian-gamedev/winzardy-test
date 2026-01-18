using Components;
using Configs;
using Services;
using UnityEngine;
using View;

public class GameBootstrapper : MonoBehaviour {
    
    public GameConfig GameConfig;
    public HUD HUD;

    [Header("Asset References")]
    public GameObject PlayerPrefab;
    public GameObject EnemyPrefab;
    public GameObject ProjectilePrefab;
    public GameObject CoinPrefab;

    private GameEntry _gameEntry;

    private void Awake() {
        var contexts = Contexts.sharedInstance;
        contexts.Reset(); 

        var assets = new AssetLibraryComponent {
            PlayerPrefab = this.PlayerPrefab,
            EnemyPrefab = this.EnemyPrefab,
            ProjectilePrefab = this.ProjectilePrefab,
            CoinPrefab = this.CoinPrefab
        };
        
        contexts.game.SetUI(HUD);
        contexts.game.SetCameraService(new CameraService(Camera.main));

        _gameEntry = new GameEntry(GameConfig, assets);
    }

    private void Update() {
        _gameEntry?.Update();
    }

    private void OnDestroy() {
        _gameEntry?.TearDown();
    }
}