using UnityEngine;
using Naninovel;

[CommandAlias("Notify")]
public class CC_Notification : Command
{
    [ParameterAlias("id")]
    public IntegerParameter nid;
    
    public override UniTask ExecuteAsync(AsyncToken asyncToken = default)
    {
        NotificationController.Instance.AddNotification(nid);
        return UniTask.CompletedTask;
    }
    
}
