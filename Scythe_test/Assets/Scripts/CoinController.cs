using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
   private void Update()
   {
      transform.position = Vector3.MoveTowards(transform.position, SellPlaneController.coinIconPos, Constants.coinFlySpeed * Time.deltaTime);

      if (transform.position == SellPlaneController.coinIconPos)
      {
         UIController.AddMoney();
         Destroy(gameObject);
      }
   }
}
