using UnityEngine;
using Zenject;

namespace Game.Menu.MainWindow
{
    [CreateAssetMenu(menuName = "ScriptableObject/Installers/Game/Menu/MainWindow", fileName = "MenuMainWindowInstaller")]
    public class MenuMainWindowInstaller : ScriptableObjectInstaller
    {
        [SerializeField] private MainWindowView _mainWindowView;

        public override void InstallBindings()
        {
            Container.Bind<MainWindowView>().FromComponentsInNewPrefab(_mainWindowView).AsSingle();
            Container.BindInterfacesTo<MainWindow>().AsSingle();
        }
    }
}
