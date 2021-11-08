using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace UI
{
    public class ArrowButtonController : MonoBehaviour
    {
        [SerializeField]
        private Image eclipseImage;
        [SerializeField]
        private Image arrowImage;

        [SerializeField]
        private float targetValue;
        [SerializeField]
        private float speedScroll;
        [SerializeField]
        private AnimationCurve curve;

        private bool isPressed;

        public event System.EventHandler<float> OnButtonPress;

        private void Update()
        {
            if (isPressed == true)
            {
                Scroll(speedScroll);
            }
        }

        public void Check(float value)
        {

            float x = curve.Evaluate(value);
            x = Mathf.Clamp(x, 0, 1);
            eclipseImage.DOFade(x, 0);
            arrowImage.DOFade(x, 0);
        }

        private void Scroll(float value)
        {
            OnButtonPress?.Invoke(this, value);
        }

        public void IsPresed(bool value)
        {
            isPressed = value;
        }
    }
}
