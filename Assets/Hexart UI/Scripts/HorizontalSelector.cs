using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

namespace Michsky.UI.Hexart
{
    public class HorizontalSelector : MonoBehaviour
    {
        [Header("RESOURCES")]
        public Text label;
        private int index = 0;
        public int defaultIndex = 0;

        [Header("ELEMENTS")]
        public List<string> elements = new List<string>();

        [Header("EVENT")]
        public UnityEvent onValueChanged;

        void Start()
        {
            label = transform.Find("Text").GetComponent<Text>();
            label.text = elements[defaultIndex];
        }

        public void PreviousClick()
        {
            if (index == 0)
            {
                index = elements.Count - 1;
            }

            else
            {
                index--;
            }

            onValueChanged.Invoke();
            label.text = elements[index];
        }

        public void ForwardClick()
        {
            if ((index + 1) >= elements.Count)
            {
                index = 0;
            }

            else
            {
                index++;
            }

            onValueChanged.Invoke();
            label.text = elements[index];
        }
    }
}