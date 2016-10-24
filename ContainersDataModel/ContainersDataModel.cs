using System;
using System.Collections.Generic;
using System.Linq;

namespace ContainersDataModel
{
    // compile with: /doc:DocContainersDataModel.xml

    /// <summary>
    /// Abstract base class of point <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The numeric type of the point</typeparam>
    /// <seealso cref="ContainersDataModel.Point{T}" />
    public abstract class Point<T>
          where T : struct
    {

    }

    /// <summary>
    /// Generic type that describe point in 1D
    /// </summary>
    /// <typeparam name="T">The numeric type of the point</typeparam>
    /// <seealso cref="ContainersDataModel.Point{T}" />
    public class Point1D<T> : Point<T>
         where T : struct
    {
        /// <summary>
        /// Gets the x.
        /// </summary>
        /// <value>
        /// x.
        /// </value>
        public T x
        {
            get; private set;
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="Point1D{T}"/> class.
        /// </summary>
        /// <param name="x">Single numerical value x.</param>
        public Point1D(T x)
        {
            this.x = x;
        }
        /// <summary>
        /// Initializes a new default instance of the <see cref="Point1D{T}"/> class.
        /// </summary>
        public Point1D() { }


        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return "X:" + x.ToString();
        }
    }

    /// <summary>
    /// Generic type that describe point in 2D
    /// </summary>
    /// <typeparam name="T">The numeric type of the point</typeparam>
    /// <seealso cref="ContainersDataModel.Point1D{T}" />
    public class Point2D<T> : Point1D<T>
        where T : struct
    {
        /// <summary>
        /// Gets the y.
        /// </summary>
        /// <value>
        /// The y.
        /// </value>
        public T y
        {
            get; private set;
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="Point2D{T}"/> class.
        /// </summary>
        /// <param name="x">First numerical value x .</param>
        /// <param name="y">Second numerical value y.</param>
        public Point2D(T x, T y) : base(x)
        {
            this.y = y;
        }

        /// <summary>
        /// Initializes a new default instance of the <see cref="Point2D{T}"/> class.
        /// </summary>
        public Point2D() : base() { y = default(T); }
        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return base.ToString() + "; Y:" + y.ToString();
        }
    }

    /// <summary>
    /// Generic type that describe point in 3D
    /// </summary>
    /// <typeparam name="T">The numeric type of the point</typeparam>
    /// <seealso cref="ContainersDataModel.Point1D{T}" />
    public class Point3D<T> : Point2D<T>
        where T : struct
    {
        /// <summary>
        /// Gets the z.
        /// </summary>
        /// <value>
        /// The z.
        /// </value>
        public T z
        {
            get; private set;
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="Point2D{T}"/> class.
        /// </summary>
        /// <param name="x">First numerical value x .</param>
        /// <param name="y">Second numerical value y.</param>
        /// <param name="z">Third numerical value z.</param>
        public Point3D(T x, T y, T z) : base(x, y)
        {
            this.z = z;
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="Point3D{T}"/> class.
        /// </summary>
        public Point3D() : base() { z = default(T); }
        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return base.ToString() + "; Z:" + z.ToString();
        }
    }

    /// <summary>
    /// Abstract base class of position <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The numeric type of the position</typeparam>
    /// <seealso cref="ContainersDataModel.Point{T}" />
    public abstract class Position<T>
        where T : struct
    {
        protected List<Point<T>> points;

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            if (pointsCount.HasValue)
            {
                string pointsToString = string.Empty;
                for (int i = 0; i < points.Count; i++)
                {
                    pointsToString += "\t\t\tPoint" + i + " [" + points[i].ToString() + "]" + Environment.NewLine;
                };
                return pointsToString;
            }
            else
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// Gets the points count.
        /// </summary>
        /// <value>
        /// The points count.
        /// </value>
        public virtual int? pointsCount
        {
            get
            {
                return this.points != null ? points.Count : (int?)null;
            }
        }
        /// <summary>
        /// Gets the <see cref="Point{T}"/> at the specified index.
        /// </summary>
        /// <value>
        /// The <see cref="Point{T}"/>.
        /// </value>
        /// <param name="index">The index.</param>
        /// <returns></returns>
        /// <exception cref="System.IndexOutOfRangeException"></exception>
        public Point<T> this[int index]
        {
            get
            {
                if (this.points != null)
                {
                    if (index < points.Count)
                    {
                        return points[index];
                    }
                    else
                    {
                        throw new IndexOutOfRangeException();
                    }
                }
                else
                {
                    return null;
                }
            }
        }
    }
    /// <summary>
    /// Generic class that describe position in 1D
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="ContainersDataModel.Position{T}" />
    public class Position1D<T> : Position<T>
    where T : struct
    {
        /// <summary>
        /// Gets the list of <see cref="Point1D{T}"/>.
        /// </summary>
        /// <value>
        /// The points.
        /// </value>
        public new List<Point1D<T>> points
        {
            get
            {
                return base.points.Cast<Point1D<T>>().ToList();
            }
            private set
            {
                base.points = value != null ? new List<Point<T>>(value) : null;
            }
        }
        /// <summary>
        /// Initializes a new default instance of the <see cref="Position1D{T}"/> class.
        /// </summary>
        public Position1D()
        {
            points = null;
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="Position1D{T}"/> class.
        /// </summary>
        /// <param name="points">The points list.</param>
        public Position1D(List<Point1D<T>> points)
        {
            this.points = new List<Point1D<T>>(points);
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="Position1D{T}"/> class.
        /// </summary>
        /// <param name="points">The points as params.</param>
        public Position1D(params Point1D<T>[] points) : this(new List<Point1D<T>>(points)) { }

    }

    /// <summary>
    /// Generic class that describe position in 2D
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="ContainersDataModel.Position{T}" />
    public class Position2D<T> : Position<T>
    where T : struct
    {
        /// <summary>
        /// Gets the <see cref="List{Point2D{T}}"/> of points.
        /// </summary>
        /// <value>
        /// The points list.
        /// </value>
        public new List<Point2D<T>> points
        {
            get
            {
                return base.points.Cast<Point2D<T>>().ToList();
            }
            private set
            {
                base.points = new List<Point<T>>(value);
            }
        }
        /// <summary>
        /// Initializes a new default instance of the <see cref="Position2D{T}"/> class.
        /// </summary>
        public Position2D()
        {
            this.points = new List<Point2D<T>>();
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="Position2D{T}"/> class.
        /// </summary>
        /// <param name="points">The points list.</param>
        public Position2D(List<Point2D<T>> points)
        {
            this.points = new List<Point2D<T>>(points);
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="Position2D{T}"/> class.
        /// </summary>
        /// <param name="points">The points as params.</param>
        public Position2D(params Point2D<T>[] points) : this(new List<Point2D<T>>(points)) { }

        /// <summary>
        /// Gets the points count.
        /// </summary>
        /// <value>
        /// The points count.
        /// </value>
        public override int? pointsCount
        {
            get
            {
                return points.Count;
            }
        }
    }

    /// <summary>  
    /// Generic class that describe position in 3D
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="ContainersDataModel.Position{T}" />
    public class Position3D<T> : Position<T>
    where T : struct
    {
        /// <summary>
        /// Gets the list of <see cref="Point1D{T}"/>..
        /// </summary>
        /// <value>
        /// The points.
        /// </value>
        public new List<Point3D<T>> points
        {
            get
            {
                return base.points.Cast<Point3D<T>>().ToList();
            }
            private set
            {
                base.points = new List<Point<T>>(value);
            }
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="Position3D{T}"/> class.
        /// </summary>
        public Position3D()
        {
            this.points = new List<Point3D<T>>();
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="Position3D{T}"/> class.
        /// </summary>
        /// <param name="points">The points list.</param>
        public Position3D(List<Point3D<T>> points)
        {
            this.points = new List<Point3D<T>>(points);
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="Position3D{T}"/> class.
        /// </summary>
        /// <param name="points">The points as params.</param>
        public Position3D(params Point3D<T>[] points) : this(new List<Point3D<T>>(points)) { }

        /// <summary>
        /// Gets the points count.
        /// </summary>
        /// <value>
        /// The points count.
        /// </value>
        public override int? pointsCount
        {
            get
            {
                return points.Count;
            }
        }
    }

    /// <summary>
    /// Generic class that describe matrix <typeparamref name="T"/>.
    /// <typeparam name="T">The numeric type of the point</typeparam>
    /// </summary>    
    public class Matrix<T>
        where T : struct
    {
        /// <summary>
        /// Gets the positions list.
        /// </summary>
        /// <value>
        /// The positions list.
        /// </value>
        public IEnumerable<Position<T>> positions { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Matrix{T}"/> class.
        /// </summary>
        /// <param name="positions">The positions list.</param>
        public Matrix(IEnumerable<Position<T>> positions)
        {
            Validate(positions.ToList());
            this.positions = new List<Position<T>>(positions);
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="Matrix{T}"/> class.
        /// </summary>
        /// <param name="positions">The positions as params.</param>
        public Matrix(params Position<T>[] positions) : this(new List<Position<T>>(positions)) { }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            string posinionsToString = string.Empty;
            for (int i = 0; i < positions.Count(); i++)
            {
                posinionsToString += "\t\tPosition" + i + Environment.NewLine + positions.ElementAt(i).ToString() + Environment.NewLine;
            };
            return posinionsToString;
        }
        /// <summary>
        /// Validates list of positions to follow the rules.
        /// </summary>
        /// <param name="positions">The positions list.</param>
        /// <exception cref="ContainersDataModel.PositionTypeException">Positions type not match at " + positions.IndexOf(p) + " position</exception>
        /// <exception cref="ContainersDataModel.Matrix3DPointCountException">Points count not match at " + positions.IndexOf(p) + " position</exception>
        void Validate(List<Position<T>> positions)
        {
            foreach (Position<T> p in positions.Skip(1))
            {
                if (p.GetType() != positions.First().GetType())
                {
                    throw new PositionTypeException("Positions type not match at " + positions.IndexOf(p) + " position");
                }
                if (positions.First().GetType() == typeof(Position3D<T>) && positions.First().pointsCount != p.pointsCount)
                {
                    throw new Matrix3DPointCountException("Points count not match at " + positions.IndexOf(p) + " position");
                }
            }
        }
        /// <summary>
        /// Gets the <see cref="Position{T}"/> at the specified index.
        /// </summary>
        /// <value>
        /// The <see cref="Position{T}"/>.
        /// </value>
        /// <param name="index">The index.</param>
        /// <returns></returns>
        /// <exception cref="IndexOutOfRangeException"></exception>
        public Position<T> this[int index]
        {
            get
            {
                if (index < positions.Count())
                {
                    return positions.ElementAt(index);
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }
        }

        /// <summary>
        /// Gets the matrix points count.
        /// </summary>
        /// <value>
        /// The points count.
        /// </value>
        public int pointsCount
        {
            get
            {
                return positions.Where(p => p.pointsCount.HasValue).Sum(p => p.pointsCount.Value);
            }
        }
        /// <summary>
        /// Gets the matrix type of the positions.
        /// </summary>
        /// <value>
        /// The type of the positions.
        /// </value>
        public Type positionsType
        {
            get
            {
                return positions.First().GetType();
            }
        }
        /// <summary>
        /// Determines if matrix1 is same position type with the specified matrix2;.
        /// </summary>
        /// <param name="m1">The matrix1.</param>
        /// <param name="m2">The matrix2.</param>
        /// <returns>
        ///   <c>true</c> if matrix1 is same position type with the specified matrix2; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsSamePositionType(Matrix<T> m1, Matrix<T> m2)
        {
            return m1.positionsType == m2.positionsType;
        }
        /// <summary>
        /// Determines if matrix1 is same point size with the specified matrix2;.
        /// </summary>
        /// <param name="m1">The matrix1.</param>
        /// <param name="m2">The matrix2.</param>
        /// <returns>
        ///   <c>true</c> if matrix1 is same point size with the specified matrix2; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsSamePointSize(Matrix<T> m1, Matrix<T> m2)
        {
            return m1.pointsCount == m2.pointsCount;
        }
        /// <summary>
        /// Determines if matrix1 is same position size with the specified matrix2;.
        /// </summary>
        /// <param name="m1">The matrix1.</param>
        /// <param name="m2">The matrix2.</param>
        /// <returns>
        ///   <c>true</c> if matrix1 is same position size with the specified matrix2; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsSamePositionSize(Matrix<T> m1, Matrix<T> m2)
        {
            return m1.positions.Count() == m2.positions.Count();
        }
    }


    /// <summary>
    /// Generic class that discribe container of matrices/>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Container<T>
           where T : struct
    {
        /// <summary>
        /// Gets the matrices list.
        /// </summary>
        /// <value>
        /// The matrices.
        /// </value>
        public List<Matrix<T>> matrices { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Container{T}"/> class.
        /// </summary>
        /// <param name="matrices">The matrices list.</param>
        public Container(List<Matrix<T>> matrices)
        {
            Validate(matrices);
            this.matrices = new List<Matrix<T>>(matrices);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Container{T}"/> class.
        /// </summary>
        /// <param name="matrices">The matrices as params.</param>
        public Container(params Matrix<T>[] matrices) : this(new List<Matrix<T>>(matrices)) { }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            string pointsToString = string.Empty;
            for (int i = 0; i < matrices.Count; i++)
            {
                pointsToString += "\tMatrix" + i + Environment.NewLine + matrices[i].ToString() + Environment.NewLine;
            };
            return pointsToString;
        }

        /// <summary>
        /// Gets the matrix count.
        /// </summary>
        /// <value>
        /// The matrix count.
        /// </value>
        public int matrixCount
        {
            get
            {
                return matrices.Count;
            }
        }

        /// <summary>
        /// Validates the specified matrices to follow the rules.
        /// </summary>
        /// <param name="matrices">The matrices.</param>
        /// <exception cref="ContainersDataModel.ContainerMatrixPositionSizeException">Matrix position size not match at " + matrices.IndexOf(m) + " matrix</exception>
        private void Validate(List<Matrix<T>> matrices)
        {
            foreach (Matrix<T> m in matrices)
            {
                if (!Matrix<T>.IsSamePositionSize(matrices.First(), m))
                {
                    throw new ContainerMatrixPositionSizeException("Matrix position size not match at " + matrices.IndexOf(m) + " matrix");
                }
            }
        }
        /// <summary>
        /// Gets the <see cref="Matrix{T}"/> at the specified index.
        /// </summary>
        /// <value>
        /// The <see cref="Matrix{T}"/>.
        /// </value>
        /// <param name="index">The index.</param>
        /// <returns></returns>
        /// <exception cref="IndexOutOfRangeException"></exception>
        public Matrix<T> this[int index]
        {
            get
            {
                if (index < matrices.Count)
                {
                    return matrices[index];
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }
        }

    }
    /// <summary>
    /// Abstract class of containers
    /// </summary>
    public abstract class Containers
    {

    }

    /// <summary>
    /// Generic class of containers
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Containers<T> : Containers
            where T : struct
    {
        /// <summary>
        /// Gets the containers list.
        /// </summary>
        /// <value>
        /// The containers list.
        /// </value>
        public List<Container<T>> containers { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Containers{T}"/> class.
        /// </summary>
        /// <param name="containers">The containers list.</param>
        public Containers(List<Container<T>> containers)
        {
            Validate(containers);
            this.containers = new List<Container<T>>(containers);
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="Containers{T}"/> class.
        /// </summary>
        /// <param name="containers">The containers as params.</param>
        public Containers(params Container<T>[] containers) : this(new List<Container<T>>(containers)) { }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            string pointsToString = string.Empty;
            for (int i = 0; i < containers.Count; i++)
            {
                pointsToString += "Container" + i + Environment.NewLine + containers[i].ToString() + Environment.NewLine;
            };
            return pointsToString;
        }
        /// <summary>
        /// Gets the <see cref="Container{T}"/> at the specified index.
        /// </summary>
        /// <value>
        /// The <see cref="Container{T}"/>.
        /// </value>
        /// <param name="index">The index.</param>
        /// <returns></returns>
        /// <exception cref="IndexOutOfRangeException"></exception>
        public Container<T> this[int index]
        {
            get
            {
                if (index < containers.Count)
                {
                    return containers[index];
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }
        }

        /// <summary>
        /// Validates the specified containers list to follow the rules
        /// </summary>
        /// <param name="containers">The containers.</param>
        /// <exception cref="ContainersDataModel.ContainersMatrixCountException">Matrix count not match at " + containers.IndexOf(c) + " container</exception>
        /// <exception cref="ContainersDataModel.ContainersMatrixTypeException">Matrix type not match in " + containers.IndexOf(c) + " container at " + tamplateMatrix.IndexOf(m) + " matrix</exception>
        /// <exception cref="ContainersDataModel.ContainerMatrixPositionSizeException">Matrix position size not match in " + containers.IndexOf(c) + " container at " + tamplateMatrix.IndexOf(m) + " matrix</exception>
        /// <exception cref="ContainersDataModel.ContainerMatrix3DPointCountException">3DMatrix points size not match in  " + containers.IndexOf(c) + " container at " + tamplateMatrix.IndexOf(m) + " matrix</exception>
        void Validate(List<Container<T>> containers)
        {
            if (containers != null && containers.Count != 0)
            {
                List<Matrix<T>> tamplateMatrix = containers.First().matrices;
                foreach (Container<T> c in containers.Skip(1))
                {
                    if (c.matrixCount != containers.First().matrixCount)
                    {
                        throw new ContainersMatrixCountException("Matrix count not match at " + containers.IndexOf(c) + " container");
                    }
                    foreach (Matrix<T> m in tamplateMatrix)
                    {
                        if (!Matrix<T>.IsSamePositionType(c.matrices[tamplateMatrix.IndexOf(m)], m))
                        {
                            throw new ContainersMatrixTypeException("Matrix type not match in " + containers.IndexOf(c) + " container at " + tamplateMatrix.IndexOf(m) + " matrix");
                        }
                        if (!Matrix<T>.IsSamePositionSize(c.matrices[tamplateMatrix.IndexOf(m)], m))
                        {
                            throw new ContainerMatrixPositionSizeException("Matrix position size not match in " + containers.IndexOf(c) + " container at " + tamplateMatrix.IndexOf(m) + " matrix");
                        }
                        if (c.matrices[tamplateMatrix.IndexOf(m)].positionsType == typeof(Position3D<T>) && !Matrix<T>.IsSamePointSize(c.matrices[tamplateMatrix.IndexOf(m)], m))
                        {
                            throw new ContainerMatrix3DPointCountException("Matrix points size not match in  " + containers.IndexOf(c) + " container at " + tamplateMatrix.IndexOf(m) + " matrix");
                        }
                    }
                }
            }
        }
    }

    /// <summary>
    /// static class of factory of containers
    /// </summary>
    public static class ContainersFactory
    {
        /// <summary>
        /// Creates the containers list.
        /// </summary>
        /// <param name="containers">The containers.</param>
        /// <returns></returns>
        public static List<Containers> CreateContainersList(params Containers[] containers)
       {
            return new List<Containers>(containers);
       }
        /// <summary>
        /// Creates the list of Containers <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T"> Numeric type of containers </typeparam>
        /// <param name="containers">The containers.</param>
        /// <returns></returns>
        public static List<Containers<T>> CreateContainersList<T>(params Containers<T>[] containers)
            where T: struct
       {
            return new List<Containers<T>>(containers);
       }
    }

    /// <summary>
    /// Helper class to add random decimal values
    /// </summary>
    public static class Healper
    {
        /// <summary>
        /// Next random decimal value.
        /// </summary>
        /// <param name="rng">The RNG.</param>
        /// <returns> Random decimal value</returns>
        public static decimal NextDecimal(this Random rng)
        {
            byte scale = (byte)rng.Next(29);
            bool sign = rng.Next(2) == 1;
            return new decimal(rng.Next(),
                               rng.Next(),
                               rng.Next(),
                               sign,
                               scale);
        }
    }

    public class MatricesPositionCountException : Exception
    {
        public MatricesPositionCountException()
        {
        }

        public MatricesPositionCountException(string message)
            : base(message)
        {
        }

        public MatricesPositionCountException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }

    public class PositionTypeException : Exception
    {
        public PositionTypeException()
        {
        }

        public PositionTypeException(string message)
            : base(message)
        {
        }

        public PositionTypeException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }

    public class Matrix3DPointCountException : Exception
    {
        public Matrix3DPointCountException()
        {
        }

        public Matrix3DPointCountException(string message)
            : base(message)
        {
        }

        public Matrix3DPointCountException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }

    public class ContainerMatrix3DPointCountException : Exception
    {
        public ContainerMatrix3DPointCountException()
        {
        }

        public ContainerMatrix3DPointCountException(string message)
            : base(message)
        {
        }

        public ContainerMatrix3DPointCountException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }

    public class ContainersMatrixTypeException : Exception
    {
        public ContainersMatrixTypeException()
        {
        }
        public ContainersMatrixTypeException(string message)
        : base(message)
        {
        }
        public ContainersMatrixTypeException(string message, Exception inner)
        : base(message, inner)
        {
        }
    }

    public class ContainerMatrixPositionSizeException : Exception
    {
        public ContainerMatrixPositionSizeException()
        {
        }
        public ContainerMatrixPositionSizeException(string message)
        : base(message)
        {
        }
        public ContainerMatrixPositionSizeException(string message, Exception inner)
        : base(message, inner)
        {
        }
    }

    public class ContainersMatrixCountException : Exception
    {
        public ContainersMatrixCountException()
        {
        }
        public ContainersMatrixCountException(string message)
        : base(message)
        {
        }
        public ContainersMatrixCountException(string message, Exception inner)
        : base(message, inner)
        {
        }
    }
}
