using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkTerminal : MonoBehaviour
{
	[Header("Spawner")]

	public GameObject _spawnLocation; 
	public GameObject _junkObject;


    // Start is called before the first frame update
    void Start()
    {
        //init function at the start
        init();
    }

    // Update is called once per frame
    void Update()
    {
        //the behaviour for the junk script 
        JunkBehaviour();
    }

    public void init(){
	
    }

    public void JunkBehaviour(){


    	//INTERACTION TO SPAWN STUFF, PREFERABLY A BUTTON
    	if(Input.GetKeyDown("space"))
    		Instantiate(_junkObject, _spawnLocation.transform.position, _spawnLocation.transform.rotation);
    }
}
