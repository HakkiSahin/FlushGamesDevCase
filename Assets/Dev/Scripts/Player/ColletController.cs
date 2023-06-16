using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;

public class ColletController : MonoBehaviour
{
    private int backPackCount = 0;
    [SerializeField] private Transform backPack;
    [SerializeField] private Transform shopPoint;
    private bool isSell = false;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Gem"))
        {
            if (other.transform.localScale.x > 0.25f)
            {
                other.transform.parent.GetComponent<GridSystem>().CreateGem(other.transform.position);
                //

                other.transform.tag = "Collected";
                CollectBackPack(other.gameObject.transform);
            }
        }
    }

    private IEnumerator co;
    private void Update()
    {
        if (Vector3.Distance(transform.position, shopPoint.position) < 6f && !isSell)
        {
            isSell = true;
            SeelGem();
        }
        else if (Vector3.Distance(transform.position, shopPoint.position) > 6f)
        {
            isSell = false;
        }
    }


    void CollectBackPack(Transform gem)
    {
        
        backPackCount++;
        gem.GetComponent<Gem>().Colleted();
        gem.localScale = new Vector3(0.3f, 0.3f, 0.3f);
        Vector3 pos = gem.transform.localPosition;
        gem.transform.parent = backPack;

        gem.DOLocalMove(new Vector3(0, backPackCount * 0.3f, 0), 0.3f);
    }

   
    void SeelGem()
    {
        if (backPackCount <=0)
        {
            return;
        }
        Transform obj = backPack.GetChild(backPackCount - 1);

        obj.DOMove(shopPoint.position, 0.1f).OnComplete(() =>
        {
            SaveLoad._instance.SaveCountGem(obj.name);
            Destroy(obj.gameObject);

            backPackCount--;

            if (backPackCount > 0 && isSell)
                SeelGem();
            else
                isSell = false;


        });
    }
    

    //Sell to Shop
    // IEnumerator SellGemEnum()
    // {
    //     Transform obj = backPack.GetChild(backPackCount - 1);
    //
    //     obj.DOMove(shopPoint.position, 0.1f).OnComplete(() =>
    //     {
    //         SaveLoad._instance.SaveCountGem(obj.name);
    //         Destroy(obj.gameObject);
    //
    //         backPackCount--;
    //
    //         if (backPackCount > 0 && isSell)
    //         {
    //             StartCoroutine(SellGemEnum());
    //         }
    //         else
    //         {
    //             isSell = false;
    //         }
    //     });
    //     return null;
    // }
}