using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

namespace AccrossTheEvergate
{
    public class DissolvingController : MonoBehaviour
    {
        [Header("Dissolve Shader")]
        [SerializeField] SkinnedMeshRenderer _skinnedMesh;
        [SerializeField] float dissolveRate = 0.0125f;
        [SerializeField] float refreshRate = 0.025f;
        [SerializeField] Material[] _skinnedMaterials;

        [Header("Dissolve VFX")]
        [SerializeField] VisualEffect VFXGraph;
        // Start is called before the first frame update
        void Start()
        {
            if(_skinnedMesh != null)
            {
                _skinnedMaterials = _skinnedMesh.materials;
            }
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.H))
            {
                Dissolve();
            }
        }

        public void Dissolve()
        {
            StartCoroutine(StartDissolve());
        }

        IEnumerator StartDissolve()
        {
            if(VFXGraph != null)
            {
                VFXGraph.Play();
            }

            if(_skinnedMaterials.Length > 0)
            {
                float counter = 0;
                while (_skinnedMaterials[0].GetFloat("_DissolveAmount") < 1)
                {
                    counter += dissolveRate;
                    for(int i =0; i < _skinnedMaterials.Length; i++)
                    {
                        _skinnedMaterials[i].SetFloat("_DissolveAmount", counter);
                    }
                    yield return new WaitForSeconds(refreshRate);
                }
            }
        }
    }
}
