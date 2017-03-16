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

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Globalization;
using System.Runtime.Serialization;
using Essence.Util.Math;
using Essence.Util.Math.Double;
using REAL = System.Double;

namespace Essence.Geometry.Core.Double
{
    public struct Point4d : IPoint4D,
                            IEpsilonEquatable<Point4d>,
                            IEquatable<Point4d>,
                            IFormattable,
                            ISerializable
    {
        /// <summary>Name of the property X.</summary>
        public const string _X = "X";

        /// <summary>Name of the property Y.</summary>
        public const string _Y = "Y";

        /// <summary>Name of the property Z.</summary>
        public const string _Z = "Z";

        /// <summary>Name of the property W.</summary>
        public const string _W = "W";

        private const REAL ZERO_TOLERANCE = MathUtils.ZERO_TOLERANCE;
        private const REAL EPSILON = MathUtils.EPSILON;

        /// <summary>Tuple zero.</summary>
        public static Point4d Zero
        {
            get { return new Point4d(0, 0, 0, 0); }
        }

        /// <summary>Tuple one.</summary>
        public static Point4d One
        {
            get { return new Point4d(1, 1, 1, 1); }
        }

        /// <summary>Tuple with property X = 1 and others = 0.</summary>
        public static Point4d UX
        {
            get { return new Point4d(1, 0, 0, 0); }
        }

        /// <summary>Tuple with property Y = 1 and others = 0.</summary>
        public static Point4d UY
        {
            get { return new Point4d(0, 1, 0, 0); }
        }

        /// <summary>Tuple with property Z = 1 and others = 0.</summary>
        public static Point4d UZ
        {
            get { return new Point4d(0, 0, 1, 0); }
        }

        /// <summary>Tuple with property W = 1 and others = 0.</summary>
        public static Point4d UW
        {
            get { return new Point4d(0, 0, 0, 1); }
        }

        public Point4d(REAL x, REAL y, REAL z, REAL w)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
            this.W = w;
        }

        public Point4d(IPoint4D p)
        {
            this.X = p.X.ToDouble(null);
            this.Y = p.Y.ToDouble(null);
            this.Z = p.Z.ToDouble(null);
            this.W = p.W.ToDouble(null);
        }

        public Point4d(IPoint p)
        {
            IPoint4D p4 = p as IPoint4D;
            if (p4 != null)
            {
                this.X = p4.X.ToDouble(null);
                this.Y = p4.Y.ToDouble(null);
                this.Z = p4.Z.ToDouble(null);
                this.W = p4.W.ToDouble(null);
            }
            else
            {
                if (p.Dim < 4)
                {
                    throw new Exception("Punto no valido");
                }
                this.X = p[0].ToDouble(null);
                this.Y = p[1].ToDouble(null);
                this.Z = p[2].ToDouble(null);
                this.W = p[3].ToDouble(null);
            }
        }

        /// <summary>Property X.</summary>
        public readonly REAL X;

        /// <summary>Property Y.</summary>
        public readonly REAL Y;

        /// <summary>Property Z.</summary>
        public readonly REAL Z;

        /// <summary>Property W.</summary>
        public readonly REAL W;

        #region operators

        /// <summary>
        ///     Casting a REAL[].
        /// </summary>
        public static explicit operator REAL[](Point4d v)
        {
            return new REAL[] { v.X, v.Y, v.Z, v.W };
        }

        public static Point4d operator +(Point4d p, Vector4d v)
        {
            return p.Add(v);
        }

        public static Point4d operator -(Point4d p, Vector4d v)
        {
            return p.Sub(v);
        }

        public static Vector4d operator -(Point4d p1, Point4d p2)
        {
            return p1.Sub(p2);
        }

        public static implicit operator Vector4d(Point4d p)
        {
            return new Vector4d(p.X, p.Y, p.Z, p.W);
        }

        #endregion

        [Pure]
        public int Dim
        {
            get { return 4; }
        }

        [Pure]
        public REAL this[int i]
        {
            get
            {
                switch (i)
                {
                    case 0:
                        return this.X;
                    case 1:
                        return this.Y;
                    case 2:
                        return this.Z;
                    case 3:
                        return this.W;
                }
                throw new IndexOutOfRangeException();
            }
        }

        /// <summary>
        ///     Indica si es valido: ningun componente es NaN ni Infinito.
        /// </summary>
        [Pure]
        public bool IsValid
        {
            get { return MathUtils.IsValid(this.X) && MathUtils.IsValid(this.Y) && MathUtils.IsValid(this.Z) && MathUtils.IsValid(this.W); }
        }

        /// <summary>
        ///     Indica que algun componente es NaN.
        /// </summary>
        [Pure]
        public bool IsNaN
        {
            get { return REAL.IsNaN(this.X) || REAL.IsNaN(this.Y) || REAL.IsNaN(this.Z) || REAL.IsNaN(this.W); }
        }

        /// <summary>
        ///     Indica que algun componente es infinito.
        /// </summary>
        [Pure]
        public bool IsInfinity
        {
            get { return REAL.IsInfinity(this.X) || REAL.IsInfinity(this.Y) || REAL.IsInfinity(this.Z) || REAL.IsInfinity(this.W); }
        }

        /// <summary>
        ///     Indica si es cero.
        /// </summary>
        [Pure]
        public bool IsZero
        {
            get { return this.EpsilonEquals(0, 0, 0, 0); }
        }

        [Pure]
        public Point4d Add(Vector4d v)
        {
            return new Point4d(this.X + v.X, this.Y + v.Y, this.Z + v.Z, this.W + v.W);
        }

        [Pure]
        public Point4d Sub(Vector4d v)
        {
            return new Point4d(this.X - v.X, this.Y - v.Y, this.Z - v.Z, this.W - v.W);
        }

        [Pure]
        public Vector4d Sub(Point4d p2)
        {
            return new Vector4d(this.X - p2.X, this.Y - p2.Y, this.Z - p2.Z, this.W - p2.W);
        }

        [Pure]
        public REAL Distance2To(Point4d p2)
        {
            return (MathUtils.Cuad(p2.X - this.X) + MathUtils.Cuad(p2.Y - this.Y) + MathUtils.Cuad(p2.Z - this.Z) + MathUtils.Cuad(p2.W - this.W));
        }

        [Pure]
        public REAL DistanceTo(Point4d p2)
        {
            return (REAL)Math.Sqrt(this.Distance2To(p2));
        }

        [Pure]
        public Point4d Lerp(Point4d p2, REAL alpha)
        {
            return this.Lineal(p2, 1 - alpha, alpha);
        }

        [Pure]
        public REAL InvLerp(Point4d p2, Point4d p3)
        {
            Vector4d v12 = p2.Sub(this);
            return v12.Proy(p3.Sub(this));
        }

        [Pure]
        public Point4d Lineal(Point4d p2, REAL alpha, REAL beta)
        {
            return new Point4d(alpha * this.X + beta * p2.X, alpha * this.Y + beta * p2.Y, alpha * this.Z + beta * p2.Z, alpha * this.W + beta * p2.W);
        }

        #region parse

        /// <summary>
        ///     Parsea la cadena de texto segun los estilos indicados y devuelve una tupla.
        /// </summary>
        /// <param name="s">Cadena de texto a parsear.</param>
        /// <param name="provider">Proveedor de formato.</param>
        /// <param name="vstyle">Estilo de vectores.</param>
        /// <param name="style">Estilo de numeros.</param>
        /// <returns>Resultado.</returns>
        public static Point4d Parse(string s,
                                    IFormatProvider provider = null,
                                    VectorStyles vstyle = VectorStyles.All,
                                    NumberStyles style = NumberStyles.Float | NumberStyles.AllowThousands)
        {
            Point4d result;
            if (!TryParse(s, out result, provider, vstyle, style))
            {
                throw new Exception();
            }
            return result;
        }

        /// <summary>
        ///     Parsea la cadena de texto segun los estilos indicados y devuelve una tupla.
        /// </summary>
        /// <param name="s">Cadena de texto a parsear.</param>
        /// <param name="provider">Proveedor de formato.</param>
        /// <param name="vstyle">Estilo de vectores.</param>
        /// <param name="style">Estilo de numeros.</param>
        /// <param name="result">Resultado.</param>
        /// <returns>Indica si lo ha parseado correctamente.</returns>
        public static bool TryParse(string s,
                                    out Point4d result,
                                    IFormatProvider provider = null,
                                    VectorStyles vstyle = VectorStyles.All,
                                    NumberStyles style = NumberStyles.Float | NumberStyles.AllowThousands)
        {
            Contract.Requires(s != null);

            REAL[] ret;
            if (!VectorUtils.TryParse(s, 4, out ret, REAL.TryParse, provider, vstyle, style))
            {
                result = Zero;
                return false;
            }
            result = new Point4d(ret[0], ret[1], ret[2], ret[3]);
            return true;
        }

        #endregion

        #region protected

        #endregion

        #region private

        /// <summary>
        ///     Comprueba si son casi iguales.
        /// </summary>
        [Pure]
        private bool EpsilonEquals(REAL x, REAL y, REAL z, REAL w, REAL epsilon = ZERO_TOLERANCE)
        {
            return this.X.EpsilonEquals(x, epsilon) && this.Y.EpsilonEquals(y, epsilon) && this.Z.EpsilonEquals(z, epsilon) && this.W.EpsilonEquals(w, epsilon);
        }

        #endregion

        #region object

        [Pure]
        public override string ToString()
        {
            return this.ToString("F3", null);
        }

        [Pure]
        public override bool Equals(object obj)
        {
            if (!(obj is Point4d))
            {
                return false;
            }

            return this.Equals((Point4d)obj);
        }

        [Pure]
        public override int GetHashCode()
        {
            // http://www.jarvana.com/jarvana/view/org/apache/lucene/lucene-spatial/2.9.3/lucene-spatial-2.9.3-sources.jar!/org/apache/lucene/spatial/geometry/shape/Vector2D.java
            const int prime = 31;
            int hash = 1;
            unchecked
            {
                hash = prime * hash + this.X.GetHashCode();
                hash = prime * hash + this.Y.GetHashCode();
                hash = prime * hash + this.Z.GetHashCode();
                hash = prime * hash + this.W.GetHashCode();
            }
            return hash;
        }

        #endregion

        #region IEpsilonEquatable

        [Pure]
        public bool EpsilonEquals(Point4d other, REAL epsilon = EPSILON)
        {
            return this.EpsilonEquals(other.X, other.Y, other.Z, other.W, (REAL)epsilon);
        }

        #endregion

        #region IEquatable

        [Pure]
        public bool Equals(Point4d other)
        {
            return other.X == this.X && other.Y == this.Y && other.Z == this.Z && other.W == this.W;
        }

        #endregion

        #region IFormattable

        [Pure]
        public string ToString(string format, IFormatProvider provider)
        {
            if (provider != null)
            {
                ICustomFormatter formatter = provider.GetFormat(this.GetType()) as ICustomFormatter;
                if (formatter != null)
                {
                    return formatter.Format(format, this, provider);
                }
            }

            return VectorUtils.ToString(provider, format, (REAL[])this);
        }

        #endregion

        #region ISerializable

        public Point4d(SerializationInfo info, StreamingContext context)
        {
            this.X = info.GetDouble(_X);
            this.Y = info.GetDouble(_Y);
            this.Z = info.GetDouble(_Z);
            this.W = info.GetDouble(_W);
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue(_X, this.X);
            info.AddValue(_Y, this.Y);
            info.AddValue(_Z, this.Z);
            info.AddValue(_W, this.W);
        }

        #endregion

        #region IPoint

        //[Pure]
        //int Dim { get; }

        [Pure]
        IConvertible IPoint.this[int i]
        {
            get { return this[i]; }
        }

        [Pure]
        IPoint IPoint.Add(IVector v)
        {
            return this.Add(v.ToVector4d());
        }

        [Pure]
        IPoint IPoint.Sub(IVector v)
        {
            return this.Sub(v.ToVector4d());
        }

        [Pure]
        IVector IPoint.Sub(IPoint p2)
        {
            return this.Sub(p2.ToPoint4d());
        }

        [Pure]
        IPoint IPoint.Lerp(IPoint p2, REAL alpha)
        {
            return this.Lerp(p2.ToPoint4d(), alpha);
        }

        [Pure]
        REAL IPoint.InvLerp(IPoint p2, IPoint pLerp)
        {
            return this.InvLerp(p2.ToPoint4d(), pLerp.ToPoint4d());
        }

        [Pure]
        IPoint IPoint.Lineal(IPoint p2, REAL alpha, REAL beta)
        {
            return this.Lineal(p2.ToPoint4d(), alpha, beta);
        }

        #endregion

        #region IPoint4D

        [Pure]
        IConvertible IPoint4D.X
        {
            get { return this.X; }
        }

        [Pure]
        IConvertible IPoint4D.Y
        {
            get { return this.Y; }
        }

        [Pure]
        IConvertible IPoint4D.Z
        {
            get { return this.Z; }
        }

        [Pure]
        IConvertible IPoint4D.W
        {
            get { return this.W; }
        }

        #endregion

        #region IEpsilonEquatable<IPoint>

        [Pure]
        bool IEpsilonEquatable<IPoint>.EpsilonEquals(IPoint other, REAL epsilon)
        {
            return this.EpsilonEquals(other.ToPoint4d(), epsilon);
        }

        #endregion

        #region inner classes

        /// <summary>
        ///     Compara los puntos en funcion a la coordenada indicada (X o Y).
        /// </summary>
        public sealed class CoordComparer : IComparer<Point4d>, IComparer
        {
            public CoordComparer(int coord)
            {
                this.coord = coord;
            }

            private readonly int coord;

            public int Compare(Point4d v1, Point4d v2)
            {
                switch (this.coord)
                {
                    case 0:
                        return v1.X.CompareTo(v2.X);
                    case 1:
                        return v1.Y.CompareTo(v2.Y);
                    case 2:
                        return v1.Z.CompareTo(v2.Z);
                    case 3:
                        return v1.W.CompareTo(v2.W);
                }
                throw new IndexOutOfRangeException();
            }

            int IComparer.Compare(object o1, object o2)
            {
                Contract.Requires(o1 is Point4d && o2 is Point4d);
                return this.Compare((Point4d)o1, (Point4d)o2);
            }
        }

        /// <summary>
        ///     Comparador lexicografico, primero compara por X y despues por Y.
        /// </summary>
        public sealed class LexComparer : IComparer<Point4d>, IComparer
        {
            public int Compare(Point4d v1, Point4d v2)
            {
                int i;
                i = v1.X.CompareTo(v2.X);
                if (i != 0)
                {
                    return i;
                }
                i = v1.Y.CompareTo(v2.Y);
                if (i != 0)
                {
                    return i;
                }
                i = v1.Z.CompareTo(v2.Z);
                if (i != 0)
                {
                    return i;
                }
                i = v1.W.CompareTo(v2.W);
                return i;
            }

            int IComparer.Compare(object o1, object o2)
            {
                Contract.Requires(o1 is Point4d && o2 is Point4d);
                return this.Compare((Point4d)o1, (Point4d)o2);
            }
        }

        #endregion
    }
}