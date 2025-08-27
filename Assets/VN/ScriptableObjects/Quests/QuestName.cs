using UnityEngine;

[System.Serializable]
public class QuestName
{
    public int questID;
    public string questName;
    [TextArea]
    public string questDescription;

    public QuestStage[] stages;
}
