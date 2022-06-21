using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Linq;
using UnityEngine;
using UnityEngine.Networking;

public class GameManager : MonoBehaviour
{
    private string _hostaddress;
    private string _UserID;
    private string _status;
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
        set { 
            _hostaddress = value;
        } 
    }
    public string Status
    {
        get { return _status; }
        set { _status = value; }
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
        _networkManager = GameObject.Find("NetworkManager").GetComponent<NetworkManager>();
        GetIpAddress();
    }
    public void HostGame(string _userID)
    {
        UserID = _userID;
        Status = "Hosting";
        _networkManager.StartHost();
        Debug.Log("Hosting Game");
    }
    public void JoinGame(string _userID)
    {
        UserID = _userID;
        Status = "Guest";
        if (_hostaddress != null)
        {
            _networkManager.networkAddress = _hostaddress;
            Debug.Log("Joining Game at address: " + _hostaddress);
        }
        _networkManager.StartClient();
        
    }
    public void IsHosting()
    {
        HostAddress = GetIpAddress();
        _networkManager.networkAddress = HostAddress;
    }
    /// <summary>
    /// Just to get the ipaddress of the host
    /// </summary>
    /// <returns></returns>
    private string GetIpAddress()
    {
        return Dns.GetHostEntry(Dns.GetHostName())
            .AddressList.First(
                f => f.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
            .ToString();
    }
}
