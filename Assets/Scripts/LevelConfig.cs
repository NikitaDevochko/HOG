using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelConfig", menuName = "Config/LevelConfig")]
public class LevelConfig : ScriptableObject
{
    [SerializeField] private List<Level> allLevels;

    public Level GetLevelByIndex(int index)
    {
        if (allLevels == null || allLevels.Count == 0)
        {
            return null;
        }
        return allLevels[index >= allLevels.Count ? allLevels.Count - 1 : index];
    }

}
