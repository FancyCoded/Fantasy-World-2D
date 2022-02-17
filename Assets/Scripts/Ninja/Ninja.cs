using UnityEngine;
using UnityEngine.Events;

public class Ninja : MonoBehaviour
{
    [SerializeField] private UnityEvent _achieved;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.TryGetComponent(out Coin coin))
        {
            _achieved.Invoke();
        }
    }
}
