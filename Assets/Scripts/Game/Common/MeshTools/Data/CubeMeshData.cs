using UnityEngine;

namespace Game.Common.MeshTools
{
    //   3---------0
    //  /|        /|
    // 2---------1 |
    // | |       | |   Y
    // | 7-------|-4   | Z
    // |/        |/    |/
    // 6---------5     0---X
    public struct CubeMeshData
    {
        public PlaneMeshData Forward => new PlaneMeshData(P4, P0, P3, P7);
        public PlaneMeshData ReverseForward => new PlaneMeshData(P7, P3, P0, P4);

        public PlaneMeshData Backward => new PlaneMeshData(P6, P2, P1, P5);
        public PlaneMeshData ReverseBackward => new PlaneMeshData(P5, P1, P2, P6);

        public PlaneMeshData Right => new PlaneMeshData(P5, P1, P0, P4);
        public PlaneMeshData ReverseRight => new PlaneMeshData(P4, P0, P1, P5);

        public PlaneMeshData Left => new PlaneMeshData(P7, P3, P2, P6);
        public PlaneMeshData ReverseLeft => new PlaneMeshData(P6, P2, P3, P7);

        public PlaneMeshData Up => new PlaneMeshData(P2, P3, P0, P1);
        public PlaneMeshData ReverseUp => new PlaneMeshData(P1, P0, P3, P2);

        public PlaneMeshData Down => new PlaneMeshData(P7, P6, P5, P4);
        public PlaneMeshData ReverseDown => new PlaneMeshData(P4, P5, P6, P7);

        public Vector3 P0 { get; }
        public Vector3 P1 { get; }
        public Vector3 P2 { get; }
        public Vector3 P3 { get; }
        public Vector3 P4 { get; }
        public Vector3 P5 { get; }
        public Vector3 P6 { get; }
        public Vector3 P7 { get; }

        public CubeMeshData(Vector3 size)
        {
            var halfSize = size / 2;
            P0 = Vector3.Scale(halfSize, new Vector3(1, 1, 1));
            P1 = Vector3.Scale(halfSize, new Vector3(1, 1, -1));
            P2 = Vector3.Scale(halfSize, new Vector3(-1, 1, -1));
            P3 = Vector3.Scale(halfSize, new Vector3(-1, 1, 1));
            P4 = Vector3.Scale(halfSize, new Vector3(1, -1, 1));
            P5 = Vector3.Scale(halfSize, new Vector3(1, -1, -1));
            P6 = Vector3.Scale(halfSize, new Vector3(-1, -1, -1));
            P7 = Vector3.Scale(halfSize, new Vector3(-1, -1, 1));
        }
    }
}
