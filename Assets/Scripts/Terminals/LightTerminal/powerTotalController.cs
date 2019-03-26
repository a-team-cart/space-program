using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class powerTotalController : MonoBehaviour
{
    // public variables -------------------------
    public float m_total;                           // Total power used currently
    [Header("Colours used")]
    public Color m_critical;                        // Colour when total is critical (red)
    public Color m_warning;                         // Colour when total is in warning mode (yellow)
    public Color m_optimal;                         // Colour when total is optimal (green)
    public Image m_filler;                          // Object that is filled
    [Header("Critical Errors Screen")]
    public TerminalController m_terminalManager;    // Master monitor (parent of the terminal)
    public GameObject m_resolveBtn;                 // Resolve btn that will appear if an error occurs
    public GameObject m_lightErrorScreen;           // Error image for light control screen
    public GameObject m_viewErrorScreen;            // Error image for master view screen
    [Header("Sounds")]
    public AudioClip m_criticalSound;               // Sound to play when slider is in critical section
    
    // private variables ------------------------
    private Slider m_slider;                        // Slider component of the object
    private AudioSource m_as;                       // Audio source attached to this object
    private bool m_playingAudio;                    // Bool to see if playing audio
    private bool m_stopAudio;                       // Bool to stop the polaying audio
    private bool m_resolving = false;               // Check if the player is currently resolving an error


    // ------------------------------------------
    // Start is called before update
    // ------------------------------------------
    void Start()
    {
        // Get the slider component and audio
        m_slider = gameObject.GetComponent<Slider>();	
        m_as = gameObject.GetComponent<AudioSource>();
        

        // Set total to 0 first
        m_total = 0f;   
    }

    // ------------------------------------------
    // Update is called once per frame
    // ------------------------------------------
    void Update()
    {
        // Change slider value (based on total)
        smoothTotal();

        // Check the correct colour
        checkColour();

        // Check for errors
        errorScan();
    }

    // ------------------------------------------
    // Methods
    // ------------------------------------------

    // Select a colour for the filler -------------------------------
    private void checkColour()
    {
        // Select the current colour for the slider value
        // Also play a sound if it's in a critical zone
        if (m_slider.value >= 0 && m_slider.value < 12.45f)
        {
            m_filler.color = m_critical;
            playSound(m_criticalSound);
        }
        
        if (m_slider.value >= 12.45f && m_slider.value < 24.9f)
        {
            m_filler.color = m_warning;
            stopSound();
        }
        
        if (m_slider.value >= 24.9f && m_slider.value < 75f)
            m_filler.color = m_optimal;
        
        if (m_slider.value >= 75f && m_slider.value < 87.45f)
        {
            m_filler.color = m_warning;
            stopSound();
        }

        if (m_slider.value >= 87.45f && m_slider.value <= 100f)
        {
            m_filler.color = m_critical;
            playSound(m_criticalSound);
        }
    }


    // Change smoothly the value of the slider ----------------------
    private void smoothTotal()
    {
        // Keep the total in range
        m_total = Mathf.Clamp(m_total, 0f, 100f);

        // Smooth transition
        float step = 10f;

        // Adjust smoothlt the value of the slider
        if (m_slider.value < m_total)
            m_slider.value += step * Time.deltaTime;

        if (m_slider.value > m_total)
            m_slider.value -= step * Time.deltaTime;
    }


    // Play/stop specific sound ---------------------------------------
    private void playSound(AudioClip sound)
    {
        // Give a clip to the audio source
         m_as.clip = sound;

        // Play the clip
        if (!m_playingAudio)
        {
            m_as.Play(0);
            m_playingAudio = true;
        }        
    }

    private void stopSound()
    {
        // To stop the current sound 
        m_as.Stop();
        m_playingAudio = false;
    }


    // Receive Data from a btn ---------------------------------------
    public void receivePowerData(float data, bool direction)
    {
        // Give or delete power value
        if (direction)
            m_total += data;
        else
            m_total -= data;

        // Player should have resolve the issue if they are sending data
        m_resolving = false;
    }

    
    // Lookout for a power error--------------------------------------
    public void errorScan()
    {
        // If the slider value enter the error zones (and is not currently resolving)
        if (m_slider.value == 0f && !m_resolving || 
            m_slider.value == 100f && !m_resolving)
        {
            // Set the first selection of the terminal to the resolve btn
            m_terminalManager.m_firstBtn = m_resolveBtn;
            m_terminalManager.m_setSelection = true;
            
            // Activate the errors screen
            m_lightErrorScreen.SetActive(true);
            m_viewErrorScreen.SetActive(true);

            // Turn resolving on (to block the error screen once the player will be resolving)
            m_resolving = true;
        }
    }
}
