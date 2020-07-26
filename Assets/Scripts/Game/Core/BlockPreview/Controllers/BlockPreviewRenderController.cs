using Game.Core.Block;
using Game.Core.BlockSpawn;
using System;
using System.Linq;
using UnityEngine;

namespace Game.Core.BlockPreview
{
    public class BlockPreviewRenderController : IDisposable
    {
        private readonly IBlockPreviewRenderView _renderView;
        private readonly IBlockSpawnController _spawnController;
        private readonly IBlockViewBuilder _blockViewBuilder;

        private IBlockView _blockView;

        public BlockPreviewRenderController(IBlockPreviewRenderView renderView,
                                            IBlockSpawnController spawnController,
                                            IBlockViewBuilder blockViewBuilder)
        {
            _renderView = renderView;
            _spawnController = spawnController;
            _blockViewBuilder = blockViewBuilder;

            _spawnController.OnNextBlockChange += RedrawBlockView;
        }

        private void RedrawBlockView()
        {
            _blockView?.Dispose();

            var block = _spawnController.NextBlock;
            var bounds = ComputeBounds(block.Shape);
            var halfSize = bounds.size / 2;
            var root = _renderView.BlockRoot;
            
            _renderView.SetCameraScale(Mathf.Max(halfSize.x, halfSize.z) + 0.5f);

            _blockView = _blockViewBuilder.BuildView(block);
            _blockView.Position = root.position - bounds.center;
            _blockView.SetParent(root);
        }

        private Bounds ComputeBounds(BlockShapeData shapeData)
        {
            var minX = shapeData.Sections.Min(s => s.x) - 0.5f;
            var minY = shapeData.Sections.Min(s => s.y) - 0.5f;
            var minZ = shapeData.Sections.Min(s => s.z) - 0.5f;
            var maxX = shapeData.Sections.Max(s => s.x) + 0.5f;
            var maxY = shapeData.Sections.Max(s => s.y) + 0.5f;
            var maxZ = shapeData.Sections.Max(s => s.z) + 0.5f;
            var size = new Vector3(maxX - minX, maxY - minY, maxZ - minZ);
            var center = new Vector3(minX + maxX, minY + maxY, minZ + maxZ) / 2;

            return new Bounds(center, size);
        }

        public void Dispose()
        {
            _spawnController.OnNextBlockChange -= RedrawBlockView;
        }
    }
}
