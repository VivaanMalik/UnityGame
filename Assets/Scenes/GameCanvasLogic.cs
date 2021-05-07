using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAPI;
using MLAPI.Spawning;
using MLAPI.Transports.UNET;

public class GameCanvasLogic : MonoBehaviour
{
    UNetTransport transport;
    public string ip="127.0.0.1";
    public GameObject panel;
    public Camera lobbycam;


    public void Host(){
        //lobbycam.gameObject.SetActive(false);
        NetworkManager.Singleton.ConnectionApprovalCallback+=ApprovalCheck;
        panel.SetActive(false);
        NetworkManager.Singleton.StartHost(Vector3.zero, Quaternion.identity);
    }


    private void ApprovalCheck(byte[] connectionData, ulong clientID, NetworkManager.ConnectionApprovedDelegate callback){
        //check data
        bool approve =System.Text.Encoding.ASCII.GetString(connectionData)=="3.1415926535897932384626433832795028841971693993751058209749445923078164062862089986280348253421170679";
        callback(true, null,approve, Vector3.zero, Quaternion.identity);
    }


    public void Join(){
        //lobbycam.gameObject.SetActive(false);
        transport=NetworkManager.Singleton.GetComponent<UNetTransport>();
        transport.ConnectAddress = ip;
        NetworkManager.Singleton.NetworkConfig.ConnectionData=System.Text.Encoding.ASCII.GetBytes("3.1415926535897932384626433832795028841971693993751058209749445923078164062862089986280348253421170679");
        panel.SetActive(false);
        NetworkManager.Singleton.StartClient();
    }


    public void IPChange(string newIP){
        this.ip=newIP;
    }
}
