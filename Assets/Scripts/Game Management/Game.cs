using UnityEngine;
using System.Collections;



public class Game : MonoBehaviour
{
	public static Game Manager;
	public FactionRegister FactionRegister;
	public string localPlayerName;

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

		FactionRegister.UdateLookup ();




	}





}
