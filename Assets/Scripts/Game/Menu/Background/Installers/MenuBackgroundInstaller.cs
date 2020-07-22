using UnityEngine;
using Zenject;

namespace Game.Menu.Background
{
    [CreateAssetMenu(menuName = "ScriptableObject/Installers/Game/Menu/Background", fileName = "MenuBackgroundInstaller")]
    public class MenuBackgroundInstaller : ScriptableObjectInstaller
    {
        [SerializeField] private BackgroundView _backgroundView;

        public override void InstallBindings()
        {
            Container.Bind<BackgroundView>().FromComponentInNewPrefab(_backgroundView).AsSingle();
            Container.BindInterfacesTo<Background>().AsSingle();
        }
    }
}
