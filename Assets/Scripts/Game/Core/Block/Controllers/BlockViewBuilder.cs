using Game.Core.BlockMesh;

namespace Game.Core.Block
{
    public class BlockViewBuilder : IBlockViewBuilder
    {
        private readonly IBlockShapeMeshProvider _meshProvider;
        private readonly IBlockMeshViewFactory _viewFactory;

        public BlockViewBuilder(IBlockShapeMeshProvider meshProvider,
                                IBlockMeshViewFactory viewFactory)
        {
            _meshProvider = meshProvider;
            _viewFactory = viewFactory;
        }

        public IBlockView BuildView(IBlockModel block)
        {
            var view = _viewFactory.CreateBlock();
            var mesh = _meshProvider.GetShapeMesh(block.Shape);

            view.SetMesh(mesh);

            return view;
        }
    }
}
