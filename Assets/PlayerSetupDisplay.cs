﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerSetupDisplay : MonoBehaviour
{

	protected Player player;
	public Image sprite;
	public Text playerName;
	public Dropdown factionChoice;
	public Dropdown typeChoice;

	public delegate void PlayerDisplayDelegate (Player _Player);

	public event PlayerDisplayDelegate onClick;


	public void Prime (Player _player)
	{
		player = _player;
		getFactionList ();

		if (factionChoice != null)
			factionChoice.value = Game.Manager.FactionRegister.factionList.IndexOf (_player.Faction);
		if (typeChoice != null)
			typeChoice.value = (int)_player.playerType;
	}

	void getFactionList ()
	{
		factionChoice.ClearOptions ();
		factionChoice.AddOptions (Game.Manager.FactionRegister.FactionNameList ());
	}

	public void OnClick ()
	{
		if (onClick != null)
			onClick.Invoke (player);
	}

	public void ChangePlayerFaction ()
	{
		player.factionName = Game.Manager.FactionRegister.GetFaction (factionChoice.value).FactionName;
	}

	public void ChangePlayerType ()
	{
		if (typeChoice.value == 0)
			player.playerType = PlayerType.Human;

		if (typeChoice.value == 1)
			player.playerType = PlayerType.Computer;
	


	}



}
