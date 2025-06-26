using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField] GameObject gun;

    public void AmmoCreate()
    {
        Instantiate(gun, transform);
    }
}
