using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ChessLogic.Helper.OpeningBook
{
    public class ChessTrie
    {
        public class TrieNode
        {
            public string Move { get; private set; }
            private Dictionary<string, TrieNode> _children { get; set; } = new Dictionary<string, TrieNode>();
            public bool IsEndOfWord { get; set; }

            public Dictionary<string, TrieNode> Children
            {
                get { return _children; }
            }
            public TrieNode(string move)
            {
                Move = move;
                _children = new Dictionary<string, TrieNode>();
            }
        }

        public class Trie
        {
            public TrieNode root
            {
                get; private set;
            }

            public Trie()
            {
                root = new TrieNode(null);
            }

            public void AddMove(List<string> moveSequence)
            {
                TrieNode currentNode = root;

                foreach (var move in moveSequence)
                {
                    if (!currentNode.Children.ContainsKey(move))
                    {
                        currentNode.Children[move] = new TrieNode(move);
                    }
                    currentNode = currentNode.Children[move];
                }
                currentNode.IsEndOfWord = true;
            }

            public bool SearchMove(List<string> moves)
            {
                TrieNode curNode = root;

                foreach (var move in moves)
                {
                    if (!curNode.Children.ContainsKey(move))
                    {
                        return false; // Move not found in the trie
                    }
                    curNode = curNode.Children[move];
                }
                return true; // All moves found in the trie
            }

            public void PrintTree (TrieNode node, List<string> curMove = null, string prefix = "")
            {
                if (node == null) return;
                 
                //if (node.Move != null && node.Move != string.Empty)
                //{
                //    prefix += node.Move + " ";
                //    Debug.WriteLine(prefix); // Print the current move with prefix
                //}
                //else
                //{
                //    prefix = string.Empty; // Reset prefix for root node
                //    Debug.WriteLine(prefix);
                //}

                //if (node.IsEndOfWord)
                //{
                //    Debug.WriteLine(prefix);
                //}

                //foreach (var child in node.Children)
                //{
                //    PrintTree(child.Value, prefix + child.Key + " ");
                //}

                //---
                //if (node.Move != null)
                //    Debug.WriteLine(prefix + node.Move);

                //foreach (var child in node.Children.Values)
                //{
                //    PrintTree(child, prefix + " ");
                //}

                //---

                if (node == null) return;

                if (curMove == null)
                    curMove = new List<string>();

                if (node.Move != null)
                    curMove.Add(node.Move);

                Debug.WriteLine(prefix + string.Join("->", curMove));

                foreach(var child in node.Children.Values)
                {
                    PrintTree(child, new List<string>(curMove), prefix + " ");
                }
            }
        }
    }
}
