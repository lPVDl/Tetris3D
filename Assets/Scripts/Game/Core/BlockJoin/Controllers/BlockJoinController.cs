using Game.Common.Audio;
using Game.Core.Block;
using Game.Core.Level;

namespace Game.Core.BlockJoin
{
    public class BlockJoinController : IBlockJoinController
    {
        private readonly IBlockShapeUtil _shapeUtil;
        private readonly ILevelModel _levelModel;
        private readonly IBlockModelStorage _blockStorage;
        private readonly IBlockShapeTextureProvider _shapeTextureProvider;
        private readonly IAudioController _audioController;

        public BlockJoinController(IBlockShapeUtil shapeUtil,
                                   ILevelModel levelModel,
                                   IBlockModelStorage blockStorage,
                                   IBlockShapeTextureProvider shapeTextureProvider,
                                   IAudioController audioController)
        {
            _shapeUtil = shapeUtil;
            _levelModel = levelModel;
            _blockStorage = blockStorage;
            _shapeTextureProvider = shapeTextureProvider;
            _audioController = audioController;
        }

        public void JoinBlock()
        {
            if (_blockStorage.Blocks.Count <= 0) return;

            var block = _blockStorage.Blocks[0];
            var texture = _shapeTextureProvider.GetTexture(block.Shape);
            foreach (var pos in _shapeUtil.IterateBlockSections(block))
                _levelModel.AddBlock(pos, texture);

            _audioController.ReportEvent(EAudioEventType.BlockJoined);

            _blockStorage.RemoveBlock(block);
        }
    }
}
