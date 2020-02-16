using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Main;
using Player;

namespace Plank
{
    public class PlankController : SingletonSaved<PlankController>
    {
        protected GameObject terrain { get => MainController.Instance.terrain; }
        protected Vector3 tSize { get => terrain.GetComponent<Renderer>().bounds.size; }
        float timeLeft = 1.0f;
        public GameObject prefab;
        public float padding = 2f;
        void Update()
        {
            timeLeft -= Time.deltaTime;
            if (timeLeft < 0)
            {
                Spawn();
                timeLeft = 1.0f;
            }
        }

        void Spawn()
        {
            GameObject newOne = Instantiate(prefab);
            float x = Random.Range(-tSize.x / 2 + padding, tSize.x / 2 - padding);
            float z = Random.Range(-tSize.z / 2 + padding, tSize.z / 2 - padding);
            newOne.transform.position = new Vector3(x, .4f, z);
            newOne.transform.Rotate(new Vector3(0, Random.Range(-180.0f, 180.0f), 0));
        }
    }
}
