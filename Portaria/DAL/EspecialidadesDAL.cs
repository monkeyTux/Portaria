﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;
using System.Data;
using System.Xml.Linq;
using Portaria.MODEL;

namespace Portaria.DAL
{
    class EspecialidadeDAL
    {



        public DataTable dt = new DataTable(); // cria tabela de dados
        public DataSet ds = new DataSet();
       
        private string xml_path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;

        public List<Especialidade> todasEspecialidades()
        {

            var xDoc = XDocument.Load(xml_path + @"\DB\Especialidades.xml");

            List<Especialidade> especialidades = new List<Especialidade>();
          

            foreach (XElement xe in xDoc.Descendants("especialidade"))
            {
                Especialidade especialidade = new Especialidade();

                especialidade.Cod = Convert.ToInt32(xe.Element("cod").Value);
                especialidade.Esp = xe.Element("nome").Value;

                especialidades.Add(especialidade);
            }

            return especialidades;
        }

        public DataTable carregaEspecialidades()
        {
            try
            {

                ds.ReadXml(xml_path + @"\DB\Especialidades.xml");
                dt = ds.Tables[("especialidade")];
            }
            catch (FileNotFoundException ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

            return dt;
        }

        public void Salvar (string nome)
        {
            try
            {
                
                var xDoc = XDocument.Load(xml_path + @"\DB\Especialidades.xml");
                var count = xDoc.Descendants("especialidade").Count();
                var novoElemento = new XElement("especialidade",
                                  new XElement("cod", count + 1),
                                  new XElement("nome", nome));
                xDoc.Root.Add(novoElemento);
                xDoc.Save(xml_path + @"\DB\Especialidades.xml");

            } catch (FileNotFoundException ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }
    }
}
