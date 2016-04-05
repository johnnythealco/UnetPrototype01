using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using UnityEngine.UI;


public class NetManager : NetworkManager 
{

	public void StartupHost()
	{
		SetPort ();
		NetworkManager.singleton.StartHost ();
	}

	public void JoinGame()
	{
		NetworkManager.singleton.StartClient ();

	
	}

	void SetPort()
	{
		NetworkManager.singleton.networkPort = 7777;
	}

	void SetIPAddress()
	{
		string ipAddress = GameObject.Find ("InputFieldIPAddress").transform.FindChild ("Text").GetComponent<Text> ().text;
		NetworkManager.singleton.networkAddress = ipAddress;
	}





	



}
