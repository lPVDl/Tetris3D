using UnityEngine;
using Zenject;

namespace Game.Core.LevelGrid
{
    [CreateAssetMenu(menuName = "ScriptableObject/Installers/Game/Core/LevelGrid", fileName = "CoreLevelGridInstaller")]
    public class CoreLevelGridInstaller : ScriptableObjectInstaller
    {
        [SerializeField] private Material _gridMaterial;

        public override void InstallBindings()
        {
            Container.BindInterfacesTo<LevelGridMeshBuilder>().AsSingle();
            Container.BindInterfacesTo<LevelGridMeshController>().AsSingle().WithArguments(_gridMaterial);
        }
    }
}
