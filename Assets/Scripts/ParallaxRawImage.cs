using UnityEngine;
using UnityEngine.UI;

public class ParallaxRawImage : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private RawImage _image;

    private float _imagePositionX;
    private float _imagePositionY;

    private void Start()
    {
        _imagePositionX = _image.uvRect.x;
        _imagePositionY = _image.uvRect.y;
    }

    private void Update()
    {
        _imagePositionX += _speed * Time.deltaTime;

        if (_imagePositionX > 1)
            _imagePositionX = 0;

        _image.uvRect = new Rect(_imagePositionX, _imagePositionY,
            _image.uvRect.width, _image.uvRect.height);
    }
}