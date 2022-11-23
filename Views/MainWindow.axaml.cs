using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using HarfBuzzSharp;
using System.Collections.Generic;
using System;
using SkiaSharp;
using DynamicData;
using System.Xml.Linq;
using Avalonia.Utilities;

namespace Project.Views
{
    public partial class MainWindow : Window
    {
        public int number;
        public List<LinkedList<Vertex>> adjacency;
        public List<Vertex> vertices;
        public List<Edge> edges;
        public int[,] matrix;
        public Node root;
        public string shortestText = "";
        public string dfsText = "";
        public string bfsText = "";
        public string traverseText = "";
        public string treeText = "";
        public string searchText = "";
        public MainWindow()
        {
            InitializeComponent();
            txtDirection1.IsVisible = false;
            txtSource1.IsVisible = false;
            txtWeight1.IsVisible = false;
            AddEdge.IsVisible = false;
            txtDirection2.IsVisible = false;
            txtSource2.IsVisible = false;
            DeleteEdge.IsVisible = false;
            txtData1.IsVisible = false;
            AddVertex.IsVisible = false;
            txtData2.IsVisible = false;
            DeleteVertex.IsVisible = false;
            btnGraph.IsVisible = false;
            btnShortest.IsVisible = false;
            btnDepth.IsVisible = false;
            btnBreadth.IsVisible = false;
            btnNode.IsVisible = false;
            btnBack.IsVisible = false;
            btnNode.IsVisible = false;
            txtAddNode.IsVisible = false;
            btnAddNode.IsVisible = false;
            txtDeleteNode.IsVisible = false;
            btnDeleteNode.IsVisible = false;
            txtTraverse.IsVisible = false;
            btnTraverse.IsVisible = false;
            txtSearch.IsVisible = false;
            btnSearch.IsVisible = false;
            txtLevel.IsVisible = false;
            btnLevelr.IsVisible = false;

            this.adjacency = new List<LinkedList<Vertex>>();
            this.vertices = new List<Vertex>();
            this.edges = new List<Edge>();
            this.matrix = new int[5, 5];

        }

        //private string edu()
        //{
        //    this.vertices[0] = new Vertex('A');
        //    this.vertices[1] = new Vertex('B');
        //    this.vertices[2] = new Vertex('C');
        //    this.vertices[3] = new Vertex('D');
        //    this.vertices[4] = new Vertex('E');

        //    this.edges[0] = new Edge(0, 1, 25);
        //    this.edges[1] = new Edge(1, 2, 35);
        //    this.edges[2] = new Edge(2, 3, 45);
        //    this.edges[3] = new Edge(3, 4, 55);
        //    this.edges[4] = new Edge(4, 1, 65);

        //    string graphText = " ";
        //    for (int i = 0; i < this.vertices.Count; i++)
        //    {
        //        graphText = graphText + this.vertices[i].data;
        //    }

        //    graphText = graphText + " \n";
        //    foreach (Vertex vertex in this.vertices)
        //    {

        //        graphText = graphText + vertex.data + " ";
        //    }
        //    graphText = graphText + "\n";

        //    for (int i = 0; i < this.matrix.GetLength(0); i++)
        //    {
        //        Console.Write(this.vertices[i].data + " ");
        //        for (int j = 0; j < this.matrix.GetLength(1); j++)
        //        {
        //            graphText = graphText + this.matrix[i, j] + " ";

        //        }
        //        graphText = graphText + "\n";
        //    }
        //    graphText = graphText + "\n";
        //    return graphText;
        //}


        private void OnButtonClick(object sender, RoutedEventArgs e)
        {
            txtDirection1.IsVisible = false;
            txtSource1.IsVisible = false;
            txtWeight1.IsVisible = false;
            AddEdge.IsVisible = false;
            txtDirection2.IsVisible = false;
            txtSource2.IsVisible = false;
            DeleteEdge.IsVisible = false;
            txtData1.IsVisible = false;
            AddVertex.IsVisible = false;
            txtData2.IsVisible = false;
            DeleteVertex.IsVisible = false;
            string graphText = " ";
            graphText = graphText + "  ";
            foreach (Vertex vertex in this.vertices)
            {
                graphText = graphText + vertex.data + " ";
            }
            graphText = graphText + "\n";

            for (int i = 0; i < this.matrix.GetLength(0); i++)
            {
                graphText = graphText + this.vertices[i].data + " ";
                for (int j = 0; j < this.matrix.GetLength(1); j++)
                {
                    graphText = graphText + this.matrix[i, j] + " ";

                }
                graphText = graphText + "\n";
            }
            graphText = graphText + "\n";
            txtPrint.Text = graphText;
        }

        private void OnButtonClick2(object sender, RoutedEventArgs e)
        {
            sPHelper(weigthMatrix(this.matrix, this.edges), 0);
            txtPrint.Text = shortestText;
            shortestText = "";
        }

        private void OnButtonClick3(object sender, RoutedEventArgs e)
        {
            Boolean[] visited = new Boolean[matrix.GetLength(0)];
            dFSHelper(0, visited);
            dfsText = dfsText + "\n";

            txtPrint.Text = dfsText;
            dfsText = "";
        }

        private void OnButtonClick4(object sender, RoutedEventArgs e)
        {
            bFSHelper(0);
            txtPrint.Text = bfsText;
            bfsText = "";
        }

        private void OnButtonClick5(object sender, RoutedEventArgs e)
        {
            displayHelper(root, 1);
            txtPrint.Text = treeText;
            treeText = "";
        }

        private void OnButtonClick6(object sender, RoutedEventArgs e)
        {
            btnToGraph.IsVisible = false;
            btnToTree.IsVisible = false;
            btnEXit.IsVisible = false;
            btnBack.IsVisible = true;
            btnNode.IsVisible = true;
            txtAddNode.IsVisible = true;
            btnAddNode.IsVisible = true;
            txtDeleteNode.IsVisible = true;
            btnDeleteNode.IsVisible = true;
            txtTraverse.IsVisible = true;
            btnTraverse.IsVisible = true;
            txtLevel.IsVisible = true;
            btnLevelr.IsVisible = true;
        }

        private void OnButtonClick7(object sender, RoutedEventArgs e)
        {
            btnBack.IsVisible = true;
            btnEXit.IsVisible = false;
            btnToGraph.IsVisible = false;
            btnToTree.IsVisible = false;
            txtDirection1.IsVisible = true;
            txtSource1.IsVisible = true;
            txtWeight1.IsVisible = true;
            AddEdge.IsVisible = true;
            txtDirection2.IsVisible = true;
            txtSource2.IsVisible = true;
            DeleteEdge.IsVisible = true;
            txtData1.IsVisible = true;
            AddVertex.IsVisible = true;
            txtData2.IsVisible = true;
            DeleteVertex.IsVisible = true;
            btnGraph.IsVisible = true;
            btnShortest.IsVisible = true;
            btnDepth.IsVisible = true;
            btnBreadth.IsVisible = true;
        }

        private void OnButtonClick8(object sender, RoutedEventArgs e)
        {
            txtPrint.Text = "";
            txtDirection1.IsVisible = false;
            txtSource1.IsVisible = false;
            txtWeight1.IsVisible = false;
            AddEdge.IsVisible = false;
            txtDirection2.IsVisible = false;
            txtSource2.IsVisible = false;
            DeleteEdge.IsVisible = false;
            txtData1.IsVisible = false;
            AddVertex.IsVisible = false;
            txtData2.IsVisible = false;
            DeleteVertex.IsVisible = false;
            btnGraph.IsVisible = false;
            btnShortest.IsVisible = false;
            btnDepth.IsVisible = false;
            btnBreadth.IsVisible = false;
            btnNode.IsVisible = false;
            btnBack.IsVisible = false;
            btnToTree.IsVisible = true;
            btnToGraph.IsVisible = true;
            btnEXit.IsVisible = true;
            btnNode.IsVisible = false;
            txtAddNode.IsVisible = false;
            btnAddNode.IsVisible = false;
            txtDeleteNode.IsVisible = false;
            btnDeleteNode.IsVisible = false;
            txtTraverse.IsVisible = false;
            btnTraverse.IsVisible = false;
            txtSearch.IsVisible = false;
            btnSearch.IsVisible = false;
            txtLevel.IsVisible = false;
            btnLevelr.IsVisible = false;
        }

        private void OnButtonClick9(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void AddNode(object sender, RoutedEventArgs e)
        {
            Node node = new Node(int.Parse(txtAddNode.Text));
            root = insertHelper(root, node);
            txtAddNode.Text = "";
        }

        private void DeleteNode(object sender, RoutedEventArgs e)
        {
            int data = int.Parse(txtDeleteNode.Text);
            if (searchHelper(root, data))
            {

                removeHelper(root, data);
            }
            else
            {

                txtPrint.Text = txtPrint.Text + data + " couldn't be found";
            }
            txtPrint.Text = "";
            txtDeleteNode.Text = "";
        }

        private void SearchNode(object sender, RoutedEventArgs e)
        {
            int data = int.Parse(txtSearch.Text);
            searchHelper(root, data);
            txtPrint.Text = searchText;
            searchText = "";
        }

        private void LevelNode(object sender, RoutedEventArgs e)
        {
            int data = int.Parse(txtLevel.Text);
            txtPrint.Text = "Node with data " + data + " is in level: " + levelHelper(root, data, 1);
        }

        private void TraverseTree(object sender, RoutedEventArgs e)
        {
            string option = txtTraverse.Text;
            traverseHelper(root, option);
            txtPrint.Text = traverseText;
            traverseText = "";
        }

        private int levelHelper(Node root, int data, int level)
        {
            if (root == null)
            {
                return 0;
            }
            if (root.data == data)
            {
                return level;
            }
            int result = levelHelper(root.left, data, level + 1);
            if (result != 0)
            {
                return result;
            }
            result = levelHelper(root.right, data, level + 1);
            return result;
        }

        private void traverseHelper(Node root, string type)
        {

            if (root != null)
            {
                switch (type)
                {
                    case "Pre-Order":
                        traverseText = traverseText + root.data + " ";
                        traverseHelper(root.left, type);
                        traverseHelper(root.right, type);
                        break;
                    case "In-Order":
                        traverseHelper(root.left, type);
                        traverseText = traverseText + root.data + " ";
                        traverseHelper(root.right, type);
                        break;
                    case "Post-Order":
                        traverseHelper(root.left, type);
                        traverseHelper(root.right, type);
                        traverseText = traverseText + root.data + " ";
                        break;
                    default:
                        traverseText = traverseText + "That's not a traverse order.";
                        break;
                }

            }
        }

        private Boolean searchHelper(Node root, int data)
        {
            if (root == null)
            {
                searchText = searchText + data + " wasn't found";
                return false;
            }
            else if (root.data == data)
            {
                searchText = searchText + data + " was found";
                return true;
            }
            else if (root.data < data)
            {

                return searchHelper(root.left, data);
            }
            else
            {

                return searchHelper(root.right, data);
            }
        }

        private Node removeHelper(Node root, int data)
        {
            if (root == null)
            {

                return root;
            }
            else if (root.data < data)
            {

                root.left = removeHelper(root.left, data);
            }
            else if (root.data > data)
            {

                root.right = removeHelper(root.right, data);
            }
            else
            {
                if (root.left == null && root.right == null)
                {

                    root = null;
                }
                else if (root.right != null)
                {
                    root.data = successor(root);
                    root.right = removeHelper(root.right, root.data);

                }
                else
                {

                    root.data = predecessor(root);
                    root.left = removeHelper(root.left, root.data);
                }
            }

            return root;
        }

        private int successor(Node root)
        {

            root = root.right;
            while (root.left != null)
            {

                root = root.left;
            }
            return root.data;
        }

        private int predecessor(Node root)
        {

            root = root.left;
            while (root.right != null)
            {

                root = root.right;
            }
            return root.data;
        }

        private Node insertHelper(Node root, Node node)
        {
            int data = node.data;

            if (root == null)
            {
                root = node;
                return root;

            }
            else if (root.data < data)
            {

                root.left = insertHelper(root.left, node);

            }
            else
            {

                root.right = insertHelper(root.right, node);
            }

            return root;
        }

        private void displayHelper(Node node, int depth)
        {
            int h = height(node);
            int i;
            for (i = 1; i <= h; i++)
            {
                printGivenLevel(node, i);
                treeText = treeText + "\n";
            }
        }

        public int height(Node root)
        {
            if (root == null)
            {
                return 0;
            }
            else
            {
                /* compute height of each subtree */
                int lheight = height(root.left);
                int rheight = height(root.right);

                /* use the larger one */
                if (lheight > rheight)
                {
                    return (lheight + 1);
                }
                else
                {
                    return (rheight + 1);
                }
            }
        }

        public void printGivenLevel(Node root, int level)
        {
            if (root == null)
                return;
            if (level == 1)
            {
                treeText = treeText + root.data + " ";
            }
            else if (level > 1)
            {
                printGivenLevel(root.right, level - 1);
                printGivenLevel(root.left, level - 1);
            }
        }

        private void bFSHelper(int source)
        {
            Queue<int> queue = new Queue<int>();
            Boolean[] visited = new Boolean[matrix.GetLength(0)];

            queue.Enqueue(source);
            visited[source] = true;

            while (queue.Count != 0)
            {
                source = queue.Dequeue();
                bfsText = bfsText + vertices[source].data + " = visited";
                bfsText = bfsText + "\n";

                for (int i = 0; i < matrix.GetLength(1); i++)
                {
                    if (matrix[source, i] == 1 && !visited[i])
                    {
                        queue.Enqueue(i);
                        visited[i] = true;
                    }
                }
            }
            bfsText = bfsText + "\n";
        }

        private void dFSHelper(int source, Boolean[] visited)
        {

            if (visited[source])
            {
                return;

            }
            else
            {
                visited[source] = true;
                dfsText = dfsText + this.vertices[source].data + " = visited";
                dfsText = dfsText + "\n";
            }

            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                if (matrix[source, i] == 1)
                {

                    dFSHelper(i, visited);
                }
            }
            return;
        }

        private void sPHelper(int[,] weights, int source)
        {
            int[] distance = new int[this.matrix.GetLength(0)];
            Boolean[] visited = new Boolean[this.matrix.GetLength(1)];

            for (int i = 0; i < distance.Length; i++)
            {
                distance[i] = Int32.MaxValue;
                visited[i] = false;
            }

            distance[0] = 0;
            shortestText = shortestText + "Path: ";
            shortestText = shortestText + "\n";
            for (int j = 0; j < distance.Length; j++)
            {
                int m = minDistance(distance, visited);
                visited[m] = true;
                for (int k = 0; k < distance.Length; k++)
                {
                    if (!visited[k] && weights[m, k] != 0 && distance[m] != Int32.MaxValue
                        && distance[m] + weights[m, k] <= distance[k])
                    {
                        distance[k] = distance[m] + weights[m, k];
                        for (int e = 0; e < this.edges.Count; e++)
                        {
                            if (m == this.edges[e].source && k == this.edges[e].destination)
                            {
                                shortestText = shortestText + this.vertices[m].data + " -- > " + this.vertices[k].data + " || Price to pass: " + weights[m, k] + " || Price at the moment: " + distance[k];
                                shortestText = shortestText + "\n";
                            }
                        }
                    }
                }
            }
            showTravel(distance, this.vertices);
        }

        private int[,] weigthMatrix(int[,] matrix, List<Edge> edges)
        {
            int[,] weights = new int[matrix.GetLength(0), this.matrix.GetLength(1)];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == 1)
                    {
                        for (int k = 0; k < edges.Count; k++)
                        {
                            if (i == edges[k].source && j == edges[k].destination)
                            {
                                weights[i, j] = edges[k].weight;
                            }
                        }
                    }
                }
            }
            return weights;
        }

        private int minDistance(int[] distance, Boolean[] visited)
        {
            int index = -1;
            int min = Int32.MaxValue;
            for (int i = 0; i < this.matrix.GetLength(0); i++)
            {
                if (!visited[i] && distance[i] <= min)
                {
                    min = distance[i];
                    index = i;
                }
            }
            return index;
        }

        private void showTravel(int[] distance, List<Vertex> vertices)
        {
            shortestText = shortestText + "\n";
            shortestText = shortestText + "Cheapest price: " + distance[distance.Length - 1];
        }

        private void AddVertexButton(object sender, RoutedEventArgs e)
        {
            char data = char.Parse(txtData1.Text);
            Vertex vertex = new Vertex(data);
            this.vertices.Add(vertex);
            txtData1.Text = "";
        }

        private void DeleteVertexButton(object sender, RoutedEventArgs e)
        {
            char data = char.Parse(txtData1.Text);

            for (int i = 0; i < this.vertices.Count; i++)
            {
                if (data == this.vertices[i].data)
                {
                    Vertex vertex = this.vertices[i];
                    this.vertices.Remove(vertex);
                }
            }

            txtData1.Text = "";
        }

        private void enterEdge(object sender, RoutedEventArgs e)
        {
            //this.vertices.Add(new Vertex(char.Parse(txtSource.Text)));
            //txtSource.Text = "";


            int source = int.Parse(txtSource1.Text);
            int direction = int.Parse(txtDirection1.Text);
            int weight = int.Parse(txtWeight1.Text);
            Edge edge = new Edge(source, direction, weight);
            this.edges.Add(edge);

            this.matrix[source, direction] = 1;
            //LinkedList<Vertex> currentList = this.adjacency[source];
            //Vertex destinationVertex = (Vertex)this.adjacency[direction].ElementAt(0);
            //currentList.AddLast(destinationVertex);


            txtSource1.Text = "";
            txtDirection1.Text = "";
            txtWeight1.Text = "";
        }

        private void deleteEdge(object sender, RoutedEventArgs e)
        {
            int source = int.Parse(txtSource2.Text);
            int direction = int.Parse(txtDirection2.Text);

            for (int i = 0; i < this.edges.Count; i++)
            {
                if (source == this.edges[i].source && direction == this.edges[i].destination)
                {
                    Edge edge = this.edges[i];
                    this.edges.Remove(edge);
                }
            }
            this.matrix[source, direction] = 0;
            txtDirection2.Text = "";
            txtSource2.Text = "";
        }

    }

    public class Vertex
    {
        public char data;

        public Vertex(char data)
        {
            this.data = data;
        }
    }

    public class Edge
    {
        public int source;
        public int destination;
        public int weight;

        public Edge(int source, int destination, int weight)
        {
            this.source = source;
            this.destination = destination;
            this.weight = weight;

        }
    }

    public class Node
    {
        public int data;
        public Node left;
        public Node right;
        public List<Node> children;

        public Node(int data)
        {
            this.data = data;
            this.children = new List<Node>();
        }
    }
}
