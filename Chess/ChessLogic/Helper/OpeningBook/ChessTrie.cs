using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLogic.Helper.OpeningBook
{
    public class ChessTrie
    {
        class TrieNode
        {
            public Dictionary<string, TrieNode> Children { get; set; } = new Dictionary<string, TrieNode>();
            public bool IsEndOfWord { get; set; }

            public TrieNode()
            {
                Children = new Dictionary<string, TrieNode>();
                IsEndOfWord = false;
            }
        }

        class OpeningTrie
        {
            private TrieNode root;
            public OpeningTrie()
            {
                root = new TrieNode();
            }

            public void Insert(string opening, string moveSequence)
            {
                TrieNode currentNode = root;
             
                string[] moves = moveSequence.Split(' ');

                foreach (string move in moves)
                {
                    if (!currentNode.Children.ContainsKey(move))
                    {
                        currentNode.Children[move] = new TrieNode();
                    }
                    currentNode = currentNode.Children[move];
                }
                currentNode.IsEndOfWord = true;
            }
        }
    }
}
