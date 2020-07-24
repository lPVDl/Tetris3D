using UnityEngine;

namespace Game.Core.LevelGrid
{
    public interface ILevelGridMeshBuilder
    {
        Mesh Build(Vector3 size);
    }
}
