using UnityEngine;
using Zenject;

namespace Game.Core.GameOver
{
    [CreateAssetMenu(menuName = "ScriptableObject/Installers/Game/Core/GameOver", fileName = "CoreGameOverInstaller")]
    public class CoreGameOverInstaller : ScriptableObjectInstaller
    {
        [SerializeField] private GameOverWindowView _gameOverWindowView;

        public override void InstallBindings()
        {
            Container.Bind<GameOverWindowView>().FromComponentInNewPrefab(_gameOverWindowView).AsSingle();

            Container.BindInterfacesTo<GameOverWindow>().AsSingle();
            Container.BindInterfacesTo<GameOverWindowStartGameHandler>().AsSingle();
        }
    }
}
