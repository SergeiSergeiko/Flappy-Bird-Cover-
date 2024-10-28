using UnityEngine;

[CreateAssetMenu(fileName = "new author", menuName = "Author")]
public class Author : ScriptableObject
{
    [SerializeField] private string _position;
    [SerializeField] private string _firstName;
    [SerializeField] private string _lastName;

    public string Position => _position;
    public string FirstName => _firstName;
    public string LastName => _lastName;
}
