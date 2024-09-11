using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
//Code made with help from ChatGPT
public class TypeOfCard : MonoBehaviour
{
    // Start is called before the first frame update
    // Define the tag pool with four specific tags
    private List<string> tagPool = new List<string>
   
    {
        "Attack",
        "Block",
        "Effect",
        "Hazard"
    };
    private SpriteRenderer sR;

    void Start()
    {
        sR = gameObject.GetComponent<SpriteRenderer>();
        // Ensure the tag pool is not empty
        if (tagPool == null || tagPool.Count == 0)
        {
            Debug.LogWarning("Tag pool is empty. No tag will be assigned.");
            return;
        }
        if (gameObject.tag != "Untagged")
        {
            Debug.Log("The GameObject has a tag.");
        }
        else
        {
            // Get a random index from the tag pool
            int randomIndex = Random.Range(0, tagPool.Count);

            // Get the tag at the random index
            string selectedTag = tagPool[randomIndex];

            // Ensure the tag exists in Unity's tag manager
            if (TagExists(selectedTag))
            {
                // Assign the tag to this GameObject
                gameObject.tag = selectedTag;
                Debug.Log(selectedTag);
                if (tag == tagPool[0])
                {
                    sR.color = Color.red;
                }
                if (tag == tagPool[1])
                {
                    sR.color = Color.blue;
                }
                if (tag == tagPool[2])
                {
                    sR.color = Color.yellow;
                }
                if (tag == tagPool[3])
                {
                    sR.color = Color.gray;
                }
            }
       
            
        }
        
    }

    bool TagExists(string tagName) =>
       // Check if the tag exists in the Unity editor
       // UnityEditorInternal.InternalEditorUtility.tags.Contains(tagName);
       true; 
}
