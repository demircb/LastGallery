using UnityEngine;

public class ResizeCubeToTexture : MonoBehaviour
{
    public Texture2D paintingTexture; // Assign your painting texture in the Inspector
    [SerializeField] float scalefactor = 0.001f;
    [SerializeField] float paintingDepth = 0.3f;
    private void Start()
    {
        // Get the dimensions of the painting texture
        float textureWidth = paintingTexture.width * scalefactor;
        float textureHeight = paintingTexture.height * scalefactor;

        // Adjust the cube's scale to match the texture dimensions
        Vector3 newScale = new Vector3(textureWidth, textureHeight,paintingDepth );
        transform.localScale = newScale;
    }
}
