using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class NetPlayer :  NetworkBehaviour{

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown (KeyCode.Space) && isServer)
			RpcTest ();

		if (Input.GetKeyDown (KeyCode.Tab) && localPlayerAuthority)
			CmdTest ();
	
	}

	[ClientRpc]
	void RpcTest()
	{
		Debug.Log (" Client RPC Test");
	}

	[Command]
	void CmdTest()
	{
		
		Debug.Log (" Server Command Test");
	}
}
