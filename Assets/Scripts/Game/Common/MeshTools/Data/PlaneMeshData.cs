using UnityEngine;

namespace Game.Common.MeshTools
{
    // 1---2
    // |   |
    // 0---3
    public struct PlaneMeshData
    {
        public Vector3 P0 { get; }
        public Vector3 P1 { get; }
        public Vector3 P2 { get; }
        public Vector3 P3 { get; }

        public PlaneMeshData(Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3)
        {
            P0 = p0;
            P1 = p1;
            P2 = p2;
            P3 = p3;
        }
    }
}
