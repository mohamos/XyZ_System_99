using UnityEngine;
using UnityEngine.UI;
using System;

namespace RoundOne
{
    public class CardBehaviour : MonoBehaviour
    {
        [Header("UI References")]
        [SerializeField] private GameObject backLayer;
        [SerializeField] private Image frontLayer;

        public int CardID { get; private set; }
        public bool IsFlipped { get; private set; }


        public static event Action<CardBehaviour> OnCardClicked;

        public void Initialize(int id, Color color)
        {
            CardID = id;
            frontLayer.color = color;
            ShowBack();
        }

        public void OnClick()
        {

            if (IsFlipped) return;
            Flip(true);
            OnCardClicked?.Invoke(this);
        }

        public void Flip(bool showFront)
        {
            IsFlipped = showFront;
            backLayer.SetActive(!showFront);

        }

        private void ShowBack()
        {
            IsFlipped = false;
            backLayer.SetActive(true);
        }
    }
}