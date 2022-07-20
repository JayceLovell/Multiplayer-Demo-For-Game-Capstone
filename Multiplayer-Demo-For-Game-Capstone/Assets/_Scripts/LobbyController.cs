using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LobbyController : MonoBehaviour
{
    //This can be changed to take user ID from database when ported into app
    [SerializeField]
    private string _userID;
    private string _hostAddress;
    private bool isHosting;
    private GameManager _gameManager;
    public bool IsActiveMenu;

    /// <summary>
    /// Will contain information for display user information
    /// </summary>
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
    /// <summary>
    /// If user hosting game or not
    /// This is for LAN only!!!
    /// </summary>
    public bool Hosting
    {
        get { return isHosting; }
        set { 
            isHosting = value;
            _gameManager.IsHosting();
        }
    }
    public bool RankMode
    {
        get { return _gameManager.IsRankMode; }
        set { 
            _gameManager.IsRankMode = value;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        _gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        GameObject.Find("txtVersion").GetComponent<Text>().text = "Version: " + Application.version;
    }
    public void Connect()
    {
        if(isHosting)
        {          
            Debug.Log("Hosting Game Selected");
            _gameManager.HostGame(UserID);
        }
        else
        { 
            Debug.Log("Joining Game Selected");
            _gameManager.HostAddress = HostAddress;
            _gameManager.JoinGame(UserID);
        }
    }
    public void DROP_DOWN_CLICK(Animator anim)
    {
        IsActiveMenu = !IsActiveMenu;
        ANIMATION_STATE(anim, "IsActive", IsActiveMenu);
    }
    public static void ANIMATION_STATE(Animator anim, string parameterName, bool state)
    {
        anim.SetBool(parameterName, state);
    }
}

