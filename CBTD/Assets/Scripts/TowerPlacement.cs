using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPlacement : MonoBehaviour
{
    [SerializeField] private GameObject poland;
    [SerializeField] private float polandPrice;

    [SerializeField] private GameObject bangladesh;
    [SerializeField] private float bangladeshPrice;

    [SerializeField] private GameObject finland;
    [SerializeField] private float finlandPrice;

    [SerializeField] private GameObject errortext1;
    [SerializeField] private Shop shop;

    private string reference;

    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            spawn(reference);
        }

        if(Input.GetButtonDown("Fire2"))
        {
            reference = null;
        }

        Vector2 mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);


        if (Input.GetKeyDown(KeyCode.G))
        {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit))
            {
                if (hit.transform.CompareTag("Map"))
                {
                    Debug.Log("yess");
                }
            }
        }
    }

    public void SetReference(string refer)
    {
        reference = refer;
    }

    void spawn(string refer)
    {     
        Vector2 mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);


        if(Input.GetKeyDown(KeyCode.G))
        {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.transform.position, mousepos, out hit))
            {
                if (hit.transform.CompareTag("Map"))
                {
                    Debug.Log("yess");
                }
            }
        }


        switch(refer) 
        {
            case "poland":
                if(shop.potato >= polandPrice)
                {
                    Instantiate(poland, new Vector3(mousepos.x, mousepos.y, 0f), Quaternion.identity);
                    shop.potato -= polandPrice;
                }
                else
                {
                    StartCoroutine(toogleerror(errortext1));
                }
                break;

            case "bangladesh":
                if (shop.potato >= bangladeshPrice)
                {
                    Instantiate(bangladesh, new Vector3(mousepos.x, mousepos.y, 0f), Quaternion.identity);
                    shop.potato -= bangladeshPrice;
                }
                else
                {
                    StartCoroutine(toogleerror(errortext1));
                }
                break;

            case "finland":
                if (shop.potato >= finlandPrice)
                {
                    Instantiate(finland, new Vector3(mousepos.x, mousepos.y, 0f), Quaternion.identity);
                    shop.potato -= finlandPrice;
                }
                else
                {
                    StartCoroutine(toogleerror(errortext1));
                }
                break;

            default:
                break;
        }
    }

    IEnumerator toogleerror(GameObject error)
    {
        error.SetActive(true);
        yield return new WaitForSeconds(2f);
        error.SetActive(false);
    }
}
