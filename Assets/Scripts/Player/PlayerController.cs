using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Main;

namespace Player
{
    public class PlayerController : SingletonSaved<PlayerController>
    {
        protected PlayerEntity _player;
        protected bool isValid = false;

        public GameObject playerPrefab;
        public GameObject spawner;
        public PlayerEntity player
        {
            get => _player;
        }

        void Start()
        {
            isValid = playerPrefab != null && spawner != null;

            if (isValid)
            {
                GameObject playerGO = Instantiate(playerPrefab);
                _player = playerGO.GetComponent<PlayerEntity>();

                if (_player != null)
                {
                    _player.player = _player.gameObject;
                    player.gameObject.transform.position = spawner.transform.position;
                } 
                else
                {
                    isValid = false;
                }
            }
        }

        void Update()
        {
            if (isValid)
            {
                if (CheckIfPlayerHasFallen())
                {
                    player.transform.position = spawner.transform.position;
                }
            }
        }

        bool CheckIfPlayerHasFallen()
        {
            return player.transform.position.y < -5;
        }
    }
}
