using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
using CoroutineHandler;

public class PoinsViewer : MonoBehaviour
{
    [SerializeField]
    private TMP_Text countPoinsTrext;
    [SerializeField]
    private RectTransform starTransform;

    private int currentShowPoins;

    private CoroutineObject<int,int> smoothChangedViewCountPoinsRoutine;
    private CoroutineObject rotateStarRoutine;

    private void Awake()
    {
        smoothChangedViewCountPoinsRoutine = new CoroutineObject<int,int>(this, SmoothChangedViewCountPoinsCoroutine);
        rotateStarRoutine = new CoroutineObject(this, RotateStarCoroutine);
    }

    private void OnDisable()
    {
        smoothChangedViewCountPoinsRoutine?.Stop();
    }

    public void SetCountPoins(int poins, bool isUsedAnimation = false)
    {

        if (isUsedAnimation == false)
        {
            SetText(poins);
        }
        else
        {
            smoothChangedViewCountPoinsRoutine.Start(currentShowPoins,poins);
            rotateStarRoutine.Start();
        }
        currentShowPoins = poins;
    }

    private void SetText(int value)
    {
        countPoinsTrext.text = value.ToString();
    }
   
    private IEnumerator SmoothChangedViewCountPoinsCoroutine(int currentValue, int targetValue)
    {
        int countIterations = Mathf.Abs (targetValue - currentValue);
        bool isIncrease = targetValue > currentValue;
        float delayTime = 0.1f;

        if (countIterations > 0)
        {
            for (int i = 0; i < countIterations; i++)
            {
                targetValue += isIncrease ? 1 : -1;
                SetText(targetValue);
                yield return new WaitForSeconds(delayTime);
            }
        }
    }
    private IEnumerator RotateStarCoroutine()
    {
        float speed = 1;
        float rotateSpeed = 360 * speed;
        while (smoothChangedViewCountPoinsRoutine != null && smoothChangedViewCountPoinsRoutine.IsProcessing)
        {
            starTransform.Rotate(new Vector3(0, 0, -Time.deltaTime * rotateSpeed));
            yield return null;
        }
    }
    private void OnDestroy()
    {
        smoothChangedViewCountPoinsRoutine?.Stop();
    }
}
