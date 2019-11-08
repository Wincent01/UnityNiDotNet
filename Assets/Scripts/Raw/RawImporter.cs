using System;
using UnityEditor.Experimental.AssetImporters;
using UnityEngine;

namespace Raw
{
    [ScriptedImporter(1, "raw")]
    public class RawImporter : ScriptedImporter
    {
        public override void OnImportAsset(AssetImportContext ctx)
        {
            var raw = new RawFile(ctx.assetPath);
            
            var heightMap = raw.RenderHeightMap(out var min, out var max, out _);

            var terrainAsset = Terrain.activeTerrain;

            terrainAsset.terrainData.size = new Vector3(heightMap.width, Math.Abs(min) + Math.Abs(max), heightMap.height);

            var colorMap0 = raw.RenderColorMap();
            var colorMap1 = raw.RenderColorMap(true);
            
            raw.RenderTerrain(terrainAsset);
            
            heightMap.name = "HeightMap";
            colorMap0.name = "ColorMap - 0";
            colorMap1.name = "ColorMap - 1";

            var terrainHeightMap = new Texture2D(heightMap.width, heightMap.height);
            terrainHeightMap.SetPixels(heightMap.GetPixels());
            
            terrainHeightMap.name = "HeightMap";

            ctx.AddObjectToAsset("HeightMap - 0", heightMap);
            ctx.AddObjectToAsset("HeightMap - 1", terrainHeightMap);
            ctx.AddObjectToAsset("ColorMap - 0", colorMap0);
            ctx.AddObjectToAsset("ColorMap - 1", colorMap1);
        }
    }
}