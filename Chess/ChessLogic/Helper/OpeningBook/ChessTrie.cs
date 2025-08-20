using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
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

            public int Count { get; set; } = 0; // Count for fruency or occurrences to add in json

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
                currentNode.Count++; // Increment the count for this move sequence
            }

            public void AddSingelMove(string move)
            {
                TrieNode curNode = root;

                if (!curNode.Children.ContainsKey(move))
                {
                    curNode.Children[move] = new TrieNode(move);
                }

                curNode = curNode.Children[move];

                curNode.IsEndOfWord = true; // Mark the end of the word
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

            #region print 1
            public void PrintTree(TrieNode node, List<string> curMove = null, string prefix = "")
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

                foreach (var child in node.Children.Values)
                {
                    PrintTree(child, new List<string>(curMove), prefix + " ");
                }
            }
            #endregion

            public void PrintTree2(TrieNode node = null, string indent = "", bool isLast = true)
            {
                if (node == null)
                    node = root;

                string display = node.Move ?? "ROOT";
                Debug.WriteLine(indent + (isLast ? "└── " : "├── ") + display);

                indent += isLast ? "    " : "│   ";

                var children = node.Children.Values.ToList();
                for (int i = 0; i < children.Count; i++)
                {
                    PrintTree2(children[i], indent, i == children.Count - 1);
                }

            }

            public string ToJSon()
            {
                var dict = NodeToDict(root);
                return JsonSerializer.Serialize(dict, new JsonSerializerOptions { WriteIndented = true });
            }

            private Dictionary<string, object> NodeToDict(TrieNode node)
            {
                var dict = new Dictionary<string, object>();


                foreach (var child in node.Children)
                {
                    dict[child.Key] = NodeToDict(child.Value);
                }

                if (node.IsEndOfWord)
                {
                    dict["$"] = true; // Mark this node as the end of a word
                }

                return dict;
            }

            public void ExportToJson(string filePath)
            {
                var allPaths = new List<List<string>>();
                CollectPaths(root, new List<string>(), allPaths);

                var options = new JsonSerializerOptions
                {
                    WriteIndented = true
                };

                string json = JsonSerializer.Serialize(allPaths, options);
                File.WriteAllText(filePath, json);
            }

            private void CollectPaths(TrieNode node, List<string> curPath, List<List<string>> result)
            {
                if (node.Move != null)
                {
                    curPath.Add(node.Move);
                }

                if (node.IsEndOfWord)
                {
                    result.Add(new List<string>(curPath));
                }

                foreach (var child in node.Children.Values)
                {
                    CollectPaths(child, new List<string>(curPath), result);
                }
            }

            public void ImportJson(string filePath)
            {
                string json = File.ReadAllText(filePath);
                var moveLists = JsonSerializer.Deserialize<List<List<string>>>(json);

                foreach (var moveList in moveLists)
                {
                    AddMove(moveList);
                }
            }

            public class MovePathWithCount
            {
                public List<string> Moves { get; set; }
                public int Count { get; set; }
            }
            private void CollectPathsWithCount(TrieNode node, List<string> curPath, List<MovePathWithCount> result)
            {
                if (node.Move != null)
                {
                    curPath.Add(node.Move);
                }

                if (node.IsEndOfWord && node.Count > 0)
                {
                    result.Add(new MovePathWithCount
                    {
                        Moves = new List<string>(curPath),
                        Count = node.Count
                    });
                }

                foreach (var child in node.Children.Values)
                {
                    CollectPathsWithCount(child, new List<string>(curPath), result);
                }
            }

            public void ExportToJsonWithCount(string filePath)
            {
                var paths = new List<MovePathWithCount>();
                CollectPathsWithCount(root, new List<string>(), paths);

                var options = new JsonSerializerOptions
                {
                    WriteIndented = true
                };

                string json = JsonSerializer.Serialize(paths, options);
                File.WriteAllText(filePath, json);
            }

            public void ImportJsonWithCount(string filePath)
            {
                string json = File.ReadAllText(filePath);
                var moveLists = JsonSerializer.Deserialize<List<MovePathWithCount>>(json);

                foreach ( var movePath in moveLists)
                {
                    for (int i = 0; i < movePath.Count; i++)
                    {
                        AddMove(movePath.Moves); // Add the move sequence multiple times based on the count
                    }
                }
            }
        }
    }
}
