using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Main;
using Player;

namespace Crystal
{
    public class CrystalController : SingletonSaved<CrystalController>
    {
        protected GameObject terrain { get => MainController.Instance.terrain; }
        protected Vector3 tSize { get => terrain.GetComponent<Renderer>().bounds.size; }
        protected float timeElapsed = 0f;
        public float padding = 2f;

        public GameObject prefab;

        private Color[] potColor = new Color[]
        {
            Color.white, Color.black, Color.yellow, Color.red, Color.green
        };



        void Update()
        {
            timeElapsed += Time.deltaTime;

            if (timeElapsed >= 5f)
            {
                if (Random.Range(0f, 1f) >= 0.6f)
                {
                    Spawn();
                }
                timeElapsed = 0f;
            }
        }

        public void Spawn()
        {
            GameObject newPot = Instantiate(prefab);
            float x = Random.Range(-tSize.x / 2 + padding, tSize.x / 2 - padding);
            float z = Random.Range(-tSize.z / 2 + padding, tSize.z / 2 - padding);
            newPot.transform.position = new Vector3(x, .4f, z);
            newPot.transform.Rotate(0, Random.Range(-180.0f, 180.0f), 0);
            int randColor = Random.Range(0, potColor.Length);
            Color newPotColor = potColor[randColor];
            newPot.GetComponentInChildren<MeshRenderer>().material.color = newPotColor;
            newPot.GetComponentInChildren<CrystalEntity>().color = randColor;
        }
    }
}
