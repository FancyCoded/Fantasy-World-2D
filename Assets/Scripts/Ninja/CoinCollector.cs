using UnityEngine;
using UnityEngine.UI;

public class CoinCollector : MonoBehaviour
{
    [SerializeField] private Text _text;

    private string _textValue;
    private int _coinAmount;

    private void OnEnable()
    {
        _textValue = "Coins: " + _coinAmount;
    }

    private void FixedUpdate()
    {
        _text.text = _textValue;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.TryGetComponent(out Coin coin))
        {
            _coinAmount++;
            _textValue = "Coins: " + _coinAmount;
        }
    }
}
