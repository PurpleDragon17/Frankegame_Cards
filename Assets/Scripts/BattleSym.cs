using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;
//Code made with help from ChatGPT
public class BattleSym : MonoBehaviour
{

    public int EnemyHealth;
    public TMP_Text EnemHealthDisplay;
    public int PlayerHealth;
    public TMP_Text PlayHealthDisplay;
    public DeckBuild deckBuid;
    public bool EnemHazard;
    public GameObject HazardCard;


    public void Start()
    {
        EnemHazard = false;
        EnemHealthDisplay.text = EnemyHealth.ToString();
        PlayHealthDisplay.text = PlayerHealth.ToString();
    }
    // Update is called once per frame


    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the object we collided with has a specific tag
        if (other.CompareTag("Attack"))
        {
            EnemyHealth = EnemyHealth - 3;
            EnemHealthDisplay.text = EnemyHealth.ToString();
            other.transform.position = new Vector3(9, -8, 0);
        }
        if (other.CompareTag("Block"))
        {
            PlayerHealth = PlayerHealth + 2;
            PlayHealthDisplay.text = PlayerHealth.ToString();
            other.transform.position = new Vector3(9, -8, 0);
        }
        if (other.CompareTag("Effect"))
        {
            EnemHazard = true;
            other.transform.position = new Vector3(9, -8, 0);
        }
        if (other.CompareTag("Hazard"))
        {
            PlayerHealth = PlayerHealth - 1;
            PlayHealthDisplay.text = PlayerHealth.ToString();
            other.transform.position = new Vector3(9, -8, 0);
        }
        Discard();
        EnemTurn();
        DeckShuffle();

    }

    public void Discard()
    {
        foreach (GameObject item in deckBuid.Hand)
        {
            // Ensure the item is not null
            if (item != null)
            {
                // Move the item by the specified offset
                item.transform.position = new Vector3(9, -8, 0);
                deckBuid.prefabInstances.Add(item);
            }
        }

    }
    public void EnemTurn()
    {
        if (EnemHazard == false)
        {
            int value1 = 1;
            int value2 = 2;
            int chosenValue = RandomChoice(value1, value2);
            if(chosenValue == 1)
            {
                PlayerHealth = PlayerHealth - 3;
                PlayHealthDisplay.text = PlayerHealth.ToString();
            }
            if (chosenValue == 2)
            {
              GameObject AddCard1 =  Instantiate(HazardCard, transform.position, Quaternion.identity);
                deckBuid.prefabInstances.Add(AddCard1);
                GameObject AddCard2 = Instantiate(HazardCard, transform.position, Quaternion.identity);
                deckBuid.prefabInstances.Add(AddCard2);
            }
        }
        if(EnemHazard == true)
        {
            EnemyHealth = EnemyHealth - 1;
            EnemHealthDisplay.text = EnemyHealth.ToString();
            EnemHazard = false;
        }
    }
    int RandomChoice(int val1, int val2)
    {
        // Generate a random integer (0 or 1) and use it to select between val1 and val2
        return Random.Range(0, 2) == 0 ? val1 : val2;
    }

    public void DeckShuffle()
    {
        int deckSize = deckBuid.prefabInstances.Count;
        if (deckSize >= 5)
        {
            int numberOfSelections = 5;
            List<GameObject> shuffledObjects = Shuffle(deckBuid.prefabInstances);
            List<GameObject> selectedObjects = GetRandomValues(shuffledObjects, numberOfSelections);

            // Output the selected GameObjects
            foreach (GameObject obj in selectedObjects)
            {
                Debug.Log("Selected GameObject: " + obj.name);
            }
            MoveGameObject(deckBuid.prefabInstances[0], new Vector3(-3, -3, 0));
            MoveGameObject(deckBuid.prefabInstances[1], new Vector3(-1, -3, 0));
            MoveGameObject(deckBuid.prefabInstances[2], new Vector3(1, -3, 0));
            MoveGameObject(deckBuid.prefabInstances[3], new Vector3(3, -3, 0));
            MoveGameObject(deckBuid.prefabInstances[4], new Vector3(5, -3, 0));
            deckBuid.DeckSize.text = (deckBuid.numberOfPrefabs - 5).ToString();
            GameObject DrawnCard = deckBuid.prefabInstances[0];
            deckBuid.Hand.Add(DrawnCard);
            GameObject DrawnCard2 = deckBuid.prefabInstances[1];
            deckBuid.Hand.Add(DrawnCard2);
            GameObject DrawnCard3 = deckBuid.prefabInstances[2];
            deckBuid.Hand.Add(DrawnCard3);
            GameObject DrawnCard4 = deckBuid.prefabInstances[3];
            deckBuid.Hand.Add(DrawnCard4);
            GameObject DrawnCard5 = deckBuid.prefabInstances[4];
            deckBuid.Hand.Add(DrawnCard5);
            deckBuid.prefabInstances.RemoveAt(4);
            deckBuid.prefabInstances.RemoveAt(3);
            deckBuid.prefabInstances.RemoveAt(2);
            deckBuid.prefabInstances.RemoveAt(1);
            deckBuid.prefabInstances.RemoveAt(0);
        }

    
   

        else
        {
            if(deckSize == 4)
            {
                int numberOfSelections = 5;
                List<GameObject> shuffledObjects = Shuffle(deckBuid.prefabInstances);
                List<GameObject> selectedObjects = GetRandomValues(shuffledObjects, numberOfSelections);

                // Output the selected GameObjects
                foreach (GameObject obj in selectedObjects)
                {
                    Debug.Log("Selected GameObject: " + obj.name);
                }
                MoveGameObject(deckBuid.prefabInstances[0], new Vector3(-3, -3, 0));
                MoveGameObject(deckBuid.prefabInstances[1], new Vector3(-1, -3, 0));
                MoveGameObject(deckBuid.prefabInstances[2], new Vector3(1, -3, 0));
                MoveGameObject(deckBuid.prefabInstances[3], new Vector3(3, -3, 0));
                deckBuid.DeckSize.text = (deckBuid.numberOfPrefabs - 4).ToString();
                GameObject DrawnCard = deckBuid.prefabInstances[0];
                deckBuid.Hand.Add(DrawnCard);
                GameObject DrawnCard2 = deckBuid.prefabInstances[1];
                deckBuid.Hand.Add(DrawnCard2);
                GameObject DrawnCard3 = deckBuid.prefabInstances[2];
                deckBuid.Hand.Add(DrawnCard3);
                GameObject DrawnCard4 = deckBuid.prefabInstances[3];
                deckBuid.Hand.Add(DrawnCard4);
                deckBuid.prefabInstances.RemoveAt(3);
                deckBuid.prefabInstances.RemoveAt(2);
                deckBuid.prefabInstances.RemoveAt(1);
                deckBuid.prefabInstances.RemoveAt(0);
            }
        
        if(deckSize == 3)
        {
            MoveGameObject(deckBuid.prefabInstances[0], new Vector3(-3, -3, 0));
            MoveGameObject(deckBuid.prefabInstances[1], new Vector3(-1, -3, 0));
            MoveGameObject(deckBuid.prefabInstances[2], new Vector3(1, -3, 0));
            deckBuid.DeckSize.text = (deckBuid.numberOfPrefabs - 4).ToString();
            GameObject DrawnCard = deckBuid.prefabInstances[0];
            deckBuid.Hand.Add(DrawnCard);
            GameObject DrawnCard2 = deckBuid.prefabInstances[1];
            deckBuid.Hand.Add(DrawnCard2);
            GameObject DrawnCard3 = deckBuid.prefabInstances[2];
            deckBuid.Hand.Add(DrawnCard3);
            deckBuid.prefabInstances.RemoveAt(2);
            deckBuid.prefabInstances.RemoveAt(1);
            deckBuid.prefabInstances.RemoveAt(0);
        }
        if(deckSize == 2) {
            MoveGameObject(deckBuid.prefabInstances[0], new Vector3(-3, -3, 0));
            MoveGameObject(deckBuid.prefabInstances[1], new Vector3(-1, -3, 0));
            deckBuid.DeckSize.text = (deckBuid.numberOfPrefabs - 4).ToString();
            GameObject DrawnCard = deckBuid.prefabInstances[0];
            deckBuid.Hand.Add(DrawnCard);
            GameObject DrawnCard2 = deckBuid.prefabInstances[1];
            deckBuid.Hand.Add(DrawnCard2);
            deckBuid.prefabInstances.RemoveAt(1);
            deckBuid.prefabInstances.RemoveAt(0);
        }
        if(deckSize == 1)
            {
                MoveGameObject(deckBuid.prefabInstances[0], new Vector3(-3, -3, 0));
                deckBuid.DeckSize.text = (deckBuid.numberOfPrefabs - 4).ToString();
                GameObject DrawnCard = deckBuid.prefabInstances[0];
                deckBuid.Hand.Add(DrawnCard);
                deckBuid.prefabInstances.RemoveAt(0);
            }
    }
      
    }
    List<GameObject> Shuffle(List<GameObject> list)
    {
        // Implementing the Fisher-Yates shuffle algorithm
        System.Random rng = new System.Random();
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            GameObject value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
        return list;
    }

    List<GameObject> GetRandomValues(List<GameObject> list, int count)
    {
        // Ensure count does not exceed the list size
        count = Mathf.Min(count, list.Count);

        // Return the first 'count' elements from the shuffled list
        return list.GetRange(0, count);
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

