using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindArea : MonoBehaviour
{
    [Header("Gust Timing")]
    public float startDelay;
    public float cooldown;
    public float gustScalar;
    public bool randomizeWind;
    float timer;
    int gustCounter;

    [Header("Wind")]
    public float strength;
    public float strengthMultiplier;
    public Vector3 direction;

    protected virtual void Start()
    {
        timer = startDelay;
    }
    protected virtual void Update()
    {
        if (randomizeWind)
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
        }
        strengthMultiplier = Mathf.Sqrt(gustCounter) * gustScalar;
    }
}
