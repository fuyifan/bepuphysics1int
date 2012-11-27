﻿using BEPUphysics.CollisionTests.CollisionAlgorithms;
using BEPUutilities.ResourceManagement;

namespace BEPUphysics.CollisionTests.Manifolds
{
    ///<summary>
    /// Manages persistent contacts between a convex and an instanced mesh.
    ///</summary>
    public class MobileMeshTriangleContactManifold : MobileMeshContactManifold
    {

        UnsafeResourcePool<TriangleTrianglePairTester> testerPool = new UnsafeResourcePool<TriangleTrianglePairTester>();
        protected override void GiveBackTester(CollisionAlgorithms.TrianglePairTester tester)
        {
            testerPool.GiveBack((TriangleTrianglePairTester)tester);
        }

        protected override CollisionAlgorithms.TrianglePairTester GetTester()
        {
            return testerPool.Take();
        }

    }
}
