using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class ViewController : MonoBehaviour
    {
        [Header("Cards")]
        [SerializeField]
        private List<Card> allCards;
        [Header("UI")]
        [SerializeField]
        private PoinsViewer poinsViewer;
        [SerializeField]
        private List<ArrowButtonController> arrowButtons;
        [SerializeField]
        private ScrollRect scrollRect;

        private void Awake()
        {
            allCards.ForEach(x =>
            {
                x.OnClickedPlayButton += Card_OnClickedPlayButton;
            });

            poinsViewer.SetCountPoins(GamePoinsManager.GetCurrentCountPoins());
            arrowButtons.ForEach(x => x.OnButtonPress += ArrowButton_OnButtonPress);
            scrollRect.horizontalScrollbar.onValueChanged.AddListener(UpdateScrollbarValue);
        }


        private void Reset()
        {
            allCards = new List<Card>();
            allCards.AddRange(FindObjectsOfType<Card>());
        }

        private void UpdateScrollbarValue(float value)
        {
            arrowButtons.ForEach(x => x.Check(value));
        }
        private void Card_OnClickedPlayButton(object sender, int e)
        {
            GamePoinsManager.AddPoins(e);
            poinsViewer.SetCountPoins(GamePoinsManager.GetCurrentCountPoins(), true);
            Debug.Log(GamePoinsManager.GetCurrentCountPoins());
        }
        private void ArrowButton_OnButtonPress(object sender, float e)
        {
          //  scrollRect.horizontalScrollbar.value += e * Time.deltaTime;
            scrollRect.horizontalNormalizedPosition += e * Time.deltaTime;
        }

        private void OnDestroy()
        {
            allCards.ForEach(x =>
            {
                x.OnClickedPlayButton -= Card_OnClickedPlayButton;
            });
        }
    }
}
