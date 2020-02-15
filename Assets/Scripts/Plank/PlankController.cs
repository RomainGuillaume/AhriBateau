using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Main;
using Player;

namespace Plank
{
    public class PlankController : SingletonSaved<PlankController>
    {
        float timeLeft = 1.0f;
        public GameObject prefab;

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
            newOne.transform.position = new Vector3(Random.Range(-10.0f, 10.0f), .4f, Random.Range(-5.0f, 5.0f));
            newOne.transform.Rotate(new Vector3(0, Random.Range(-180.0f, 180.0f), 0));
        }
    }
}
