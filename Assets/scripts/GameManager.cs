using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private Dictionary<string, int> inventory = new Dictionary<string, int>();

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddItem(string id, int count)
    {
        if (inventory.ContainsKey(id)) {
            inventory[id] += count;
        }
        else {
            inventory[id] = count;
        }
    }

    public bool RemoveItem(string id, int count)
    {
        if (!inventory.ContainsKey(id) || inventory[id] < count)
        {
            return false;
        }

        inventory[id] -= count;
        return true;
    }

    public int GetItemCount(string id)
    {
        if (inventory.ContainsKey(id))
        {
            return inventory[id];
        }
        else
        {
            return 0;
        }
    }
}