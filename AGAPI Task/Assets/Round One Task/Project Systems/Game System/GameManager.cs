using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RoundOne
{
    public class GameManager : MonoBehaviour
    {
        private List<CardBehaviour> _openedCards = new List<CardBehaviour>();
        private int _score = 0;

        private void OnEnable()
        {
            CardBehaviour.OnCardClicked += HandleCardClick;
        }

        private void OnDisable()
        {
            CardBehaviour.OnCardClicked -= HandleCardClick;
        }

        private void HandleCardClick(CardBehaviour card)
        {
            _openedCards.Add(card);

      
            if (_openedCards.Count >= 2)
            {
                CardBehaviour card1 = _openedCards[0];
                CardBehaviour card2 = _openedCards[1];

                _openedCards.RemoveRange(0, 2);

                StartCoroutine(CheckMatchRoutine(card1, card2));
            }
        }

        private IEnumerator CheckMatchRoutine(CardBehaviour c1, CardBehaviour c2)
        {
            yield return new WaitForSeconds(1.0f);

            if (c1.CardID == c2.CardID)
            {
              
                _score += 10;
                Debug.Log("Match! Score: " + _score);
               
            }
            else
            {
                
                c1.Flip(false);
                c2.Flip(false);
            }
        }
    }
}