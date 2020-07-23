using UnityEngine;

namespace Game.Core.BlockMesh
{
    public class BlockMeshView : MonoBehaviour, IBlockMeshView
    {
        [SerializeField] private MeshFilter _meshFilter;
        [SerializeField] private MeshRenderer _meshRenderer;

        public void SetMesh(Mesh mesh)
        {
            _meshFilter.mesh = mesh;
        }

        public void SetParent(Transform parent)
        {
            transform.SetParent(parent);
        }

        public void SetPosition(Vector3 position)
        {
            transform.position = position;
        }

        public void SetRotation(Quaternion rotation)
        {
            transform.rotation = rotation;
        }

        public void SetMaterial(Material material)
        {
            _meshRenderer.material = material;
        }

        public void Dispose()
        {
            Destroy(gameObject);
        }
    }
}
