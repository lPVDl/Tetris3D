using Game.Core.Block;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Core.BlockSpawn
{
    [System.Serializable]
    public class BlockSpawnControllerConfig
    {
        public IReadOnlyList<EBlockShapeType> Shapes => _shapes;

        [SerializeField] private List<EBlockShapeType> _shapes;
    }
}
