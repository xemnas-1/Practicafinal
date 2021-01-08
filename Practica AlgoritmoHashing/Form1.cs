using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Dynamic;
using System.Diagnostics;

namespace Practica_AlgoritmoHashing
{
    public partial class FrmInicio : Form
    {
        public FrmInicio()
        {
            InitializeComponent();
            SetStyle(ControlStyles.SupportsTransparentBackColor,
                     true);
        }

        public Indice[] Tablas = new Indice[250];
        public String[] Alfabeto = new String[26];


        public void LLenarAlfabeto()
        {
            int c = 1;

            char inicio = 'A';

            Alfabeto[0] = inicio.ToString();

            while (inicio < 'Z')
            {
                inicio++;
                Alfabeto[c] = inicio.ToString();
                c++;

            }

            for (int x = 0; x < Tablas.Length; x++)
            {
                Tablas[x] = new Indice();
                Tablas[x].Memoria = x;
            }
        }      
        private void FrmInicio_Load(object sender, EventArgs e)
        {
            LLenarAlfabeto();
            //solamente sirve para diseño
            Cprogreso.Value += 1;
            if (Cprogreso.Value == 100)
            {
                Cprogreso.Value = 0;
            }
            else {
                if (Cprogreso.Value == 0)
                {
                    Cprogreso.Value +=1;
               }
            }
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            Ingresando_Busqueda(txtIngresar.Text);
            LLenarTabla();
        }

        public void LLenarTabla()
        {

            Tabla.Rows.Clear();

            for (int x = 1; x < Tablas.Length; x++)
            {

                if (Tablas[x].Colicion == 221)
                {
                    Tabla.Rows.Add(Tablas[x].Memoria, Tablas[x].ClaveBusqueda, "");
                }
                else
                {
                    Tabla.Rows.Add(Tablas[x].Memoria, Tablas[x].ClaveBusqueda, Tablas[x].Colicion);
                }
            }
        }
        //Aqui es de buscar la letras en alfabeticamento.
        public int Buscar(String letra)
        {
            int salida = 0;

            for (int x = 0; x < Alfabeto.Length; x++)
            {

                if (Alfabeto[x] == letra)
                {
                    salida = x;
                    break;
                }
            }
            return salida;
        }

        //aqui inicia la busqueda, pero primero transforma las letras String a un numero int.
        public void Ingresando_Busqueda(String ClaveBusqueda)
        {
            int Clave = 1;

            foreach (char letras in ClaveBusqueda)
            {
                Clave += Buscar(letras.ToString());
            }

        //Buscar la Clave
            if (Tablas[Clave].ClaveBusqueda == "")
            {
                Tablas[Clave].ClaveBusqueda = ClaveBusqueda;
                MessageBox.Show("Fue Agregada en la Posicion " + Clave.ToString());
            }
            else
            {
                if (Tablas[Clave].ClaveBusqueda != ClaveBusqueda)
                {
                    if (Tablas[Clave].Colicion != 221)
                    {
                        int C = Tablas[Clave].Colicion;
                    }
                    else
                    {
                        NuevaColicion(Clave, ClaveBusqueda);
                    }
                }
                else
                {
                    MessageBox.Show("Se encontro en la Posicion " + Clave.ToString());
                }
            }

        }
        //Cuando pasa una nueva colision.
        public void NuevaColicion(int Clave, String ClaveBusqueda)
        {

            for (int x = 249; x > 0; x--)
            {
                if (Tablas[x].ClaveBusqueda == "")
                {
                    Tablas[Clave].Colicion = x;
                    Tablas[x].ClaveBusqueda = ClaveBusqueda;
                    MessageBox.Show("Fue Agregada en la Posicion " + x.ToString());
                    break;
                }
            }
        }
        public class Indice
        {
            public int Memoria = 221;
            public String ClaveBusqueda = "";
            public int Colicion = 221;

            public Indice(int m, String cb, int c)
            {
                Memoria = m;
                cb = ClaveBusqueda;
                c = Colicion;
            }

            public Indice()
            {
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        { 
            label2.Text = "   Cerrando";
                Close();
           
        }

        private void Cprogreso_Click(object sender, EventArgs e)
        {

        }

        private void btnbuscar_Click(object sender, EventArgs e)
        {

        }
    }
}
