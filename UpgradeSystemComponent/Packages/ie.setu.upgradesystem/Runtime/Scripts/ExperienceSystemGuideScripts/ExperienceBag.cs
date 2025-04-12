using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ExperienceBag : MonoBehaviour
{
    public int ExpereinceAmountFromBag = 100;
    public GameObject ExperienceAmountText;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Vector3 screenPosition = Camera.main.WorldToScreenPoint(transform.position);
            GameObject newText = Instantiate(ExperienceAmountText, this.transform);
            newText.transform.SetParent(GameObject.Find("Canvas").transform, worldPositionStays: false);
            newText.transform.position = screenPosition;
            newText.GetComponent<TMP_Text>().text = ExpereinceAmountFromBag.ToString();
            EventManager.Instance.RaiseEvent("AddExperience", ExpereinceAmountFromBag);

        }
    }
}
