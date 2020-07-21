using UnityEngine;

namespace Game.Core.Block
{
    public interface IBlockModelFactory
    {
        IBlockModel CreateBlock(EBlockShapeType shapeType, Vector3Int position, Quaternion rotation);
    }
}
