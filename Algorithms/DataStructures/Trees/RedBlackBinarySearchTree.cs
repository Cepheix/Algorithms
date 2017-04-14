using System;
using System.Collections.Generic;
namespace Algorithms.DataStructures.Trees
{
    public class RedBlackBinarySearchTree<Key, Value> where Key : IComparable<Key>
    {
        private Node root;
        private const bool RED = true;
        private const bool BLACK = false;
        public void Put(Key key, Value value)
        {
            root = Put(root, key, value);
        }

        private Node Put(Node node, Key key, Value value)
        {
            if (node == null)
            {
                return new Node(key, value, RED);
            }

            int compare = key.CompareTo(node.key);

            if (compare < 0)
            {
                node.left = Put(node.left, key, value);
            }
            else if (compare > 0)
            {
                node.right = Put(node.right, key, value);
            }
            else
            {
                node.value = value;
            }

            if (IsRed(node.right) && !IsRed(node.left))
            {
                node = RotateLeft(node);
            }

            if (IsRed(node.left) && !IsRed(node.left.left))
            {
                node = RotateRight(node);
            }

            if (IsRed(node.left) && IsRed(node.right))
            {
                FlipColors(node);
            }

            node.count = 1 + Size(node.left) + Size(node.right);
            return node;
        }

        public Value Get(Key key)
        {
            Node x = root;
            // start at the root
            // if the node's key is lesser that the given key go right if not go left and return value of found node

            while (x != null)
            {
                int compute = key.CompareTo(x.key);

                if (compute < 0)
                {
                    x = x.left;
                }
                else if (compute > 0)
                {
                    x = x.right;
                }
                else if (compute == 0)
                {
                    return x.value;
                }
            }

            // if not exist return null
            return default(Value);
        }

        public void Delete(Key key)
        {
            root = Delete(root, key);
        }

        private Node Delete(Node node, Key key)
        {
            if (node == null)
            {
                return null;
            }

            int compare = key.CompareTo(node.key);

            if (compare < 0)
            {
                node.left = Delete(node.left, key);
            }
            else if (compare > 0)
            {
                node.right = Delete(node.right, key);
            }
            else
            {
                if (node.right == null)
                {
                    return node.left;
                }
                if (node.left == null)
                {
                    return node.right;
                }

                Node t = node;
                node = Min(t.right);
                node.right = DeleteMin(t.right);
                node.left = t.left;
            }

            node.count = Size(node.left) + Size(node.right) + 1;
            return node;
        }

        public Key Min()
        {
            Node node = Min(root);

            if (node == null)
            {
                return default(Key);
            }

            return node.key;
        }

        private Node Min(Node node)
        {
            while (node.left != null)
            {
                node = node.left;
            }

            return node;
        }

        public int Size()
        {
            return Size(root);
        }

        private int Size(Node node)
        {
            if (node == null)
            {
                return 0;
            }
            return node.count;
        }

        public void DeleteMin()
        {
            root = DeleteMin(root);
        }

        private Node DeleteMin(Node node)
        {
            if (node.left == null)
            {
                return node.right;
            }

            node = DeleteMin(node.left);
            node.count = 1 + Size(node.left) + Size(node.right);
            return node;
        }

        public Key Floor(Key key)
        {
            Node node = Floor(root, key);

            if (node == null)
            {
                return default(Key);
            }

            return node.key;
        }

        private Node Floor(Node node, Key key)
        {
            if (node == null)
            {
                return null;
            }

            int compare = key.CompareTo(node.key);

            if (compare == 0)
            {
                return node;
            }
            else if (compare < 0)
            {
                return Floor(node.left, key);
            }
            else
            {
                Node t = Floor(node.right, key);
                if (t != null)
                {
                    return t;
                }
                else
                {
                    return node;
                }
            }
            {

            }
        }

        public int Rank(Key key)
        {
            return Rank(key, root);
        }

        private int Rank(Key key, Node node)
        {
            if (node == null)
            {
                return 0;
            }

            int compare = key.CompareTo(node.key);

            if (compare < 0)
            {
                return Rank(key, node.left);
            }
            else if (compare > 0)
            {
                return 1 + Size(node.left) + Rank(key, node.right);
            }
            else
            {
                return Size(node.left);
            }
        }

        public IEnumerator<Key> Iterator()
        {
            Queue<Key> queue = new Queue<Key>();
            Inorder(root, queue);
            return queue.GetEnumerator();
        }

        private void Inorder(Node node, Queue<Key> queue)
        {
            if (node == null)
            {
                return;
            }

            Inorder(node.left, queue);
            queue.Enqueue(node.key);
            Inorder(node.right, queue);
        }

        private Node RotateLeft(Node h)
        {
            // Assert(IsRed(h.right))
            Node node = h.right;
            h.right = node.left;
            node.left = h;
            node.color = h.color;
            h.color = RED;
            return node;
        }

        private Node RotateRight(Node h)
        {
            // Assert(IsRed(h.left))

            Node node = h.left;
            h.left = node.right;
            node.right = h;
            node.color = RED;
            return node;
        }

        private void FlipColors(Node h)
        {
            // Assert(!IsRed(h))
            // Assert(IsRed(h.left))
            // Assert(IsRed(h.right))

            h.color = RED;
            h.left.color = BLACK;
            h.right.color = BLACK;
        }

        private bool IsRed(Node node)
        {
            if (node == null)
            {
                return false; // null links are black
            }

            return node.color == RED;
        }

        class Node
        {
            public Key key;
            public Value value;
            public Node left;
            public Node right;
            public int count;
            public bool color; // color of parent link

            public Node(Key key, Value value, bool color)
            {
                this.key = key;
                this.value = value;
                this.color = color;
            }
        }
    }
}
