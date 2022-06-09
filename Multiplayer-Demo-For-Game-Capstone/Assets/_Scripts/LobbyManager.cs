using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LobbyManager : MonoBehaviour
{
    //This can be changed to take user ID from database when ported into app

    private string _userID;
    private string _hostAddress;
    private GameManager _gameManager;

    public string UserID
    {
        get { return _userID; }
        set { _userID = value; }
    }
    /// <summary>
    /// Information to join Host
    /// </summary>
    public string HostAddress
    {
        get { return _hostAddress; }
        set { _hostAddress = value; }
    }

    // Start is called before the first frame update
    void Start()
    {
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        GameObject.Find("txtVersion").GetComponent<Text>().text = "Version: " + Application.version;
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void Connect()
    {
        if(HostAddress == null)
        {          
            Debug.Log("Hosting Game Selected");
            _gameManager.HostGame(UserID);
        }
        else
        { 
            Debug.Log("Joining Game Selected");
            _gameManager.JoinGame(UserID);
        }
    }
}
