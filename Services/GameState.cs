﻿using System;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Net.Http;
using System.Linq;
using System.Threading;

public class GameState
{
	public event EventHandler StateChanged;

    public bool isGathering;
    public bool isHunting;
    public bool isWorkingOut;
    public bool isRunning;
    public bool isSmithing;
    public bool canSell;
    public bool canBank;

    public bool isSplitView;
    public bool inventoryIsActiveView;

    public bool saveDataLoaded;
    public bool gameDataLoaded;

    public string previousURL;
    
    public GameItem currentUsedItem;
    public GameItem currentGatherItem;
    public GameItem currentBuffItem;

    public int buffSecondsLeft;
    private Player player = new Player();

    public Area currentArea;

    public Timer attackTimer;
    public Timer foodTimer;

    private void StateHasChanged()
    {
        StateChanged?.Invoke(this, EventArgs.Empty);
    }
    public void UpdateState()
    {
        StateHasChanged();
    }
    public GameState()
    {

    }
    public Player GetPlayer()
    {
        return player;
    }
    public Inventory GetPlayerInventory()
    {
        return player.inventory;
    }
    public Bank GetPlayerBank()
    {
        return player.bank;
    }
    public void LoadPlayerData(HttpClient Http)
    {
        player.LoadSkills(Http);
    }
    public void SetBuffItem(GameItem item)
    {
        currentBuffItem = item;
        buffSecondsLeft = item.HealDuration;
    }
    public bool CanLeave()
    {
        if(!isGathering && !isHunting && !isWorkingOut && !isSmithing && !isRunning)
        {
            return true;
        }
        return false;
    }
    public void ToggleSplitView()
    {
        isSplitView = !isSplitView;
        UpdateState();
    }
    public void ToggleActiveView()
    {
        inventoryIsActiveView = !inventoryIsActiveView;
        UpdateState();
    }
}
