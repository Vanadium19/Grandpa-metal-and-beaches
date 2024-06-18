using UnityEngine;

[CreateAssetMenu(fileName = "New Stat", menuName = "Stats/Create new BagLevel", order = 54)]
public class BagLevel : Stat
{
    public BagLevel() => Name = GameSaver.Names.Bag;
}