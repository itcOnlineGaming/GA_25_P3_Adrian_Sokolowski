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
            // Get the Screen Position of the Object we are going to spawn the text from
            Vector3 screenPosition = Camera.main.WorldToScreenPoint(transform.position);
            // Spawn the Text
            GameObject newText = Instantiate(ExperienceAmountText, this.transform);
            // Give it a Canvas Parent
            newText.transform.SetParent(GameObject.Find("Canvas").transform, worldPositionStays: false);
            // Give it the position of the Object we want it to spawn from
            newText.transform.position = screenPosition;
            // Change the text to the Experienced gain Value
            newText.GetComponent<TMP_Text>().text = ExpereinceAmountFromBag.ToString();
            ExperienceSystemController.Instance.AddExperience(ExpereinceAmountFromBag);

        }
    }
}
