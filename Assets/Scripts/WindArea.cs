using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindArea : MonoBehaviour
{
    [Header("GustTiming")]
    public float startDelay;
    public float cooldown;
    public float gustScalar;
    float timer;
    int gustCounter;

    [Header("Wind")]
    public float strength;
    public float strengthMultiplier;
    public Vector3 direction;
    float originalStrength;

    public void Start()
    {
        timer = startDelay;
        originalStrength = strength;
    }
    public void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            strength = Random.Range(0f, 1f) * strengthMultiplier;
            direction = Random.insideUnitSphere;
            timer = cooldown;
            gustCounter++;
        }
        strengthMultiplier = Mathf.Sqrt(gustCounter) * gustScalar;
    }
}
