using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LootItem
{
    public string itemId;
    public int weight;
}

public class LootTable : MonoBehaviour
{
    public List<LootItem> lootItems;

    public string GetRandomItem()
    {
        int totalWeight = 0;
        for (int i = 0; i < lootItems.Count; i++)
        {
            totalWeight = totalWeight + lootItems[i].weight;
        }

        int randomVal = Random.Range(0, totalWeight);
        int collective = 0;

        for (int i = 0; i < lootItems.Count; i++)
        {
            collective = collective + lootItems[i].weight;
            if (randomVal < collective)
            {
                return lootItems[i].itemId;
            }
        }
        
        return lootItems[0].itemId;
    }
}