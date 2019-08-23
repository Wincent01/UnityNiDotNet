using System;
using System.IO;
using Luz.Enums;
using Lvl;
using NiDotNet.NIF.Nodes;
using UnityEngine;

namespace Luz
{
    [Serializable]
    public class LuzFile
    {
        public uint Version { get; set; }
    
        public uint WorldId { get; set; }
    
        public NiVector3 SpawnPoint { get; set; }
        
        public NiQuaternion SpawnRotation { get; set; }
    
        public uint SceneCount { get; set; }
    
        public LuzScene[] Scenes { get; set; }
        
        public NiString TerrainFileName { get; set; }
        
        public NiString TerrainFile { get; set; }
        
        public NiString TerrainDescription { get; set; }
        
        public uint SceneTransitionCount { get; set; }
        
        public LuzSceneTransition[] Transitions { get; set; }
        
        public uint PathDataCount { get; set; }
        
        public LuzPathData[] PathData { get; set; }
        
        public LvlFile[] LvlFiles { get; set; }
        
        public LuzFile(string path)
        {
            var reader = new BinaryReader(File.OpenRead(path));

            Version = reader.ReadUInt32();

            if (Version >= 0x24)
            {
                reader.ReadUInt32();
            }

            WorldId = reader.ReadUInt32();

            if (Version >= 0x26)
            {
                SpawnPoint = new NiVector3(reader, null);
                SpawnRotation = new NiQuaternion(reader, null);
            }

            SceneCount = Version < 0x25 ? reader.ReadByte() : reader.ReadUInt32();
            
            Scenes = new LuzScene[SceneCount];
            LvlFiles = new LvlFile[SceneCount];

            for (var i = 0; i < SceneCount; i++)
            {
                Scenes[i] = new LuzScene(reader);
                Debug.Log(Scenes[i].FileName);
                LvlFiles[i] = new LvlFile($"{Path.GetDirectoryName(path)}/{Scenes[i].FileName}");
            }

            reader.ReadByte();

            TerrainFileName = new NiString(reader, false, true);

            TerrainFile = new NiString(reader, false, true);

            TerrainDescription = new NiString(reader, false, true);

            if (Version >= 0x20)
            {
                SceneTransitionCount = reader.ReadUInt32();
                
                Transitions = new LuzSceneTransition[SceneTransitionCount];

                for (var i = 0; i < SceneTransitionCount; i++)
                {
                    Transitions[i] = new LuzSceneTransition(reader, this);
                }
            }

            if (Version < 0x23) return;
            {
                reader.ReadUInt32();
                reader.ReadUInt32();
                
                PathDataCount = reader.ReadUInt32();
                
                PathData = new LuzPathData[PathDataCount];

                for (var i = 0; i < PathDataCount; i++)
                {
                    var version = reader.ReadUInt32();
                    var name = new NiString(reader, true, true);
                    var type = (PathType) reader.ReadUInt32();

                    reader.ReadUInt32();

                    switch (type)
                    {
                        case PathType.Movement:
                            PathData[i] = new LuzPathData(reader, version, name, type);
                            break;
                        case PathType.MovingPlatform:
                            PathData[i] = new LuzMovingPlatformPath(reader, version, name, type);
                            break;
                        case PathType.Property:
                            PathData[i] = new LuzPropertyPath(reader, version, name, type);
                            break;
                        case PathType.Camera:
                            PathData[i] = new LuzCameraPath(reader, version, name, type);
                            break;
                        case PathType.Spawner:
                            PathData[i] = new LuzSpawnerPath(reader, version, name, type);
                            break;
                        case PathType.Showcase:
                            PathData[i] = new LuzPathData(reader, version, name, type);
                            break;
                        case PathType.Race:
                            PathData[i] = new LuzPathData(reader, version, name, type);
                            break;
                        case PathType.Rail:
                            PathData[i] = new LuzPathData(reader, version, name, type);
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }

                    var count = reader.ReadUInt32();
                    PathData[i].Waypoints = new LuzPathWaypoint[count];

                    for (var j = 0; j < count; j++)
                    {
                        switch (type)
                        {
                            case PathType.Movement:
                                PathData[i].Waypoints[j] = new LuzMovementWaypoint(reader, PathData[i]);
                                break;
                            case PathType.MovingPlatform:
                                PathData[i].Waypoints[j] = new LuzMovingPlatformWaypoint(reader, PathData[i]);
                                break;
                            case PathType.Property:
                                PathData[i].Waypoints[j] = new LuzPathWaypoint(reader, PathData[i]);
                                break;
                            case PathType.Camera:
                                PathData[i].Waypoints[j] = new LuzCameraWaypoint(reader, PathData[i]);
                                break;
                            case PathType.Spawner:
                                PathData[i].Waypoints[j] = new LuzSpawnerWaypoint(reader, PathData[i]);
                                break;
                            case PathType.Showcase:
                                PathData[i].Waypoints[j] = new LuzPathWaypoint(reader, PathData[i]);
                                break;
                            case PathType.Race:
                                PathData[i].Waypoints[j] = new LuzRaceWaypoint(reader, PathData[i]);
                                break;
                            case PathType.Rail:
                                PathData[i].Waypoints[j] = new LuzRailWaypoint(reader, PathData[i]);
                                break;
                            default:
                                throw new ArgumentOutOfRangeException();
                        }
                    }
                }
            }
        }
    }
}