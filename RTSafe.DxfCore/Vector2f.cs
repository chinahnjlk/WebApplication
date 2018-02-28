using System;

namespace RTSafe.DxfCore
{
    /// <summary>
    /// Represent a two component vector of single precision.
    /// </summary>
    public struct Vector2f
    {
        #region private fields

        private double x;
        private double y;

        #endregion

        #region constructors

        /// <summary>
        /// Initializes a new instance of Vector2f.
        /// </summary>
        /// <param name="x">X component.</param>
        /// <param name="y">Y component.</param>
        public Vector2f(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        /// <summary>
        /// Initializes a new instance of Vector2f.
        /// </summary>
        /// <param name="array">Array of two elements that represents the vector.</param>
        public Vector2f(double[] array)
        {
            if (array.Length != 2)
                throw new ArgumentOutOfRangeException("The dimension of the array must be two");
            this.x = array[0];
            this.y = array[1];
        }

        #endregion

        #region constants

        /// <summary>
        /// Zero vector.
        /// </summary>
        public static Vector2f Zero
        {
            get { return new Vector2f(0, 0); }
        }

        /// <summary>
        /// Unit X vector.
        /// </summary>
        public static Vector2f UnitX
        {
            get { return new Vector2f(1, 0); }
        }

        /// <summary>
        /// Unit Y vector.
        /// </summary>
        public static Vector2f UnitY
        {
            get { return new Vector2f(0, 1); }
        }

        #endregion

        #region public properties

        /// <summary>
        /// Gets or sets the X component.
        /// </summary>
        public double X
        {
            get { return this.x; }
            set { this.x = value; }
        }

        /// <summary>
        /// Gets or sets the Y component.
        /// </summary>
        public double Y
        {
            get { return this.y; }
            set { this.y = value; }
        }

        /// <summary>
        /// Gets or sets a vector element defined by its index.
        /// </summary>
        /// <param name="index">Index of the element.</param>
        public double this[int index]
        {
            get
            {
                switch (index)
                {
                    case 0:
                        return this.x;
                    case 1:

                        return this.y;
                    default:

                        throw (new ArgumentOutOfRangeException("index"));
                }
            }
            set
            {
                switch (index)
                {
                    case 0:
                        this.x = value;
                        break;
                    case 1:

                        this.y = value;
                        break;
                    default:

                        throw (new ArgumentOutOfRangeException("index"));
                }
            }
        }

        #endregion

        #region static methods

        /// <summary>
        /// Obtains the dot product of two vectors.
        /// </summary>
        /// <param name="u">Vector2f.</param>
        /// <param name="v">Vector2f.</param>
        /// <returns>The dot product.</returns>
        public static double DotProduct(Vector2f u, Vector2f v)
        {
            return (u.X*v.X) + (u.Y*v.Y);
        }

        /// <summary>
        /// Obtains the cross product of two vectors.
        /// </summary>
        /// <param name="u">Vector2f.</param>
        /// <param name="v">Vector2f.</param>
        /// <returns>Vector2f.</returns>
        public static double CrossProduct(Vector2f u, Vector2f v)
        {
            return (u.X*v.Y) - (u.Y*v.X);
        }

        /// <summary>
        /// Obtains the counter clockwise perpendicular vector .
        /// </summary>
        /// <param name="u">Vector2f.</param>
        /// <returns>Vector2f.</returns>
        public static Vector2f Perpendicular(Vector2f u)
        {
            return new Vector2f(-u.Y, u.X);
        }

        /// <summary>
        /// Obtains the distance between two points.
        /// </summary>
        /// <param name="u">Vector2f.</param>
        /// <param name="v">Vector2f.</param>
        /// <returns>Distancie.</returns>
        public static double Distance(Vector2f u, Vector2f v)
        {
            return (double) (Math.Sqrt((u.X - v.X)*(u.X - v.X) + (u.Y - v.Y)*(u.Y - v.Y)));
        }

        /// <summary>
        /// Obtains the square distance between two points.
        /// </summary>
        /// <param name="u">Vector2f.</param>
        /// <param name="v">Vector2f.</param>
        /// <returns>Square distance.</returns>
        public static double SquareDistance(Vector2f u, Vector2f v)
        {
            return (u.X - v.X)*(u.X - v.X) + (u.Y - v.Y)*(u.Y - v.Y);
        }

        /// <summary>
        /// Obtains the angle between two vectors.
        /// </summary>
        /// <param name="u">Vector2f.</param>
        /// <param name="v">Vector2f.</param>
        /// <returns>Angle in radians.</returns>
        public static double AngleBetween(Vector2f u, Vector2f v)
        {
            double cos = DotProduct(u, v)/(u.Modulus()*v.Modulus());
            if (MathHelper.IsOne(cos))
            {
                return 0;
            }
            if (MathHelper.IsOne(-cos))
            {
                return (double) Math.PI;
            }
            return (double) Math.Acos(cos);

            //if (AreParallel(u, v))
            //{
            //    if (Math.Sign(u.X) == Math.Sign(v.X) && Math.Sign(u.Y) == Math.Sign(v.Y))
            //    {
            //        return 0;
            //    }
            //    return (double)Math.PI;
            //}
            //Vector3f normal = Vector3f.CrossProduct(new Vector3f(u.X, u.Y, 0), new Vector3f(v.X, v.Y, 0));

            //if (normal.Z < 0)
            //{
            //    return (double)(2 * Math.PI - Math.Acos(DotProduct(u, v) / (u.Modulus() * v.Modulus())));
            //}
            //return (double)(Math.Acos(DotProduct(u, v) / (u.Modulus() * v.Modulus())));
        }


        /// <summary>
        /// Obtains the midpoint.
        /// </summary>
        /// <param name="u">Vector2f.</param>
        /// <param name="v">Vector2f.</param>
        /// <returns>Vector2f.</returns>
        public static Vector2f MidPoint(Vector2f u, Vector2f v)
        {
            return new Vector2f((v.X + u.X)*0.5F, (v.Y + u.Y)*0.5F);
        }

        /// <summary>
        /// Checks if two vectors are perpendicular.
        /// </summary>
        /// <param name="u">Vector2f.</param>
        /// <param name="v">Vector2f.</param>
        /// <param name="threshold">Tolerance used.</param>
        /// <returns>True if are penpendicular or false in anyother case.</returns>
        public static bool ArePerpendicular(Vector2f u, Vector2f v, double threshold)
        {
            return MathHelper.IsZero(DotProduct(u, v), threshold);
        }

        /// <summary>
        /// Checks if two vectors are parallel.
        /// </summary>
        /// <param name="u">Vector2f.</param>
        /// <param name="v">Vector2f.</param>
        /// <param name="threshold">Tolerance used.</param>
        /// <returns>True if are parallel or false in anyother case.</returns>
        public static bool AreParallel(Vector2f u, Vector2f v, double threshold)
        {
            double a = u.X*v.Y - u.Y*v.X;
            return MathHelper.IsZero(a, threshold);
        }

        /// <summary>
        /// Rounds the components of a vector.
        /// </summary>
        /// <param name="u">Vector2f.</param>
        /// <param name="numDigits">Number of significative defcimal digits.</param>
        /// <returns>Vector2f.</returns>
        public static Vector2f Round(Vector2f u, int numDigits)
        {
            return new Vector2f((double) Math.Round(u.X, numDigits), (double) Math.Round(u.Y, numDigits));
        }

        #endregion

        #region overloaded operators

        public static bool operator ==(Vector2f u, Vector2f v)
        {
            return ((v.X == u.X) && (v.Y == u.Y));
        }

        public static bool operator !=(Vector2f u, Vector2f v)
        {
            return ((v.X != u.X) || (v.Y != u.Y));
        }

        public static Vector2f operator +(Vector2f u, Vector2f v)
        {
            return new Vector2f(u.X + v.X, u.Y + v.Y);
        }

        public static Vector2f operator -(Vector2f u, Vector2f v)
        {
            return new Vector2f(u.X - v.X, u.Y - v.Y);
        }

        public static Vector2f operator -(Vector2f u)
        {
            return new Vector2f(-u.X, -u.Y);
        }

        public static Vector2f operator *(Vector2f u, double a)
        {
            return new Vector2f(u.X*a, u.Y*a);
        }

        public static Vector2f operator *(double a, Vector2f u)
        {
            return new Vector2f(u.X*a, u.Y*a);
        }

        public static Vector2f operator /(Vector2f u, double a)
        {
            double invEscalar = 1/a;
            return new Vector2f(u.X*invEscalar, u.Y*invEscalar);
        }

        public static Vector2f operator /(double a, Vector2f u)
        {
            double invEscalar = 1/a;
            return new Vector2f(u.X*invEscalar, u.Y*invEscalar);
        }

        #endregion

        #region public methods

        /// <summary>
        /// Normalizes the vector.
        /// </summary>
        public void Normalize()
        {
            double mod = this.Modulus();
            if (mod == 0)
                throw new ArithmeticException("Cannot normalize a zero vector");
            double modInv = 1 / mod;
            this.x *= modInv;
            this.y *= modInv;
        }

        /// <summary>
        /// Obtains the modulus of the vector.
        /// </summary>
        /// <returns>Vector modulus.</returns>
        public double Modulus()
        {
            return (double) (Math.Sqrt(DotProduct(this, this)));
        }

        /// <summary>
        /// Returns an array that represents the vector.
        /// </summary>
        /// <returns>Array.</returns>
        public double[] ToArray()
        {
            var u = new[] {this.x, this.y};
            return u;
        }
        
        #endregion

        #region comparision methods

        /// </summary>
        /// Check if the components of two vectors are approximate equals.
        /// <param name="obj">Vector2f.</param>
        /// <param name="threshold">Maximun tolerance.</param>
        /// <returns>True if the three components are almost equal or false in anyother case.</returns>
        public bool Equals(Vector2f obj, double threshold)
        {
            if (Math.Abs(obj.X - this.x) > threshold)
            {
                return false;
            }
            if (Math.Abs(obj.Y - this.y) > threshold)
            {
                return false;
            }

            return true;
        }

        public bool Equals(Vector2f obj)
        {
            return obj.x == this.x && obj.y == this.y;
        }

        public override bool Equals(object obj)
        {
            if (obj is Vector2f)
                return this.Equals((Vector2f) obj);
            return false;
            
        }

        public override int GetHashCode()
        {
            return unchecked(this.x.GetHashCode() ^ this.y.GetHashCode());
        }

        #endregion

        #region overrides

        /// <summary>
        /// Obtains a string that represents the vector.
        /// </summary>
        /// <returns>A string text.</returns>
        public override string ToString()
        {
            return string.Format("{0};{1}", this.x, this.y);
        }

        /// <summary>
        /// Obtains a string that represents the vector.
        /// </summary>
        /// <param name="provider">An IFormatProvider interface implementation that supplies culture-specific formatting information. </param>
        /// <returns>A string text.</returns>
        public string ToString(IFormatProvider provider)
        {
            return string.Format("{0};{1}", this.x.ToString(provider), this.y.ToString(provider));
        }

        #endregion
    }
}