using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Moq;
using NUnit.Framework;
using _01.DataBaseT;

namespace Base.Tests
{
    [TestFixture]
    public class BaseTests
    {
        //[SetUp]
        //public void InitializeDatabase()
        //{
        //    //var values = new int[] { 1, 2, 3 };
        //    //var db = new Database();
        //}


        [Test]
        [TestCase(new int[] { 1, 2, 3, 4 })]
        [TestCase(new int[] { })]
        [TestCase((new int[] { -10 }))]
        public void TestValidConstructor(int[] tests)
        {
            var db = new Database(tests);

            var fieldInfo = GetFieldInfo(db, typeof(int[]));

            int[] fieldValues = (int[])fieldInfo.GetValue(db);
            var buffer = new int[fieldValues.Length - tests.Length];

            Assert.That(fieldValues, Is.EquivalentTo(tests.Concat(buffer)));
        }

        [Test]
        public void TestInvalidConstructor()
        {
            int[] moreThanMaxCapacityValues = new int[17];

            Assert.That(()=> new Database(moreThanMaxCapacityValues),
                Throws.InvalidOperationException );
        }

        [Test]
        [TestCase(int.MinValue)]
        [TestCase(int.MaxValue)]
        [TestCase(0)]
        [TestCase(-20)]
        [TestCase(500)]
        public void TestAddMethodValid(int value)
        {
            var db = new Database();
            db.Add(value);

            var fieldInfo = GetFieldInfo(db, typeof(int[]));

            var currentIndexInfo = GetFieldInfo(db, typeof(int));

            var firstValue = ((int[]) fieldInfo.GetValue(db))
                .First();

            var valuesCount = (int) currentIndexInfo.GetValue(db);

            Assert.That(firstValue, Is.EqualTo(value));
            Assert.That(valuesCount, Is.EqualTo(1));
        }

        [Test]
        public void TestAddMethodInvalid()
        {
           // var values = new int[] {1, 2, 3};
            var db = new Database();

            var currentIndexInfo = GetFieldInfo(db, typeof(int));

            currentIndexInfo.SetValue(db, 16);

            Assert.That(() => db.Add(1), Throws.InvalidOperationException);

        }

        [Test]
        [TestCase(new int[] {1, 2, 3, 4})]
        [TestCase(new int[] {-1, 0, -234, 4})]
        public void TestRemoveMethodValid(int[] values)
        {
            var db = new Database();

            var fieldInfo = GetFieldInfo(db, typeof(int[]));


            fieldInfo.SetValue(db, values);

            var currentIndexInfo = GetFieldInfo(db, typeof(int));

            currentIndexInfo.SetValue(db, values.Length);

            db.Remove();

            var fieldValues = (int[]) fieldInfo.GetValue(db);
            var buffer = new int[fieldValues.Length - (values.Length - 1)];

            values = values.Take(values.Length - 1).Concat(buffer).ToArray();

            Assert.That(fieldValues, Is.EquivalentTo(values));
        }

        [Test]
        public void TestRemoveMethodInvalid()
        {
            var db = new Database();

            var currentIndexInfo = GetFieldInfo(db, typeof(int));

            currentIndexInfo.SetValue(db, 0);

            Assert.That(() => db.Remove(), Throws.InvalidOperationException);
        }

        //[Test]
        //public void TestFetchMethod()
        //{
        //    var values = new int[] {1, 2, 3};
        //    var db = new Database();
        //    var fieldInfo = GetFieldInfo(db, typeof(int[]));

        //    fieldInfo.SetValue(db, values);

        //    Assert.That( )
        //}

        private FieldInfo GetFieldInfo(object instance, Type fieldType)
        {
            var fieldInfo = instance.GetType()
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .First(f => f.FieldType == fieldType);

            return fieldInfo;
        }
    }
}

