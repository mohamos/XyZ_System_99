using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

namespace RoundOne
{
    public class GridManager : MonoBehaviour
    {
        [Header("Settings")]
        public int rows = 4;
        public int columns = 4;
        public float spacing = 10f;

        [Header("References")]
        [SerializeField] private GameObject cardPrefab;
        [SerializeField] private RectTransform gridContainer;
        [SerializeField] private GridLayoutGroup gridLayout;

        private void Start()
        {
            GenerateGrid();
        }

        public void GenerateGrid()
        {

            float containerWidth = gridContainer.rect.width;
            float containerHeight = gridContainer.rect.height;

            float cellWidth = (containerWidth - (spacing * (columns - 1))) / columns;
            float cellHeight = (containerHeight - (spacing * (rows - 1))) / rows;

          
            float finalSize = Mathf.Min(cellWidth, cellHeight);
            gridLayout.cellSize = new Vector2(finalSize, finalSize);
            gridLayout.spacing = new Vector2(spacing, spacing);
            gridLayout.constraint = GridLayoutGroup.Constraint.FixedColumnCount;
            gridLayout.constraintCount = columns;

        
            int totalCards = rows * columns;
            List<Color> cardColors = PrepareColors(totalCards / 2);

      
            for (int i = 0; i < totalCards; i++)
            {
                GameObject newCard = Instantiate(cardPrefab, gridContainer);
                CardBehaviour cardScript = newCard.GetComponent<CardBehaviour>();

              
                cardScript.Initialize(i, cardColors[i]);
            }
        }

        private List<Color> PrepareColors(int pairCount)
        {
            List<Color> colors = new List<Color>();
            for (int i = 0; i < pairCount; i++)
            {
                Color randomColor = new Color(Random.value, Random.value, Random.value);
                colors.Add(randomColor);
                colors.Add(randomColor); 
            }

         
            for (int i = 0; i < colors.Count; i++)
            {
                Color temp = colors[i];
                int randomIndex = Random.Range(i, colors.Count);
                colors[i] = colors[randomIndex];
                colors[randomIndex] = temp;
            }
            return colors;
        }
    }
}