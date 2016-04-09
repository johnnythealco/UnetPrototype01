﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine.UI;


public class NetManager : NetworkManager 
{

	public NetPlayer LocalPlayer;

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

	public void LoadScene(string sceneName)
	{
		NetworkManager.singleton.ServerChangeScene (sceneName);
	}


	public override void OnClientConnect (NetworkConnection conn)
	{
		base.OnClientConnect (conn);

		Debug.Log ("OnClientConnect Called : Conection " + conn.ToString ());
	}




	



}
