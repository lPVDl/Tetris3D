using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Game.Core.Level
{
    public class LevelViewTransform : ILevelViewTransform
    {
        private readonly ILevelModel _levelModel;

        public LevelViewTransform(ILevelModel levelModel)
        {
            _levelModel = levelModel;
        }

        public Vector3 TransformPosition(Vector3Int index)
        {
            return new Vector3()
            {
                x = index.x + (1 - _levelModel.Size.x) * 0.5f,
                z = index.z + (1 - _levelModel.Size.y) * 0.5f,
                y = index.y + 0.5f,
            };
        }
    }
}
