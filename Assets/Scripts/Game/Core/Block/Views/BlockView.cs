using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Core.Block
{
    public class BlockView : MonoBehaviour, IBlockView
    {
        private List<IBlockSectionView> _sections;

        private void Awake()
        {
            _sections = new List<IBlockSectionView>();
        }

        public void AttachSection(IBlockSectionView section)
        {
            _sections.Add(section);
            section.SetParent(transform);
        }

        public void SetPosition(Vector3 position)
        {
            transform.position = position;
        }

        public void SetRotation(Quaternion rotation)
        {
            transform.rotation = rotation;
        }

        public void Dispose()
        {
            foreach (var section in _sections)
                section.Dispose();
            Destroy(gameObject);
        }
    }
}
