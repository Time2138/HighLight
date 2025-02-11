using HighLight.Attributes;
using HighLight.Interfaces;

namespace HighLight.Commands;

[Command]
public class Exit : ICommand
{
    public string Name => "Exit";
    public string[] Aliases => [];
    public string Description => "Close the program";
    
    public bool Execute(string[] args, out string? response)
    {
        Program.Exit(1);
        
        response = "";
        return true;
    }
}