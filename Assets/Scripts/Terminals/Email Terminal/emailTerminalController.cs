using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class emailTerminalController : MonoBehaviour
{
    // public variables -------------------------
    public string[] m_senders;                      // Arrays containing all the senders
    public string[] m_subjects;                     // Arrays containing all the subjects
    public int m_emailIndex;                        // Tells at what index we are with the emails 
    [Header("Rows")]
    public emailRowsController[] m_rows;            // List of all the rows

    // private variables ------------------------
    private float m_counter;                        // Counter to check when to deploy a new email
    private float m_newEmailChance = 25f;           // Chance that a new email is deployed
    private float m_checkEmail = 15f;               // After how many seconds there's a chance to deploy a new email           
    private int m_deleted = 0;                      // Number of message deleted

    // ------------------------------------------
    // Start is called before update
    // ------------------------------------------
    void Start()
    {
        // Display the first message right at the beggining 
        m_rows[0].NewMessage(m_senders[0], m_subjects[0]);
     	   
    }

    // ------------------------------------------
    // Update is called once per frame
    // ------------------------------------------
    void Update()
    {
        // Always check for an email
        Syncronize();
    	    
    }

    // ------------------------------------------
    // Methods
    // ------------------------------------------

    // Check if there's new emails in the mail ----------------------------
    private void Syncronize()
    {
        // Count time
        m_counter += Time.deltaTime;
        
        // Check email after some time
        if (m_counter >= m_checkEmail)
        {
            // Pick a random number
            float rando = Random.Range(0, 100);

            // Check the probability (and make sure there's other emails to display)
            if (m_newEmailChance >= rando && m_emailIndex < m_senders.Length)
                AddAnEmail();

            // Reset the counter
            m_counter = 0f;
        }
    }


    // Add a row ----------------------------------------------------------
    private void AddAnEmail()
    {
        // Upgrade the email index
        m_emailIndex ++;

        // Record the remaining emails
        int remainingEmails = m_emailIndex - m_deleted;

        // Always display the newest message on the first row
        m_rows[0].NewMessage(m_senders[m_emailIndex], m_subjects[m_emailIndex]);
        remainingEmails --;

        // Display the emails on all the other rows
        for (int i = 1; i < m_rows.Length; i++)
        {
            // Check if there's other emails to display
            if (remainingEmails >= 0)
            {
                // Print the email and deduct one other remaining emails
                m_rows[i].NewMessage(m_senders[remainingEmails], m_subjects[remainingEmails]);
                remainingEmails --;
            }
        }
    }



}
