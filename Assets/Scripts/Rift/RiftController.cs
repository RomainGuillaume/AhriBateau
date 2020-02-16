using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Main;
using Player;
using UI;

namespace Rift
{
    public class RiftController : SingletonSaved<RiftController>
    {
        GameObject terrain { get => MainController.Instance.terrain; }
        Vector3 tPos { get => terrain.transform.position; }
        Vector3 tScale { get => terrain.transform.localScale; }
        Vector3 tSize { get => terrain.GetComponent<Renderer>().bounds.size; }
        float timeElapsed = 0f;
        bool isValid = false;
        int countRift = 0;
        
        public float padding = 2f;
        public float chanceOfSpawn = 1.0f;
        public float interval = .5f;
        public GameObject prefabRift;
        public GameObject prefabPanelPress;
        public float planksGenerated = 3f;

        public void TogglePanelPress(GameObject rift, bool toggle)
        {
            if (isValid)
            {
                prefabPanelPress.SetActive(toggle);
            }
        }

        public void RepairComplete(GameObject rift)
        {
            if (isValid)
            {
                prefabPanelPress.SetActive(false);
                Destroy(rift);
                StopRepair();
            }
        }

        public void StartRepair(float speed)
        {
            if (isValid)
            {
                prefabPanelPress.GetComponent<ButtonPress>().speed = speed;
                prefabPanelPress.GetComponent<ButtonPress>().isPressed = true;
            }
        }

        public void StopRepair()
        {
            if (isValid)
            {
                prefabPanelPress.GetComponent<ButtonPress>().isPressed = false;
            }
        }

        public void OnRemoveRift()
        {
            if (isValid)
            {
                countRift--;
            }
        }

        void Start()
        {
            isValid = prefabRift != null && prefabPanelPress != null;
        }

        void Update()
        {
            if (isValid)
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
                        countRift++;

                        for (int i = 0; i <= planksGenerated; i ++)
                        {
                            MainController.Instance.GetComponent<Plank.PlankController>().Spawn();
                        }
                    }

                    CauseDamages();
                }
            }
        }

        void CauseDamages()
        {
            PlayerController.Instance.CauseDamages(countRift);
        }
    }
}
