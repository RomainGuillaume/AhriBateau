using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class PlayerEntity : MonoBehaviour
    {
        protected bool directionDown = false;
        protected bool directionUp = false;
        protected bool directionLeft = false;
        protected bool directionRight = false;
        protected bool isValid = false;

        public float speed = .01f;
        public GameObject player;
        public int wood = 0;

        public void AddWood()
        {
            wood++;
        }

        void Start()
        {
            isValid = player != null;
        }

        void Update()
        {
            if (isValid)
            {
                CheckIfKeyDirectionIsDown();
                UpdateMovement();
            }
        }

        void UpdateMovement()
        {
            if (directionRight == true)
            {
                player.transform.position = player.transform.position + new Vector3(speed, 0, 0);
            }
            if (directionLeft == true)
            {
                player.transform.position = player.transform.position + new Vector3(-speed, 0, 0);
            }
            if (directionDown == true)
            {
                player.transform.position = player.transform.position + new Vector3(0, 0, -speed);
            }
            if (directionUp == true)
            {
                player.transform.position = player.transform.position + new Vector3(0, 0, speed);
            }
        }

        void CheckIfKeyDirectionIsDown()
        {
            directionRight = Input.GetAxis("Horizontal") > 0f ? true : false;
            directionLeft = Input.GetAxis("Horizontal") < 0f ? true : false;
            directionUp = Input.GetAxis("Vertical") > 0f ? true : false;
            directionDown = Input.GetAxis("Vertical") < 0f ? true : false;
        }

    }
}
