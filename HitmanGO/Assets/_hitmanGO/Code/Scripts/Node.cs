using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    Vector2 coordinate;
    public Vector2 Coordinate { get {  return Utility.RoundVector2(coordinate); } }

    List<Node> neighborNodes = new List<Node>();
    public List<Node> NeighborNodes { get { return neighborNodes; } }

    private Board board;

    [SerializeField] private GameObject _geometry;
    [SerializeField] private Ease _ease = Ease.InExpo;

    //Animating Node Start

    private void Awake()
    {
        board = FindObjectOfType<Board>();
        coordinate = new Vector2(transform.position.x, transform.position.z);
    }

    private void Start()
    {
        ShowNode();

        if(board != null)
        {
            neighborNodes = FindNeighbors(board.AllNodes);
        }
    }

    void ShowNode()
    {
        StartCoroutine(NodeAnimRoutine());
    }
    IEnumerator NodeAnimRoutine()
    {
        if(_geometry != null)
        {
            _geometry.transform.DOScale(Vector3.zero, 0f);

            yield return new WaitForSeconds(1);

            _geometry.transform.DOScale(Vector3.one, 1f).SetEase(_ease);
        }
        
    }

    public List<Node> FindNeighbors(List<Node> nodes)
    {
        List<Node> nodeList = new List<Node>();

        foreach(Vector2 dir in Board.directions)
        {
            Node foundNeighbor = nodes.Find(n => n.Coordinate == Coordinate + dir);

            if(foundNeighbor != null && !nodeList.Contains(foundNeighbor))
            {
                nodeList.Add(foundNeighbor);
            }
        }


        return nodeList;
    }
}
