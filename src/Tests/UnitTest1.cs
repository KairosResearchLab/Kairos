using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VL.Core;
using VL.Lib.Collections;

namespace Tests
{
    [TestClass]
    public class UnitTest1
    {
        class Track_M : VLObject
        {
            [Element]
            public string Path;
            [Element]
            public Spread<Clip_M> Clips = Spread.Create(new Clip_M(), new Clip_M());

            public Track_M() : base(NodeContext.Default)
            {
            }

            public Track_M With(string path, Spread<Clip_M> clips)
            {
                return new Track_M() { Path = path, Clips = clips };
            }
        }

        class Clip_M : VLObject
        {
            [Element]
            public string Path;

            public Clip_M() : base(NodeContext.Default)
            {
            }

            public Clip_M With(string path)
            {
                return new Clip_M() { Path = path };
            }
        }

        [TestMethod]
        public void GeneratePathsTest()
        {
            var track = new Track_M();
            var newTrack = track.GeneratePaths();
            Assert.AreEqual(newTrack.Clips[0].Path, "Clips[0]");
        }
    }
}
