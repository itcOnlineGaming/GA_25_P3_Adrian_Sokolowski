using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class MoneyBagSpawner : MonoBehaviour
{
    public GameObject MoneyBag;

    private float timer = 2;
    private float currentTime = 0;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime > timer)
        {
            currentTime = 0;
            CreateMoneyBag();
        }

    }

    public void CreateMoneyBag()
    {
        Instantiate(MoneyBag, this.transform);
    }
}
