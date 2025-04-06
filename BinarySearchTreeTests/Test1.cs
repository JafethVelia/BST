using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using BinarySearchTreeLib; 
using static BinarySearchTreeLib.Class1;

namespace BinarySearchTreeTests
{
    [TestClass]
    public sealed class Test1
    {
        [TestMethod]
        public void InsertAndSearchTest()
        {
            var bst = new BinarySearchTree();
            bst.Insert(8);
            bst.Insert(3);
            bst.Insert(10);
            bst.Insert(1);

            Assert.IsTrue(bst.Search(8));
            Assert.IsTrue(bst.Search(1));
            Assert.IsFalse(bst.Search(99));
        }

        [TestMethod]
        public void DeleteLeafNodeTest()
        {
            var bst = new BinarySearchTree();
            bst.Insert(5);
            bst.Insert(3);
            bst.Insert(7);
            bst.Delete(3);

            Assert.IsFalse(bst.Search(3));
        }

        [TestMethod]
        public void DeleteNodeWithOneChildTest()
        {
            var bst = new BinarySearchTree();
            bst.Insert(5);
            bst.Insert(3);
            bst.Insert(2);
            bst.Delete(3);

            Assert.IsFalse(bst.Search(3));
            Assert.IsTrue(bst.Search(2));
        }

        [TestMethod]
        public void DeleteNodeWithTwoChildrenTest()
        {
            var bst = new BinarySearchTree();
            bst.Insert(5);
            bst.Insert(3);
            bst.Insert(7);
            bst.Insert(6);
            bst.Insert(8);

            bst.Delete(7);

            Assert.IsFalse(bst.Search(7));
            Assert.IsTrue(bst.Search(6));
            Assert.IsTrue(bst.Search(8));
        }

        [TestMethod]
        public void InOrderTraversalTest()
        {
            var bst = new BinarySearchTree();
            int[] values = { 8, 3, 10, 1, 6, 4, 7, 14, 13 };
            foreach (int v in values) bst.Insert(v);

            var expected = new List<int> { 1, 3, 4, 6, 7, 8, 10, 13, 14 };
            CollectionAssert.AreEqual(expected, bst.InOrder());
        }
    }
}
