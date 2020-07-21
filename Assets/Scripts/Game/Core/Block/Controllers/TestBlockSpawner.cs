using Game.Common.GameEvents;
using UnityEngine;

namespace Game.Core.Block
{
    public class TestBlockSpawner : IInitializable
    {
        private readonly IBlockModelStorage _blockStorage;
        private readonly IBlockModelFactory _blockFactory;

        public TestBlockSpawner(IBlockModelStorage blockStorage,
                                IBlockModelFactory blockFactory)
        {
            _blockStorage = blockStorage;
            _blockFactory = blockFactory;
        }

        public void Initialize()
        {
            var block = _blockFactory.CreateBlock(EBlockShapeType.Shape1, Vector3Int.zero, Quaternion.identity);
            _blockStorage.AddBlock(block);
        }
    }
}
