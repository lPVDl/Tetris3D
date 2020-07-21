using Game.Core.Level;

namespace Game.Core.Block
{
    public class BlockViewBuilder : IBlockViewBuilder
    {
        private readonly IBlockViewFactory _viewFactory;
        private readonly ILevelViewTransform _levelViewTransform;

        public BlockViewBuilder(IBlockViewFactory viewFactory,
                                ILevelViewTransform levelViewTransform)
        {
            _viewFactory = viewFactory;
            _levelViewTransform = levelViewTransform;
        }

        public IBlockView BuildView(IBlockModel blockModel)
        {
            var blockView = _viewFactory.CreateBlock();

            var worldPos = _levelViewTransform.TransformPosition(blockModel.Position);
            blockView.SetPosition(worldPos);
            blockView.SetRotation(blockModel.Rotation);
            foreach (var pos in blockModel.Shape.Sections)
            {
                var section = _viewFactory.CreateSection();
                blockView.AttachSection(section);
                section.SetPosition(worldPos + blockModel.Rotation * pos);

                // TODO: Many colors may break batching. Should change way meshes drawn.
                // section.SetColor()
            }

            return blockView;
        }
    }
}
