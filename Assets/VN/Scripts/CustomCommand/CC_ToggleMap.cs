using UnityEngine;
using Naninovel;

[CommandAlias("map")]
public class CC_ToggleMap : Command
{
    
    [ParameterAlias("turn")]
    public StringParameter map;
    
    
    public override UniTask ExecuteAsync(AsyncToken asyncToken = default)
    {
        Map_Controller.Instance.ToggleMapButton(map);
        return UniTask.CompletedTask;
    }
}
