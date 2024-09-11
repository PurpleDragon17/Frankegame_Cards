using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Code made with help from ChatGPT
public class BurnAndDup : MonoBehaviour
{
    public int SP = 0;
    public DeckBuild deckBuild;
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D collider)
    {
       
        if (deckBuild.Hand.Contains(collider.gameObject))
        {
            Debug.Log("SHIT!");
            if (SP == 0)
            {
               

                    int index = deckBuild.Hand.IndexOf(collider.gameObject);
                
                    GameObject CardinPlay = deckBuild.Hand[index];
                deckBuild.Hand.RemoveAt(index);
                CardinPlay.SetActive(false);
                    SP = 1;
                    Debug.Log("Fuck!");
                
            }
            if (SP == 1)
            {
                

                    int index = deckBuild.Hand.IndexOf(collider.gameObject);
                GameObject gameObject1 = deckBuild.Hand[index];
                GameObject CardinPlay1 = gameObject1;
                deckBuild.Hand.RemoveAt(index);
                CardinPlay1.SetActive(false);
                    SP = 2;
                
            }
            if (SP == 2)
            {
                

                    int index = deckBuild.Hand.IndexOf(collider.gameObject);
                  
                    GameObject CardinPlay2 = deckBuild.Hand[index];
                    GameObject Duplicate = Instantiate(CardinPlay2, transform.position, Quaternion.identity);
                    Duplicate.transform.position = new Vector3(-1, 1, 0);
                deckBuild.prefabInstances.Add(Duplicate);

                SP = 0;
                
            }
        }
    }

  
}
