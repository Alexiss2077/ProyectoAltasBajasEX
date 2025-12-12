using System;
using System.Collections.Generic;  ///////////////////////rrrrrrr
using System.Windows.Forms;

namespace ProyectoAltasBajasEX
{
    public partial class Form1 : Form
    {
        // Diccionario de carreras y materias 
        Dictionary<string, List<string>> materiasPorCarrera = new Dictionary<string, List<string>>()
{
            ///// Ingeniería en Informática
            { "Ingeniería en Informática", new List<string>()
                {
                    "Fundamentos de Programación",
                    "Matemáticas I",
                    "Física I",
                    "Inglés I",
                    "Introducción a la Ingeniería",
                    "Estructura de Datos",
                    "Programación Orientada a Objetos",
                    "Base de Datos I",
                    "Matemáticas Discretas",
                    "Arquitectura de Computadoras"
                }
            },

            ///// Gestión Empresarial
            { "Gestión Empresarial", new List<string>()
                {
                    "Contabilidad I",
                    "Derecho Mercantil",
                    "Matemáticas Financieras",
                    "Inglés I",
                    "Administración I",
                    "Economía Empresarial",
                    "Desarrollo Organizacional",
                    "Mercadotecnia I",
                    "Habilidades Directivas",
                    "Estadística Aplicada"
                }
            },

            ///// Energías Renovables 
            { "Energías Renovables", new List<string>()
                {
                    "Administración I",
                    "Economía I",
                    "Matemáticas I",
                    "Inglés I",
                    "Comportamiento Organizacional",
                    "Fundamentos de Energías Renovables",
                    "Electricidad y Magnetismo",
                    "Termodinámica Aplicada",
                    "Sistemas Fotovoltaicos",
                    "Eficiencia Energética",
                    "Fuentes Alternas de Energía",
                    "Impacto Ambiental"
                }
            },

            ///// Ingeniería Mecánica
            { "Ingeniería Mecánica", new List<string>()
                {
                    "Cálculo Diferencial",
                    "Álgebra Lineal",
                    "Física Mecánica",
                    "Introducción a la Ingeniería",
                    "Química Básica",
                    "Dibujo Industrial",
                    "Materiales de Ingeniería",
                    "Estática",
                    "Dinámica",
                    "Termodinámica",
                    "Procesos de Manufactura",
                    "Resistencia de Materiales"
                }
            }
        };

        public Form1()
        {
            InitializeComponent();
            CargarCarreras();
            CargarSemestres();
        }

        
        private void CargarCarreras()
        {
            cmbCarrera.Items.Add("Ingeniería en Informática");
            cmbCarrera.Items.Add("Gestión Empresarial");
            cmbCarrera.Items.Add("Energías Renovables");
            cmbCarrera.Items.Add("Ingeniería Mecánica");
        }

      
        private void CargarSemestres()
        {
            cmbSemestre.Items.Add("1");
            cmbSemestre.Items.Add("2");
            cmbSemestre.Items.Add("3");
        }

        
        private void cmbCarrera_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbMateria.Items.Clear();

            if (cmbCarrera.SelectedIndex == -1)
                return;

            string carrera = cmbCarrera.SelectedItem.ToString();

            foreach (string materia in materiasPorCarrera[carrera])
            {
                cmbMateria.Items.Add(materia);
            }
        }

        // ALTA (inscribir materia)
        private void btnAlta_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text == "" || txtMatricula.Text == "" ||
                cmbCarrera.SelectedIndex == -1 || cmbSemestre.SelectedIndex == -1 ||
                cmbMateria.SelectedIndex == -1)
            {
                MessageBox.Show("Todos los campos son obligatorios.");
                return;
            }

            dgvCalificaciones.Rows.Add(
                txtNombre.Text,
                txtMatricula.Text,
                cmbCarrera.SelectedItem.ToString(),
                cmbSemestre.SelectedItem.ToString(),
                cmbMateria.SelectedItem.ToString()
            );

            MessageBox.Show("Materia inscrita correctamente.");
        }

        // BAJA (eliminar inscripción)
        private void btnBaja_Click(object sender, EventArgs e)
        {
            if (dgvCalificaciones.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecciona una materia para eliminar.");
                return;
            }

            dgvCalificaciones.Rows.RemoveAt(dgvCalificaciones.SelectedRows[0].Index);

            MessageBox.Show("Materia eliminada correctamente.");
        }

        // Limpiar campos
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtNombre.Clear();
            txtMatricula.Clear();
            cmbCarrera.SelectedIndex = -1;
            cmbSemestre.SelectedIndex = -1;
           
        }
    }
}
