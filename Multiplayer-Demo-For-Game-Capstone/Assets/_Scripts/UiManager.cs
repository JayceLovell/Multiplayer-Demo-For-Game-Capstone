using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

/// <summary>
/// This script is for any UI navigation
/// WARNING THIS IS STILL UNDER CONSTRUCTION NOT FINAL SCRIPT
/// </summary>
public class UiManager : MonoBehaviour
{
    public bool IsActiveMenu;

    private AccuracyBattleManager _accuacyBattleManager;
    private AccuracyBattleMusicPlayer _musicPlayer;
    private GameManager _gameManager;
    private NetworkManager networkmanager;

    public GameObject DisplaySong;
    /// <summary>
    /// is Called before Start
    /// </summary>
    void Awake()
    {
        _accuacyBattleManager = GameObject.Find("AccuracyBattleManager").GetComponent<AccuracyBattleManager>();
        _musicPlayer = GameObject.Find("Music Player").GetComponent<AccuracyBattleMusicPlayer>();
        networkmanager = GameObject.Find("NetworkManager").GetComponent<NetworkManager>();
        _gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }
    // Start is called before the first frame update
    void Start()
    {
    }
    public void Ready()
    {
        _accuacyBattleManager.GameStart();
        DisplaySong.GetComponent<TextMeshProUGUI>().text = _musicPlayer.SongName;
    }
    /// <summary>
    /// TODO
    /// Change this to work with firebase and go back to gameScene
    /// </summary>
    public void Exit()
    {
        if (_gameManager.Status == "Hosting")
        {
            networkmanager.StopHost();
            Debug.Log("Ending Host");
        }
        else
        {
            networkmanager.StopClient();
            Debug.Log("Ending Client");
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
