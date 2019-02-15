using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class CoinScreen : MonoBehaviour
{
    public Coin[] coins;
    public UnityEvent afterCoinsIn;

    void Start()
    {
        bool atLeastOneShow = false;;
        foreach (Coin c in coins)
        {
            bool hide = Random.value < 0.5f ? false : true;
            if(!hide)
            {
                atLeastOneShow = true;
            }
            c.gameObject.SetActive(hide);
        }

        if(atLeastOneShow == false)
        {
            coins[ Random.Range(0, coins.Length) ].gameObject.SetActive(true);
        }
    }

    void Update()
    {
        if (coins.All(x => x.wentIn || x.gameObject.activeInHierarchy == false))
        {
            afterCoinsIn.Invoke();
            this.gameObject.SetActive(false);
        }
    }
}
