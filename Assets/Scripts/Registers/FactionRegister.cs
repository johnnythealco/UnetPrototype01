using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class FactionRegister : ScriptableObject
{
	public List<Faction> factionList;
	Dictionary<string,Faction> lookup = new Dictionary<string, Faction> ();

	public List<string> FactionNameList ()
	{
		var result = new List<string> ();

		foreach (var _faction in factionList)
		{
			result.Add (_faction.FactionName);
		}
		return result;
	}

	public void UdateLookup ()
	{

		foreach (var _faction in factionList)
		{
			lookup.Add (_faction.FactionName, _faction);
		}
		
	}

	/// <summary>
	/// Find the Faction by the Faction Name
	/// </summary>
	/// <returns>The faction.</returns>
	/// <param name="factionName">Faction name.</param>
	public Faction GetFaction (string factionName)
	{
		return lookup [factionName]; 
	}

	/// <summary>
	/// Find the Faction by the position in the Faction Register List
	/// </summary>
	/// <returns>The faction.</returns>
	/// <param name="index">Index.</param>
	public Faction GetFaction (int index)
	{
		if (index <= factionList.Count () && index > -1)
		{
			return factionList [index];
		} else
		{
			Debug.Log ("Faction not Found!");
			return factionList [0];
		}
	}


}
