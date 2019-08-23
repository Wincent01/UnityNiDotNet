using System;
using System.IO;
using NiDotNet.NIF.Nodes;

namespace Luz
{
    [Serializable]
    public class LuzSceneTransition
    {
        public NiString SceneTransitionName { get; set; }
        
        public LuzSceneTransitionPoint[] TransitionPoints { get; set; }
        
        public LuzSceneTransition(BinaryReader reader, LuzFile file)
        {
            if (file.Version < 0x25)
            {
                SceneTransitionName = new NiString(reader, false, true);
            }

            var pointCount = file.Version <= 21 || file.Version >= 0x27 ? 2 : 5;
            
            TransitionPoints = new LuzSceneTransitionPoint[pointCount];

            for (var i = 0; i < pointCount; i++)
            {
                TransitionPoints[i] = new LuzSceneTransitionPoint(reader);
            }
        }
    }
}