using ContainersDataModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ExampleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            { 
                Random rnd = new Random();

                //Example1
                #region Example 1

                //Position 1 of the XY data contains 50 points
                var positionXY1 = new Position2D<decimal>(new Point2D<decimal>[50].Select(c => c = new Point2D<decimal>(Healper.NextDecimal(rnd), Healper.NextDecimal(rnd))).ToList());
                //Position 2 of the XY data contains 200 points
                var positionXY2 = new Position2D<decimal>(new Point2D<decimal>[200].Select(c => c = new Point2D<decimal>(Healper.NextDecimal(rnd), Healper.NextDecimal(rnd))).ToList());

                //The other XY positions are empty       
                var positionsXY = new List<Position2D<decimal>>(new Position2D<decimal>[98].Select(c => c = new Position2D<decimal>()));
                positionsXY.Insert(0, positionXY1);
                positionsXY.Insert(1, positionXY2);

                //Position 1 and 2 of the X data matrix contain a numerical value
                var positionX1 = new Position1D<decimal>(new Point1D<decimal>[rnd.Next(1, 50)].Select(c => c = new Point1D<decimal>(Healper.NextDecimal(rnd))).ToList());
                var positionX2 = new Position1D<decimal>(new Point1D<decimal>[rnd.Next(1, 50)].Select(c => c = new Point1D<decimal>(Healper.NextDecimal(rnd))).ToList());
                //the others do not
                var positionsX = new List<Position1D<decimal>>(new Position1D<decimal>[98].Select(c => c = new Position1D<decimal>()));
                positionsX.Insert(0, positionX1);
                positionsX.Insert(1, positionX2);

                //Each matrix contains 100 positions
                //first matrix in each container being XY data  
                var matrix1 = new Matrix<decimal>(positionsXY);
                //the second matrix in each container being X data
                var matrix2 = new Matrix<decimal>(positionsX);

                //A container collection contains 3 containers.  All data points are decimal
                var containersExample1 = new Containers<decimal>
                    (
                        new Container<decimal>(matrix1, matrix2),
                        new Container<decimal>(matrix1, matrix2),
                        new Container<decimal>(matrix1, matrix2)
                    );

                #endregion

                //Example2
                #region Example 2

                var matrixXY = new Matrix<double>(
                    new List<Position2D<double>>
                    (
                        new Position2D<double>[10].Select(c => c = new Position2D<double>(
                            //All positions in all matrices contain values
                            new Point2D<double>[rnd.Next(1, 50)]
                            .Select(p => p = new Point2D<double>(rnd.NextDouble(), rnd.NextDouble())).ToList())
                    )));

                var matrixX = new Matrix<double>(
                    new List<Position1D<double>>
                    (
                        new Position1D<double>[10].Select(c => c = new Position1D<double>(
                            //All positions in all matrices contain values
                            new Point1D<double>[rnd.Next(1, 50)]
                            .Select(p => p = new Point1D<double>(rnd.NextDouble())).ToList())
                    )));

                //A container collection contains 10 containers.  All data points are double
                var containersExample2 = new Containers<double>
                    (
                        new List<Container<double>>(
                            //Each container contains 10 matrices
                            new Container<double>[10].Select(c => c = new Container<double>(
                                new List<Matrix<double>>(
                                    //first 5 matrices being XY data
                                    new Matrix<double>[5].Select(m => m = matrixXY).Concat(
                                    //remaining 5 being X data
                                    new Matrix<double>[5].Select(m => m = matrixX)))
                                    )
                                ))

                    );

                #endregion

                //Test large dataset
                #region large dataset
                //containers contains 1000 container
                //each container contains 50 matrices 
                //each matrix is XYZ contains 1 position
                //each position contains 50 points

                //!!!!dont increase size
                //bigger size will work as memory bomb

                //var containersExample3 = new Containers<int>
                //(
                //    new List<Container<int>>(
                //        new Container<int>[1000].Select(c => c = new Container<int>(
                //            new List<Matrix<int>>(
                //                new Matrix<int>[50].Select(m => m = new Matrix<int>(
                //                    new List<Position2D<int>>(
                //                        new Position2D<int>[1].Select(n => n = new Position2D<int>(
                //                            new List<Point2D<int>>(
                //                                new Point2D<int>[500].Select(r => r = new Point2D<int>(rnd.Next(), rnd.Next())
                //))))))))))));

                #endregion

                //Console.WriteLine(containersExample1.ToString());
                //Console.WriteLine(containersExample1.ToString());

                File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory +"allData.txt", containersExample1.ToString() + containersExample1.ToString());
                Console.WriteLine("All data saved in " + AppDomain.CurrentDomain.BaseDirectory + "allData.txt");
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadKey();
            }
        }
    }
    
}