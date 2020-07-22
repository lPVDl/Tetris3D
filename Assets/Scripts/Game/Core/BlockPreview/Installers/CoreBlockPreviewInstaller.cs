using UnityEngine;
using Zenject;

namespace Game.Core.BlockPreview
{
    [CreateAssetMenu(menuName = "ScriptableObject/Installers/Game/Core/BlockPreview", fileName = "CoreBlockPreviewInstaller")]
    public class CoreBlockPreviewInstaller : ScriptableObjectInstaller
    {
        [SerializeField] private BlockPreviewPanelView _panelView;
        [SerializeField] private BlockPreviewRenderView _renderView;

        public override void InstallBindings()
        {
            Container.Bind<BlockPreviewPanelView>().FromComponentInNewPrefab(_panelView).AsSingle();
            Container.BindInterfacesTo<BlockPreviewRenderView>().FromComponentInNewPrefab(_renderView).AsSingle();
            Container.BindInterfacesTo<BlockPreviewPanel>().AsSingle();
            Container.BindInterfacesTo<BlockPreviewRenderController>().AsSingle();
        }
    }
}
