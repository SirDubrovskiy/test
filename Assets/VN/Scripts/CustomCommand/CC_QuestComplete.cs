using UnityEngine;
using Naninovel;

[CommandAlias("QComplete")]
public class CC_QuestComplete : Command
{
    
    public override UniTask ExecuteAsync(AsyncToken asyncToken = default)
    {
        QuestManager.Instance.QuestComplete();
        return UniTask.CompletedTask;
    }
}
