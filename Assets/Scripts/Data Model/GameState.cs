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
	public short ID;
	public string name;
	public PlayerType playerType;
	public string factionName;

	public List<Unit> units;
	public bool ready;


	public Player (string _name, short _ID)
	{
		name = _name;
		ID = _ID;
		playerType = PlayerType.Human;
		factionName = Game.Manager.FactionRegister.factionList [0].FactionName;

		this.units = new List<Unit> ();
		units.Add (new Unit ());
		units.Add (new Unit ());
		units.Add (new Unit ());
	}

	public Faction Faction
	{
		get
		{
			return Game.Manager.FactionRegister.GetFaction (this.factionName);
		}
	}

	
}

public enum PlayerType
{
	Human,
	Computer
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

	public string FactionName{ get { return factionName; } }

	public Faction (string name)
	{
		this.factionName = name;
	}


}
