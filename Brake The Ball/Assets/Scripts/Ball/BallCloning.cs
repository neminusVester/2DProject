using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCloning : MonoBehaviour
{
    [SerializeField] private GameObject ballPrefab;
    private readonly List<GameObject> _saveBalls = new List<GameObject>();

    void Start()
    {
        Create();
    }

    public void Create()
    {
        _saveBalls.Clear();
        _saveBalls.Add(Instantiate(ballPrefab, new Vector2( transform.position.x, transform.position.y + 0.25f),Quaternion.identity,transform));
    }

    public void CreateClone()
    {
        foreach(var item in _saveBalls)
        {
            if (item != null)
            {
                GameObject cloneOne = Instantiate(ballPrefab, new Vector2(item.transform.position.x,
                item.transform.position.y), Quaternion.identity, null);
                cloneOne.GetComponent<MovingBall>().StartClone(1f);
                _saveBalls.Add(cloneOne);
                break;
            }
        }
    }
}
