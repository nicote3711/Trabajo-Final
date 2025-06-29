using BLL;
using ENTITY;
using Newtonsoft.Json;
using Org.BouncyCastle.Tls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class FormLlenadoDeDatos : Form
    {
        public FormLlenadoDeDatos()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void FormLlenadoDeDatos_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void btnGenerarClientes_Click(object sender, EventArgs e)
        {
            string personasJson = @"[
            {
            ""Nombre"": ""Sofía"",
            ""Apellido"": ""Gómez"",
            ""DNI"": ""28123456"",
            ""CuitCuil"": ""27-28123456-9"",
            ""FechaNacimiento"": ""1980-03-15"",
            ""Email"": ""sofia.gomez@example.com"",
            ""Telefono"": ""+5491155551234""
            },
            {
            ""Nombre"": ""Juan"",
            ""Apellido"": ""Pérez"",
            ""DNI"": ""30987654"",
            ""CuitCuil"": ""20-30987654-8"",
            ""FechaNacimiento"": ""1975-11-22"",
            ""Email"": ""juan.perez@example.com"",
            ""Telefono"": ""+5491155555678""
            },
            {
            ""Nombre"": ""Mariana"",
            ""Apellido"": ""Rodríguez"",
            ""DNI"": ""35456789"",
            ""CuitCuil"": ""27-35456789-2"",
            ""FechaNacimiento"": ""1992-07-01"",
            ""Email"": ""mariana.rodriguez@example.com"",
            ""Telefono"": ""+5491155559012""
            },
            {
            ""Nombre"": ""Lucas"",
            ""Apellido"": ""Fernández"",
            ""DNI"": ""32109876"",
            ""CuitCuil"": ""20-32109876-0"",
            ""FechaNacimiento"": ""1988-01-28"",
            ""Email"": ""lucas.fernandez@example.com"",
            ""Telefono"": ""+5491155553456""
            },
            {
            ""Nombre"": ""Valentina"",
            ""Apellido"": ""Díaz"",
            ""DNI"": ""40112233"",
            ""CuitCuil"": ""27-40112233-5"",
            ""FechaNacimiento"": ""1995-09-10"",
            ""Email"": ""valentina.diaz@example.com"",
            ""Telefono"": ""+5491155557890""
            },
            {
            ""Nombre"": ""Martín"",
            ""Apellido"": ""García"",
            ""DNI"": ""29876543"",
            ""CuitCuil"": ""20-29876543-7"",
            ""FechaNacimiento"": ""1983-05-03"",
            ""Email"": ""martin.garcia@example.com"",
            ""Telefono"": ""+5491155552345""
            },
            {
            ""Nombre"": ""Camila"",
            ""Apellido"": ""Martínez"",
            ""DNI"": ""38765432"",
            ""CuitCuil"": ""27-38765432-1"",
            ""FechaNacimiento"": ""1990-12-19"",
            ""Email"": ""camila.martinez@example.com"",
            ""Telefono"": ""+5491155556789""
            },
            {
            ""Nombre"": ""Diego"",
            ""Apellido"": ""López"",
            ""DNI"": ""31234567"",
            ""CuitCuil"": ""20-31234567-6"",
            ""FechaNacimiento"": ""1978-08-07"",
            ""Email"": ""diego.lopez@example.com"",
            ""Telefono"": ""+5491155550123""
            },
            {
            ""Nombre"": ""Florencia"",
            ""Apellido"": ""González"",
            ""DNI"": ""36789012"",
            ""CuitCuil"": ""27-36789012-4"",
            ""FechaNacimiento"": ""1985-02-14"",
            ""Email"": ""florencia.gonzalez@example.com"",
            ""Telefono"": ""+5491155554567""
            },
            {
            ""Nombre"": ""Agustín"",
            ""Apellido"": ""Sánchez"",
            ""DNI"": ""33445566"",
            ""CuitCuil"": ""20-33445566-3"",
            ""FechaNacimiento"": ""1993-04-25"",
            ""Email"": ""agustin.sanchez@example.com"",
            ""Telefono"": ""+5491155558901""
            },
            {
            ""Nombre"": ""Emilia"",
            ""Apellido"": ""Paz"",
            ""DNI"": ""41234567"",
            ""CuitCuil"": ""27-41234567-0"",
            ""FechaNacimiento"": ""1998-06-03"",
            ""Email"": ""emilia.paz@example.com"",
            ""Telefono"": ""+5491155551122""
            },
            {
            ""Nombre"": ""Federico"",
            ""Apellido"": ""Ruiz"",
            ""DNI"": ""27890123"",
            ""CuitCuil"": ""20-27890123-5"",
            ""FechaNacimiento"": ""1972-10-09"",
            ""Email"": ""federico.ruiz@example.com"",
            ""Telefono"": ""+5491155553344""
            },
            {
            ""Nombre"": ""Carolina"",
            ""Apellido"": ""Torres"",
            ""DNI"": ""34567890"",
            ""CuitCuil"": ""27-34567890-7"",
            ""FechaNacimiento"": ""1987-03-20"",
            ""Email"": ""carolina.torres@example.com"",
            ""Telefono"": ""+5491155555566""
            },
            {
            ""Nombre"": ""Nicolás"",
            ""Apellido"": ""Ramírez"",
            ""DNI"": ""37890123"",
            ""CuitCuil"": ""20-37890123-2"",
            ""FechaNacimiento"": ""1991-09-05"",
            ""Email"": ""nicolas.ramirez@example.com"",
            ""Telefono"": ""+5491155557788""
            },
            {
            ""Nombre"": ""Julieta"",
            ""Apellido"": ""Benítez"",
            ""DNI"": ""39012345"",
            ""CuitCuil"": ""27-39012345-8"",
            ""FechaNacimiento"": ""1994-01-12"",
            ""Email"": ""julieta.benitez@example.com"",
            ""Telefono"": ""+5491155559900""
            },
            {
            ""Nombre"": ""Gastón"",
            ""Apellido"": ""Acosta"",
            ""DNI"": ""30123456"",
            ""CuitCuil"": ""20-30123456-1"",
            ""FechaNacimiento"": ""1982-07-30"",
            ""Email"": ""gaston.acosta@example.com"",
            ""Telefono"": ""+5491155551000""
            },
            {
            ""Nombre"": ""Daniela"",
            ""Apellido"": ""Pereyra"",
            ""DNI"": ""35098765"",
            ""CuitCuil"": ""27-35098765-3"",
            ""FechaNacimiento"": ""1989-11-28"",
            ""Email"": ""daniela.pereyra@example.com"",
            ""Telefono"": ""+5491155552000""
            },
            {
            ""Nombre"": ""Esteban"",
            ""Apellido"": ""Castro"",
            ""DNI"": ""28901234"",
            ""CuitCuil"": ""20-28901234-9"",
            ""FechaNacimiento"": ""1977-04-16"",
            ""Email"": ""esteban.castro@example.com"",
            ""Telefono"": ""+5491155553000""
            },
            {
            ""Nombre"": ""Lorena"",
            ""Apellido"": ""Silva"",
            ""DNI"": ""32012345"",
            ""CuitCuil"": ""27-32012345-6"",
            ""FechaNacimiento"": ""1984-06-08"",
            ""Email"": ""lorena.silva@example.com"",
            ""Telefono"": ""+5491155554000""
            },
            {
            ""Nombre"": ""Pablo"",
            ""Apellido"": ""Ortiz"",
            ""DNI"": ""36098765"",
            ""CuitCuil"": ""20-36098765-4"",
            ""FechaNacimiento"": ""1996-02-01"",
            ""Email"": ""pablo.ortiz@example.com"",
            ""Telefono"": ""+5491155555000""
            },
            {
            ""Nombre"": ""Romina"",
            ""Apellido"": ""Núñez"",
            ""DNI"": ""40011223"",
            ""CuitCuil"": ""27-40011223-9"",
            ""FechaNacimiento"": ""1997-08-14"",
            ""Email"": ""romina.nunez@example.com"",
            ""Telefono"": ""+5491155556000""
            },
            {
            ""Nombre"": ""Facundo"",
            ""Apellido"": ""Blanco"",
            ""DNI"": ""29123456"",
            ""CuitCuil"": ""20-29123456-8"",
            ""FechaNacimiento"": ""1981-03-22"",
            ""Email"": ""facundo.blanco@example.com"",
            ""Telefono"": ""+5491155557000""
            },
            {
            ""Nombre"": ""Andrea"",
            ""Apellido"": ""Rivas"",
            ""DNI"": ""33012345"",
            ""CuitCuil"": ""27-33012345-1"",
            ""FechaNacimiento"": ""1986-09-17"",
            ""Email"": ""andrea.rivas@example.com"",
            ""Telefono"": ""+5491155558000""
            },
            {
            ""Nombre"": ""Sergio"",
            ""Apellido"": ""Herrera"",
            ""DNI"": ""37012345"",
            ""CuitCuil"": ""20-37012345-5"",
            ""FechaNacimiento"": ""1990-05-06"",
            ""Email"": ""sergio.herrera@example.com"",
            ""Telefono"": ""+5491155559000""
            },
            {
            ""Nombre"": ""Laura"",
            ""Apellido"": ""Morales"",
            ""DNI"": ""38123456"",
            ""CuitCuil"": ""27-38123456-4"",
            ""FechaNacimiento"": ""1992-10-29"",
            ""Email"": ""laura.morales@example.com"",
            ""Telefono"": ""+5491155551111""
            },
            {
            ""Nombre"": ""Gabriel"",
            ""Apellido"": ""Gil"",
            ""DNI"": ""31012345"",
            ""CuitCuil"": ""20-31012345-0"",
            ""FechaNacimiento"": ""1979-12-04"",
            ""Email"": ""gabriel.gil@example.com"",
            ""Telefono"": ""+5491155552222""
            },
            {
            ""Nombre"": ""Natalia"",
            ""Apellido"": ""Vargas"",
            ""DNI"": ""36123456"",
            ""CuitCuil"": ""27-36123456-7"",
            ""FechaNacimiento"": ""1983-01-09"",
            ""Email"": ""natalia.vargas@example.com"",
            ""Telefono"": ""+5491155553333""
            },
            {
            ""Nombre"": ""Ricardo"",
            ""Apellido"": ""Méndez"",
            ""DNI"": ""34012345"",
            ""CuitCuil"": ""20-34012345-3"",
            ""FechaNacimiento"": ""1988-07-21"",
            ""Email"": ""ricardo.mendez@example.com"",
            ""Telefono"": ""+5491155554444""
            },
            {
            ""Nombre"": ""Marina"",
            ""Apellido"": ""Sosa"",
            ""DNI"": ""39123456"",
            ""CuitCuil"": ""27-39123456-0"",
            ""FechaNacimiento"": ""1995-04-02"",
            ""Email"": ""marina.sosa@example.com"",
            ""Telefono"": ""+5491155555555""
            },
            {
            ""Nombre"": ""Hernán"",
            ""Apellido"": ""Luna"",
            ""DNI"": ""32012345"",
            ""CuitCuil"": ""20-32012345-2"",
            ""FechaNacimiento"": ""1980-09-11"",
            ""Email"": ""hernan.luna@example.com"",
            ""Telefono"": ""+5491155556666""
            }]";

            List<Cliente> listaPersonas = JsonConvert.DeserializeObject<List<Cliente>>(personasJson);
            List<Persona> personasNoInsertadas = new List<Persona>();
            try
            {

                foreach (Cliente cliente in listaPersonas)
                {
                    ClienteBLL clienteBLO = new ClienteBLL();
                    Cliente personaexistente = clienteBLO.BuscarPersonaPorDni(cliente.DNI);

                    if (personaexistente != null)
                    {
                        personasNoInsertadas.Add(cliente);
                    }
                    else
                    {
                        clienteBLO.AltaCliente(cliente);
                    }
                }
                MessageBox.Show("Se generaron " + (listaPersonas.Count - personasNoInsertadas.Count) + " clientes");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error insertando clientes: " + ex.Message);
            }

        }

        private void GenerarInstructores_Click(object sender, EventArgs e)
        {
            string personasJson = @"
            [
              {
                ""Nombre"": ""Renata"",
                ""Apellido"": ""González"",
                ""DNI"": ""42112233"",
                ""CuitCuil"": ""27-42112233-1"",
                ""FechaNacimiento"": ""1999-02-18"",
                ""Email"": ""renata.gonzalez@example.com"",
                ""Telefono"": ""+5491155557777""
              },
              {
                ""Nombre"": ""Mateo"",
                ""Apellido"": ""López"",
                ""DNI"": ""43012345"",
                ""CuitCuil"": ""20-43012345-9"",
                ""FechaNacimiento"": ""2001-07-05"",
                ""Email"": ""mateo.lopez@example.com"",
                ""Telefono"": ""+5491155558888""
              },
              {
                ""Nombre"": ""Victoria"",
                ""Apellido"": ""Sánchez"",
                ""DNI"": ""44123456"",
                ""CuitCuil"": ""27-44123456-4"",
                ""FechaNacimiento"": ""2000-11-30"",
                ""Email"": ""victoria.sanchez@example.com"",
                ""Telefono"": ""+5491155559999""
              },
              {
                ""Nombre"": ""Benjamín"",
                ""Apellido"": ""Rodríguez"",
                ""DNI"": ""45098765"",
                ""CuitCuil"": ""20-45098765-2"",
                ""FechaNacimiento"": ""2003-04-12"",
                ""Email"": ""benjamin.rodriguez@example.com"",
                ""Telefono"": ""+5491155551010""
              },
              {
                ""Nombre"": ""Olivia"",
                ""Apellido"": ""Fernández"",
                ""DNI"": ""46123456"",
                ""CuitCuil"": ""27-46123456-7"",
                ""FechaNacimiento"": ""2002-08-25"",
                ""Email"": ""olivia.fernandez@example.com"",
                ""Telefono"": ""+5491155552020""
              },
              {
                ""Nombre"": ""Joaquín"",
                ""Apellido"": ""Díaz"",
                ""DNI"": ""47012345"",
                ""CuitCuil"": ""20-47012345-5"",
                ""FechaNacimiento"": ""1999-01-01"",
                ""Email"": ""joaquin.diaz@example.com"",
                ""Telefono"": ""+5491155553030""
              },
              {
                ""Nombre"": ""Isabella"",
                ""Apellido"": ""García"",
                ""DNI"": ""48123456"",
                ""CuitCuil"": ""27-48123456-0"",
                ""FechaNacimiento"": ""2004-05-19"",
                ""Email"": ""isabella.garcia@example.com"",
                ""Telefono"": ""+5491155554040""
              },
              {
                ""Nombre"": ""Thiago"",
                ""Apellido"": ""Martínez"",
                ""DNI"": ""49098765"",
                ""CuitCuil"": ""20-49098765-8"",
                ""FechaNacimiento"": ""2005-10-08"",
                ""Email"": ""thiago.martinez@example.com"",
                ""Telefono"": ""+5491155555050""
              },
              {
                ""Nombre"": ""Emma"",
                ""Apellido"": ""Pérez"",
                ""DNI"": ""50123456"",
                ""CuitCuil"": ""27-50123456-3"",
                ""FechaNacimiento"": ""2001-03-03"",
                ""Email"": ""emma.perez@example.com"",
                ""Telefono"": ""+5491155556060""
              },
              {
                ""Nombre"": ""Santino"",
                ""Apellido"": ""Gómez"",
                ""DNI"": ""51012345"",
                ""CuitCuil"": ""20-51012345-1"",
                ""FechaNacimiento"": ""2002-11-15"",
                ""Email"": ""santino.gomez@example.com"",
                ""Telefono"": ""+5491155557070""
              },
              {
                ""Nombre"": ""Catalina"",
                ""Apellido"": ""Acosta"",
                ""DNI"": ""52123456"",
                ""CuitCuil"": ""27-52123456-6"",
                ""FechaNacimiento"": ""2000-06-20"",
                ""Email"": ""catalina.acosta@example.com"",
                ""Telefono"": ""+5491155558080""
              },
              {
                ""Nombre"": ""Felipe"",
                ""Apellido"": ""Benítez"",
                ""DNI"": ""53098765"",
                ""CuitCuil"": ""20-53098765-4"",
                ""FechaNacimiento"": ""2003-09-07"",
                ""Email"": ""felipe.benitez@example.com"",
                ""Telefono"": ""+5491155559090""
              },
              {
                ""Nombre"": ""Sofía"",
                ""Apellido"": ""Castro"",
                ""DNI"": ""54123456"",
                ""CuitCuil"": ""27-54123456-9"",
                ""FechaNacimiento"": ""2004-12-01"",
                ""Email"": ""sofia.castro@example.com"",
                ""Telefono"": ""+5491155551313""
              },
              {
                ""Nombre"": ""Juan Cruz"",
                ""Apellido"": ""Herrera"",
                ""DNI"": ""55012345"",
                ""CuitCuil"": ""20-55012345-7"",
                ""FechaNacimiento"": ""2000-07-28"",
                ""Email"": ""juancruz.herrera@example.com"",
                ""Telefono"": ""+5491155552424""
              },
              {
                ""Nombre"": ""Pilar"",
                ""Apellido"": ""Ruiz"",
                ""DNI"": ""56123456"",
                ""CuitCuil"": ""27-56123456-2"",
                ""FechaNacimiento"": ""1998-03-09"",
                ""Email"": ""pilar.ruiz@example.com"",
                ""Telefono"": ""+5491155553535""
              },
              {
                ""Nombre"": ""Tomás"",
                ""Apellido"": ""Silva"",
                ""DNI"": ""57098765"",
                ""CuitCuil"": ""20-57098765-0"",
                ""FechaNacimiento"": ""2001-01-22"",
                ""Email"": ""tomas.silva@example.com"",
                ""Telefono"": ""+5491155554646""
              },
              {
                ""Nombre"": ""Lola"",
                ""Apellido"": ""Torres"",
                ""DNI"": ""58123456"",
                ""CuitCuil"": ""27-58123456-5"",
                ""FechaNacimiento"": ""2002-06-14"",
                ""Email"": ""lola.torres@example.com"",
                ""Telefono"": ""+5491155555757""
              },
              {
                ""Nombre"": ""Francisco"",
                ""Apellido"": ""Vargas"",
                ""DNI"": ""59012345"",
                ""CuitCuil"": ""20-59012345-3"",
                ""FechaNacimiento"": ""2003-11-05"",
                ""Email"": ""francisco.vargas@example.com"",
                ""Telefono"": ""+5491155556868""
              },
              {
                ""Nombre"": ""Martina"",
                ""Apellido"": ""Gómez"",
                ""DNI"": ""60123456"",
                ""CuitCuil"": ""27-60123456-8"",
                ""FechaNacimiento"": ""2000-09-29"",
                ""Email"": ""martina.gomez@example.com"",
                ""Telefono"": ""+5491155557979""
              },
              {
                ""Nombre"": ""Manuel"",
                ""Apellido"": ""Pereyra"",
                ""DNI"": ""61098765"",
                ""CuitCuil"": ""20-61098765-1"",
                ""FechaNacimiento"": ""1999-04-17"",
                ""Email"": ""manuel.pereyra@example.com"",
                ""Telefono"": ""+5491155558080""
              }
            ]";

            List<Instructor> listaPersonas = JsonConvert.DeserializeObject<List<Instructor>>(personasJson);
            List<Persona> personasNoInsertadas = new List<Persona>();
            try
            {

                foreach (Instructor instructor in listaPersonas)
                {
                    InstructorBLL instructorBLO = new InstructorBLL();
                    Instructor personaexistente = instructorBLO.BuscarPersonaPorDni(instructor.DNI);

                    if (personaexistente != null)
                    {
                        personasNoInsertadas.Add(instructor);
                    }
                    else
                    {
                        instructor.Licencia = GenerarNumeroLicenciaAleatorio();
                        instructorBLO.AltaInstructor(instructor);
                    }
                }
                MessageBox.Show("Se generaron " + (listaPersonas.Count - personasNoInsertadas.Count) + " instructores");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error insertando instructores: " + ex.Message);
            }
        }

        private void GenerarDueños_Click(object sender, EventArgs e)
        {
            string personasJson =@"
            [
              {
                ""Nombre"": ""Elena"",
                ""Apellido"": ""Blanco"",
                ""DNI"": ""62112233"",
                ""CuitCuil"": ""27-62112233-5"",
                ""FechaNacimiento"": ""1997-08-01"",
                ""Email"": ""elena.blanco@example.com"",
                ""Telefono"": ""+5491155559191""
              },
              {
                ""Nombre"": ""Simón"",
                ""Apellido"": ""Ramírez"",
                ""DNI"": ""63012345"",
                ""CuitCuil"": ""20-63012345-3"",
                ""FechaNacimiento"": ""1996-03-20"",
                ""Email"": ""simon.ramirez@example.com"",
                ""Telefono"": ""+5491155550202""
              },
              {
                ""Nombre"": ""Clara"",
                ""Apellido"": ""Núñez"",
                ""DNI"": ""64123456"",
                ""CuitCuil"": ""27-64123456-8"",
                ""FechaNacimiento"": ""1998-12-11"",
                ""Email"": ""clara.nunez@example.com"",
                ""Telefono"": ""+5491155551313""
              },
              {
                ""Nombre"": ""Ezequiel"",
                ""Apellido"": ""Ortiz"",
                ""DNI"": ""65098765"",
                ""CuitCuil"": ""20-65098765-6"",
                ""FechaNacimiento"": ""1995-06-07"",
                ""Email"": ""ezequiel.ortiz@example.com"",
                ""Telefono"": ""+5491155552424""
              },
              {
                ""Nombre"": ""Agustina"",
                ""Apellido"": ""Rivas"",
                ""DNI"": ""66123456"",
                ""CuitCuil"": ""27-66123456-1"",
                ""FechaNacimiento"": ""1997-04-25"",
                ""Email"": ""agustina.rivas@example.com"",
                ""Telefono"": ""+5491155553535""
              },
              {
                ""Nombre"": ""Valentín"",
                ""Apellido"": ""Sosa"",
                ""DNI"": ""67012345"",
                ""CuitCuil"": ""20-67012345-9"",
                ""FechaNacimiento"": ""1994-01-18"",
                ""Email"": ""valentin.sosa@example.com"",
                ""Telefono"": ""+5491155554646""
              },
              {
                ""Nombre"": ""Martina"",
                ""Apellido"": ""Vargas"",
                ""DNI"": ""68123456"",
                ""CuitCuil"": ""27-68123456-4"",
                ""FechaNacimiento"": ""1999-07-03"",
                ""Email"": ""martina.vargas@example.com"",
                ""Telefono"": ""+5491155555757""
              },
              {
                ""Nombre"": ""Luciano"",
                ""Apellido"": ""Méndez"",
                ""DNI"": ""69098765"",
                ""CuitCuil"": ""20-69098765-2"",
                ""FechaNacimiento"": ""1996-10-14"",
                ""Email"": ""luciano.mendez@example.com"",
                ""Telefono"": ""+5491155556868""
              },
              {
                ""Nombre"": ""Jazmín"",
                ""Apellido"": ""Luna"",
                ""DNI"": ""70123456"",
                ""CuitCuil"": ""27-70123456-7"",
                ""FechaNacimiento"": ""1995-02-08"",
                ""Email"": ""jazmin.luna@example.com"",
                ""Telefono"": ""+5491155557979""
              },
              {
                ""Nombre"": ""Máximo"",
                ""Apellido"": ""Gil"",
                ""DNI"": ""71012345"",
                ""CuitCuil"": ""20-71012345-5"",
                ""FechaNacimiento"": ""1998-05-29"",
                ""Email"": ""maximo.gil@example.com"",
                ""Telefono"": ""+5491155558080""
              }
            ]";
            List<Dueno> listaPersonas = JsonConvert.DeserializeObject<List<Dueno>>(personasJson);
            List<Persona> personasNoInsertadas = new List<Persona>();
            try
            {

                foreach (Dueno dueno in listaPersonas)
                {
                    DuenoBLL duenoBLO = new DuenoBLL();
                    Dueno personaexistente = duenoBLO.BuscarPersonaPorDNI(dueno.DNI);

                    if (personaexistente != null)
                    {
                        personasNoInsertadas.Add(dueno);
                    }
                    else
                    {
                        duenoBLO.AltaDueno(dueno);
                    }
                }
                MessageBox.Show("Se generaron " + (listaPersonas.Count - personasNoInsertadas.Count) + " dueños");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error insertando Dueños: " + ex.Message);
            }
        }

        private string GenerarNumeroLicenciaAleatorio()
        {
            Random random = new Random();
            StringBuilder sb = new StringBuilder(10);
            for (int i = 0; i < 10; i++)
            {
                sb.Append(random.Next(0, 10));
            }
            return sb.ToString();
        }
    }
}
