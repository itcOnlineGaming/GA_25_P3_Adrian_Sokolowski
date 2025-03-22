using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyBagController : MonoBehaviour
{
    public float MoneyBagValue = 100.0f;

    public float moveSpeed = 1f; 
    public float lifeTime = 2f;
    private float timer;

    void Start()
    {
        EconomicSystemController.Instance.AddEconomicValue(MoneyBagValue);

        timer = lifeTime;
    }

    void Update()
    {
        transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);

        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            Destroy(gameObject);
        }
    }
}

