using UnityEngine;

namespace Game.Core.Block
{
    public class BlockSectionView : MonoBehaviour, IBlockSectionView
    {
        [SerializeField] private MeshRenderer _meshRenderer;

        private MaterialPropertyBlock _propertyBlock;

        private void Awake()
        {
            _propertyBlock = new MaterialPropertyBlock();
        }

        public void SetColor(Color color)
        {
            _meshRenderer.GetPropertyBlock(_propertyBlock);
            _propertyBlock.SetColor("_Color", color);
            _meshRenderer.SetPropertyBlock(_propertyBlock);
        }

        public void SetParent(Transform parent)
        {
            transform.SetParent(parent);
        }

        public void SetPosition(Vector3 position)
        {
            transform.position = position;
        }

        public void Dispose()
        {
            Destroy(gameObject);
        }
    }
}
