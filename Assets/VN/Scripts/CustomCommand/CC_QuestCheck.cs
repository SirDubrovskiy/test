using UnityEngine;
using Naninovel;

[CommandAlias("QCheck")]
public class CC_QuestCheck : Command
{
    
    [ParameterAlias("id")]
    public IntegerParameter questIDs;
    
    [ParameterAlias("stage")]
    public IntegerParameter questStage;
    
    public override UniTask ExecuteAsync(AsyncToken asyncToken = default)
    {
        QuestManager.Instance.QuestCheck(questIDs);
        return UniTask.CompletedTask;
    }
}
