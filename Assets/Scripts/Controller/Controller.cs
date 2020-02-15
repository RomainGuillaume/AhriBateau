using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Controller
{
    public class Controller : MonoBehaviour
    {
        protected bool directionDown = false;
        protected bool directionUp = false;
        protected bool directionLeft = false;
        protected bool directionRight = false;

        public float speed = .01f;
        public GameObject player;
        public GameObject spawner;

        void Start()
        {

        }

        void Update()
        {
            if (player != null && spawner != null)
            {
                CheckIfKeyDirectionIsDown();
                UpdateMovement();
                CheckIfPlayerHasFallen();
            }
        }

        bool CheckIfPlayerHasFallen()
        {
            return player.transform.position.y < -5;
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

            if (CheckIfPlayerHasFallen())
            {
                player.transform.position = spawner.transform.position;
            }
        }

        void CheckIfKeyDirectionIsDown()
        {
            if (Input.GetKeyDown(KeyCode.D))
            {
                directionRight = true;
            }
            if (Input.GetKeyUp(KeyCode.D))
            {
                directionRight = false;
            }

            if (Input.GetKeyDown(KeyCode.Q))
            {
                directionLeft = true;
            }
            if (Input.GetKeyUp(KeyCode.Q))
            {
                directionLeft = false;
            }

            if (Input.GetKeyDown(KeyCode.Z))
            {
                directionUp = true;
            }
            if (Input.GetKeyUp(KeyCode.Z))
            {
                directionUp = false;
            }

            if (Input.GetKeyDown(KeyCode.S))
            {
                directionDown = true;
            }
            if (Input.GetKeyUp(KeyCode.S))
            {
                directionDown = false;
            }
        }

    }
}
