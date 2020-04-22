using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerB : MonoBehaviour
{
    [SerializeField] private float earnrate = 0f;
    [SerializeField] private int lifetime = 5;
    private int currentlife = 0;
    private Shop shop = null;

    void Start()
    {
        shop = GameObject.Find("Shop").GetComponent<Shop>();
    }

    void Update()
    {
        if(currentlife >= lifetime)
        {
            Destroy(gameObject);
        }
    }

    public void WaveEnd()
    {
        shop.potato += earnrate;
        currentlife++;
    }
}
