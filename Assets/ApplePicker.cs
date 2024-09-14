using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ApplePicker : MonoBehaviour
{
    [Header("Inscribed")]
    public GameObject basketPrefab;
    public int numBaskets = 3;
    public float basketBottomY = -14f;
    public float basketSpacingY = 2f;
    public List<GameObject> basketList;

    // Start is called before the first frame update
    void Start()
    {
        basketList = new List<GameObject>();
        for (int i = 0; i < numBaskets; i++) {
            GameObject tBasketGo = Instantiate<GameObject>(basketPrefab);
            Vector3 pos = Vector3.zero;
            pos.y = basketBottomY + (basketSpacingY * i);
            tBasketGo.transform.position = pos;
            basketList.Add(tBasketGo);
        }
    }

    public void AppleMissed() {
        // destroy all of the falling Apples
        GameObject[] appleArray=GameObject.FindGameObjectsWithTag("Apple");
        foreach (GameObject tempGo in appleArray) {
            Destroy(tempGo);
        }

        // destroy one of the Baskets
        // get the index of the last Basket in basketList
        int basketIndex = basketList.Count - 1;
        //get a reference to that Basket GameObject
        GameObject basketGO = basketList[basketIndex];
        // remove the Basket from the list and destroy the GameObject
        basketList.RemoveAt(basketIndex);
        Destroy(basketGO);

        // if tehre are no Baskets left, restart the game
        if (basketList.Count == 0) {
            SceneManager.LoadScene("_Scene_0");
        }
    }
}
