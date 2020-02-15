using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Main;

namespace Rift
{
    public class RiftController : MonoBehaviour
    {
        protected GameObject terrain { get => MainController.Instance.terrain; }
        protected Vector3 tPos { get => terrain.transform.position; }
        protected Vector3 tScale { get => terrain.transform.localScale; }
        protected Vector3 tSize { get => terrain.GetComponent<Renderer>().bounds.size; }
        protected float timeElapsed = 0f;
        
        public float padding = 2f;
        public float chanceOfSpawn = 1.0f;
        public GameObject prefabRift;
        public float interval = .5f;

        void Update()
        {
            if (prefabRift != null)
            {
                timeElapsed += Time.deltaTime;

                if (timeElapsed >= 1f)
                {
                    timeElapsed = 0f;
                    float random = Random.Range(0.0f, 1.0f);

                    if (random <= chanceOfSpawn)
                    {
                        GameObject newRift = Instantiate(prefabRift);
                        float x = Random.Range(-tSize.x / 2 + padding, tSize.x / 2 - padding);
                        float z = Random.Range(-tSize.z / 2 + padding, tSize.z / 2 - padding);
                        newRift.transform.position = new Vector3(x, .1f, z);
                    }
                }
            }
        }
    }
}
