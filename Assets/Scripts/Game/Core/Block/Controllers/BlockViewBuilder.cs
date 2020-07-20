namespace Game.Core.Block
{
    public class BlockViewBuilder : IBlockViewBuilder
    {
        private readonly IBlockViewFactory _viewFactory;

        public BlockViewBuilder(IBlockViewFactory viewFactory)
        {
            _viewFactory = viewFactory;
        }

        public IBlockView BuildView(IBlockModel blockModel)
        {
            var blockView = _viewFactory.CreateBlock();

            blockView.SetPosition(blockModel.Position);
            foreach (var pos in blockModel.Shape.Sections)
            {
                var section = _viewFactory.CreateSection();
                blockView.AttachSection(section);
                section.SetPosition(blockModel.Position + blockModel.Rotation * pos);
            }

            return blockView;
        }
    }
}
