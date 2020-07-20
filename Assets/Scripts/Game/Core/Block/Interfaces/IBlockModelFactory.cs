using UnityEngine;

namespace Game.Core.Block
{
    public interface IBlockModelFactory
    {
        IBlockModel CreateBlock(EBlockShapeType shapeType, Vector3 position, Quaternion rotation);
    }
}
