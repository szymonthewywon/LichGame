using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class FlickerLights : MonoBehaviour
{
    [SerializeField] private float startingLightIntensity;
    [SerializeField] private float minRadius;
    [SerializeField] private float maxRadius;
    [SerializeField] private float flickeringIntensity;
    public Light2D lightSource;
    void Start()
    {
        StartCoroutine(flicker());
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
