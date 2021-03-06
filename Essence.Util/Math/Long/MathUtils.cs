﻿// Copyright 2017 Jose Luis Rovira Martin
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

using System.Text;
using INT = System.Int64;

namespace Essence.Util.Math.Long
{
    public static class MathUtils
    {
        #region Clamp

        public static long Clamp(this long v, long min, long max)
        {
            if (v < min)
            {
                return min;
            }
            if (v > max)
            {
                return max;
            }
            return v;
        }

        #endregion Clamp

        /// <summary>
        ///     Formatea un valor largo en una cadena de texto binaria.
        /// </summary>
        /// <param name="valor">Valor largo para formatear.</param>
        /// <param name="blancos">Indica si se ponen blancos cada 4 bits.</param>
        /// <returns>Cadena de texto con el valor binario.</returns>
        public static string ToBinaryString(long valor, bool blancos)
        {
            StringBuilder bitstring = new StringBuilder();
            for (int i = 63; i >= 0; i--)
            {
                string result = ((((valor >> i) & 1) == 1) ? "1" : "0");
                bitstring.Append(result);
                if (blancos)
                {
                    if ((i > 0) && ((i) % 4) == 0)
                    {
                        bitstring.Append(" ");
                    }
                }
            }
            return bitstring.ToString();
        }

        /// <summary>
        ///     Interpolación lineal.
        /// </summary>
        public static long Lerp(long x, long x1, long y1, long x2, long y2)
        {
            if ((x1 == x2) || (y1 == y2))
            {
                return y1;
            }
            return (y1 * (x2 - x) + y2 * (x - x1)) / (x2 - x1);
        }

        /// <summary>
        ///     Interpolación lineal.
        /// </summary>
        public static long Lerp(long x, long x1, long y1, long x2, long y2, out long result)
        {
            if ((x1 == x2) || (y1 == y2))
            {
                result = 0;
                return y1;
            }
            return System.Math.DivRem((y1 * (x2 - x) + y2 * (x - x1)), (x2 - x1), out result);
        }
    }
}