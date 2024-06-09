using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AccrossTheEvergate
{
    public class TerrainSystem : MonoBehaviour
    {
        [SerializeField] private Terrain t;
        [SerializeField] Material originalMatrial;
        [SerializeField] Material TimeTraverMatrial;

        public void ChangeMatrialToOriginal()
        {
            t.materialTemplate = originalMatrial;
        }

        public void ChangeMatrialToTimeTravelMatrial()
        {
            t.materialTemplate = TimeTraverMatrial;
        }
    }
}
