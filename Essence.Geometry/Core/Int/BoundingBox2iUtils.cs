﻿#region License

// Copyright 2017 Jose Luis Rovira Martin
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//     http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

#endregion

using INT = System.Int32;
using SysMath = System.Math;

namespace Essence.Geometry.Core.Int
{
    public static class BoundingBox2iUtils
    {
        public static bool IsEmpty(INT xMin, INT xMax)
        {
            return xMax < xMin;
        }

        public static void Union(INT xMin, INT xMax, INT y, out INT zMin, out INT zMax)
        {
            // Si [xMin, xMax] es vacio -> [zMin, zMax] = [y, y]
            if (IsEmpty(xMin, xMax))
            {
                zMin = y;
                zMax = y;
                return;
            }

            zMin = SysMath.Min(xMin, y);
            zMax = SysMath.Max(xMax, y);
        }

        public static void Union(INT xMin, INT xMax, INT yMin, INT yMax, out INT zMin, out INT zMax)
        {
            // Si [xMin, xMax] es vacio -> [zMin, zMax] = [yMin, yMax]
            if (IsEmpty(xMin, xMax))
            {
                zMin = yMin;
                zMax = yMax;
                return;
            }

            // Si [yMin, yMax] es vacio -> [zMin, zMax] = [xMin, xMax]
            if (IsEmpty(yMin, yMax))
            {
                // Vacio.
                zMin = xMin;
                zMax = xMax;
                return;
            }

            zMin = SysMath.Min(xMin, yMin);
            zMax = SysMath.Max(xMax, yMax);
        }

        public static void Intersect(INT xMin, INT xMax, INT yMin, INT yMax, out INT zMin, out INT zMax)
        {
            // Si [xMin, xMax] es vacio -> [zMin, zMax] = vacio ( [xMin, xMax] )
            if (IsEmpty(xMin, xMax))
            {
                zMin = xMin;
                zMax = xMax;
                return;
            }

            // Si [yMin, yMax] es vacio -> [zMin, zMax] = vacio ( [yMin, yMax] )
            if (IsEmpty(yMin, yMax))
            {
                zMin = yMin;
                zMax = yMax;
                return;
            }

            zMin = SysMath.Max(xMin, yMin);
            zMax = SysMath.Min(xMax, yMax);
        }

        public static bool IntersectsWith(INT xMin, INT xMax, INT yMin, INT yMax)
        {
            // Si [xMin, xMax] es vacio -> no hay interseccion.
            if (IsEmpty(xMin, xMax))
            {
                return false;
            }

            // Si [yMin, yMax] es vacio -> no hay interseccion.
            if (IsEmpty(yMin, yMax))
            {
                return false;
            }

            return SysMath.Max(xMin, yMin) <= (SysMath.Min(xMax, yMax));
        }

        public static bool ContainsPoint(INT xMin, INT xMax, INT y)
        {
            // Si [xMin, xMax] es vacio -> no lo contiene.
            if (IsEmpty(xMin, xMax))
            {
                return false;
            }

            return ((xMin <= y) && (y <= xMax));
        }

        public static bool Contains(INT xMin, INT xMax, INT yMin, INT yMax)
        {
            // Si [xMin, xMax] es vacio -> no lo contiene.
            if (IsEmpty(xMin, xMax))
            {
                return false;
            }

            // Si [yMin, yMax] es vacio -> no lo contiene.
            if (IsEmpty(yMin, yMax))
            {
                return false;
            }

            return ((xMin <= yMin) && (yMax <= xMax));
        }

        public static bool TouchPoint(INT xMin, INT xMax, INT y)
        {
            // Si [xMin, xMax] es vacio -> no lo toca.
            if (IsEmpty(xMin, xMax))
            {
                return false;
            }

            return ((xMin == y) || (xMin == y));
        }

        public static bool Touch(INT xMin, INT xMax, INT yMin, INT yMax)
        {
            // Si [xMin, xMax] es vacio -> no lo toca.
            if (IsEmpty(xMin, xMax))
            {
                return false;
            }

            // Si [yMin, yMax] es vacio -> no lo toca.
            if (IsEmpty(yMin, yMax))
            {
                return false;
            }

            return ((xMin == yMin) || (xMin == yMax) || (xMax == yMin) || (xMax == yMax));
        }

        public static bool Equals(INT xMin, INT xMax, INT yMin, INT yMax)
        {
            if (IsEmpty(xMin, xMax))
            {
                return IsEmpty(yMin, yMax);
            }
            else if (IsEmpty(yMin, yMax))
            {
                return false;
            }

            return (xMin == yMin) || (xMax == yMax);
        }
    }
}