using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MonkeyClicker : MonoBehaviour
{
    [Header("Made by chatg- i mean klombo real not fake only real")]
    public TextMeshPro textMeshPro;
    public float clickDelay = 1.0f;
    private int count;
    private bool canClick = true;

    private void OnTriggerEnter(Collider other)
    {
        if (canClick && other.CompareTag("HandTag"))
        {
            UpdateText(++count);
            Invoke(nameof(ResetClick), clickDelay);
            canClick = false;
        }
    }

    private void UpdateText(int value) => textMeshPro.text = value.ToString();

    private void ResetClick() => canClick = true;
}
