using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class GameManager : MonoBehaviour
{
    public List<GameObject> ground;
    private int index;

    private void Start()
    {
        ground = new List<GameObject>(GameObject.FindGameObjectsWithTag("Ground"));

        StartCoroutine(CubeDestroyer());
    }

    private IEnumerator CubeDestroyer()
    {
        index = Random.Range(0, ground.Count);

        ground[index].GetComponent<Renderer>().material.color = Color.red;

        yield return new WaitForSeconds(2);

        Destroy(ground[index]);

        ground.RemoveAt(index);

        if (ground.Count > 0) StartCoroutine(CubeDestroyer());
    }
}