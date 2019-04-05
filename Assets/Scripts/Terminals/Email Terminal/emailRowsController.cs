using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class emailRowsController : MonoBehaviour
{
    // public variables -------------------------
    [HideInInspector]public string m_sender;            // The sender string to display
    [HideInInspector]public string m_subject;           // The subject string to display
    [HideInInspector]public string m_date;              // The date (or orbit) string to display


    // private variables ------------------------
    private Text[] m_element;
    private GameManager m_gm;

    // ------------------------------------------
    // Start is called before update
    // ------------------------------------------
    void Start()
    {
        // Get the GM
        m_gm = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();

        // Create an array of elements (sender[0], subject[1], date[3])
        m_element = new Text[3];

        // Run a loop for all the elements in the row
        for (int i = 0; i < m_element.Length; i++)
        {
            // Get the text element for every child of this object
            m_element[i] = gameObject.transform.GetChild(i).GetComponent<Text>();
        }  
    }

    // ------------------------------------------
    // Update is called once per frame
    // ------------------------------------------
    void Update()
    {
        // Display a message to the row
        DisplayRow(); 
    }

    // ------------------------------------------
    // Methods
    // ------------------------------------------

    // Print the row on the screen ----------------------------------------
    private void DisplayRow()
    {
        // Update each element of the row by a specific string
        m_element[0].text = m_sender;
        m_element[1].text = m_subject;
        m_element[2].text = m_date;
    }


    // Receive a message --------------------------------------------------
    public void NewMessage(string sender, string subject)
    {
        // Update info of the row
        m_sender = sender;
        m_subject = subject;

        // Update the date 
        m_date = "Orbit " + m_gm.m_orbitNum.ToString();
    }


    // Empty the row --------------------------------------------------
    public void EmptyRow()
    {
        m_sender = "";
        m_subject = "";
        m_date = "";
    }

}
