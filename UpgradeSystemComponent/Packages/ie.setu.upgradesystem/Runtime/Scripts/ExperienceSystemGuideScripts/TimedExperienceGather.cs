using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedExperienceGather : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(GatherExperienceRoutine());
    }

    private IEnumerator GatherExperienceRoutine()
    {
        while (true)
        {
            EventManager.Instance.RaiseEvent("AddExperience", 500);
            yield return new WaitForSeconds(2f);
        }
    }
}
