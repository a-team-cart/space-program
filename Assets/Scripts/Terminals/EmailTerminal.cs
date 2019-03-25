using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using SimpleJSON;

public class EmailTerminal : MonoBehaviour
{
	[Header("Email List Parameters")]
	public string m_emailDataFileName = "emails.json";

	public List<string>	m_sendersList = new List<string>();
	public List<string>	m_messagesList = new List<string>();


	[System.Serializable]
	public class Email
	{
	    public string m_sender;
	    public string m_message;
	}

    // Start is called before the first frame update
    void Start()
    {
		//load all the emails
		LoadEmails();   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //loads all the emails from the streaming file directory
    private void LoadEmails()
    {
    	// Path.Combine combines strings into a file path
        // Application.StreamingAssets points to Assets/StreamingAssets in the Editor, and the StreamingAssets folder in a build
        string filePath = Path.Combine(Application.streamingAssetsPath, m_emailDataFileName);

        //if the path exists
        if(File.Exists(filePath))
        {
            // Read the json from the file into a string
            string dataAsJson = File.ReadAllText(filePath); 
            // Pass the json to JsonUtility, and tell it to create a GameData object from it
            // Email[] emails = JsonHelper.getJsonArray<Email>(dataAsJson);
            var N = JSON.Parse(dataAsJson);
			string emails = N["emails"][0].Value;
			Debug.Log(emails);
            // Retrieve the allRoundData property of loadedData
            // allRoundData = loadedData.allRoundData;

            //DEBUG
            // Debug.Log(emails[0]);
        }
        else
        {
            Debug.LogError("Cannot load game data!");
        }
    }
}
