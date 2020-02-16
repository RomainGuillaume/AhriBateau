using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

namespace UI
{
    public class Test : MonoBehaviour
    {

        public GameObject HPBarGO;
        public GameObject HPWave;
        public float current;

        bool isValid = false;

        void Start()
        {
            isValid = HPBarGO != null && HPWave != null;
        }

        void Update()
        {
            if (isValid)
            {
                if (current > 40)
                {
                    HPWave.GetComponent<Image>().fillAmount = ((current - 40) * 100 / 60) / 100;
                }

                HPBarGO.GetComponent<Image>().fillAmount = current / 100;
            }
        }
    }
}