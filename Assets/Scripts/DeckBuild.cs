using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//Code made with a lot of help from ChatGPT 
public class DeckBuild : MonoBehaviour
{
    // Reference to the prefab you want to instantiate
    public GameObject prefab;
    public TMP_Text DeckSize;
   // public GameObject FireCircle;
    

    // List to hold the spawned prefab instances
    public List<GameObject> prefabInstances = new List<GameObject>();
    public List<GameObject> Hand = new List<GameObject>();

    // Number of prefabs to spawn
    public int numberOfPrefabs = 10;

    // Start is called before the first frame update
    void Start()
    {
        SpawnPrefabs();
        DrawStartingHand();
    }

    void SpawnPrefabs()
    {
        for (int i = 0; i < numberOfPrefabs; i++)
        {
            // Instantiate the prefab at a random position (you can customize this as needed)
            Vector3 spawnPosition = new Vector3(-7, -3);
            GameObject instance = Instantiate(prefab, spawnPosition, Quaternion.identity);

            // Add the instantiated prefab to the list
            prefabInstances.Add(instance);
            DeckSize.text = (i + 1).ToString();

        }

    }

    void DrawStartingHand()
    {
        {
            //List<GameObject> Deck = DeckBuild.prefabInstances;
            // Example: Move the first GameObject in the list
            if (prefabInstances.Count > 0)
            {
                MoveGameObject(prefabInstances[0], new Vector3(-3, -3, 0));
                MoveGameObject(prefabInstances[1], new Vector3(-1, -3, 0));
                MoveGameObject(prefabInstances[2], new Vector3(1, -3, 0));
                MoveGameObject(prefabInstances[3], new Vector3(3, -3, 0));
                MoveGameObject(prefabInstances[4], new Vector3(5, -3, 0));
                DeckSize.text = (numberOfPrefabs-5).ToString();
                GameObject DrawnCard = prefabInstances[0];
                Hand.Add(DrawnCard);
                GameObject DrawnCard2 = prefabInstances[1];
                Hand.Add(DrawnCard2);
                GameObject DrawnCard3 = prefabInstances[2];
                Hand.Add(DrawnCard3);
                GameObject DrawnCard4 = prefabInstances[3];
                Hand.Add(DrawnCard4);
                GameObject DrawnCard5 = prefabInstances[4];
                Hand.Add(DrawnCard5);
                prefabInstances.RemoveAt(4);
                prefabInstances.RemoveAt(3);
                prefabInstances.RemoveAt(2);
                prefabInstances.RemoveAt(1);
                prefabInstances.RemoveAt(0);
                Debug.Log(Hand.Count);


            }


        }
        void MoveGameObject(GameObject obj, Vector3 newPosition)
        {
            if (obj != null)
            {
                obj.transform.position = newPosition;
            }
            else
            {
                Debug.LogWarning("The GameObject is null and cannot be moved.");
            }
        }
    }
   
}

