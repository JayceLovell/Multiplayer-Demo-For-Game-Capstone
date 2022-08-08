using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LobbyController : MonoBehaviour
{
    /// <summary>
    /// Will contain information for display user information
    /// This can be changed to take user ID from database when ported into app
    /// </summary>
    public string UserID;

    /// <summary>
    /// this can be removed or changed for the mix master project
    /// </summary>
    private GameManager _gameManager;

    /// <summary>
    /// for the animations of the menu
    /// </summary>
    public bool IsActiveMenu;

    //Testing variables
    public bool isTestMode;
    /// <summary>
    /// Information to join Host
    /// This is for LAN only!!!
    /// /// can be deleted after port
    /// </summary>
    [Tooltip("Enter address of person connecting to.")]
    public string HostAddress;
    /// <summary>
    /// If user hosting game or not
    /// This is for LAN only!!!
    /// can be deleted after port
    /// </summary>
    [Tooltip("Look at networkManager for your ipaddress to share")]
    public bool IsHosting;
    //end of testing variables

    // Start is called before the first frame update
    void Start()
    {
        //Finds the game manager
        _gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();

        //Not fully need can be deleted after port
        GameObject.Find("txtVersion").GetComponent<Text>().text = "Version: " + Application.version;
    }
    void Update()
    {
        if (isTestMode)
        {
            if (IsHosting && (_gameManager.HostAddress == null))
            {
                _gameManager.IsHosting();
            }
        }
    }
    /// <summary>
    /// based on bool value
    /// </summary>
    /// <param name="isRanked">Playing ranked or regular mode</param>
    public void FindGame(bool isRanked)
    {
        _gameManager.IsRankMode = isRanked;
        if (isTestMode)
        {
            if (IsHosting)
            {
                _gameManager.HostAddress = HostAddress;
                _gameManager.HostGame(UserID);
            }
            else
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

