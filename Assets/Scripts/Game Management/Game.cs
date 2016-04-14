using UnityEngine;
using System.Collections;

//using LitJson;

public class Game : MonoBehaviour
{
	public static Game Manager;
	NetManager NetMgr;

	public GameState state = new GameState ();

	void Awake ()
	{
		if (Manager == null)
		{
			Manager = this;
		} else if (Manager != this)
		{
			Destroy (this.gameObject);
		}
		DontDestroyOnLoad (this.gameObject);

		NetMgr = GameObject.Find ("! NetworkManager !").GetComponent<NetManager> ();


	}





}
