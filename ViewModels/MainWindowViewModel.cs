using Avalonia.Controls;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Project.Views;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {

        public List<LinkedList<Vertex>> adjacency = new List<LinkedList<Vertex>>();
        public List<Vertex> vertices = new List<Vertex>();
        public List<Edge> edges = new List<Edge>();
        public int[,] matrix = new int[5, 5];


        
			//<TextBox Name = "txtData1" HorizontalAlignment="Center" VerticalAlignment="Center" Width="150"/>
			//<Button Name = "btnAddVertex"

   //                 Width="100"
			//		HorizontalAlignment="Center"
			//		VerticalAlignment="Center"
			//		Click="addVertex"
			//		Content="Add vertex" />

			//<TextBox Name = "txtData2" HorizontalAlignment="Center" VerticalAlignment="Center" Width="150"/>
			//<Button Name = "btnDeleteVertex"

   //                 Width="100"
			//		HorizontalAlignment="Center"
			//		VerticalAlignment="Center"
			//		Click="deleteVertex"
			//		Content="Delete vertex"/>


        public static string Greeting => "Hola";
        //public string Perro => imprimir();
        

        

        //private string imprimir()
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
    }
}
