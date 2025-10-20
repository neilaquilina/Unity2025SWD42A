using UnityEngine;

public class DestroyLaser : MonoBehaviour
{

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }


}
