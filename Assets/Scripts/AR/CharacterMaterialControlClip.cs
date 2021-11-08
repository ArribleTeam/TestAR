using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.Playables;

public class CharacterMaterialControlClip : PlayableAsset, ITimelineClipAsset
{
    [SerializeField]
    private CharacterMaterialControlBehaviour template = new CharacterMaterialControlBehaviour();

    public ClipCaps clipCaps { get => ClipCaps.None; }

    public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
    {
        return ScriptPlayable<CharacterMaterialControlBehaviour>.Create(graph, template);
    }
}
