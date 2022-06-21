using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class UserPointsController : NetworkBehaviour
{
    /// <summary>
    /// text box to display username and points
    /// </summary>
    private Text _displayPoints;

    private GameManager _gameManager;

    private float _userPoints;

    public float UserPoints { get => _userPoints; set => _userPoints = value; }

    // Start is called before the first frame update
    void Start()
    {
        _displayPoints=GetComponent<Text>();
        _gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        UserPoints = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(!isLocalPlayer)
        {
            return;
        }
        _displayPoints.text = _gameManager.UserID + ":" + UserPoints;
    }
}
