using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class NetworkManagerUI :  MonoBehaviour
{
	Button StartHost_Btn;
	Button JoinGame_Btn;
	InputField PlayerName_Inpt;
	NetManager NetMgr;

	void Awake ()
	{
		NetMgr = GameObject.Find ("! NetworkManager !").GetComponent<NetManager> ();

		if (SceneManager.GetActiveScene ().name == "Lobby")
		{
			PlayerName_Inpt = GameObject.Find ("PlayerNameInputField").GetComponent<InputField> (); 
			StartHost_Btn = GameObject.Find ("StartHostBtn").GetComponent<Button> ();
			JoinGame_Btn = GameObject.Find ("JoinGameBtn").GetComponent<Button> ();
			StartHost_Btn.interactable = false; 
			JoinGame_Btn.interactable = false;
		}


	}


	public void StartHost ()
	{
		NetMgr.StartupHost ();
	}

	public void JoinGame ()
	{
		NetMgr.JoinGame ();
	}

	public void Disconnect ()
	{
		NetMgr.LocalPlayer.Disconnect ();
	}

	public void EnableHostAndJoinBtn ()
	{
		Game.Manager.localPlayerName = PlayerName_Inpt.text;
		StartHost_Btn.interactable = true; 
		JoinGame_Btn.interactable = true;
	}



	public void LoadScene2 ()
	{
		NetMgr.LoadScene ("Main2");
	}



}
