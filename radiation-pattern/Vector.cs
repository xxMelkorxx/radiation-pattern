using System;

namespace radiation_pattern
{
    public struct Vector
    {
        public double X;
        public double Y;
        public double Z;

        public Vector(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        /// <summary>
        /// Нулевой вектор.
        /// </summary>
        public static Vector Zero => new Vector(0, 0, 0);

        /// <summary>
        /// Единичный вектор.
        /// </summary>
        public static Vector One => new Vector(1, 1, 1);

        /// <summary>
        /// Длина вектора до точки.
        /// </summary>
        /// <param name="vector">Конечная точка.</param>
        public double Magnitude(Vector vector)
        {
            return Math.Sqrt(Math.Pow(vector.X - X, 2) + Math.Pow(vector.Y - Y, 2) + Math.Pow(vector.Z - Z, 2));
        }

        /// <summary>
        /// Длина вектора.
        /// </summary>
        public double Magnitude()
        {
            return Math.Sqrt(SquaredMagnitude());
        }

        /// <summary>
        /// Длина вектора.
        /// </summary>
        /// <param name="vector1">Начальная точка.</param>
        /// <param name="vector2">Конечная точка.</param>
        /// <returns></returns>
        public static double Magnitude(Vector vector1, Vector vector2)
        {
            return Math.Sqrt(Math.Pow(vector2.X - vector1.X, 2) + Math.Pow(vector2.Y - vector1.Y, 2) +
                             Math.Pow(vector2.Z - vector1.Z, 2));
        }

        /// <summary>
        /// Квадрат длины вектора.
        /// </summary>
        /// <returns></returns>
        public double SquaredMagnitude()
        {
            return X * X + Y * Y + Z * Z;
        }

        /// <summary>
        /// Нормированный вектор.
        /// </summary>
        /// <returns></returns>
        public Vector Normalized()
        {
            return new Vector(X, Y, Z) / Magnitude();
        }

        /// <summary>
        /// Возвращает значение наибольшей координаты.
        /// </summary>
        /// <returns></returns>
        public double MaxElement()
        {
            return (X > Y && X > Z) ? X : (Y > X && Y > Z) ? Y : Z;
        }

        /// <summary>
        /// Возвращает значение наименьшей координаты.
        /// </summary>
        /// <returns></returns>
        public double MinElement()
        {
            return (X < Y && X < Z) ? X : (Y < X && Y < Z) ? Y : Z;
        }

        /// <summary>
        /// Сложение координат.
        /// </summary>
        /// <param name="vec1">Первая координата.</param>
        /// <param name="vec2">Вторая координата.</param>
        /// <returns></returns>
        public static Vector operator +(Vector vec1, Vector vec2)
        {
            return new Vector(vec1.X + vec2.X, vec1.Y + vec2.Y, vec1.Z + vec2.Z);
        }

        /// <summary>
        /// Сложение координат.
        /// </summary>
        /// <param name="vec1">Первая координата.</param>
        /// <param name="value">Число.</param>
        /// <returns></returns>
        public static Vector operator +(Vector vec1, double value)
        {
            return new Vector(vec1.X + value, vec1.Y + value, vec1.Z + value);
        }

        /// <summary>
        /// Вычитание из одной координаты другой координаты.
        /// </summary>
        /// <param name="vec1">Первая координата.</param>
        /// <param name="vec2">Вторая координата.</param>
        /// <returns></returns>
        public static Vector operator -(Vector vec1, Vector vec2)
        {
            return new Vector(vec1.X - vec2.X, vec1.Y - vec2.Y, vec1.Z - vec2.Z);
        }

        /// <summary>
        /// Вычитание из одной координаты другой координаты.
        /// </summary>
        /// <param name="vec1">Первая координата.</param>
        /// <param name="value">Число.</param>
        /// <returns></returns>
        public static Vector operator -(Vector vec1, double value)
        {
            return new Vector(vec1.X - value, vec1.Y - value, vec1.Z - value);
        }

        /// <summary>
        /// Перемножение координат.
        /// </summary>
        /// <param name="vec1">Первая координата.</param>
        /// <param name="vec2">Вторая координата.</param>
        /// <returns></returns>
        public static Vector operator *(Vector vec1, Vector vec2)
        {
            return new Vector(vec1.X * vec2.X, vec1.Y * vec2.Y, vec1.Z * vec2.Z);
        }

        /// <summary>
        /// Деление одной координаты на другую.
        /// </summary>
        /// <param name="vec1">Первая координата.</param>
        /// <param name="vec2">Вторая координата.</param>
        /// <returns></returns>
        public static Vector operator /(Vector vec1, Vector vec2)
        {
            return new Vector(vec1.X / vec2.X, vec1.Y / vec2.Y, vec1.Z / vec2.Z);
        }

        /// <summary>
        /// Умножение числа с плавающей запятой на точку справа.
        /// </summary>
        /// <param name="vec">Координата точки.</param>
        /// <param name="num">Домножаемое число.</param>
        /// <returns></returns>
        public static Vector operator *(Vector vec, double num)
        {
            return new Vector(vec.X * num, vec.Y * num, vec.Z * num);
        }

        /// <summary>
        /// Умножение целого числа на точку справа.
        /// </summary>
        /// <param name="vec">Координата точки.</param>
        /// <param name="num">Домножаемое число.</param>
        /// <returns></returns>
        public static Vector operator *(Vector vec, int num)
        {
            return new Vector(vec.X * num, vec.Y * num, vec.Z * num);
        }

        /// <summary>
        /// Умножение числа с плавающей запятой на точку слева.
        /// </summary>
        /// <param name="vec">Координата точки.</param>
        /// <param name="num">Домножаемое число.</param>
        /// <returns></returns>
        public static Vector operator *(double num, Vector vec)
        {
            return new Vector(vec.X * num, vec.Y * num, vec.Z * num);
        }

        /// <summary>
        /// Умножение целого числа на точку слева.
        /// </summary>
        /// <param name="vec">Координата точки.</param>
        /// <param name="num">Домножаемое число.</param>
        /// <returns></returns>
        public static Vector operator *(int num, Vector vec)
        {
            return new Vector(vec.X * num, vec.Y * num, vec.Z * num);
        }

        /// <summary>
        /// Деление точки на число с плавающей запятой.
        /// </summary>
        /// <param name="vec">Координата точки.</param>
        /// <param name="num">Число-делитель.</param>
        /// <returns></returns>
        public static Vector operator /(Vector vec, double num)
        {
            return new Vector(vec.X / num, vec.Y / num, vec.Z / num);
        }

        /// <summary>
        /// Деление точки на целое число.
        /// </summary>
        /// <param name="vec">Координата точки.</param>
        /// <param name="num">Число-делитель.</param>
        public static Vector operator /(Vector vec, int num)
        {
            return new Vector(vec.X / num, vec.Y / num, vec.Z / num);
        }
    }
}