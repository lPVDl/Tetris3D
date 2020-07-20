using Game.Common.GameEvents;
using Game.Core.Level;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Game.Core.Block
{
    public class TestBlockSpawner : IInitializable
    {
        private const int SpawnCount = 5000;
        private const float SpawnRange = 10;

        private readonly IBlockViewFactory _blockViewFactory;
        private readonly ILevelViewTransform _levelViewTransform;

        private GameObject _root;

        public TestBlockSpawner(IBlockViewFactory blockViewFactory,
                                ILevelViewTransform levelViewTransform)
        {
            _blockViewFactory = blockViewFactory;
            _levelViewTransform = levelViewTransform;
        }

        private static Color[] Colors = { Color.red, Color.green, Color.yellow, Color.magenta };

        public void Initialize()
        {
            _root = new GameObject("_TestBlockSpawner");

            for (var x = 0; x < 10; x++)
                for (var y = 0; y < 10; y++)
                    for (var z = 0; z < 20; z++)
                        SpawnBlock(x, y, z);
        }

        private void SpawnBlock(int x, int y, int z)
        {
            var view = _blockViewFactory.CreateSection();
            var pos = _levelViewTransform.TransformPosition(new Vector3Int(x, y, z));
            view.SetParent(_root.transform);
            view.SetPosition(pos);
            //view.SetColor(Colors[Random.Range(0, Colors.Length)]);
        }
    }
}
