using UnityEngine;
using Naninovel;

[CommandAlias("playminigame")]
public class CC_StartMinigame : Command
{
    
    [ParameterAlias("id")]
    public IntegerParameter minigameID;
    
    [ParameterAlias("scene")]
    public StringParameter nextSceneName;

    [ParameterAlias("command")]
    public StringParameter command;
    
    
    public override UniTask ExecuteAsync(AsyncToken asyncToken = default)
    {
        switch (command.Value)
        {
            case "play":
                MiniGamesManager.Instance.nextSceneName = nextSceneName;
                MiniGamesManager.Instance.StartMinigame(minigameID);
                break;
            
            case "stop":
                MiniGamesManager.Instance.StopMinigame(minigameID);
                break;
            
            default:
                Debug.LogWarning($"Неизвестная команда: {command.Value}");
                break;
        }
        
        return UniTask.CompletedTask;
    }
}
