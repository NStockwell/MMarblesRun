using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Toggle))]
public class ToggleNotBacksies : MonoBehaviour
{
    private Toggle selfToggle;

    private void Awake()
    {
        selfToggle = GetComponent<Toggle>();
    }

    public void OnPointerClick()
    {
        if(selfToggle.isOn)
            return;
    }

    public void ActivateValue()
    {
        Debug.Log($"ActivaeValue");
    }
}
