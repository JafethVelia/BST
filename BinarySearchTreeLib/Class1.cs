using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTreeLib
{
    public class Class1
    {
        public class TreeNode
        {
            public int Key;
            public TreeNode Left, Right;

            public TreeNode(int key)
            {
                Key = key;
                Left = Right = null;
            }
        }

        public class BinarySearchTree
        {
            public TreeNode Root;

            public BinarySearchTree()
            {
                Root = null;
            }

            // Inserción
            public void Insert(int key)
            {
                Root = InsertRecursive(Root, key);
            }

            private TreeNode InsertRecursive(TreeNode node, int key)
            {
                if (node == null) return new TreeNode(key);
                if (key < node.Key) node.Left = InsertRecursive(node.Left, key);
                else if (key > node.Key) node.Right = InsertRecursive(node.Right, key);
                return node;
            }

            // Búsqueda
            public bool Search(int key)
            {
                return SearchRecursive(Root, key);
            }

            private bool SearchRecursive(TreeNode node, int key)
            {
                if (node == null) return false;
                if (node.Key == key) return true;
                return key < node.Key
                    ? SearchRecursive(node.Left, key)
                    : SearchRecursive(node.Right, key);
            }

            // Eliminación
            public void Delete(int key)
            {
                Root = DeleteRecursive(Root, key);
            }

            private TreeNode DeleteRecursive(TreeNode node, int key)
            {
                if (node == null) return null;

                if (key < node.Key) node.Left = DeleteRecursive(node.Left, key);
                else if (key > node.Key) node.Right = DeleteRecursive(node.Right, key);
                else
                {
                    if (node.Left == null) return node.Right;
                    if (node.Right == null) return node.Left;

                    node.Key = MinValue(node.Right);
                    node.Right = DeleteRecursive(node.Right, node.Key);
                }
                return node;
            }

            private int MinValue(TreeNode node)
            {
                int minv = node.Key;
                while (node.Left != null)
                {
                    node = node.Left;
                    minv = node.Key;
                }
                return minv;
            }

            // Recorrido In-Order
            public List<int> InOrder()
            {
                var result = new List<int>();
                InOrderRecursive(Root, result);
                return result;
            }

            private void InOrderRecursive(TreeNode node, List<int> result)
            {
                if (node != null)
                {
                    InOrderRecursive(node.Left, result);
                    result.Add(node.Key);
                    InOrderRecursive(node.Right, result);
                }
            }
        }

    }
}
