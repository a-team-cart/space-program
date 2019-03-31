using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class inventoryActionController : MonoBehaviour
{
    // public variables -------------------------
    public float m_inventoryTotal;                   // Inventory total of this type of stock
    [Header("Colours")]
    public Color m_blue;                            // Blue color is used when inventory is good
    public Color m_yellow;                          // Yellow color is used when inventory is low
    public Color m_green;                           // Green color is used when inventory is optimal
    public Color m_red;                             // Red color is used when inventory is critical
    public Color m_transitColor;                    // Color to dsiplay when in transit
    [Header("States")]
    public bool m_inTransit = false;                // Check if an item is in transit or not
    public float m_loopTime;                        // Time it takes to consume part of the stock
    public float m_transitTimeRequired;             // Time it takes to order an item
    [Header("Attached Objects")]
    public Slider m_stockSlider;                    // Slider link to the value of this action
    public Image m_filler;                          // Filler of the slider (for the colours)
    public Text m_totalText;                        // Text that display the inventory total

    // private variables ------------------------
    private Image m_outline;                        // The Image doing the outline of the text
    private Text m_displayText;                     // The text that is displayed on the terminal
    private string m_transitText = "IN TRANSIT";    // Text for in transit message
    private string m_request = "REQUEST [+10 ]";    // Text for requesting (default state)
    private bool m_hover = false;                   // Bool to see if player is hovering the btn
    private float m_consumeTimer = 0.0f;            // Timer for when this inv needs to consume stock
    private float m_transitTimer = 0.0f;            // Timer for when an item has been requested
    private inventoryStateController m_invState;    // Script that check the overall state of the inventory
    private bool m_empty = false;                   // Is true when the stock equals to 0
    private AudioManager m_audioManager;            // Instance of Audio Manager


    // ------------------------------------------
    // Start is called before update
    // ------------------------------------------
    void Start()
    {
        // Get the outline box
        m_outline = gameObject.transform.GetChild(0).GetComponent<Image>();

        // Get the inventory state controller from the parent
        m_invState = transform.parent.GetComponent<inventoryStateController>();

        // Get the text of this object
        m_displayText = gameObject.GetComponent<Text>();
        m_displayText.text = m_request;

        // Get the AudioManager
        m_audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
    }


    // ------------------------------------------
    // Update is called once per frame
    // ------------------------------------------
    void Update()
    {
        // Update the stock slider value and colours
        SmoothTotal();
        LookColour();

        // Update the inventory text number
        InventoryText();

        // Consume
        ConsumeStock();

        // Check if an error occurs
        CheckForErrors();

        // Check if an item has bee ordered
        if (m_inTransit)
            RequestStock();
    	    
    }


    // ------------------------------------------
    // Methods
    // ------------------------------------------

    // Always update the slider and btn, with colours ---------------------
    private void LookColour()
    {
        // Select the current colour for the slider, and btn v
        if (m_stockSlider.value >= 0 && m_stockSlider.value <= 20f)
            ChangeColour(m_red);
        
        if (m_stockSlider.value > 20f && m_stockSlider.value <= 50f)
            ChangeColour(m_yellow);
        
        if (m_stockSlider.value > 50f && m_stockSlider.value <= 90f)
            ChangeColour(m_blue);

        if (m_stockSlider.value > 90f && m_stockSlider.value <= 100f)
            ChangeColour(m_green);
    }


    // Change colours of items on the terminal -------------------------
    private void ChangeColour(Color ColourVariant)
    {
        // First check if the player is currently over
        if (!m_hover && !m_inTransit)
        {
            // Change colour of those selected items
            m_outline.color = ColourVariant;
            m_displayText.color = ColourVariant;
        }
        else if (!m_hover && m_inTransit)
        {
            // Change colour for in transit of those selected items
            m_outline.color = m_transitColor;
            m_displayText.color = m_transitColor;
        }
        else
        {
            // When the btn is on over, put those items white
            m_outline.color = Color.white;
            m_displayText.color = Color.white;
        }

        // Filler is always updating even on over
        m_filler.color = ColourVariant;
    }


    // Change smoothly the value of the slider -------------------------
    private void SmoothTotal()
    {
        // Keep the total in range
        m_inventoryTotal = Mathf.Clamp(m_inventoryTotal, 0f, 100f);

        // Smooth transition
        float step = 10f;

        // Adjust smoothlt the value of the slider
        if (m_stockSlider.value < m_inventoryTotal)
            m_stockSlider.value += step * Time.deltaTime;

        if (m_stockSlider.value > m_inventoryTotal)
            m_stockSlider.value -= step * Time.deltaTime;
    }


    // Always update the number of inventory stock --------------------
    private void InventoryText()
    {
        // Print the inventory total to a string
        m_totalText.text = m_inventoryTotal.ToString();
    }


    // After a certain number of time, consume stock ------------------
    private void ConsumeStock()
    {
        // Count time
        m_consumeTimer += Time.deltaTime;

        // When the timer reach a time loop
        if (m_consumeTimer >= m_loopTime)
        {
            // Consume stock and restart the timer
            m_inventoryTotal -= 10f;
            m_consumeTimer = 0.0f;
        }
    }


    // Command stock when in transit -----------------------------------
    private void RequestStock()
    {
        // Count time
        m_transitTimer += Time.deltaTime;

        // Change the display text to "IN TRANSIT"
        m_displayText.text = m_transitText;

        // When the timer reach a time loop
        if (m_transitTimer >= m_transitTimeRequired)
        {
            // Consume stock and restart the timer
            m_inventoryTotal += 10f;
            m_transitTimer = 0.0f;

            // Put back the request text on the display text
            m_displayText.text = m_request;

            // Item no longer in transit
            m_inTransit = false;
        }
    }


    // Add or delete an error when it occurs ---------------------------
    private void CheckForErrors()
    {
        // When the stock is equal to 0
        if (m_stockSlider.value == 0f && !m_empty)
        {
            // Tell the inventory controller
            m_invState.ErrorCounter(true);
            m_empty = true;
        }

        // If the stock goes up after being empty
        if (m_empty && m_stockSlider.value > 0)
        {
            // Tell the inventory controller
            m_invState.ErrorCounter(false);
            m_empty = false;
        }
    }


    // If the button got pressed --------------------------------------
    public void GotPressed()
    {
        //Play submit sound
        m_audioManager.PitchShiftSubmitEffect();

        // Make sure the object is not already in transit
        if (!m_inTransit)
            m_inTransit = true;

    }


    // If the btn is highlighted --------------------------------------
    public void IsOver(bool state)
    {
        // Change the hover state 
        m_hover = state;
    }
}
