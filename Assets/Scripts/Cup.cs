using DG.Tweening;
using UnityEngine;

public class Cup : MonoBehaviour
{
    private const float _yPosition = 2;
    private const float _duration = 1;
    private const int _loops = -1;
    
    private void Start()
    {
        transform.DOMove(new Vector3(transform.position.x, _yPosition, transform.position.z), _duration).SetLoops(_loops, LoopType.Yoyo);
    }
}