using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Rift
{
    public class RiftEntity : MonoBehaviour
    {
        void Start()
        {

        }

        void Update()
        {

        }

        void OnDestroy()
        {
            RiftController.Instance.OnRemoveRift();
        }

    }
}

