using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Main;
using UnityEngine.UI;
using Rift;

namespace UI
{
    public class ButtonPress : MonoBehaviour
    {
        public GameObject topPanel;
        public GameObject botPanel;
        public GameObject circlePanel;
        public bool isPressed = false;
        public float speed = 5f;

        bool isValid = false;
        Vector3 posTopPanel;
        float amount = 0;

        void Start()
        {
            isValid = topPanel != null && botPanel != null && circlePanel != null;

            if (isValid)
            {
                posTopPanel = topPanel.GetComponent<RectTransform>().localPosition;
            }
        }

        void Update()
        {
            if (isValid)
            {
                TranslateTopPanel(isPressed);
                TranslatCirclePanel(isPressed);
            }
        }


        void TranslatCirclePanel(bool pressed)
        {
            if (pressed && amount < 100)
            {
                amount += speed * Time.deltaTime;
                circlePanel.GetComponent<Image>().fillAmount = amount / 100;
            }
            else
            {
                amount = 0;
                circlePanel.GetComponent<Image>().fillAmount = 0;
                pressed = false;
            }
        }

        void TranslateTopPanel(bool pressed)
        {
            topPanel.GetComponent<RectTransform>().localPosition = pressed ? new Vector3(0, posTopPanel.y, posTopPanel.z) : posTopPanel;
        }
    }
}