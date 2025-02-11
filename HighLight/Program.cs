﻿using System.Reflection;
using HighLight.Managers;
using Timersky.Config;
using Timersky.Log;

namespace HighLight;

public static class Program
{
    public static void Main(string[] args)
    {
        try
        {
            Start();

            while (true)
            {
                CommandManager.HandleCommand(Log.Read()?.Split(' ', StringSplitOptions.RemoveEmptyEntries));
            }
        }
        catch (Exception e)
        {
            Log.Error(e);
            Exit(1);
        }
    }

    private static void OnProcessExit(object? sender, EventArgs e) => Exit(0);
    private static void OnCancelKeyPress(object? sender, ConsoleCancelEventArgs e) => Exit(0);
    
    private static void Start()
    {
        Log.Initialize();
        
        Log.Info("Starting...");
        
        CommandManager.RegisterCommands(Assembly.GetExecutingAssembly(), false);
        PluginManager.LoadPlugins();
        
        AppDomain.CurrentDomain.ProcessExit += OnProcessExit;
        Console.CancelKeyPress += OnCancelKeyPress;
        
        Log.Info("Ready");
    }

    public static void Exit(int exitCode)
    {
        Log.Info("Exiting...");
        
        PluginManager.UnloadPlugins();
        CommandManager.UnregisterCommands();
        
        AppDomain.CurrentDomain.ProcessExit -= OnProcessExit;
        Console.CancelKeyPress -= OnCancelKeyPress;
        
        Environment.Exit(exitCode);
    }
}