using System;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    private List<GameItem> gameItems = null;
    private int itemCount = 0;

    public Action OnCompllete = null;
    public Action<string> OnItemListChanged = null;

    public void Initialize()
    {
        gameItems = new List<GameItem>(GetComponentsInChildren<GameItem>());
        foreach (GameItem item in gameItems)
        {
            item.OnFind += OnFindItem;
        }
        itemCount = gameItems.Count;
    }

    private void OnFindItem(string name)
    {
        if (--itemCount > 0)
        {
            OnItemListChanged?.Invoke(name);
        }
        else
        {
            OnCompllete?.Invoke();
        }
    }

    public Dictionary<string, GameItemData> GetItemDictionary()
    {
        Dictionary<string, GameItemData> item = new Dictionary<string, GameItemData>();
        foreach (GameItem gameItem in gameItems)
        {
            if (item.ContainsKey(gameItem.Name))
            {
                item[gameItem.Name].IncreaseAmount();
            }
            else
            {
                item.Add(gameItem.Name, new GameItemData(gameItem.ItemSprite));
            }
        }
        return item;
    }
}
