using UnityEngine;
using UnityEngine.EventSystems;

namespace DottedFill
{
    public class Node : MonoBehaviour, IPointerDownHandler
    {
        public bool isTargetNode;
        [SerializeField] private bool isFilled;
        public int xPos;
        public int yPos;

        public Line line;

        [SerializeField] private SpriteRenderer sr;
        [SerializeField] private Color normalColor;
        [SerializeField] private Color filledColor;

        private bool isMouseExit = true;

        #region Properties
        public bool IsFiiled { get => isFilled; }
        public bool IsMouseExit { get => isMouseExit; }
        #endregion

        public void Setup(int xPos, int yPos, bool isTargetNode, bool isFilled, Line line)
        {
            this.xPos = xPos;
            this.yPos = yPos;
            this.isTargetNode = isTargetNode;
            this.isFilled = isFilled;
            this.line = line;
        }

        public void ResetFillNode()
        {
            isFilled = false;
            if(isTargetNode == false)
                sr.color = normalColor;
        }

        public void SetFillNode()
        {
            isFilled = true;
            if (isTargetNode == false)
                sr.color = filledColor;
        }

        public bool IsNeighbour(Node node)
        {
            int deltaX = Mathf.Abs(node.xPos - this.xPos);
            int deltaY = Mathf.Abs(node.yPos - this.yPos);

            // Check if the difference is 1 in one dimension and 0 in the other
            if ((deltaX == 1 && deltaY == 0) || (deltaX == 0 && deltaY == 1))
            {
                return true;
            }

            return false;
        }

 
        public void OnPointerDown(PointerEventData eventData)
        {
            if(isTargetNode)
            {
                GridSystem.Instance.SetStartAndTargetNode(this);
                if(GamePlayManager.Instance.currentState == GamePlayManager.GameState.PLAYING)
                {
                    Debug.Log("Still play");

                    GridSystem.Instance.SetStartAndTargetNode(this);
                }
            }
           
        }
    }
}



