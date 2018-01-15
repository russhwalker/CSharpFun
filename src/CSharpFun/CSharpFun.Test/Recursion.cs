using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CompSci.Test
{
    [TestClass]
    public class Recursion
    {


        private void PrintNode(StringBuilder stringBuilder, Node node, int level = 0)
        {
            stringBuilder.AppendLine($"{"".PadRight(level, '-')}{node.NodeText}");
            if (node.Nodes == null)
            {
                return;
            }
            level++;
            foreach (var childNode in node.Nodes)
            {
                PrintNode(stringBuilder, childNode, level);
            }
        }

        [TestMethod]
        public void PrintNodes()
        {
            var node = new Node
            {
                NodeText = "Main",
                Nodes = new List<Node>
                    {
                        new Node
                        {
                            NodeText = "X",
                            Nodes = new List<Node>
                            {
                                new Node
                                {
                                    NodeText = "X",
                                    Nodes = new List<Node>
                                    {
                                        new Node
                                        {
                                            NodeText = "X",
                                        },
                                        new Node
                                        {
                                            NodeText = "X",
                                        }
                                    }
                                },
                                new Node
                                {
                                    NodeText = "X"
                                }
                            }
                        },
                        new Node
                        {
                            NodeText = "X"
                        },
                        new Node
                        {
                            NodeText = "X",
                            Nodes = new List<Node>
                            {
                                new Node
                                {
                                    NodeText = "X",
                                    Nodes = new List<Node>
                                    {
                                        new Node
                                        {
                                            NodeText = "X",
                                            Nodes = new List<Node>
                                            {
                                                new Node
                                                {
                                                    NodeText = "X",
                                                    Nodes = new List<Node>
                                                    {
                                                        new Node
                                                        {
                                                            NodeText = "X"
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
            };
            var stringBuilder = new StringBuilder();
            PrintNode(stringBuilder, node);
            var result = stringBuilder.ToString().Trim();
            Console.WriteLine(result);
            Assert.AreEqual(
@"Main
-X
--X
---X
---X
--X
-X
-X
--X
---X
----X
-----X", result);
        }

    }

    public class Node
    {
        public string NodeText { get; set; }
        public List<Node> Nodes { get; set; }
    }

}