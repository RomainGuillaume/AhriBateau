using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Plank;

namespace Player
{
    public class PickUp : MonoBehaviour
    {
        void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.GetComponent<PlankEntity>())
            {
                gameObject.GetComponent<PlayerEntity>().AddWood();
                Destroy(other.gameObject);
            }
        }
    }

}

