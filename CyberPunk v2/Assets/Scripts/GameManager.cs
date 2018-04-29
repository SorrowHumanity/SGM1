using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject player;
    public List<GameObject> ground;
    private int index;

    List<int> targetList;

    void Start()
    {

        Renderer rend = GetComponent<Renderer>();

        ground = new List<GameObject>(GameObject.FindGameObjectsWithTag("Ground"));

        targetList = new List<int>();

         StartCoroutine(CubeDestroyer());
        
    }

    IEnumerator CubeDestroyer()
    {

        index = Random.Range(0, ground.Count);

        ground[index].GetComponent<Renderer>().material.color = Color.red;

        yield return new WaitForSeconds(2);

        Destroy(ground[index]);

        ground.RemoveAt(index);
       
        if (ground.Count > 0) StartCoroutine(CubeDestroyer());
        
    }
}