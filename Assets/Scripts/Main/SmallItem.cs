using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Main
{
    public class SmallItem : MonoBehaviour
    {
        float timeElapsed = 0f;

        // Update is called once per frame
        void Update()
        {
            timeElapsed += Time.deltaTime;

            if (timeElapsed >= 0.01f)
            {
                float y = gameObject.transform.rotation.eulerAngles.y;
                gameObject.transform.Rotate(new Vector3(0, 1, 0));
                timeElapsed = 0f;
            }
        }
    }
}
