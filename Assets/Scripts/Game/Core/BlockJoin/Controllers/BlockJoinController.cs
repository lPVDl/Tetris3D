using Game.Core.Block;
using Game.Core.Level;

namespace Game.Core.BlockJoin
{
    public class BlockJoinController : IBlockJoinController
    {
        private readonly IBlockShapeUtil _shapeUtil;
        private readonly ILevelModel _levelModel;
        private readonly IBlockModelStorage _blockStorage;

        public BlockJoinController(IBlockShapeUtil shapeUtil,
                                   ILevelModel levelModel,
                                   IBlockModelStorage blockStorage)
        {
            _shapeUtil = shapeUtil;
            _levelModel = levelModel;
            _blockStorage = blockStorage;
        }

        public void JoinBlock()
        {
            if (_blockStorage.Blocks.Count <= 0) return;

            var block = _blockStorage.Blocks[0];

            foreach (var pos in _shapeUtil.IterateBlockSections(block))
                _levelModel.AddBlock(pos);

            _blockStorage.RemoveBlock(block);
        }
    }
}
