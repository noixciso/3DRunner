using DG.Tweening;
using UnityEngine;

public class Cup : MonoBehaviour
{
    private void Start()
    {
        transform.DOMove(new Vector3(transform.position.x, 2, transform.position.z), 1).SetLoops(-1, LoopType.Yoyo);
    }
}