using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPointController : MonoBehaviour
{
    public GameObject endTree;
    public int countForEndTree;

    void Start ()
    {
        countForEndTree = CoinCounter.Instance.coinCount;
    }
    // Update is called once per frame
    void Update()
    {
        countForEndTree = CoinCounter.Instance.coinCount;

        if(countForEndTree == 25)
        {
            endTree.SetActive(true);
        }
    }
}
