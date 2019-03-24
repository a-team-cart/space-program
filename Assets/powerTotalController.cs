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
    public GameObject m_lightErrorScreen;           // Error image for light control screen
    public GameObject m_viewErrorScreen;            // Error image for master view screen
    
    // private variables ------------------------
    private Slider m_slider;                        // Slider component of the object

    // ------------------------------------------
    // Start is called before update
    // ------------------------------------------
    void Start()
    {
        // Get the slider component
        m_slider = gameObject.GetComponent<Slider>();	
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
        if (m_slider.value >= 0 && m_slider.value < 12.45f)
            m_filler.color = m_critical;
        
        if (m_slider.value >= 12.45f && m_slider.value < 24.9f)
            m_filler.color = m_warning;
        
        if (m_slider.value >= 24.9f && m_slider.value < 75f)
            m_filler.color = m_optimal;
        
        if (m_slider.value >= 75f && m_slider.value < 87.45f)
            m_filler.color = m_warning;

        if (m_slider.value >= 87.45f && m_slider.value <= 100f)
            m_filler.color = m_critical;
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


    // Receive Data from a btn ---------------------------------------
    public void receivePowerData(float data, bool direction)
    {
        // Give or delete power value
        if (direction)
            m_total += data;
        else
            m_total -= data;

        Debug.Log ("Update Total");
    }

    
    // Lookout for a power error--------------------------------------
    public void errorScan()
    {
        if (m_slider.value == 0f || m_slider.value == 100f)
        {
            m_lightErrorScreen.SetActive(true);
            m_viewErrorScreen.SetActive(true);
        }

    }
}
