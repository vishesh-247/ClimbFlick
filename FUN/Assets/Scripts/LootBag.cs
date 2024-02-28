using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootBag : MonoBehaviour
{
    public GameObject droppeditemPrefab;
    public List<Loot> lootTable = new List<Loot>(); 

    Loot GetDroppedItem()
    {
        int randomNumber= Random.Range(1, 101); 
        List<Loot> possibleItems= new List<Loot>(); 
        foreach (Loot item in lootTable)
        {
            if (randomNumber <= item.dropChance)
            {
                possibleItems.Add(item);

            }
        }   
        if (possibleItems.Count > 0)
        {
            Loot droppedItem= possibleItems[ Random.Range(0, possibleItems.Count)];
            return droppedItem; 
        }

        Debug.Log("No item dropped");   
        return null;
    }

    public void InstantiateLoot(Vector3 spawnPosition)
    {
        Loot droppedItem= GetDroppedItem();
        if (droppedItem != null)
        {
            GameObject droppedItemObject= Instantiate(droppeditemPrefab, spawnPosition, Quaternion.identity);
            droppedItemObject.GetComponent<SpriteRenderer>().sprite= droppedItem.lootSprite;
            
            float dropForce= 300f;
            Vector2 dropDirection= new Vector2(Random.Range(-1f, 1f), Random.Range(-1f,1f));   
            droppedItemObject.GetComponent<Rigidbody2D>().AddForce(dropDirection * dropForce,ForceMode2D.Impulse);
        } 


    }
}
