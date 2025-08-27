using UnityEngine;
using Naninovel;

[CommandAlias("LAccess")]
public class CC_LocationAccess : Command
{
    
    [ParameterAlias("LName")]
    public StringParameter locationName;
    
    [ParameterAlias("LAccess")]
    public BooleanParameter locationAccess;
    
    public override UniTask ExecuteAsync(AsyncToken asyncToken = default)
    {
        Map_Controller.Instance.LockLocation(locationName, locationAccess);
        return UniTask.CompletedTask;
    }
}
