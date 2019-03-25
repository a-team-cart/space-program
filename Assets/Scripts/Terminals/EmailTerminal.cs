using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using SimpleJSON;

/*
References on JSON serialization/deserialization : 
- https://stackoverflow.com/questions/36239705/serialize-and-deserialize-json-and-json-array-in-unity
- https://docs.unity3d.com/ScriptReference/JsonUtility.FromJson.html
*/

public class EmailTerminal : MonoBehaviour
{
	[Header("Am I debugging?")]
	public bool m_isDebugging = false;

	[Header("Email List Parameters")]
	public string m_emailDataFileName = "emails.json";

	public int m_numberOfEmails = 75; 

	// public List<string>	m_sendersList = new List<string>();
	// public List<string>	m_messagesList = new List<string>();

	public List<Email>	m_emailList = new List<Email>();


	[System.Serializable]
	public class Email
	{
	    public string m_sender;
	    public string m_message;

	    public Email (string sender, string message)
	    {
	    	m_sender = sender;
	    	m_message = message;
	    }
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
            var N = JSON.Parse(dataAsJson);

            for(int i = 0; i < m_numberOfEmails; i ++)
            {
            	// m_sendersList.Add(N["emails"][i]["sender"].Value);
            	// m_messagesList.Add(N["emails"][i]["message"].Value);

				m_emailList.Add(new Email(N["emails"][i]["sender"].Value ,N["emails"][i]["message"].Value));


            	if(m_isDebugging)
            		Debug.Log(N["emails"][i]["sender"].Value + N["emails"][i]["message"].Value);
            }
        }
        else
        {
            Debug.LogError("Cannot load game data!");
        }
    }
}
