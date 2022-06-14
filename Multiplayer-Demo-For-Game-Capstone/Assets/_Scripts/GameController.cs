using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class GameController : NetworkBehaviour
{
    [SerializeField]
    [SyncVar]private int _amountOfPlayers;
    [SerializeField]
    private List<string> _playerNames;
    [SerializeField]
    [SyncVar]
    private float _playerPoints;
    private GameManager _gameManager;
    private NetworkManager networkmanager;

    public bool IsDebugging=true;
    public int AmountOfPlayers { get { return _amountOfPlayers; } set { _amountOfPlayers = value; } }
    public List<string> PlayerNames { get { return _playerNames; } set { _playerNames = value; } }
    public float PlayerPoints { get { return _playerPoints; } set { _playerPoints = value; } }

    /// <summary>
    /// is Called before Start
    /// </summary>
    void Awake()
    {
        networkmanager = GameObject.Find("NetworkManager").GetComponent<NetworkManager>();
        _gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }
    // Start is called before the first frame update
    void Start()
    {
        AmountOfPlayers = networkmanager.numPlayers;
        if (IsDebugging)
        {
            Debugging();
        }
    }


    // Update is called once per frame
    void Update()
    {
            AmountOfPlayers = NetworkServer.connections.Count;
    }
    public void Ready()
    {

    }
    public void Exit()
    {
        if (_gameManager.Status == "Host")
        {
            networkmanager.StopHost();
        }
        else
        {
            networkmanager.StopClient();
        }
    }
    /// <summary>
    /// method for initilizing debug stuff
    /// </summary>
    private void Debugging()
    {
        Debug.Log("Debuging Mode On");
        GameObject.Find("TxtStatus").GetComponent<Text>().text = "Status: " + _gameManager.Status;
        GameObject.Find("TxtHost").GetComponent<Text>().text = "Host Ip: " + _gameManager.HostAddress;
    }
}
