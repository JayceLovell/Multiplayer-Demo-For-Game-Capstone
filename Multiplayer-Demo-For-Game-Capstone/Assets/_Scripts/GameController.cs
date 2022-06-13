using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class GameController : NetworkBehaviour
{
    [SerializeField]
    private int _amountOfPlayers;
    [SerializeField]
    private GameManager _gameManager;
    [SerializeField]
    private NetworkManager networkmanager;

    public bool IsDebugging=true;
    public int AmountOfPlayers { get { return _amountOfPlayers; } set { _amountOfPlayers = value; } }

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
        
    }
    public void Ready()
    {

    }
    /// <summary>
    /// method for initilizing debug stuff
    /// </summary>
    private void Debugging()
    {
        Debug.Log("Debuging");
        GameObject.Find("TxtStatus").GetComponent<Text>().text = "Status: " + _gameManager.Status;
        GameObject.Find("TxtHost").GetComponent<Text>().text = "Host Ip: " + _gameManager.HostAddress;
    }
}
