using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedManager : MonoBehaviour
{
    [SerializeField] float speed = 20;

    [SerializeField] float limitSpeed = 50;
    [SerializeField] float increaseValue = 5;

    public float Speed
    {
        get { return speed; }
    }

    private void Awake()
    {
        StartCoroutine(Accelerate());
    }

    IEnumerator Accelerate()
    {
        while(speed <limitSpeed)
        {

            yield return CoroutineCache.WaitForSecond(10);

            speed += increaseValue;

        }
    }
}
