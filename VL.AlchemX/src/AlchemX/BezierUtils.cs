namespace AlchemX
{
	/**
	 * @author christianriekoff
	 * 
	 */
	public class CubicSolver
	{
		// cubic equation solver example using Cardano's method

		private static double THIRD = 0.333333333333333;
		private static double ROOTTHREE = 1.73205080756888;

		// this function returns the cube root if x were a negative number as well

		/**
		 * Returns the cube root of the given value, also for negative x values
		 */
		public static double CubeRoot(double theX)
		{
			if (theX < 0)
				return -Math.Pow(-theX, THIRD);
			else
				return Math.Pow(theX, THIRD);
		}

		public static double[] SolveCubic(double a, double b, double c, double d)
		{
			double[] myResult = new double[3];

			// find the discriminant
			double f = (3 * c / a - Math.Pow(b, 2) / Math.Pow(a, 2)) / 3;
			double g = (2 * Math.Pow(b, 3) / Math.Pow(a, 3) - 9 * b * c / Math.Pow(a, 2) + 27 * d / a) / 27;
			double h = Math.Pow(g, 2) / 4 + Math.Pow(f, 3) / 27;

			// evaluate discriminant
			if (f == 0 && g == 0 && h == 0)
			{
				// 3 equal roots
				// when f, g, and h all equal 0 the roots can be found by the following line
				double x = -CubeRoot(d / a);
				myResult[0] = x;
				myResult[1] = x;
				myResult[2] = x;
				return myResult;
			}

			if (h <= 0)
			{
				// 3 real roots
				// complicated math making use of the method
				double i = Math.Pow(Math.Pow(g, 2) / 4 - h, 0.5);
				double j = CubeRoot(i);
				double k = Math.Acos(-(g / (2 * i)));
				double m = Math.Cos(k / 3);
				double n = ROOTTHREE * Math.Sin(k / 3);
				double p = -(b / (3 * a));

				myResult[0] = 2 * j * m + p;
				myResult[1] = -j * (m + n) + p;
				myResult[2] = -j * (m - n) + p;
				return myResult;
			}

			if (h > 0)
			{
				// 1 real root and 2 complex roots
				double r, s, t, u, p;
				// complicated maths making use of the method
				r = -(g / 2) + Math.Pow(h, 0.5);
				s = CubeRoot(r);
				t = -(g / 2) - Math.Pow(h, 0.5);
				u = CubeRoot(t);
				p = -(b / (3 * a));
				// print solutions
				//			("x = ");
				//			(" " + (s + u + p));
				//			(" " + (-(s + u) / 2 + p) + " +" + (s - u) * ROOTTHREE / 2 + "i");
				//			(" " + (-(s + u) / 2 + p) + " " + -(s - u) * ROOTTHREE / 2 + "i");

				myResult[0] = s + u + p;
				myResult[1] = -(s + u) / 2 + p;
				myResult[2] = -(s + u) / 2 + p;
			}

			return myResult;
		}

		public static double BezierBlend(double theTime0, double theTime1, double theTime2, double theTime3, double theTime)
		{
			double a = -theTime0 + 3 * theTime1 - 3 * theTime2 + theTime3;
			double b = 3 * theTime0 - 6 * theTime1 + 3 * theTime2;
			double c = -3 * theTime0 + 3 * theTime1;
			double d = theTime0 - theTime;

			double[] myResult = SolveCubic(a, b, c, d);
			int i = 0;
			while (i < myResult.Length - 1 && (myResult[i] < -.0000001 || myResult[i] > 1.0000001))
			{
				i++;
			}
			return myResult[i];
		}

		public static double BezierValue(double theValue0, double theValue1, double theValue2, double theValue3, double theBlend)
		{
			double a = -theValue0 + 3 * theValue1 - 3 * theValue2 + theValue3;
			double b = 3 * theValue0 - 6 * theValue1 + 3 * theValue2;
			double c = -3 * theValue0 + 3 * theValue1;
			double d = theValue0;

			return
			a * theBlend * theBlend * theBlend +
			b * theBlend * theBlend +
			c * theBlend +
			d;
		}


		/*
		public double sampleBezierSegment(ControlPoint p0, ControlPoint p1, ControlPoint p2, ControlPoint p3, double theTime)
		{
			double myBezierBlend = bezierBlend(p0.time(), p1.time(), p2.time(), p3.time(), theTime);
			return bezierValue(p0.value(), p1.value(), p2.value(), p3.value(), myBezierBlend);
		}*/

	}
}