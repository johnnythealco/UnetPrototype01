using UnityEngine;
using System.Collections;
using LitJson;

public class Game : MonoBehaviour 
{
	public static Game Manager;
	NetManager NetMgr;

	public GameState state = new GameState();

	void Awake()
	{
		if(Manager == null)
		{
			Manager = this;
		}
		else if (Manager != this)
		{
			Destroy (this.gameObject);
		}
		DontDestroyOnLoad (this.gameObject);

		NetMgr = GameObject.Find ("! NetworkManager !").GetComponent<NetManager> ();

	}


	public void CreatePlayer()
	{
		var PlayerID = NetMgr.LocalPlayer.playerControllerId;
		var PlayerName = "Player " + PlayerID.ToString ();
		var newPlayerObject =  new Player (PlayerName, PlayerID);
		var JSON = JsonMapper.ToJson (newPlayerObject);

		NetMgr.LocalPlayer.CmdCreatePlayer (JSON);

	}



}
