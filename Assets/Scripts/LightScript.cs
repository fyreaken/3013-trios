using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightScript : MonoBehaviour
{
    public enum LightStates {Off, On, Flickering };

    public LightStates LightState = LightStates.On;

    public Light m_light;

    [SerializeField]
    private float minIntensity = 0f;
    [SerializeField]
    private float originalIntensity = 1f;

    private bool currentlyFlickering = false;

    [Tooltip("Minimum wait time between flickers. (in seconds)")]
    [Range(0.01f, 0.2f)]
    public float delayMin = .05f;

    [Tooltip("Maximum wait time between flickers. (in seconds)")]
    [Range(0.1f, 0.5f)]
    public float delayMax = 0.2f;

    public float timeDelay;

    private void Start()
    {

        m_light.intensity = originalIntensity;

        if (m_light == null)
        {
            m_light = GetComponent<Light>();
        }
    }

    void Update()
    {
        switch (LightState)
        {
            case LightStates.Off:
                if (m_light.intensity != 0)
                {
                    m_light.intensity = 0;
                }
                break;
            case LightStates.On:
                if (m_light.intensity != originalIntensity)
                {
                    m_light.intensity = originalIntensity;
                }
                break;
            case LightStates.Flickering:;
                if (!currentlyFlickering)
                {
                    StartCoroutine(LightFlicker());
                }
                
                break;
        }
    }

    IEnumerator LightFlicker()
    {
        currentlyFlickering = true;
        m_light.intensity = minIntensity;
        timeDelay = Random.Range(delayMin, delayMax);
        yield return new WaitForSeconds(timeDelay);
        m_light.intensity = originalIntensity;
        timeDelay = Random.Range(delayMin, delayMax);
        yield return new WaitForSeconds(timeDelay);
        currentlyFlickering = false;
    }

}
