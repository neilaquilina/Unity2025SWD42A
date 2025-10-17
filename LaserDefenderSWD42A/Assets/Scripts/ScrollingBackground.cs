using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{

    [SerializeField] float scrollSpeed = 0.02f;
    Material backgroundMaterial;
    Vector2 offset;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //get the material of the background from the Inspector
        backgroundMaterial = GetComponent<Renderer>().material;
        //scroll in the y direction based on scrollSpeed
        offset = new Vector2(0f, scrollSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        //scroll the background material by adding the offset to the mainTextureOffset
        backgroundMaterial.mainTextureOffset += offset * Time.deltaTime;
    }
}
