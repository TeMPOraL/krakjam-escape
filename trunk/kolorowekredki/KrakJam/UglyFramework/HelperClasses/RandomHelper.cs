using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UglyFramework.HelperClasses
{
    public static class RandomHelper
    {
        // a random number generator that the whole sample can share.
        private static Random random = new Random();
        public static Random Random
        {
            get { return random; }
        }

        //  a handy little function that gives a random float between two
        // values. This will be used in several places in the sample, in particilar in
        // ParticleSystem.InitializeParticle.
        public static float RandomBetween(float min, float max)
        {
            return min + (float)random.NextDouble() * (max - min);
        }

    }
}
