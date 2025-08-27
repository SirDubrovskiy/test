using UnityEngine;

[System.Serializable]
public class QuestStage
{
    public int stageID;
    [TextArea]
    public string description;
    public bool isCompleted;
}
