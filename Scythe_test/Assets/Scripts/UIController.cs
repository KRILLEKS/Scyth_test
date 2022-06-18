using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
   [Header("coin")]
   [SerializeField] private TextMeshProUGUI coinTextSerializable;
   [SerializeField] private GameObject coinIconSerializable; // it'll shake
   [Header("wheat amount")]
   [SerializeField] private TextMeshProUGUI wheatTextSerializable;

   // private variables
   private static TextMeshProUGUI _coinText;
   private static GameObject _coinIcon;
   private static TextMeshProUGUI _wheatText;
   private static int _maxWheatAmount;
   // ideally it should be in money controller or at least in sell plane controller
   private static float _currentMoneyAmount = 0;

   private void Awake()
   {
      _coinText = coinTextSerializable;
      _coinIcon = coinIconSerializable;
      _wheatText = wheatTextSerializable;
      _maxWheatAmount = Constants.backpackSize.x * Constants.backpackSize.y * Constants.backpackSize.z;

      _wheatText.text = $"0/{_maxWheatAmount}";
   }

   public static void AddMoney()
   {
      // floor to int in case player will get float amount of money per wheat
      _coinIcon.transform.DOScale(1.25f, 0.1f)
               .SetEase(Ease.InOutSine)
               .OnComplete(() => _coinIcon.transform.DOScale(1, 0.1f).OnComplete(() => _coinText.text = (_currentMoneyAmount += Constants.moneyPerOneCoin).ToString()));
   }

   public static void UpdateWheatInfo(int currentAmount)
   {
      _wheatText.text = $"{currentAmount}/{_maxWheatAmount}";
   }
}