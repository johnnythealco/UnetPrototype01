using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ClientInputController :  NetworkBehaviour
{
	[SyncVar]
	public short PlayerID;

	[SyncVar]
	public string PlayerName;

	public bool isPlayer;


	NetManager NetMgr;
	PlayerListDisplay PlayerList;

	#region Setup and Network Management

	void Awake ()
	{
		DontDestroyOnLoad (this.gameObject);
		NetMgr = GameObject.Find ("! NetworkManager !").GetComponent<NetManager> ();


	}

	void Start ()
	{
		Setup ();
	}

	void Setup ()
	{
		if (hasAuthority)
		{
			PlayerName = Game.Manager.localPlayerName;
			PlayerList = GameObject.Find ("Player List").GetComponent<PlayerListDisplay> ();

			NetMgr.LocalPlayer = this;
			this.gameObject.name = "Local Player";
			this.PlayerID = (short)this.netId.Value;
			this.isPlayer = this.isLocalPlayer;


		}

		if (!hasAuthority)
		{
			this.enabled = false;
		}

	}

	/// <summary>
	/// Disconnect this Player
	/// </summary>
	public void Disconnect ()
	{

		if (isServer)
		{
			NetworkManager.singleton.StopHost ();
			NetworkServer.Reset ();
		}

		if (isClient)
		{
			NetworkManager.singleton.StopClient ();
		}
	}

	#endregion

	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.Space))
			CreatePlayer ();

	}


	[Command]
	void CmdAddPlayer (string JSON_Player)
	{
		var player = JsonUtility.FromJson<Player> (JSON_Player);
		Game.Manager.state.Players.Add (player);
		PlayerList.Prime (Game.Manager.state.Players);
		RpcAddPlayer (JSON_Player);
	}

	[ClientRpc]
	void RpcAddPlayer (string JSON_Player)
	{

		var player = JsonUtility.FromJson<Player> (JSON_Player);
		if (!this.isServer)
			Game.Manager.state.Players.Add (player);


	}

	void CreatePlayer ()
	{
		var PlayerID = (short)this.netId.Value;
		var PlayerName = "Player " + PlayerID.ToString ();

		var newPlayerObject = new Player (PlayerName, PlayerID);
		var JSON_Player = JsonUtility.ToJson (newPlayerObject);

		CmdAddPlayer (JSON_Player);
	}


}
