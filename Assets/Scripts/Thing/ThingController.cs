using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Main;

namespace Thing
{
    public class ThingController : MonoBehaviour
    {

        public GameObject prefab1;
        public GameObject prefab2;
        public float timeElapsed = 0f;
        public float chanceOfSpawn = 0.2f;
        public float padding = 2f;
        protected GameObject terrain { get => MainController.Instance.terrain; }
        protected Vector3 tSize { get => terrain.GetComponent<Renderer>().bounds.size; }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (prefab1 != null && prefab2 != null)
            {
                timeElapsed += Time.deltaTime;

                if (timeElapsed >= 1f)
                {
                    timeElapsed = 0f;
                    float random = Random.Range(0.0f, 1.0f);

                    if (random <= chanceOfSpawn)
                    {
                        GameObject prefabThing = (Random.Range(0.0f, 1.0f) >= .75f) ? prefab1 : prefab2;
                        GameObject newRift = Instantiate(prefabThing);
                        float x = Random.Range(-tSize.x / 2 + padding, tSize.x / 2 - padding);
                        float z = Random.Range(-tSize.z / 2 + padding, tSize.z / 2 - padding);
                        newRift.transform.position = new Vector3(x, 10f, z);
                    }
                }
            }
        }
    }
}