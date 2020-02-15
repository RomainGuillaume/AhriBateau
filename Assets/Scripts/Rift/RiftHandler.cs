using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Rift
{
    public class RiftHandler : MonoBehaviour
    {
        void Start()
        {

        }

        void Update()
        {

        }

        void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.GetComponent<Player.PlayerEntity>())
            {
                Destroy(gameObject);
            }
        }
    }
}

