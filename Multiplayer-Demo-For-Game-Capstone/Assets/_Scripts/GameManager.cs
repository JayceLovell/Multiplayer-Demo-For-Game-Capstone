﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class GameManager : MonoBehaviour
{

    private string _hostaddress;
    private string _UserID;
    private NetworkManager _networkManager;

    public static GameManager instance = null;              //Static instance of GameManager which allows it to be accessed by any other script.
    public string UserID
    {
        get
        {   return _UserID;   }
        set
        {   _UserID = value;    }
    }
    public string HostAddress
    {
        get { return _hostaddress; }
        set { _hostaddress = value; } 
    }

    /// <summary>
    /// Awake is always called before any Start functions
    /// Makes GameManager Omnipresent
    /// </summary>
    void Awake()
    {
        //Check if instance already exists
        if (instance == null)

            //if not, set instance to this
            instance = this;

        //If instance already exists and it's not this:
        else if (instance != this)

            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);

        //Sets this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);

    }

    // Start is called before the first frame update
    void Start()
    {
        _networkManager = GameObject.Find("NetworkManager").GetComponent<NetworkManager>() ;
        //.GetComponent<MyNetworkManager>();
    }
    public void HostGame(string _userID)
    {
        UserID = _userID;
        _networkManager.StartHost();
        Debug.Log("Hosting Game");
    }
    public void JoinGame(string _userID)
    {
        UserID = _userID;
        if (_hostaddress != null)
        {
            _networkManager.networkAddress = _hostaddress;
        }
        _networkManager.StartClient();
        Debug.Log("Joining Game");
    }
}
