using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class MyNetworkManager :NetworkManager
{
    private GameManager gameManager;

    public GameObject UserIdPrefab;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void OnClientConnect(NetworkConnection conn)
    {
        Debug.Log("Connected User: " + gameManager.UserID);
        GameObject UserConnectID = Instantiate(UserIdPrefab);
        UserConnectID.transform.SetParent(GameObject.Find("Points Leader board").transform);
        UserConnectID.GetComponent<Text>().text = gameManager.UserID;
        UserConnectID.transform.localScale = new Vector3(1, 1, 1);
        UserConnectID.transform.name = gameManager.UserID;
    }
}
