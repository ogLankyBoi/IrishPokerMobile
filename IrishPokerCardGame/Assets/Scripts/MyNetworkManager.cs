using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class MyNetworkManager : NetworkManager
{
    public Vector3 newClientSpawnPos;

    public override void OnServerAddPlayer(NetworkConnection conn)
    {
        GameObject player = (GameObject)Instantiate(playerPrefab, newClientSpawnPos, Quaternion.identity);
        NetworkServer.AddPlayerForConnection(conn, player);
    }
}
