using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class inventoryActionController : MonoBehaviour
{
    // public variables -------------------------
    public int m_inventoryTotal;                    // Inventory total of this type of stock
    [Header("Colours")]
    public Color m_blue;                            // Blue color is used when inventory is good
    public Color m_yellow;                          // Yellow color is used when inventory is low
    public Color m_Green;                           // Green color is used when inventory is optimal
    public Color m_red;                             // Red color is used when inventory is critical
    [Header("Attached Objects")]
    public Slider m_stockSlider;                    // Slider link to the value of this action
    public Text m_totalText;                        // Text that display the inventory total

    // private variables ------------------------
    private Image m_outline;                        // The Image doing the outline of the text
    private Text m_displayText;                     // The text that is displayed on the terminal
    private string m_transit = "IN TRANSIT";        // Text for in transit message
    private string m_request = "REQUEST [+10 ]";    // Text for requesting (default state)


    // ------------------------------------------
    // Start is called before update
    // ------------------------------------------
    void Start()
    {
     	   
    }

    // ------------------------------------------
    // Update is called once per frame
    // ------------------------------------------
    void Update()
    {
    	    
    }

    // ------------------------------------------
    // Methods
    // ------------------------------------------

    // If the button got pressed -------------------------------------
    public void GotPressed()
    {

    }
}
