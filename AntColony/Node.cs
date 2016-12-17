﻿using DataStructures;
using Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntColony
{
    internal class Node
    {
        private MathMatrix<decimal> matrix;
        private int sense;
        public readonly List<Node> connectedNodes;
        public readonly List<Ant> antsOnNode;
        private string hashCode = null;

        public Node(MathMatrix<decimal> newMatrix)
        {
            matrix = newMatrix;
            sense = 1;
            connectedNodes = new List<Node>();
            antsOnNode = new List<Ant>();
        }

        public string HashCode
        {
            get
            {
                if(hashCode == null)
                {
                    hashCode = matrix.GetMatrixHash();
                }
                return hashCode;
            }
        }

        public MathMatrix<decimal> Matrix
        {
            get { return matrix; }
        }

        public int AntNumberOnNode
        {
            get
            {
                return antsOnNode.Count;
            }
        }

        public int Sense
        {
            get
            {
                return sense;
            }
            set
            {
                if (value >= sense)
                {
                    sense = 1;
                }
                else
                {
                    sense = value;
                }
            }
        }
    }
}