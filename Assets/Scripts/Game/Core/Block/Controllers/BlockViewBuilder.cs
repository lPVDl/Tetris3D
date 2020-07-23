using Game.Core.BlockMesh;
using Game.Core.Level;

namespace Game.Core.Block
{
    public class BlockViewBuilder : IBlockViewBuilder
    {

        private readonly ILevelViewTransform _viewTransform;
        private readonly IBlockShapeMeshProvider _meshProvider;
        private readonly IBlockMeshViewFactory _viewFactory;

        public BlockViewBuilder(ILevelViewTransform viewTransform,
                                IBlockShapeMeshProvider meshProvider,
                                IBlockMeshViewFactory viewFactory)
        {

            _viewTransform = viewTransform;
            _meshProvider = meshProvider;
            _viewFactory = viewFactory;
        }

        public IBlockView BuildView(IBlockModel block)
        {
            var view = _viewFactory.CreateBlock();
            var mesh = _meshProvider.GetShapeMesh(block.Shape);
            var worldPos = _viewTransform.TransformPosition(block.Position);

            view.SetMesh(mesh);
            view.SetPosition(worldPos);
            view.SetRotation(block.Rotation);

            return view;
        }
    }
}
