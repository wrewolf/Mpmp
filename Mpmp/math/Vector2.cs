using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mpmp.math
{
    class Vector2
    {
        public Vector2(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public Vector2() : this(0, 0) { }
        public Vector2(Vector2 v) : this(v.x, v.y) { }

        public double x { get; set; }

        public double y { get; set; }

        public double getX()
        {
            return x;
        }

        public double getY()
        {
            return y;
        }

        public double getFloorX()
        {
            return (int)x;
        }

        public double getFloorY()
        {
            return (int)y;
        }

        public Vector2 subtract(Vector2 v)
        {
            return this.add(-v.x, -v.y);
        }

        public Vector2 subtract(double x, double y)
        {
            return this.add(-x, -y);
        }

        public Vector2 add(double x, double y)
        {
            this.x += x;
            this.y += y;
            return this;
        }

        public Vector2 add(Vector2 v)
        {
            return this.add(v.x, v.y);
        }

        public Vector2 ceil()
        {
            return new Vector2((int)(this.x + 1), (int)(this.y + 1));
        }

        public Vector2 floor()
        {
            return new Vector2((int)this.x, (int)this.y);
        }

        public Vector2 round()
        {
            return new Vector2(Math.Round(this.x), Math.Round(this.y));
        }

        public Vector2 abs()
        {
            return new Vector2(Math.Abs(this.x), Math.Abs(this.y));
        }

        public Vector2 multiply(double number)
        {
            return new Vector2(this.x * number, this.y * number);
        }

        public Vector2 divide(double number)
        {
            return new Vector2(this.x / number, this.y / number);
        }

        public double distance(Vector2 v)
        {
            return this.distance(v.x, v.y);
        }

        public double distance(double x, double y)
        {
            return Math.Sqrt(this.distanceSquared(x, y));
        }

        public double distanceSquared(Vector2 v)
        {
            return this.distanceSquared(v.x, v.y);
        }
        public double distanceSquared(double x, double y)
        {
            return Math.Pow(this.x - x, 2) + Math.Pow(this.y - y, 2);
        }

        public double length()
        {
            return Math.Sqrt(this.lengthSquared());
        }

        public double lengthSquared()
        {
            return this.x * this.x + this.y * this.y;
        }

        public Vector2 normalize()
        {
            double len = this.length();
            if (len != 0)
            {
                return this.divide(len);
            }
            return new Vector2(0, 0);
        }

        public double dot(Vector2 v)
        {
            return this.x * v.x + this.y * v.y;
        }

        public override string ToString()
        {
            return "Vector2(x=" + this.x.ToString() + ",y=" + this.y.ToString() + ")";
        }
    }
}
