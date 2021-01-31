using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindArea : MonoBehaviour
{
    [Header("Gust Timing")]
    public float startDelay;
    public float cooldown;
    [Range(0, 10)] public float gustScalar;
    public bool randomizeWind;
    float timer;
    int gustCounter;

    [Header("Wind")]
    public float strength;
    public float strengthMultiplier;
    public Vector3 direction;
    ParticleSystem windParticles;

    protected virtual void Start()
    {
        timer = startDelay;
        windParticles = GetComponentInChildren<ParticleSystem>();
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
                windParticles.Play();
                gustCounter++;
            }
        }
        strengthMultiplier = Mathf.Pow(gustCounter / gustScalar, 2);
    }
}
