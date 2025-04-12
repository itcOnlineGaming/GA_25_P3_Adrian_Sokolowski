using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddExperience : MonoBehaviour
{

    private Button button;
    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(onButtonIsClicked);
    }

    void onButtonIsClicked()
    {
        EventManager.Instance.RaiseEvent("AddExperience", 5000);
    }
}
