using TMPro;
using UnityEngine;

public class AuthorViewer : MonoBehaviour
{
    [SerializeField] private TMP_Text _position;
    [SerializeField] private TMP_Text _initials;
    [SerializeField] private Author _author;

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        _position.text = _author.Position;
        _initials.text = _author.FirstName + " " + _author.LastName;
    }
}