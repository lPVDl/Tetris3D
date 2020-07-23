using UnityEngine;
using Zenject;

namespace Game.Core.BlockMesh
{
    [CreateAssetMenu(menuName = "ScriptableObject/Installers/Game/Core/BlockMesh", fileName = "CoreBlockMeshInstaller")]
    public class CoreBlockMeshInstaller : ScriptableObjectInstaller
    {
        [SerializeField] private BlockMeshView _blockMeshView;
        [SerializeField] private Mesh _blockMesh;

        public override void InstallBindings()
        {
            Container.BindInterfacesTo<BlockMeshBuilder>().AsSingle().WithArguments(_blockMesh);
            Container.BindInterfacesTo<BlockMeshViewFactory>().AsSingle().WithArguments(_blockMeshView);
            Container.BindInterfacesTo<BlockShapeMeshProvider>().AsSingle();
        }
    }
}
