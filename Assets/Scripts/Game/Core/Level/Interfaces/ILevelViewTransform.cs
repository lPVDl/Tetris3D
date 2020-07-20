using UnityEngine;

namespace Game.Core.Level
{
    public interface ILevelViewTransform
    {
        Vector3 TransformPosition(Vector3Int index);
    }
}
