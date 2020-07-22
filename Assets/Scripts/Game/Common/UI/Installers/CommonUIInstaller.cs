using UnityEngine;
using Zenject;

namespace Game.Common.UI
{
    [CreateAssetMenu(menuName = "ScriptableObject/Installers/Game/Common/UI", fileName = "CommonUIInstaller")]
    public class CommonUIInstaller : ScriptableObjectInstaller
    {
        [SerializeField] private CanvasView _canvasView;

        public override void InstallBindings()
        {
            Container.BindInterfacesTo<CanvasView>().FromComponentInNewPrefab(_canvasView).AsSingle();
            Container.BindInterfacesTo<CanvasController>().AsSingle();
            Container.BindInterfacesTo<UIElementsAttacher>().AsSingle();
        }
    }
}
