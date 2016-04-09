using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using LitJson;

[System.Serializable]
public class GameState : System.Object
{
	public List<Player> Players = new List<Player>();

	public GameState()
	{
		
	}
	public GameState (string json)
	{
		var ItemData = JsonMapper.ToObject (json);

		for (int i = 0; i < ItemData ["Players"].Count; i++)
		{	
			var JSONString =  JsonMapper.ToJson (ItemData ["Players"] [i]); 				
			var player =	new Player (JSONString);
			Players.Add (player);
		}
	}


}

[System.Serializable]
public struct Player
{
	public string name;
	public short ID;
	public List<Unit> units;

	public Player (string _name, short _ID)
	{
		name = _name;
		ID = _ID;
		this.units = new List<Unit> ();		
	}

	public Player (string json)
	{

		Debug.Log ("Player Constructor JSON String Reecieved : " + json);
		this.units = new List<Unit> ();
		var ItemData = JsonMapper.ToObject (json);

		name = ItemData ["name"].ToString ();
		ID = (short)ItemData ["ID"];

		for (int i = 0; i < ItemData ["units"].Count; i++)
		{
			var JSONUnit = JsonMapper.ToJson (ItemData ["units"] [i]);
			units.Add (new Unit (JSONUnit)); 
		}
	}
	
}

[System.Serializable]
public struct Unit
{
	public string name;
	public int health;
	public int experience;

	public Unit (string name, int health, int experience) 
	{
		this.name = name;
		this.health = health;
		this.experience = experience;
//		name = "attackShip";
//		health = 120;
//		experience = 1589;

	}

	public Unit (String json)
	{
		Debug.Log ("Unit Constructor JSON String Reecieved : " + json);
		var ItemData = JsonMapper.ToObject (json);

		name = ItemData ["name"].ToString ();
		health = (int)ItemData ["health"];
		experience = (int)ItemData ["experience"];

	}
}
