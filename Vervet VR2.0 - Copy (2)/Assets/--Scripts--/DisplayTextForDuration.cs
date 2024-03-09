using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayTextForDuration : MonoBehaviour
{
    public TextMeshPro textMeshPro;
    public GameObject objectToEnableDisable;
    public string textToDisplay = "ur text here";
    public float displayDuration = 5f;

    void Start()
    {
        if (textMeshPro == null)
        {
            Debug.LogError("TextMeshPro isnt assinged");
            return;
        }

        textMeshPro.text = textToDisplay;
        StartCoroutine(DisplayTextCoroutine());
    }

    System.Collections.IEnumerator DisplayTextCoroutine()
    {
        yield return new WaitForSeconds(displayDuration);
        textMeshPro.text = "";
        if (objectToEnableDisable != null)
            objectToEnableDisable.SetActive(!objectToEnableDisable.activeSelf);
    }
}

