using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FactionBuilder : MonoBehaviour
{
	public FactionRegister factionRegister;

	public InputField FactionNameInput;

	public void AddFaction ()
	{
		if (FactionNameInput.text != null)
		{
			var faction = new Faction (FactionNameInput.text);
			factionRegister.factionList.Add (faction);
		}
	}

}
