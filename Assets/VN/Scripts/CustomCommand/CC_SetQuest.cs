using System.Threading;
using UnityEngine;
using Naninovel;

[CommandAlias("setquest")]
public class CC_SetQuest : Command
{
    [ParameterAlias("id")]
    public IntegerParameter questIDs;
    
    [ParameterAlias("stage")]
    public IntegerParameter questStage;

    public override UniTask ExecuteAsync(AsyncToken asyncToken = default)
    {
        
        QuestManager.Instance.SetCurrentQuest(questIDs);
          
        return UniTask.CompletedTask;
    }
}
