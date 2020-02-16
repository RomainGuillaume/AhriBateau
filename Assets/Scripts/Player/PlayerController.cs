using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Main;
using UnityEngine.UI;

namespace Player
{
    public class PlayerController : SingletonSaved<PlayerController>
    {
        PlayerEntity _player;
        bool playerHasFall = false;
        bool isValid = false;
        float timeElapsed = 0f;
        int lifesMax = 0;

        public UI.Test hpBar;
        public float timeoutRespawn = 0.5f;
        public int lifesLostByFall = 5;
        public int lifes = 100;
        public int scores = 0;
        public GameObject playerPrefab;
        public GameObject spawner;
        public GameObject losePanel;
        public Text plankCounterText;
        public PlayerEntity player
        {
            get => _player;
        }

        public void UpdatePlayerPlankCounter(PlayerEntity player)
        {
            plankCounterText.text = player.wood.ToString();
        }

        public void CauseDamages(int damage)
        {
            lifes -= damage;
        }

        void Start()
        {
            isValid = playerPrefab != null && spawner != null && hpBar != null;

            lifesMax = lifes;

            if (isValid)
            {
                GameObject playerGO = Instantiate(playerPrefab);
                _player = playerGO.GetComponent<PlayerEntity>();

                if (_player != null)
                {
                    _player.gameObject.transform.position = spawner.transform.position;
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
                UpdateLosePanel();
                UpdatePlayer();
                UpdateLife();
            }
        }

        void UpdateLosePanel()
        {
            if (lifes <= 0)
            {
                losePanel.SetActive(true);
                Time.timeScale = 0;
            }
        }

        void UpdateLife()
        {
            hpBar.current = lifesMax - lifes;        
        }

        void UpdatePlayer()
        {
            if (!playerHasFall && _player.gameObject.transform.position.y < -5 )
            {
                timeElapsed = 0f;
                playerHasFall = true;
                _player.stop = true;
                lifes -= lifesLostByFall;
            }

            if (playerHasFall && timeElapsed < timeoutRespawn)
            {
                timeElapsed += Time.deltaTime;
                _player.Reset(spawner.transform.position);
            } 
            else if (playerHasFall && timeElapsed >= timeoutRespawn)
            {
                timeElapsed = 0f;
                playerHasFall = false;
                _player.stop = false;
            }
        }
    }
}
