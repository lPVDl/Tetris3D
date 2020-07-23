using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Game.Core.BlockMesh
{
    public class BlockMeshBuilder : IBlockMeshBuilder
    {
        private readonly Mesh _blockMesh;
        private readonly List<Vector3> _buffer;

        public BlockMeshBuilder(Mesh blockMesh)
        {
            _buffer = new List<Vector3>();
            _blockMesh = blockMesh;
        }

        public void BuildMesh(Mesh target, IEnumerable<Vector3> blocks)
        {
            var instances = blocks.Select(p => new CombineInstance()
            {
                mesh = _blockMesh,
                transform = Matrix4x4.Translate(p)
            }).ToArray();

            target.CombineMeshes(instances, mergeSubMeshes: true, useMatrices: true);
            target.RecalculateBounds();
            target.RecalculateNormals();
            target.Optimize();
        }
    }
}
