using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class GameController : MonoBehaviour
{
    private int _amountOfPlayers;
    private GameManager gameManager;
    private NetworkManager networkmanager;

    public bool IsDebugging=true;
    public int amountOfPlayers { get { return _amountOfPlayers; } set { _amountOfPlayers = value; } }

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
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
        GameObject.Find("TxtStatus").GetComponent<Text>().text = "Status: " + gameManager.Status;
    }
}
