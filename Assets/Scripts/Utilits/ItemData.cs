using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "Custom/ItemData", order = 1)]
public sealed class ItemData : ScriptableObject
{
    [SerializeField] private ItemInfo[] items;

    public ItemInfo GetRandomItem()
    {
        float totalChance = 0f;

        foreach (var item in items)
        {
            totalChance += item.SpawnChance;
        }

        float randomValue = Random.Range(0f, totalChance);

        foreach (var item in items)
        {
            if (randomValue <= item.SpawnChance)
            {
                return item;
            }

            randomValue -= item.SpawnChance;
        }

        return null;
    }

    [System.Serializable]
    public class ItemInfo
    {
        public GameObject Prefab;
        [Range(0,1)] public float SpawnChance;
    }
}