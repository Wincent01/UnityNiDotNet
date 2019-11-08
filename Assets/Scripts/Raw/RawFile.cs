using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

namespace Raw
{
    public class RawFile
    {
        public readonly Dictionary<int, Chunk> Chunks;

        public int ChunkTotalCount { get; set; }

        public int ChunkCountX { get; set; }

        public int ChunkCountY { get; set; }

        public RawFile(string file)
        {
            Chunks = new Dictionary<int, Chunk>();

            var stream = File.OpenRead(file);

            using (var reader = new BinaryReader(stream))
            {
                reader.ReadBytes(3);
                
                ChunkTotalCount = reader.ReadInt32();
                ChunkCountX = reader.ReadInt32();
                ChunkCountY = reader.ReadInt32();

                for (var i = 0; i < ChunkTotalCount; i++)
                {
                    var chunk = new Chunk(reader);
                    Chunks.Add(chunk.ChunkIndex, chunk);
                }
            }
        }

        public Texture2D RenderColorMap(bool secondColorMap = false)
        {
            var colorMapWidth = secondColorMap ? Chunks[0].Colormap1.Width : Chunks[0].Colormap0.Width;
            var colorMapHeight = secondColorMap ? Chunks[0].Colormap1.Height : Chunks[0].Colormap0.Height;

            var texture = new Texture2D(
                ChunkCountX * colorMapWidth,
                ChunkCountY * colorMapHeight
            );

            Debug.Log($"{texture.height} x {texture.width}");

            for (var y = 0; y < ChunkCountY; y++)
            {
                for (var x = 0; x < ChunkCountX; x++)
                {
                    var chunk = Chunks[y * ChunkCountX + x];

                    var colorMap = secondColorMap ? chunk.Colormap1 : chunk.Colormap0;
                    for (var colorMapX = 0; colorMapX < colorMap.Height; colorMapX++)
                    {
                        for (var colorMapY = 0; colorMapY < colorMap.Width; colorMapY++)
                        {
                            var reference = colorMap.GetValue(x, y);
                            texture.SetPixel(x, y, new Color
                            {
                                a = (float) ((reference >> 24) / 255d),
                                r = (float) ((reference >> 16) / 255d),
                                g = (float) ((reference >> 8) / 255d),
                                b = (float) (reference / 255d)
                            });
                        }
                    }
                }
            }

            texture.Apply();

            return texture;
        }

        public Texture2D RenderHeightMap()
        {
            return RenderHeightMap(out _, out _, out _);
        }

        public Texture2D RenderHeightMap(out float min, out float max, out float[,] heights)
        {
            var heightMapWidth = Chunks[0].Heighmap.Width;
            var heightMapHeight = Chunks[0].Heighmap.Height;

            var texture = new Texture2D(
                ChunkCountX * heightMapWidth,
                ChunkCountY * heightMapHeight
            );

            min = 1E+09F;
            max = -1E+09F;
            heights = new float[texture.width, texture.height];

            //
            // Calculate max & min
            //
            for (var y = 0; y < ChunkCountY; y++)
            {
                for (var x = 0; x < ChunkCountX; x++)
                {
                    var chunk = Chunks[y * ChunkCountX + x];

                    for (var heightMapX = 0; heightMapX < chunk.Heighmap.Height; heightMapX++)
                    {
                        for (var heightMapY = 0; heightMapY < chunk.Heighmap.Width; heightMapY++)
                        {
                            var value = chunk.Heighmap.GetValue(x, y);

                            if (value < min) min = value;
                            if (value > max) max = value;
                        }
                    }
                }
            }

            Debug.Log($"Min - {min} -> Max {max}");

            //
            // Render HeightMap
            //
            for (var chunkY = 0; chunkY < ChunkCountY; ++chunkY)
            {
                for (var chunkX = 0; chunkX < ChunkCountX; ++chunkX)
                {
                    var chunk = Chunks[chunkY * ChunkCountX + chunkX];

                    for (var y = 0; y < chunk.Heighmap.Height; ++y)
                    {
                        for (var x = 0; x < chunk.Heighmap.Width; ++x)
                        {
                            var value = chunk.Heighmap.GetValue(x, y);
                            var normalizedHeight = Mathf.InverseLerp(min, max, value);

                            var pixelX = chunkX * Chunks[0].Heighmap.Width + x;
                            var pixelY = chunkY * Chunks[0].Heighmap.Height + y;

                            heights[pixelX, pixelY] = Mathf.InverseLerp(min, 2000, value);

                            texture.SetPixel(
                                pixelX,
                                pixelY,
                                new Color(
                                    normalizedHeight,
                                    normalizedHeight,
                                    normalizedHeight
                                )
                            );
                        }
                    }
                }
            }

            texture.Apply();

            var png = texture.EncodeToPNG();

            File.WriteAllBytes($"{Application.dataPath}/map.png", png);

            return texture;
        }

        public void RenderTerrain(Terrain terrain)
        {
            var render = RenderHeightMap(out _, out var max, out var heights);

            var terrainData = terrain.terrainData;
            
            terrainData.size = new Vector3(render.width, max, render.height);
            terrainData.heightmapResolution = 715;

            var newHeights = new float[render.width, render.height];

            for (var x = 0; x < render.width; x++)
            {
                for (var y = 0; y < render.height; y++)
                {
                    newHeights[x, y] = heights[x, y];
                }
            }

            terrain.terrainData.SetHeights(default, default, newHeights);
        }

        public override string ToString()
        {
            var str = new StringBuilder();
            foreach (var property in GetType().GetProperties())
            {
                str.AppendLine($"{property.Name} = {property.GetValue(this)}");
            }

            foreach (var chunk in Chunks)
            {
                str.AppendLine("Chunk:");
                str.AppendLine(chunk.ToString());
            }

            return str.ToString();
        }
    }
}