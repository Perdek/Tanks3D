using UnityEngine;

namespace RunTime.Managers
{
    [CreateAssetMenu(fileName = "LevelPrefabsDB", menuName = "ScriptableObjects/SpawnLevelPrefabsDB", order = 1)]
    public class LevelPrefabsDB : ScriptableObject
    {
        [SerializeField] private GameObject _eagle;
        [SerializeField] private GameObject _bricks;
        [SerializeField] private GameObject _emptySpace;
        [SerializeField] private GameObject _nonDestructiveBricks;
        [SerializeField] private GameObject _grass;
    }
}