[System.Serializable]
public class Quest 
{
    //Quest State
    public QuestState State = QuestState.New;
    //Name
    public string name;
    //Description
    public string description;
    //Experience Reward
    public int expReward;
    //Gold Reward
    public int goldReward;

    //Goal
    public QuestGoal goal;
    //SourceID
    //QuestID
    //ChainID

    //Complete
    public void Complete()
    {
        State = QuestState.Completed;
    }
}
public enum QuestState
{
    New,
    Accepted,
    Failed,
    Completed,
    Claimed,
}
