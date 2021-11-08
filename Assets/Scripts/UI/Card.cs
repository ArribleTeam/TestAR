using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class Card : MonoBehaviour
    {
        [SerializeField]
        private int addPoints;
        [SerializeField]
        private Button playButton;

        public event System.EventHandler<int> OnClickedPlayButton;

        private void Awake()
        {
            playButton.onClick.AddListener(PlayButtonClick);
        }

        public void PlayButtonClick()
        {
            OnClickedPlayButton?.Invoke(this, addPoints);
        }
    }
}