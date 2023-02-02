using System;
using System.Xml.Linq;

namespace Lab0
{
	public class BinarySearchTree<T> : IBinarySearchTree<T>
	{

        private BinarySearchTreeNode<T> Root { get; set; }

        public BinarySearchTree()
		{
            Root = null;
            Count = 0;
		}

        public bool IsEmpty => Root == null;

        public int Count { get; private set; }

        // TODO
        public int Height => HeightRecursive(Root);

        private int HeightRecursive(BinarySearchTreeNode<T> node)
        {
            if (node == null)
            {
                return -1;
            }

            //if (node.Left == null && node.Right == null)
            //{
            //    return 0;
            //}

            int leftHeight = HeightRecursive(node.Left);
            int rightHeight = HeightRecursive(node.Right);

            return 1 + Math.Max(leftHeight, rightHeight);
        }

        // TODO
        public int? MinKey => MinKeyRecursive(Root);

        private int? MinKeyRecursive(BinarySearchTreeNode<T> node)
        {
            if(node == null)
            {
                return null;
            }
            else if(node.Left == null)
            {
                return node.Key;
            }
            else
            {
                return MinKeyRecursive(node.Left);
            }
        }

        // TODO
        public int? MaxKey => throw new NotImplementedException();

        // TODO
        public BinarySearchTreeNode<T> Min => throw new NotImplementedException();

        // TODO
        public BinarySearchTreeNode<T> Max => throw new NotImplementedException();

        // TODO
        public double MedianKey => throw new NotImplementedException();


        public BinarySearchTreeNode<T> GetNode(int key)
        {
            return GetNodeRecursive(Root, key);
        }

        private BinarySearchTreeNode<T>? GetNodeRecursive(BinarySearchTreeNode<T> node, int key)
        {
            if(node == null)
            {
                return null;
            }

            if(node.Key == key)
            {
                return node;
            }

            else if (key < node.Key)
            {
                return GetNodeRecursive(node.Left, key);
            }
            else
            {
                return GetNodeRecursive(node.Right, key);
            }
        }


        
        public void Add(int key, T value)
        {
            Count++; 
            if ( Root == null)
            {
                Root = new BinarySearchTreeNode<T>(key, value);
                Count++;
            }

            else
            {
                AddRecursive(key, value, Root);
            }
        }
        
        private void AddRecursive(int key, T value, BinarySearchTreeNode<T> parent)
        {
            //duplicate found
            // do not add to BST
            if ( key == parent.Key)
            {
                return;
            }

            if (key < parent.Key)
            {
                if(parent.Left == null)
                {
                    var newNode = new BinarySearchTreeNode<T>(key, value);
                    parent.Left = newNode;
                    newNode.Parent = parent;
                    Count++;

                }
                else
                {
                    AddRecursive(key, value, parent.Left);
                }
            }

            else
            {
                if(parent.Right == null)
                {
                    var newNode = new BinarySearchTreeNode<T>(key, value);
                    parent.Right = newNode;
                    newNode.Parent = parent;
                    Count++;

                }

                else
                {
                    AddRecursive(key, value, parent.Right);
                }
            }
        }

        // TODO
        public void Clear()
        {
            Root = null;
        }

        
        public bool Contains(int key)
        {
            var node = GetNode(key);
            
            if(node == null)
            {
                return false;
            }

            else
            {
                return true;
            }
        }

        // TODO
        public BinarySearchTreeNode<T> Next(BinarySearchTreeNode<T> node)
        {
            // find the min node in the right child's subtree



            throw new NotImplementedException();
        }

        // TODO
        public BinarySearchTreeNode<T> Prev(BinarySearchTreeNode<T> node)
        {
            throw new NotImplementedException();
        }

        // TODO
        public List<BinarySearchTreeNode<T>> RangeSearch(int min, int max)
        {
            throw new NotImplementedException();
        }

        public void Remove(int key)
        {
            var node = GetNode(key);
            var parent = node.Parent;

            if (node == null)
            {
                return;
            }

            Count--;

            // 1) leaf node
            if (node.Left == null && node.Right == null)
            {
                if (parent.Left == node)
                {
                    parent.Left = null;
                    node.Parent = null;
                }
                else if (parent.Right == node)
                {
                    parent.Right = null;
                    node.Parent = null;
                }

                return;
            }

            // 2) parent with 1 child
            if (node.Left == null && node.Right != null)
            {
                // only has a right child
                var child = node.Right;
                if (parent.Left == node)
                {
                    parent.Left = child;
                    child.Parent = parent;
                }
                else if (parent.Right == node)
                {
                    parent.Right = child;
                    child.Parent = parent;
                }

                return;
            }

            if (node.Left != null && node.Right == null)
            {
                // only has a left child
                var child = node.Left;
                if (parent.Left == node)
                {
                    parent.Left = child;
                    child.Parent = parent;

                    node.Parent = null;
                    node.Left = null;
                }
                else if (parent.Right == node)
                {
                    parent.Right = child;
                    child.Parent = parent;

                    node.Parent = null;
                    node.Right = null;
                }

                return;
            }

            // 3) parent with 2 children
            // Find the node to remove
            // Find the next node (successor)
            // Swap Key and Data from successor to node
            // Remove the successor (a leaf node) (like case 1)





        }

        
        public T Search(int key)
        {
            if (Contains(key))
            {
                var node = GetNode(key);
                return node.Value;
            }

            else
            {
                return default(T);
            }
        }

        // TODO
        public void Update(int key, T value)
        {
            throw new NotImplementedException();
        }


        // TODO
        public List<int> InOrderKeys
        {
            get
            {
                List<int> keys = new List<int>();
                InOrderKeysRecursive(Root, keys);

                return keys;

            }
        }

        private void InOrderKeysRecursive(BinarySearchTreeNode<T> node, List<int> keys)
        {
            //left
            //root
            //right

            if(node == null)
            {
                return;
            }

            InOrderKeysRecursive(node.Left, keys);
            keys.Add(node.Key);
            InOrderKeysRecursive(node.Right, keys);
        }

        //TODO
        public List<int> PreOrderKeys
        {
            get
            {
                List<int> keys = new List<int>();
                PreOrderKeysRecursive(Root, keys);

                return keys;
            }
        }

        private void PreOrderKeysRecursive(BinarySearchTreeNode<T> node, List<int> keys)
        {
            //root
            //left
            //right
            if (node == null)
            {
                return;
            }

            PreOrderKeysRecursive(node.Left, keys);
            keys.Add(node.Key);
            PreOrderKeysRecursive(node.Right, keys);
        }

        // TODO
        public List<int> PostOrderKeys
        {
            get
            {
                List<int> keys = new List<int>();
                PostOrderKeysRecursive(Root, keys);
                return keys;
            }
        }

        Tuple<int, T> IBinarySearchTree<T>.Min => throw new NotImplementedException();

        Tuple<int, T> IBinarySearchTree<T>.Max => throw new NotImplementedException();

        private void PostOrderKeysRecursive(BinarySearchTreeNode<T> node, List<int> keys)
        {
            
        }

        public BinarySearchTreeNode<T> MinNode(BinarySearchTreeNode<T> node)
        {
            return MinNodeRecursive(node);
        }

        private BinarySearchTreeNode<T> MinNodeRecursive(BinarySearchTreeNode<T> node)
        {
            if (node.Left == null)
            {
                return node;
            }

            return MinNodeRecursive(node.Left);
        }

        public BinarySearchTreeNode<T> MaxNode(BinarySearchTreeNode<T> node)
        {
            return MaxNodeRecursive(node);
        }

        private BinarySearchTreeNode<T> MaxNodeRecursive(BinarySearchTreeNode<T> node)
        {
            if (node.Right == null)
            {
                return node;
            }

            return MaxNodeRecursive(node.Right);
        }


    }
}

