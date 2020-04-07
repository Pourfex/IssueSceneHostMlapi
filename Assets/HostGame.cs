using System;
using System.Collections;
using System.Collections.Generic;
using MLAPI;
using MLAPI.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HostGame : MonoBehaviour {
    
    
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            CreateServer();
        }
        if(Input.GetKeyDown(KeyCode.B))
        {
            JoinGame();
        }
    
    }

    public void JoinGame() {
        NetworkingManager.Singleton.OnClientConnectedCallback += ClientConnected;
        NetworkingManager.Singleton.OnClientDisconnectCallback += ClientDisconnected;
        NetworkingManager.Singleton.StartClient();
    }

    public void CreateServer() {
        NetworkingManager.Singleton.OnClientConnectedCallback += clientId => { Debug.Log($"Client connected {clientId}"); };
        NetworkingManager.Singleton.OnClientDisconnectCallback += clientId => { Debug.Log($"Client disconnected {clientId}"); };
        NetworkingManager.Singleton.OnServerStarted += () => {
            Debug.Log("Server started");
            CreateServerEnvironment();
        };

        NetworkingManager.Singleton.StartHost();
    }

    private void CreateServerEnvironment() {
        var progress = NetworkSceneManager.SwitchScene("InteractionScene");
        progress.OnClientLoadedScene += id => {
            Debug.Log("client " + id + "has changed scene");
        };
    }

    private void ClientConnected(ulong clientId) {
        Debug.Log($"I'm connected {clientId}");
    }

    private void ClientDisconnected(ulong clientId) {
        Debug.Log($"I'm disconnected {clientId}");
        NetworkingManager.Singleton.OnClientDisconnectCallback -= ClientDisconnected;
        NetworkingManager.Singleton.OnClientConnectedCallback -= ClientConnected;
    }
}
