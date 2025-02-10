﻿using HarmonyLib;

namespace SimplePlugin;

public class Plugin : HighLight.Plugin
{
    public string Name => "Simple Plugin";
    public string Description => "";
    public string Author => "Ivan Timersky";
    public Version Version => new(1, 0, 0);
    
    public void OnEnable()
    {
        base.OnEnable();
    }

    public void OnDisable()
    {
        base.OnDisable();
    }

    public void OnReloaded()
    {
        base.OnReloaded();
    }
}