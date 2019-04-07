using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightManager : MonoBehaviour
{
    // public variables -------------------------
    public Color m_normalState;                     // Normal color to put on lights
    public Color m_alarmState;                      // Light color when there's a critical error
    [Space(10)]
    public float m_normalIntensity;                 // Normal intensity of the lights
    public float m_alarmIntensity;                  // Alarm intensity of the lights

    // private variables ------------------------
    private GameObject[] m_lights;                  // All the lights in the scene
    private bool m_glowing = false;                 // Bool used for blinking animation
    private bool m_bootUp = true;                   // Light up the lights on default
    private float m_currentIntensity;               // Current intensity of the lights
    private bool m_returnNormal;                    // Set returning to normal
    private float m_startingAlarmIntensity;         // Starting alarm intensity of the lights


    // ------------------------------------------
    // Start is called before update
    // ------------------------------------------
    void Start()
    {
        // Get all the responsive lights in the scene
        m_lights = GameObject.FindGameObjectsWithTag("ResponsiveLights");
        ReturnToNormal();

        // Get a default start
        m_startingAlarmIntensity = m_alarmIntensity;
    }

    // ------------------------------------------
    // Update is called once per frame
    // ------------------------------------------
    void Update()
    {
        // if lights are coming back to normal
        if(m_returnNormal)
            DefaultLights();
    }

    // ------------------------------------------
    // Methods
    // ------------------------------------------

    // Receive info to turn the lights back -----------------------
    public void ReturnToNormal()
    {
        // Start the boot up
        m_returnNormal = true;

    }

    // public void default lighting -------------------------------
    public void DefaultLights()
    {
        // Fade in animation (first check if system is booting up)
        if (m_bootUp)
        {
            m_currentIntensity = 0f;
            m_bootUp = false;
        }

        // Get all the lights
        for(int i = 0; i < m_lights.Length; i++)
        {
            // Get the light component on each object
            Light lumen = m_lights[i].GetComponent<Light>();
            lumen.color = m_normalState;
            lumen.intensity = m_currentIntensity;
        }

        // Fade animation
        if (m_currentIntensity < m_normalIntensity)
            m_currentIntensity += Time.deltaTime * 0.1f;
        
    }


    // When a critical error occurs --------------------------------
    public void AlarmLight()
    {
        // Prepare reactivation
        m_bootUp = true;

        // Get all the lights
        for(int i = 0; i < m_lights.Length; i++)
        {
            // Get the light component on each object
            Light lumen = m_lights[i].GetComponent<Light>();
            lumen.color = m_alarmState;
            lumen.intensity = m_alarmIntensity;
        }

        // Make a blinking animation
        if (m_alarmIntensity > 0 && !m_glowing)
            m_alarmIntensity -= Time.deltaTime * 2f;
        else if (!m_glowing)
            m_glowing = true;
        
        // Going back to default
        if (m_alarmIntensity < m_startingAlarmIntensity && m_glowing)
            m_alarmIntensity += Time.deltaTime * 2f;
        else if (m_glowing)
            m_glowing = false;

        // Block the returning lights
        m_returnNormal = false;
    }
}
