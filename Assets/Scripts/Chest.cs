using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : Collectable
{
    public Sprite fullChest;
    public Sprite emptyChest;
    public int goldAmount = 10;
    private bool isEmpty = false;

    protected override void OnCollect()
    {
        if (!collected)
        {
            base.OnCollect();
            GetComponent<SpriteRenderer>().sprite = fullChest;
            initiateEmptyBox();
        }
    }

    private void initiateEmptyBox()
    {
        StartCoroutine(EmptyTheBox());
    }

    private IEnumerator EmptyTheBox()
    {
        yield return new WaitForSeconds(.2f);
        GetComponent<SpriteRenderer>().sprite = emptyChest;
        GameManager.instance.ShowText("+" + goldAmount + "gold!", 25, Color.yellow, transform.position, Vector3.up * 35, 1.5f);
    }
}
