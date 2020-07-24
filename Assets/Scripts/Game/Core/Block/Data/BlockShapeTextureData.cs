using System;
using UnityEngine;

namespace Game.Core.Block
{
    [Serializable]
    public class BlockShapeTextureData
    {
        public EBlockShapeType ShapeType => _shapeType;
        public EBlockTextureId TextureId => _textureId;

        [SerializeField] private EBlockShapeType _shapeType;
        [SerializeField] private EBlockTextureId _textureId;
    }
}
