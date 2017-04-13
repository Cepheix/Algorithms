using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.DataStructures.Trees
{
    public class BinarySearchTree<Key, Value> where Key : IComparable<Key>
    {
        private Node root;

        public void Put(Key key, Value value)
        {
            root = Put(root, key, value);
        }

        private Node Put(Node node, Key key, Value value)
        {
            if (node == null)
            {
                return new Node(key, value);
            }

            int compare = key.CompareTo(node.key);

            if (compare < 0)
            {
                node.left = Put(node.left, key, value);
            }
            else if(compare > 0)
            {
                node.right = Put(node.right, key, value);
            }
            else
            {
                node.value = value;
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
                else if(compute > 0)
                {
                    x = x.right;
                }
                else if(compute == 0)
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
                if (t != null )
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
            else if(compare > 0)
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

        class Node
        {
            public Key key;
            public Value value;
            public Node left;
            public Node right;
            public int count;

            public Node(Key key, Value value)
            {
                this.key = key;
                this.value = value;
            }
        }
    }
}
