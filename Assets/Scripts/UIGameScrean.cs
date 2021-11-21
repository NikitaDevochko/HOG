using System.Collections.Generic;
using UnityEngine;

public class UIGameScrean : MonoBehaviour
{
    [SerializeField] private RectTransform contenet;
    [SerializeField] private GameObject prefab;
    private Dictionary<string, UIItem> uiItems = new Dictionary<string, UIItem>();

    public void Initialize(Level level)
    {
        GenerateList(level.GetItemDictionary());
        level.OnItemListChanged += OnItemListChange;
    }

    private void OnItemListChange(string obj)
    {
        if (uiItems.ContainsKey(name))
        {
            uiItems[name].Decrease();
        }
    }

    private void GenerateList(Dictionary<string, GameItemData> dictionary)
    {
        foreach (var key in dictionary.Keys)
        {
            UIItem newItem = Instantiate(prefab, contenet).GetComponent<UIItem>();
            newItem.SetSprite(dictionary[key].Sprite);
            newItem.SetCount(dictionary[key].Amount);
            uiItems.Add(key, newItem);
        }
    }
}
