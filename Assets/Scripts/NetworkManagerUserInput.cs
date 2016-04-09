﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class NetworkManagerUserInput :  MonoBehaviour {

	public Button StartHostBtn;
	public Button JoinGameBtn;
	public Button DisconnectBtn;

	public NetManager NetMgr;

	void Awake()
	{
		NetMgr = GameObject.Find ("! NetworkManager !").GetComponent<NetManager> ();
	}


	public void StartHost()
	{
		NetMgr.StartupHost ();
	}

	public void JoinGame()
	{
		NetMgr.JoinGame ();
	}

	public void Disconnect()
	{
		NetMgr.LocalPlayer.Disconnect ();
	}

	public void LoadScene2()
	{
		NetMgr.LoadScene ("Main2");
	}



}
