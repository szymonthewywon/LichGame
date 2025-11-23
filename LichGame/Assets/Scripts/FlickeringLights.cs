using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class FlickeringLights : MonoBehaviour
{
    public float startingLightIntensity;
    public float minRadius;
    public float maxRadius;
    public Light2D lightSource;
    public float flickeringIntensity;

    void Start()
    {
        startingLightIntensity = lightSource.intensity;
        minRadius = lightSource.pointLightInnerRadius;
        maxRadius = lightSource.pointLightOuterRadius; 
        StartCoroutine(flicker());
    }

    void Update()
    {
    }
    IEnumerator flicker()
    {
        while (true)
        {
            float randomIntensity = Random.Range(startingLightIntensity - flickeringIntensity, startingLightIntensity + flickeringIntensity);
            float randomMinRadius = Random.Range(minRadius * 0.9f, minRadius * 1.1f);
            float randomMaxRadius = Random.Range(maxRadius * 0.9f, maxRadius * 1.1f);
            lightSource.intensity = randomIntensity;
            lightSource.pointLightInnerRadius = randomMinRadius;
            lightSource.pointLightOuterRadius = randomMaxRadius;
            yield return new WaitForSeconds(0.1f);
        }
    }
}
