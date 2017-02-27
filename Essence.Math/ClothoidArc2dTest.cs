﻿using System.Diagnostics.Contracts;
using System.IO;
using Essence.Math.Double;
using Essence.Math.Double.Curves;
using SysMath = System.Math;

namespace Essence.Math
{
    public class ClothoidArc2dTest
    {
        private const double ERROR = 1e-5;

        public void Test1()
        {
            for (double a = 0.5; a < 10; a += 0.5)
            {
                foreach (bool invertY in new[] { false, true })
                {
                    int ysign = invertY ? -1 : 1;

                    double[] angles =
                    {
                        ysign * 0,
                        ysign * SysMath.PI / 4,
                        ysign * SysMath.PI / 2,
                        ysign * 3 * SysMath.PI / 4
                    };
                    foreach (double angle in angles)
                    {
                        Vec2d v = vecMath.NewRotate(angle);

                        double l = MathUtils.FindTangent(invertY, a, v);
                        double l_v2 = MathUtils.FindTangent(invertY, a, angle);

                        // Se comprueba que las busquedas de tangente sean equivalentes.
                        Contract.Assert(l.EpsilonEquals(l_v2));

                        // Se comprueba que la solucion corresponde con el vector tangente.
                        Vec2d d_pos = MathUtils.DClotho(l, invertY, a);
                        Contract.Assert(d_pos.Cross(v).EpsilonEquals(0));

                        Vec2d d_neg = MathUtils.DClotho(-l, invertY, a);
                        Contract.Assert(d_neg.Cross(v).EpsilonEquals(0));
                    }
                }
            }
        }

        public void Test2()
        {
            double a = 10;
            bool invertY = true;
            double maxL = MathUtils.GetMaxL(a);

            int ysign = invertY ? -1 : 1;
            double[] angles =
            {
                ysign * 0,
                ysign * SysMath.PI / 4,
                ysign * SysMath.PI / 2,
                ysign * 3 * SysMath.PI / 4
            };

            using (MaterialFormat mf = new MaterialFormat(@"C:\Temp\Default.mtl"))
            {
                mf.DefaultColors();
            }

            using (WavefrontFormat wf = new WavefrontFormat(@"C:\Temp\ClothoidArc2dTest_Test2.obj"))
            {
                wf.LoadMaterialLib("Default.mtl");
                wf.DrawClotho(invertY, a, "Red");

                foreach (double angle in angles)
                {
                    Vec2d v = vecMath.NewRotate(angle);
                    double l = MathUtils.FindTangent(invertY, a, v);
                    wf.DrawLine("Green", MathUtils.Clotho(l, invertY, a), v);
                    wf.DrawLine("Magenta", MathUtils.Clotho(-l, invertY, a), v);
                }

                //wf.DrawLine("Yellow", new Vec2d(0, 0), new Vec2d(1, 0), 100);
                //wf.DrawLine("Yellow", new Vec2d(0, 0), new Vec2d(0, 1), 100);
            }
        }

        public void Test7()
        {
            bool toWavefront = false;

            // Test de una clotoide sin invertir en el cuadrante positivo.
            TestClotho(5, false, false, SysMath.PI / 10, 4 * SysMath.PI / 10, new Vec2d(5, 5), new Vec2d(0, 1), @"C:\Temp\ClothoidArc2dTest_Test7_1.obj", toWavefront);

            // Test de una clotoide invertida en el cuadrante positivo.
            TestClotho(5, true, false, -SysMath.PI / 10, -4 * SysMath.PI / 10, new Vec2d(5, 5), new Vec2d(0, 1), @"C:\Temp\ClothoidArc2dTest_Test7_2.obj", toWavefront);

            // Test de una clotoide sin invertir en el cuadrante negativo.
            TestClotho(5, false, true, 4 * SysMath.PI / 10, SysMath.PI / 10, new Vec2d(5, 5), new Vec2d(0, 1), @"C:\Temp\ClothoidArc2dTest_Test7_3.obj", toWavefront);

            // Test de una clotoide invertida en el cuadrante negativo.
            TestClotho(5, true, true, -4 * SysMath.PI / 10, -SysMath.PI / 10, new Vec2d(5, 5), new Vec2d(0, 1), @"C:\Temp\ClothoidArc2dTest_Test7_4.obj", toWavefront);

            // Se añade el mango a las pruebas.

            // Test de una clotoide sin invertir en el cuadrante positivo.
            TestClotho(5, false, false, 0, 4 * SysMath.PI / 10, new Vec2d(5, 5), new Vec2d(0, 1), @"C:\Temp\ClothoidArc2dTest_Test7_5.obj", toWavefront);

            // Test de una clotoide invertida en el cuadrante positivo.
            TestClotho(5, true, false, 0, -4 * SysMath.PI / 10, new Vec2d(5, 5), new Vec2d(0, 1), @"C:\Temp\ClothoidArc2dTest_Test7_6.obj", toWavefront);

            // Test de una clotoide sin invertir en el cuadrante negativo.
            TestClotho(5, false, true, 4 * SysMath.PI / 10, 0, new Vec2d(5, 5), new Vec2d(0, 1), @"C:\Temp\ClothoidArc2dTest_Test7_7.obj", toWavefront);

            // Test de una clotoide invertida en el cuadrante negativo.
            TestClotho(5, true, true, -4 * SysMath.PI / 10, 0, new Vec2d(5, 5), new Vec2d(0, 1), @"C:\Temp\ClothoidArc2dTest_Test7_8.obj", toWavefront);
        }

        /// <summary>
        /// Prueba el constructor ClothoidArc2d(double,Vec2d,Vec2d,double,double).
        /// </summary>
        private static void TestClotho(double a, bool invertY, bool negX, double tg0, double tg1, Vec2d p0, Vec2d dir,
                                       string fileName = null, bool toWavefront = false)
        {
            //double a = 5;
            //bool invertY = true;

            //double tg0 = -4 * SysMath.PI / 10;
            //double tg1 = -SysMath.PI / 10;

            // Si se indica negX, se invierten las tangentes.
            int sign = 1;
            if (negX)
            {
                sign = -1;
            }

            double l0 = sign * MathUtils.FindTangent(invertY, a, tg0);
            double l1 = sign * MathUtils.FindTangent(invertY, a, tg1);

            double r0 = MathUtils.ClothoRadious(l0, invertY, a);
            double r1 = MathUtils.ClothoRadious(l1, invertY, a);
            Vec2d pp0 = MathUtils.Clotho(l0, invertY, a);
            Vec2d pp1 = MathUtils.Clotho(l1, invertY, a);

            //Vec2d p0 = new Vec2d(5, 5);
            Vec2d p1 = p0.Add(dir.Mul(pp1.Sub(pp0).Length));

            ClothoidArc2 arc = new ClothoidArc2(l0, p0, p1, r0, r1);

            Contract.Assert(arc.Point0.EpsilonEquals(p0, ERROR));
            Contract.Assert(arc.Point1.EpsilonEquals(p1, ERROR));
            Contract.Assert(arc.GetRadius(arc.TMin).EpsilonEquals(r0, ERROR));
            Contract.Assert(arc.GetRadius(arc.TMax).EpsilonEquals(r1, ERROR));
            Contract.Assert(arc.InvertY == invertY);
            Contract.Assert(arc.A.EpsilonEquals(a, ERROR));

            // Salida por fichero de la prueba.
            if ((fileName != null) && toWavefront)
            {
                double figSize = 0.5;

                string mtl = Path.ChangeExtension(fileName, "mtl");

                using (MaterialFormat mf = new MaterialFormat(mtl))
                {
                    mf.DefaultColors();
                }

                using (WavefrontFormat wf = new WavefrontFormat(fileName))
                {
                    wf.LoadMaterialLib(Path.GetFileName(mtl));

                    wf.DrawLine("Yellow", Vec2d.Zero, new Vec2d(1, 0), 50);
                    wf.DrawLine("Yellow", Vec2d.Zero, new Vec2d(0, 1), 50);

                    wf.DrawFigure("Blue", WaveFigure.X, MathUtils.Clotho(l0, invertY, a), figSize);
                    wf.DrawFigure("Olive", WaveFigure.X, MathUtils.Clotho(l1, invertY, a), figSize);

                    wf.DrawClotho(invertY, a, "Red");

                    wf.DrawClotho("Magenta", arc);

                    wf.DrawFigure("Blue", WaveFigure.X, p0, figSize);
                    wf.DrawFigure("Olive", WaveFigure.X, p1, figSize);
                }
            }
        }

        private readonly VecMath<double, DoubleMath, Vec2d, Vec2dFactory> vecMath = VecMath<double, DoubleMath, Vec2d, Vec2dFactory>.Instance;
    }
}

#if false
            /*using (WavefrontFormat wf = new WavefrontFormat(@"C:\Temp\xxxx.obj"))
            {
                wf.LoadMaterialLib("Default.mtl");
                wf.DrawLine("Yellow", Vec2d.Zero, new Vec2d(1, 0), 50);
                wf.DrawLine("Yellow", Vec2d.Zero, new Vec2d(0, 1), 50);

                for (int i = 1; i <= 100; i++)
                {
                    wf.DrawClotho(false, i, "Red");
                    //wf.DrawClothoRadius(false, i, "Red");
                }
                Vec2d[] array1 = MathUtils.For(1, 100, 98)
                                         .Select(i => MathUtils.Clotho(MathUtils.ClothoRadious(100, false, i), false, i))
                                         .ToArray();
                wf.DrawPolyline("Magenta", array1, false);

                Vec2d[] array = MathUtils.For(1, 100, 98)
                                         .Select(i => MathUtils.Clotho(MathUtils.ClothoRadious(10, false, i), false, i))
                                         .ToArray();
                wf.DrawPolyline("Orange", array, false);

                //wf.DrawClotho(false, i, "Red");
                / *wf.DrawClothoRadius(false, 1, "Red");
                wf.DrawClothoRadius(false, 5, "yellow");
                wf.DrawClothoRadius(false, 10, "yellow");
                wf.DrawClothoRadius(false, 15, "yellow");
                wf.DrawClothoRadius(false, 20, "yellow");
                wf.DrawClothoRadius(false, 25, "yellow");
                wf.DrawClothoRadius(false, 30, "yellow");* /

                //wf.DrawPolyline("Magenta", MathUtils.For(0.1, 10, 2000).Select(i => MathUtils.Clotho(100, false, i)), false);
                //wf.DrawPolyline("Red", MathUtils.For(0.1, 10, 2000).Select(i => MathUtils.Clotho(10, false, i)), false);

                / *Vec2d[] array = MathUtils.For(0.1, 100, 200)
                                         .Select(i => new Vec2d(i, this.vecMath.Length(MathUtils.Clotho(MathUtils.ClothoL(100, false, i), false, 1), MathUtils.Clotho(MathUtils.ClothoL(10, false, i), false, 1))))
                                         .ToArray();
                wf.DrawPolyline("Magenta", array, false);* /
            }*/

            /*{
                double ll0 = MathUtils.ClothoL(100, false, 1);
                double ll1 = MathUtils.ClothoL(10, false, 1);

                double dd0 = this.vecMath.Length(MathUtils.Clotho(ll0, false, 1), MathUtils.Clotho(ll1, false, 1));
                Debug.WriteLine(dd0);

                double ll2 = MathUtils.ClothoL(100, false, 10);
                double ll3 = MathUtils.ClothoL(10, false, 10);

                double dd1 = this.vecMath.Length(MathUtils.Clotho(ll2, false, 10), MathUtils.Clotho(ll3, false, 10));
                Debug.WriteLine(dd1);

                double ll4 = MathUtils.ClothoL(100, false, 100);
                double ll5 = MathUtils.ClothoL(10, false, 100);

                double dd2 = this.vecMath.Length(MathUtils.Clotho(ll4, false, 100), MathUtils.Clotho(ll5, false, 100));
                Debug.WriteLine(dd2);

                double ll6 = MathUtils.ClothoL(100, false, 1000);
                double ll7 = MathUtils.ClothoL(10, false, 1000);

                double dd3 = this.vecMath.Length(MathUtils.Clotho(ll6, false, 1000), MathUtils.Clotho(ll7, false, 1000));
                Debug.WriteLine(dd3);
            }*/
#endif
