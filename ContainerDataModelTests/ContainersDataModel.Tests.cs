using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace ContainersDataModel.Tests
{
    [TestClass]
    public class MatrixTests
    {
        [TestMethod]
        [ExpectedException(typeof(PositionTypeException))]
        public void Validate_DiferentPositionType_ExceptionThrown()
        {
            IEnumerable<Position<int>> positions1D = new Position1D<int>[1].Select(c => c = new Position1D<int>());
            IEnumerable<Position<int>> positions2D = new Position2D<int>[1].Select(c => c = new Position2D<int>());
            var testMatrix = new Matrix<int>(positions1D.Concat(positions2D));
        }
        [TestMethod]
        [ExpectedException(typeof(Matrix3DPointCountException))]
        public void Validate_Matrix3DPointsCount_ExceptionThrown()
        {
            var positions1 = new Position3D<double>[2].Select(p => p = new Position3D<double>(
                new Point3D<double>[5].Select(c => c = new Point3D<double>()).ToList()
                ));
            var positions2 = new Position3D<double>[2].Select(p => p = new Position3D<double>(
               new Point3D<double>[1].Select(c => c = new Point3D<double>()).ToList()
               ));

            var testMatrix = new Matrix<double>(positions1.Concat(positions2));
        }
        
        //static metods
        [TestMethod]
        public void IsSamePositionType_SamePositionTypeMatrices_ReturnTrue()
        {
            var testMatrix1 = new Matrix<bool>(
                new Position1D<bool>[2].Select(p => p = new Position1D<bool>()));
            var testMatrix2 = new Matrix<bool>(
               new Position1D<bool>[2].Select(p => p = new Position1D<bool>()));
            Assert.IsTrue(Matrix<bool>.IsSamePositionType(testMatrix1, testMatrix2));
        }
        [TestMethod]
        public void IsSamePositionType_DifferentPositionTypeMatrices_ReturnFalse()
        {
            var testMatrix1 = new Matrix<decimal>(
                new Position1D<decimal>[2].Select(p => p = new Position1D<decimal>()));
            var testMatrix2 = new Matrix<decimal>(
               new Position3D<decimal>[2].Select(p => p = new Position3D<decimal>()));
            Assert.IsFalse(Matrix<decimal>.IsSamePositionType(testMatrix1, testMatrix2));
        }

        [TestMethod]
        public void IsSamePointSize_SamePointSizeMatrices_ReturtTrue()
        {
            var testMatrix1 = new Matrix<short>(
                new Position3D<short>[2].Select(p => p = new Position3D<short>(
                    new Point3D<short>[5].Select(c => c = new Point3D<short>()).ToList()
                )));
            var testMatrix2 = new Matrix<short>(
                new Position3D<short>[2].Select(p => p = new Position3D<short>(
                    new Point3D<short>[5].Select(c => c = new Point3D<short>()).ToList()
               )));
            Assert.IsTrue(Matrix<short>.IsSamePointSize(testMatrix1, testMatrix2));
        }
        [TestMethod]
        public void IsSamePointSize_DifferentPointSizeMatrices_ReturtFalse()
        {
            var testMatrix1 = new Matrix<short>(
                new Position3D<short>[2].Select(p => p = new Position3D<short>(
                    new Point3D<short>[1].Select(c => c = new Point3D<short>()).ToList()
                )));
            var testMatrix2 = new Matrix<short>(
                new Position3D<short>[2].Select(p => p = new Position3D<short>(
                    new Point3D<short>[6].Select(c => c = new Point3D<short>()).ToList()
               )));
            Assert.IsFalse(Matrix<short>.IsSamePointSize(testMatrix1, testMatrix2));
        }
        [TestMethod]
        public void IsSamePositionSize_SamePointSizeMatrices_ReturtTrue()
        {
            var testMatrix1 = new Matrix<short>(new Position3D<short>[4].Select(p => p = new Position3D<short>()));
            var testMatrix2 = new Matrix<short>(new Position3D<short>[4].Select(p => p = new Position3D<short>()));
            Assert.IsTrue(Matrix<short>.IsSamePositionSize(testMatrix1, testMatrix2));
        }
        [TestMethod]
        public void IsSamePositionSize_DifferentPointSizeMatrices_ReturtFalse()
        {
            var testMatrix1 = new Matrix<short>(new Position3D<short>[1].Select(p => p = new Position3D<short>()));
            var testMatrix2 = new Matrix<short>(new Position3D<short>[4].Select(p => p = new Position3D<short>()));
            Assert.IsFalse(Matrix<short>.IsSamePositionSize(testMatrix1, testMatrix2));
        }

    }

    [TestClass]
    public class ContainerTests
    {
        [TestMethod]
        [ExpectedException(typeof(ContainerMatrixPositionSizeException))]
        public void Validate_DiferentPositionSize_ExceptionThrown()
        {
            var testMatrix1 = new Matrix<byte>(new Position1D<byte>[1].Select(p => p = new Position1D<byte>()));
            var testMatrix2 = new Matrix<byte>(new Position1D<byte>[4].Select(p => p = new Position1D<byte>()));
            var testContainer = new Container<byte>(testMatrix1, testMatrix2);
        }
    }

    [TestClass]
    public class ContainersTests
    {
        [TestMethod]
        [ExpectedException(typeof(ContainersMatrixCountException))]
        public void Validate_ContainersDiferentMatrixCount_ExceptionThrown()
        {
            var testMatrix1 = new Matrix<float>();
            var testMatrix2 = new Matrix<float>();
            var testContainers = new Containers<float>(new Container<float>(testMatrix1, testMatrix2), new Container<float>(testMatrix1));
        }
        [TestMethod]
        [ExpectedException(typeof(ContainersMatrixTypeException))]
        public void Validate_ContainersDiferentMatrixPositionType_ExceptionThrown()
        {
            var testMatrix1 = new Matrix<long>(new Position1D<long>[1].Select(p => p = new Position1D<long>()));
            var testMatrix2 = new Matrix<long>(new Position2D<long>[1].Select(p => p = new Position2D<long>()));
            var testContainers = new Containers<long>(new Container<long>(testMatrix1), new Container<long>(testMatrix2));
        }
        [TestMethod]
        [ExpectedException(typeof(ContainerMatrixPositionSizeException))]
        public void Validate_ContainersDiferentMatrixPositionSize_ExceptionThrown()
        {
            var testMatrix1 = new Matrix<long>(new Position1D<long>[2].Select(p => p = new Position1D<long>()));
            var testMatrix2 = new Matrix<long>(new Position1D<long>[1].Select(p => p = new Position1D<long>()));
            var testContainers = new Containers<long>(new Container<long>(testMatrix1), new Container<long>(testMatrix2));
        }
        [TestMethod]
        [ExpectedException(typeof(ContainerMatrix3DPointCountException))]
        public void Validate_ContainersDiferentMatrix3DPointSize_ExceptionThrown()
        {
            var testMatrix1 = new Matrix<long>(new Position3D<long>[1].Select(p => p = 
                new Position3D<long>(new Point3D<long>[1].Select(c => c = new Point3D<long>()).ToList())));
            var testMatrix2 = new Matrix<long>(new Position3D<long>[1].Select(p => p =
                new Position3D<long>(new Point3D<long>[2].Select(c => c = new Point3D<long>()).ToList())));
            var containerList = new List<Container<long>>() { new Container<long>(testMatrix1), new Container<long>(testMatrix2)};
            var testContainers = new Containers<long>(containerList);
        }
        [TestMethod]
        public void LargeDataWithPointGeneratingStressTest()
        {
            try
            {
                Random rnd = new Random();
                var containersExample3 = new Containers<int>(
                    new List<Container<int>>(
                        new Container<int>[700].Select(c => c = new Container<int>(
                            new List<Matrix<int>>(
                                new Matrix<int>[50].Select(m => m = new Matrix<int>(
                                    new List<Position2D<int>>(
                                        new Position2D<int>[500].Select(n => n = new Position2D<int>(
                                            new List<Point2D<int>>(
                                                new Point2D<int>[1].Select(r => r = new Point2D<int>(rnd.Next(), rnd.Next())
                ))))))))))));

            }
            catch (Exception ex)
            {
                Assert.Fail("Expected no exception, but got: " + ex.Message);
            }
        }
        [TestMethod]
        public void LargeDataWithoutPointGeneratingStressTest()
        {
            try
            {                
                var containersExample3 = new Containers<int>(
                    new List<Container<int>>(
                        new Container<int>[700].Select(c => c = new Container<int>(
                            new List<Matrix<int>>(
                                new Matrix<int>[50].Select(m => m = new Matrix<int>(
                                    new List<Position2D<int>>(
                                        new Position2D<int>[500].Select(n => n = new Position2D<int>(
                                            new List<Point2D<int>>(
                                                new Point2D<int>[1].Select(r => r = new Point2D<int>()
                ))))))))))));

            }
            catch (Exception ex)
            {
                Assert.Fail("Expected no exception, but got: " + ex.Message);
            }
        }
        [TestMethod]
        public void Example1DataTest()
        {
            try
            {
                Random rnd = new Random();
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

            }
            catch (Exception ex)
            {
                Assert.Fail("Expected no exception, but got: " + ex.Message);
            }
        }
        [TestMethod]
        public void Example2DataTest()
        {
            try
            {
                Random rnd = new Random();
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
                     ))));

            }
            catch (Exception ex)
            {
                Assert.Fail("Expected no exception, but got: " + ex.Message);
            }
        }
    }

    [TestClass]
    public class ContainersFactoryTest
    {
        [TestMethod]
        public void CreateContainersList_DifferentNumericT()
        {
            var containers1 = new Containers<int>();
            var containers2 = new Containers<bool>();

            var resultList = ContainersFactory.CreateContainersList(containers1, containers2);

            Assert.AreNotEqual(resultList,null);
            Assert.IsInstanceOfType(resultList[0], typeof(Containers<int>));
            Assert.IsInstanceOfType(resultList[1], typeof(Containers<bool>));
        }
        [TestMethod]
        public void CreateContainersList_SameNumericT()
        {
            var containers1 = new Containers<int>();
            var containers2 = new Containers<int>();

            var resultList = ContainersFactory.CreateContainersList<int>(containers1, containers2);

            Assert.AreNotEqual(resultList, null);
            Assert.IsInstanceOfType(resultList[0], typeof(Containers<int>));
            Assert.IsInstanceOfType(resultList[1], typeof(Containers<int>));
        }
    }
}

