﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class resolveBtnController : MonoBehaviour
{
    // public variables -------------------------
    [Header("Error Screens")]
    public GameObject m_thisScreenError;            // This screen error containing the error btn
    public GameObject[] m_otherScreens;             // Other screens affected by the error
    public TerminalController m_terminalManager;    // Terminal manager for this screen
    public GameObject m_originalBtn;                // Original first button to put there
    public Sprite m_overSprite;                     // Sprite to display when the user is selecting the btn

    // private variables ------------------------
    private GameObject m_mainAlarm;                 // Main alarm in the scene
    private bool m_playing = false;                 // Bool to check if main alarm is playing 
    private Image m_btn;                            // Image btn linked to this object
    private Sprite m_original;                      // Original sprite to display per default
    private AudioManager m_audioManager;            // Instance of AudioManager
    private lightManager m_lm;                      // Light manager to control the responsive lights in the ship

    // ------------------------------------------
    // Start is called before update
    // ------------------------------------------
    void Start()
    {
        // Get the image component and the original sprite
        m_btn = GetComponent<Image>();   
        m_original = m_btn.sprite;

        // Get the AudioManager
        m_audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();

        // Get the light manager
        m_lm = GameObject.FindGameObjectWithTag("GameController").GetComponent<lightManager>();
    }

    // ------------------------------------------
    // Update is called once per frame
    // ------------------------------------------
    void Update()
    {
        if (!m_playing)
        {
            // Play the alarm sound
            GameObject.FindGameObjectWithTag("Alarm").GetComponent<AudioSource>().Play();
            m_playing = true;
        }

        // Change the room lights
        m_lm.AlarmLight();

    }

    // ------------------------------------------
    // Methods
    // ------------------------------------------

    // If the button got pressed -------------------------------------
    public void GotPressed()
    {
        // Check if there's other error screens link to this one
        if (m_otherScreens != null)
        {
            // Deactivate all other existing error screen
            for (int i = 0; i < m_otherScreens.Length; i++)
                m_otherScreens[i].SetActive(false);
        }

        // Reset original parameter for navigation on the terminal
        m_terminalManager.m_firstBtn = m_originalBtn;
        m_terminalManager.m_setSelection = true;

        // Stop Alarm
        GameObject.FindGameObjectWithTag("Alarm").GetComponent<AudioSource>().Stop();
        m_playing = false;

        // Play error resolved sound
        m_audioManager.ErrorResolved();

        // Desctivate this screen
        m_thisScreenError.SetActive(false);

        // Reactivate normal lights
        m_lm.ReturnToNormal();
    }


    // If the button got overed -------------------------------------
    public void IsOver(bool enter)
    {
        // Change the sprite if the player is selecting or deselcting
        if (enter)
            m_btn.sprite = m_overSprite;
        else
            m_btn.sprite = m_original;
    }
}
