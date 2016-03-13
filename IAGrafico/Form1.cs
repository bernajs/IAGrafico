using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IAGrafico
{
    public partial class Form1 : Form
    {
        int[,] nodoInicio = new int[3, 3];
        int [,]nodoMeta = new int[3, 3];
        int [,]nodoArriba = new int[3,3];
        int [,]nodoDerecha = new int[3,3];
        int [,]nodoAbajo = new int[3,3];
        int [,]nodoIzquierda = new int[3, 3];
        int contadorNodos = 0;

        int arriba = 1000, abajo = 1000, derecha = 1000, izquierda = 1000, aux;

        int posicioni = 0;
        int posicionj = 0;
        public int diferencia = -1;
        String valoresCadena = "";
        String[] valores;

        public Form1()
        {
            InitializeComponent();
        }
                private void button1_Click(object sender, EventArgs e)
        {
            //Obtiene valores de los TextBox y los guarda en nodoInicio
            nodoInicio[0, 0] = int.Parse(ni00.Text);
            nodoInicio[0, 1] = int.Parse(ni01.Text);
            nodoInicio[0, 2] = int.Parse(ni02.Text);
            nodoInicio[1, 0] = int.Parse(ni10.Text);
            nodoInicio[1, 1] = int.Parse(ni11.Text);
            nodoInicio[1, 2] = int.Parse(ni12.Text);
            nodoInicio[2, 0] = int.Parse(ni20.Text);
            nodoInicio[2, 1] = int.Parse(ni21.Text);
            nodoInicio[2, 2] = int.Parse(ni22.Text);

             //Obtiene los valores de nodoMeta
            nodoMeta[0, 0] = int.Parse(nm00.Text);
            nodoMeta[0, 1] = int.Parse(nm01.Text);
            nodoMeta[0, 2] = int.Parse(nm02.Text);
            nodoMeta[1, 0] = int.Parse(nm10.Text);
            nodoMeta[1, 1] = int.Parse(nm11.Text);
            nodoMeta[1, 2] = int.Parse(nm12.Text);
            nodoMeta[2, 0] = int.Parse(nm20.Text);
            nodoMeta[2, 1] = int.Parse(nm21.Text);
            nodoMeta[2, 2] = int.Parse(nm22.Text);

            //Pasa los valores de nodoInicio a las otras matrices
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                nodoArriba[i, j] = nodoInicio[i, j];
                nodoDerecha[i, j] = nodoInicio[i, j];
                nodoAbajo[i, j] = nodoInicio[i, j];
                nodoIzquierda[i, j] = nodoInicio[i, j];

                if (nodoInicio[i, j] == 0) {
                    posicioni = i;
                    posicionj = j;
                        }   
                     }
            }
            BackTracking();
            //na00.Text = nodoInicio[0, 0].ToString();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        public void BackTracking()
        {
            do
            {
                Arriba();
                Derecha();
                Abajo();
                Izquierda();
                Condiciones();
            } while (diferencia != 0);
        }
        public void Arriba()
        {
            if ((posicioni - 1) >= 1)
            {

                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (nodoArriba[i, j] == 0 && i >= 1)
                        {
                                posicioni = i;
                                posicionj = j;
                            aux = nodoArriba[posicioni - 1, posicionj];
                            nodoArriba[posicioni - 1, posicionj] = 0;
                            nodoArriba[posicioni, posicionj] = aux;
                            arriba = diferencias(nodoArriba, nodoMeta);
                            i = 2;
                            j = 2;
                        }
                    }
                }
                }
        }
            

        public void Derecha()
        {
            if (posicionj + 1 <= 1) {

                                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (nodoDerecha[i, j] == 0 && j <= 1)
                        {
                                posicioni = i;
                                posicionj = j;
                                aux = nodoDerecha[posicioni, posicionj + 1];
                                nodoDerecha[posicioni, posicionj + 1] = 0;
                                nodoDerecha[posicioni, posicionj] = aux;
                                derecha = diferencias(nodoDerecha, nodoMeta);
                                i = 2;
                                j = 2;
                        }
                    }
                }
            }
        }

        public void Abajo()
        {
                        if (posicioni + 1 <= 1) {

                            for (int i = 0; i < 3; i++)
                            {
                                for (int j = 0; j < 3; j++)
                                {
                                    if (nodoAbajo[i, j] == 0 && i <= 1)
                                    {
                                        posicioni = i;
                                        posicionj = j;
                                        aux = nodoAbajo[posicioni + 1, posicionj];

                                        nodoAbajo[posicioni + 1, posicionj] = 0;
                                        nodoAbajo[posicioni, posicionj] = aux;
                                        abajo = diferencias(nodoAbajo, nodoMeta);
                                        i = 2;
                                        j = 2;
                                    }
                                }
                            }
            }
        }

        public void Izquierda()
        {
                        if (posicionj - 1 >= 1) {

                            for (int i = 0; i < 3; i++)
                            {
                                for (int j = 0; j < 3; j++)
                                {
                                    if (nodoIzquierda[i, j] == 0 && j >= 1)
                                    {
                                        posicioni = i;
                                        posicionj = j;
                                        aux = nodoIzquierda[posicioni, posicionj - 1];
                                        nodoIzquierda[posicioni, posicionj - 1] = 0;
                                        nodoIzquierda[posicioni, posicionj] = aux;
                                        izquierda = diferencias(nodoIzquierda, nodoMeta);
                                        i = 2;
                                        j = 2;
                                    }
                                }
                            }
            }
        }

        public void Condiciones()
        {
                if (arriba <= izquierda && arriba <= derecha && arriba <= abajo && izquierda != 0 & derecha != 0 && abajo != 0) {
                    estado.Text = "El mejor movimiento es hacia arriba, tiene " + arriba + " movimientos";

                    na00.Text = nodoArriba[0, 0].ToString();
                    na01.Text = nodoArriba[0, 1].ToString();
                    na02.Text = nodoArriba[0, 2].ToString();
                    na10.Text = nodoArriba[1, 0].ToString();
                    na11.Text = nodoArriba[1, 1].ToString();
                    na12.Text = nodoArriba[1, 2].ToString();
                    na20.Text = nodoArriba[2, 0].ToString();
                    na21.Text = nodoArriba[2, 1].ToString();
                    na22.Text = nodoArriba[2, 2].ToString();
                    nodos.Items.Add("Nodo " + contadorNodos++);


                for (int i = 0; i < 3; i++) {
                    for (int j = 0; j < 3; j++) {
                        if (nodoArriba[i,j] == 0) {

                            posicioni = i;
                            posicionj = j;
                        }
                        nodoAbajo[i,j] = nodoArriba[i,j];
                        nodoIzquierda[i,j] = nodoArriba[i,j];
                        nodoDerecha[i,j] = nodoArriba[i,j];
                    }
                }
                diferencia = arriba;
            } else if (derecha <= izquierda && derecha <= arriba && derecha <= abajo && izquierda != 0 & arriba != 0 && abajo != 0) {
                estado.Text = "El mejor movimiento es hacia derecha, tiene " + derecha + " movimientos";
                na00.Text = nodoDerecha[0, 0].ToString();
                na01.Text = nodoDerecha[0, 1].ToString();
                na02.Text = nodoDerecha[0, 2].ToString();
                na10.Text = nodoDerecha[1, 0].ToString();
                na11.Text = nodoDerecha[1, 1].ToString();
                na12.Text = nodoDerecha[1, 2].ToString();
                na20.Text = nodoDerecha[2, 0].ToString();
                na21.Text = nodoDerecha[2, 1].ToString();
                na22.Text = nodoDerecha[2, 2].ToString();
                nodos.Items.Add("Nodo " + contadorNodos++);


                for (int i = 0; i < 3; i++) {
                    for (int j = 0; j < 3; j++) {
                        if (nodoDerecha[i,j] == 0) {
                            posicioni = i;
                            posicionj = j;
                        }
                        nodoAbajo[i,j] = nodoDerecha[i,j];
                        nodoArriba[i,j] = nodoDerecha[i,j];
                        nodoIzquierda[i,j] = nodoDerecha[i,j];
                    }
                }
                diferencia = derecha;
            } else if (abajo <= izquierda && abajo <= derecha && abajo <= arriba && izquierda != 0 & derecha != 0 && arriba != 0) {

                na00.Text = nodoAbajo[0, 0].ToString();
                na01.Text = nodoAbajo[0, 1].ToString();
                na02.Text = nodoAbajo[0, 2].ToString();
                na10.Text = nodoAbajo[1, 0].ToString();
                na11.Text = nodoAbajo[1, 1].ToString();
                na12.Text = nodoAbajo[1, 2].ToString();
                na20.Text = nodoAbajo[2, 0].ToString();
                na21.Text = nodoAbajo[2, 1].ToString();
                na22.Text = nodoAbajo[2, 2].ToString();
                nodos.Items.Add("Nodo " + contadorNodos++);


                estado.Text = "El mejor movimiento es hacia abajo, tiene " + abajo + " movimientos";
                for (int i = 0; i < 3; i++) {
                    for (int j = 0; j < 3; j++) {
                        if (nodoAbajo[i,j] == 0) {
                            posicioni = i;
                            posicionj = j;
                        }
                        nodoIzquierda[i,j] = nodoAbajo[i,j];
                        nodoArriba[i,j] = nodoAbajo[i,j];
                        nodoDerecha[i,j] = nodoAbajo[i,j];
                    }
                }
                diferencia = abajo;
            } else if (izquierda <= derecha && izquierda <= abajo && izquierda <= arriba && derecha != 0 & abajo != 0 && arriba != 0) {

                estado.Text = "El mejor movimiento es hacia izquierda, tiene " + izquierda + " movimientos";

            na00.Text = nodoIzquierda[0, 0].ToString();
            na01.Text = nodoIzquierda[0, 1].ToString();
            na02.Text = nodoIzquierda[0, 2].ToString();
            na10.Text = nodoIzquierda[1, 0].ToString();
            na11.Text = nodoIzquierda[1, 1].ToString();
            na12.Text = nodoIzquierda[1, 2].ToString();
            na20.Text = nodoIzquierda[2, 0].ToString();
            na21.Text = nodoIzquierda[2, 1].ToString();
            na22.Text = nodoIzquierda[2, 2].ToString();
            nodos.Items.Add("Nodo " + contadorNodos++);

                for (int i = 0; i < 3; i++) {
                    for (int j = 0; j < 3; j++) {
                        if (nodoIzquierda[i,j] == 0) {
                            posicioni = i;
                            posicionj = j;
                        }
                        nodoAbajo[i,j] = nodoIzquierda[i,j];
                        nodoArriba[i,j] = nodoIzquierda[i,j];
                        nodoDerecha[i,j] = nodoIzquierda[i,j];
                    }
                }
                diferencia = izquierda;
            }
        }

       public static int diferencias(int[,] arreglo1, int[,] arreglo2)
        {
        int cont = 0;
        for (int i = 0; i < 3; i++) {
            for (int j = 0; j < 3; j++) {
                if (arreglo1[i,j] != arreglo2[i,j]) {
                    cont++;
                }
            }
        }
        return cont;
        }
    }
}
