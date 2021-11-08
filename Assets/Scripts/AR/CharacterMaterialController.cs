using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMaterialController : MonoBehaviour
{
    [SerializeField]
    private List<Renderer> characterMeshRendererParts;

    private const string ALPHA_PROPERTY_MATERIAL_NAME = "_alpha";

    //public void Reset()
    //{
    //    characterMeshRendererParts = new List<Renderer>();
    //    characterMeshRendererParts.AddRange (GetComponentsInChildren<SkinnedMeshRenderer>());
    //}
    public void SetAlphaMaterials(float value)
    {
        characterMeshRendererParts.ForEach(x =>
        {
            if (x.material.HasProperty(ALPHA_PROPERTY_MATERIAL_NAME) == true)
            {
                x.material.SetFloat(ALPHA_PROPERTY_MATERIAL_NAME, value);
            }
        });
    }
    public float GetCurrentAlphaValue()
    {
        float result = 0;
        if (characterMeshRendererParts?.Count > 0)
        {
            result = characterMeshRendererParts[0].material.GetFloat(ALPHA_PROPERTY_MATERIAL_NAME);
        }
        return result;
    }
}
