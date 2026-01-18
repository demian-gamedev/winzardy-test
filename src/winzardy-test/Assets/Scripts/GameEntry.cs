using Components;
using Configs;
using Systems;

public class GameEntry {

    private readonly Contexts _contexts;
    private readonly Entitas.Systems _systems;

    public GameEntry(GameConfig config, AssetLibraryComponent assets) {
        _contexts = Contexts.sharedInstance;

        // 1. Инициализируем глобальные данные в ECS
        // Конфиг (числа)
        _contexts.game.SetGameConfig(config);
        
        // Ассеты (префабы)
        _contexts.game.SetAssetLibrary(
            assets.PlayerPrefab,
            assets.EnemyPrefab,
            assets.ProjectilePrefab,
            assets.CoinPrefab
        );

        // 2. Создаем иерархию систем
        _systems = new GameSystems(_contexts);

        // 3. Запуск
        _systems.Initialize();
    }

    public void Update() {
        // Здесь можно обновлять TimeComponent, если мы хотим отвязать системы от Unity Time API
        // Но для простоты оставим Time.deltaTime внутри систем или добавим позже.
        
        _systems.Execute();
        _systems.Cleanup();
    }

    public void TearDown() {
        _systems.TearDown();
    }
}