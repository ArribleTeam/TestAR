using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

[System.Serializable]
public class CharacterMaterialControlBehaviour : PlayableBehaviour
{
    [SerializeField]
    [Range(0, 1)]
    private float targetFadeValue; 
    [SerializeField]
    [Range(0, 1)]
    private float startFadeValue;


    private CharacterMaterialController materialController;
    private bool isFirstFrameHappened;

    public override void ProcessFrame(Playable playable, FrameData info, object playerData)
    {
        // base.ProcessFrame(playable, info, playerData);
        materialController = playerData as CharacterMaterialController;

        if (materialController != null)
        {
            if (isFirstFrameHappened == false)
            {
                isFirstFrameHappened = true;
                materialController.SetAlphaMaterials(startFadeValue);
            }

            double currentTime = playable.GetTime();
            double duration = playable.GetDuration();
            float currentFade = materialController.GetCurrentAlphaValue();
            currentFade = Mathf.MoveTowards(currentFade, targetFadeValue, Time.deltaTime / (float)duration);

            materialController.SetAlphaMaterials(currentFade);
        }
    }
    public override void OnBehaviourPause(Playable playable, FrameData info)
    {
        isFirstFrameHappened = false;
        if (materialController != null)
        {
            materialController.SetAlphaMaterials(targetFadeValue);
        }
        base.OnBehaviourPause(playable, info);
    }
}
