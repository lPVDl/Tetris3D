using UnityEditor;
using UnityEngine;

namespace Editor
{
    public class BlockAtlasTextureImporter : AssetPostprocessor
    {
        private const int AtlasTexelCount = 4;

        private void OnPostprocessTexture(Texture2D texture)
        {
            if (!assetPath.ToLower().Contains("blockatlas")) return;
            if (texture.width != texture.height)
            {
                Debug.LogError($"{this}: Texture width must equal texture height");
                return;
            }

            var widthPower = Mathf.Log(texture.width, 2);
            if (widthPower % 1 > 0)
            {
                Debug.LogError($"{this}: Texture size must be power of 2");
                return;
            }

            var originTexelSize = texture.width / AtlasTexelCount;
            var originTexel = new Texture2D(originTexelSize, originTexelSize);

            for (var i = 1; i < texture.mipmapCount; i++)
            {
                var mipmapWidth = (int)Mathf.Sqrt(texture.GetPixels(i).Length);
                if (mipmapWidth < AtlasTexelCount)
                {
                    var pixels = texture.GetPixels(i);
                    for (var j = 0; j < pixels.Length; j++)
                        pixels[j] = Color.black;
                    texture.SetPixels(pixels, i);
                    continue;
                }

                var mipmapTexelSize = mipmapWidth / AtlasTexelCount;

                for (var x = 0; x < AtlasTexelCount; x++)
                    for (var y = 0; y < AtlasTexelCount; y++)
                    {
                        var pixels = texture.GetPixels(x * originTexelSize, y * originTexelSize, originTexelSize, originTexelSize, 0);
                        originTexel.SetPixels(pixels);
                        originTexel.Resize(mipmapTexelSize, mipmapTexelSize, TextureFormat.ARGB32, false);
                        originTexel.Apply();

                        pixels = originTexel.GetPixels();
                        texture.SetPixels(x * mipmapTexelSize, y * mipmapTexelSize, mipmapTexelSize, mipmapTexelSize, pixels, i);
                        originTexel.Resize(originTexelSize, originTexelSize, TextureFormat.ARGB32, false);
                        originTexel.Apply();
                    }
            }

            texture.Apply();
        }
    }
}