using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace UglyFramework.HelperClasses
{
    public static class GeometryHelper
    {
        public static void ComputeBoundingBoxFromGeometry(List<Vector2> geom, out Vector2 outLTCornerPos, out Vector2 outDimmensions)
        {
            float minX = float.MaxValue;
            float minY = float.MaxValue;

            float maxX = float.MinValue;
            float maxY = float.MinValue;

            foreach (Vector2 vect in geom)
            {
                minX = Math.Min(minX, vect.X);
                minY = Math.Min(minY, vect.Y);

                maxX = Math.Max(maxX, vect.X);
                maxY = Math.Max(maxY, vect.Y);
            }

            outLTCornerPos.X = minX;
            outLTCornerPos.Y = minY;

            outDimmensions.X = maxX;
            outDimmensions.Y = maxY;
        }
    }
}
