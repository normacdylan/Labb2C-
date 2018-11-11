using System;
namespace Labb2
{
    public class Position
    {
        public Position(double inputX, double inputY)
        {
            X = inputX;
            Y = inputY;
        }

        private double x;
        private double y;

        public double X
        {
            get => this.x;
            set => this.x = Math.Max(value, 0);
        }

        public double Y
        {
            get => this.y;
            set => this.y = Math.Max(value, 0);
        }

        public double Length() 
        {
            return Math.Sqrt(Math.Pow(this.X, 2) + Math.Pow(this.Y, 2));
        }

        public bool Equals(Position p) {
            return this.X.Equals(p.X) && this.Y.Equals(p.Y);
        }

        public Position Clone() {
            return new Position(this.X, this.Y);
        }

        public override string ToString()
        {
            return "(" + this.X.ToString() + ", " + this.Y.ToString() + ")";
        }

        public static bool operator >(Position a, Position b)
        {
            if (!a.Length().Equals(b.Length()))
                return a.Length() > b.Length();
            else
                return a.X >= b.X;
        }

        public static bool operator <(Position a, Position b)
        {
            if (!a.Length().Equals(b.Length()))
                return a.Length() < b.Length();
            else
                return a.X <= b.X;
        }

        public static Position operator +(Position a, Position b)
        {
            return new Position(a.X + b.X, a.Y + b.Y);
        }

        public static Position operator -(Position a, Position b)
        {
            return new Position(Math.Abs(a.X - b.X), Math.Abs(a.Y - b.Y));
        }

        public static Position operator *(Position a, Position b)
        {
            return new Position(a.X * b.X, a.Y * b.Y);
        }

        public static double operator %(Position a, Position b)
        {
            return Math.Sqrt(Math.Pow(a.X - b.X, 2) + Math.Pow(a.Y - b.Y, 2));
        }
    }
}
