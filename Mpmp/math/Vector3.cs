using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mpmp.math
{
    class Vector3 : Vector2
    {
        public double x { get; set; }

        public double y { get; set; }

        public double z { get; set; }

        public Vector3(Vector3 v) : this(v.x, v.y, v.z) { }

        public Vector3(double x=0, double y=0, double z=0)
        {
            // TODO: Complete member initialization
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public double getZ()
        {
            return z;
        }

        public double getFloorZ()
        {
            return (int)z;
        }


        public double getRight()
        {
            return this.getX();
        }

        public double getUp()
        {
            return this.getY();
        }

        public double getForward()
        {
            return this.getZ();
        }

        public double getSouth()
        {
            return this.getX();
        }

        public double getWest()
        {
            return this.getZ();
        }

        public Vector3 add(double x, double y, double z)
        {
            this.x += x;
            this.y += y;
            this.z += z;
            return this;
        }

        public Vector3 add(Vector3 v)
        {
            return this.add(v.x, v.y, v.z);
        }

        public Vector3 subtract(double x, double y, double z)
        {
            return this.add(-x, -y, -z);
        }

        public Vector3 subtract(Vector3 v)
        {
            return this.add(-v.x, -v.y, -v.z);
        }

        public Vector3 multiply(double number)
        {
            this.x *= number;
            this.y *= number;
            this.z *= number;
            return this;
        }

        public Vector3 divide(double number)
        {
            this.x /= number;
            this.y /= number;
            this.z /= number;
            return this;
        }
        public Vector3 ceil()
        {
            return new Vector3((int)(this.x + 1), (int)(this.y + 1), (int)(this.z + 1));
        }

        public Vector3 floor()
        {
            return new Vector3((int)this.x, (int)this.y, (int)this.z);
        }

        public Vector3 round()
        {
            return new Vector3(Math.Round(this.x), Math.Round(this.y), Math.Round(this.z));
        }

        public Vector3 abs()
        {
            return new Vector3(Math.Abs(this.x), Math.Abs(this.y), Math.Abs(this.z));
        }

        public Vector3 getSide(int side)
        {
            switch ((int)side)
            {
                case 0:
                    return new Vector3(this.x, this.y - 1, this.z);
                case 1:
                    return new Vector3(this.x, this.y + 1, this.z);
                case 2:
                    return new Vector3(this.x, this.y, this.z - 1);
                case 3:
                    return new Vector3(this.x, this.y, this.z + 1);
                case 4:
                    return new Vector3(this.x - 1, this.y, this.z);
                case 5:
                    return new Vector3(this.x + 1, this.y, this.z);
                default:
                    return this;
            }
        }

        public double distance(Vector3 v)
        {
            return this.distance(v.x, v.y, v.z);
        }
        public double distance(double x, double y, double z)
        {

            return Math.Sqrt(this.distanceSquared(x, y, z));

        }

        public double distanceSquared(Vector3 v)
        {
            return this.distanceSquared(v.x, v.y, v.z);
        }
        public double distanceSquared(double x, double y, double z)
        {
            return Math.Pow(this.x - x, 2) + Math.Pow(this.y - y, 2) + Math.Pow(this.z - z, 2);
        }

        public double maxPlainDistance(Vector3 v)
        {
            return this.maxPlainDistance(v.x, v.z);
        }
        public double maxPlainDistance(double x, double z)
        {

            return Math.Max(Math.Abs(this.x - x), Math.Abs(this.z - z));
        }

        public double length()
        {
            return Math.Sqrt(this.lengthSquared());
        }

        public double lengthSquared()
        {
            return this.x * this.x + this.y * this.y + this.z * this.z;
        }

        public Vector3 normalize()
        {
            double len = this.length();
            if (len != 0)
            {
                return this.divide(len);
            }
            return new Vector3(0, 0, 0);
        }

        public double dot(Vector3 v)
        {
            return this.x * v.x + this.y * v.y + this.z * v.z;
        }

        public Vector3 cross(Vector3 v)
        {
            return new Vector3(
                this.y * v.z - this.z * v.y,
                this.z * v.x - this.x * v.z,
                this.x * v.y - this.y * v.x
            );
        }

        public override string ToString()
        {
            return "Vector3(x=" + this.x.ToString() + ",y=" + this.y.ToString() + ",z=" + this.z.ToString() + ")";
        }
    }

}

