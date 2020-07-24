using System.Collections.Generic;
using System.Linq;

namespace Game.Core.Block
{
    public class BlockShapeTextureProvider : IBlockShapeTextureProvider
    {
        private Dictionary<EBlockShapeType, EBlockTextureId> _textures;

        public BlockShapeTextureProvider(List<BlockShapeTextureData> textures)
        {
            _textures = textures.ToDictionary(t => t.ShapeType, t => t.TextureId);
        }

        public EBlockTextureId GetTexture(BlockShapeData shapeData)
        {
            if (!_textures.TryGetValue(shapeData.ShapeType, out var textureId))
            {
                UnityEngine.Debug.LogError($"{this}: texture id for '{shapeData.ShapeType}' was not found.");
            }

            return textureId;
        }
    }
}
