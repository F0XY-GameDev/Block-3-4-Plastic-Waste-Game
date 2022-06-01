using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Item Database", menuName = "Inventory System/Items/Database")]
public class ItemDatabaseObject : ScriptableObject, ISerializationCallbackReceiver
{
    public ItemObject[] Items;
    public string[] Descriptions;
    public string[] Names;
    public Sprite[] Sprites;
    public Dictionary<ItemObject, int> GetId = new Dictionary<ItemObject, int>();
    public Dictionary<int, ItemObject> GetItem = new Dictionary<int, ItemObject>();
    public Dictionary<int, string> GetDescription = new Dictionary<int, string>();
    public Dictionary<int, string> GetName = new Dictionary<int, string>();
    public Dictionary<int, Sprite> GetSprite = new Dictionary<int, Sprite>();

    public void OnAfterDeserialize()
    {
        GetId = new Dictionary<ItemObject, int>();
        GetItem = new Dictionary<int, ItemObject>();
        GetDescription = new Dictionary<int, string>();
        GetName = new Dictionary<int, string>();
        for (int i = 0; i < Items.Length; i++)
        {
            GetId.Add(Items[i], i);
            GetItem.Add(i, Items[i]);
        }
        for (int i = 0; i < Descriptions.Length; i++)
        {
            GetDescription.Add(i, Descriptions[i]);
            GetName.Add(i, Names[i]);
            GetSprite.Add(i, Sprites[i]);
        }
        

    }

    public void OnBeforeSerialize()
    {
        
    }
}
