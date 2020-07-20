using System.Collections.Generic;
using UnityEngine;

namespace Game.Core.Block
{
    [System.Serializable]
    public class BlockShapeData
    {
        public EBlockShapeType ShapeType => _shapeType;
        public IReadOnlyList<Vector3> Sections => _sections;

        [SerializeField] private List<Vector3> _sections;
        [SerializeField] private EBlockShapeType _shapeType;
    }
}
