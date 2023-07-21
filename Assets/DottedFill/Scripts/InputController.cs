using UnityEngine;

namespace DottedFill
{
    public class InputController : MonoBehaviour
    {
        public static InputController Instance { get; private set; }
        private GridSystem gridSystem;
        private GamePlayManager gamePlayManager;
        [SerializeField] private LayerMask nodeLayer;

        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            gridSystem = GridSystem.Instance;
            gamePlayManager = GamePlayManager.Instance;
        }


        private void Update()
        {
            switch(gamePlayManager.currentState)
            {
                default: break;
                case GamePlayManager.GameState.WAITING:
                    if(Input.GetMouseButtonUp(0))
                    {
                        gamePlayManager.currentState = GamePlayManager.GameState.PLAYING;
                    }
                    break;
                case GamePlayManager.GameState.PLAYING:
                    if (gamePlayManager.currentState == GamePlayManager.GameState.PLAYING)
                    {
                        if (Input.GetMouseButton(0))
                        {
                            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                            Vector2 mousePosition2D = new Vector2(mousePosition.x, mousePosition.y);
                            RaycastHit2D hit = Physics2D.Raycast(mousePosition2D, Vector2.zero, 0f, nodeLayer);
                            if (hit.collider != null)
                            {
                                Node hitNode;
                                if (hit.collider.TryGetComponent<Node>(out hitNode))
                                {                                
                                    if (gridSystem.currentNode == null)
                                    {
                                        if (hitNode.isTargetNode == false) return;

                                        gridSystem.currentNode = hitNode;
                                        gridSystem.currentNodePath.Add(hitNode);
                                        gridSystem.SetStartAndTargetNode(hitNode);
                                        hitNode.SetFillNode();

                                        return;
                                    }

                                    

                                    if (gridSystem.currentNode != hitNode)
                                    {
                                        if (hitNode.IsFiiled == false)
                                        {
                                            if (gridSystem.currentNode.IsNeighbour(hitNode) == false) return;

                                            Vector2 pointA = gridSystem.currentNode.transform.position;
                                            Vector2 pointB = hitNode.transform.position;
                                            gridSystem.currentNode.line.DrawLine(pointA, pointB);

                                            gridSystem.currentNode = hitNode;
                                            gridSystem.currentNodePath.Add(hitNode);
                                            gridSystem.SetStartAndTargetNode(hitNode);
                                            hitNode.SetFillNode();
                                        }
                                        else
                                        {

                                            // Reset current node
                                            gridSystem.currentNode.ResetFillNode();
                                            gridSystem.RemoveFromNode(hitNode);
                                            hitNode.line.Clear();

                                            gridSystem.currentNode = hitNode;
                                            gridSystem.currentNodePath.Add(hitNode);
                                            gridSystem.SetStartAndTargetNode(hitNode);
                                            hitNode.SetFillNode();

               
                                        }           
                                    }                                                                      
                                }
                            }
                        }
                    }
                    break;
            }
            
     

            

                             
        }

    
    }
}



