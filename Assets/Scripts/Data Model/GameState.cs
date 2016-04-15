using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;


[System.Serializable]
public class GameState : System.Object
{
	public List<Player> Players = new List<Player> ();

	public GameState ()
	{
		
	}
		
}

[System.Serializable]
public class Player
{
	public string name;
	public short ID;
	public List<Unit> units;

	public Player (string _name, short _ID)
	{
		name = _name;
		ID = _ID;
		this.units = new List<Unit> ();
		units.Add (new Unit ());
		units.Add (new Unit ());
		units.Add (new Unit ());
	}
	
}

[System.Serializable]
public class Unit
{
	public string name;
	[SerializeField]
	int health;
	[SerializeField]
	float experience;

	public Unit ()
	{

		name = "attackShip";
		health = 120;
		experience = 1589;

	}
		
}

[System.Serializable]
public class Faction : System.Object
{
	[SerializeField]
	string factionName;

	string FactionName{ get { return factionName; } }

	public Faction (string name)
	{
		this.factionName = name;
	}

}
