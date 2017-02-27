﻿using SysMath = System.Math;

namespace Essence.Math.Double.Curves
{
    public class Line2 : AbsCurve2
    {
        public Line2(Vec2d p0, double t0, Vec2d p1, double t1)
        {
            this.p0 = p0;
            this.p1 = p1;

            this.v01 = this.p1.Sub(this.p0);
            this.len = this.v01.Length;
            this.dirN = this.v01.Div(this.len);

            this.SetTInterval(t0, t1);
        }

        public double Project01(Vec2d p)
        {
            Vec2d diff = p.Sub(this.p0);
            //return this.dir.Dot(diff) / this.len;
            return this.dirN.Dot(diff);
        }

        #region ICurve2

        public override double TMin
        {
            get { return this.tmin; }
        }

        public override double TMax
        {
            get { return this.tmax; }
        }

        public override void SetTInterval(double tmin, double tmax)
        {
            this.tmin = tmin;
            this.tmax = tmax;
            this.ttransform = new Transform1(this.tmin, this.tmax, 0, 1);
        }

        public override Vec2d GetPosition(double t)
        {
            /*
             *  s:      t * m + n;
             *  x:      p0_x +(p1_x - p0_x)*s;
             *  y:      p0_y +(p1_y - p0_y)*s;
             *  z:      1;
             *  result: [ x, y, z ];
             *
             *  result: [(p1_x-p0_x)*(m*t+n)+p0_x,(p1_y-p0_y)*(m*t+n)+p0_y,1]
             */
            double t01 = this.GetT01(t);
            return this.Evaluate01(t01);
        }

        public override Vec2d GetFirstDerivative(double t)
        {
            /*
             *  s:      t * m + n;
             *  x:      p0_x +(p1_x - p0_x)*s;
             *  y:      p0_y +(p1_y - p0_y)*s;
             *  z:      1;
             *  result: diff([ x, y, z ], t, 1);
             *
             *  result: [m*(p1_x-p0_x),m*(p1_y-p0_y),0]
             */
            double m = this.ttransform.A;

            Vec2d v = this.v01;
            v = v.Mul(m);
            return v;
        }

        public override Vec2d GetSecondDerivative(double t)
        {
            /*
             *  s:      t * m + n;
             *  x:      p0_x +(p1_x - p0_x)*s;
             *  y:      p0_y +(p1_y - p0_y)*s;
             *  z:      1;
             *  result: diff([ x, y, z ], t, 2);
             *
             *  result: [0,0,0]
             */
            return Vec2d.Zero;
        }

        public override Vec2d GetThirdDerivative(double t)
        {
            /*
             *  s:      t * m + n;
             *  x:      p0_x +(p1_x - p0_x)*s;
             *  y:      p0_y +(p1_y - p0_y)*s;
             *  z:      1;
             *  result: diff([ x, y, z ], t, 3);
             *
             *  result: [0,0,0]
             */
            return Vec2d.Zero;
        }

        public override double TotalLength
        {
            get { return this.len; }
        }

        public override double GetLength(double t0, double t1)
        {
            double t01_0 = this.GetT01(t0);
            double t01_1 = this.GetT01(t1);
            return SysMath.Abs(t01_1 - t01_0) * this.TotalLength;
        }

        #endregion

        #region private

        private double GetT01(double t)
        {
            t = t.Clamp(this.TMin, this.TMax);
            double t01 = this.ttransform.Get(t);
            return t01;
        }

        private Vec2d Evaluate01(double t01)
        {
            //return this.p0.Add(this.dirN.Mul(t01 * this.len));
            return this.p0.Add(this.v01.Mul(t01));
        }

        private readonly Vec2d p0;
        private readonly Vec2d p1;

        private double tmin;
        private double tmax;

        private readonly Vec2d v01; // p1 - p0
        private readonly double len;
        private readonly Vec2d dirN;

        /// <summary>Transformacion que se aplica sobre el parametro.</summary>
        private Transform1 ttransform;

        #endregion
    }
}