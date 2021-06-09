using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace BuscadorIndex
{
    [Serializable]
    public class ArchivoIndexado
    {
        public string Nombre { get; set; }
        public string Ruta { get; set; }
        public long Tamanno { get; set; }
    }
    [Serializable]
    public class IndexMetadata
    {
        public DateTime UltimoIndex { get; set; }
        public bool Estado { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime Fin { get; set; }
    }
    [Serializable]
    public class ContenidoIndexado
    {
        public IndexMetadata Data { get; set; }
        public List<ArchivoIndexado> Indice { get; set; }

        public ContenidoIndexado()
        {
            Indice = new List<ArchivoIndexado>();
        }

        public async Task Indexar()
        {
            DateTime inicio = DateTime.Now;
            await Task.Run(() =>
            {
                foreach (var item in Environment.GetLogicalDrives())
                {
                    DirectoryInfo d = new DirectoryInfo(item);
                    if (d.Exists)
                    {
                        EscribirEnIndice(d);
                    }
                }
            });
            DateTime fin = DateTime.Now;

            Data = new IndexMetadata
            {
                Inicio = inicio,
                Fin = fin,
                UltimoIndex = fin,
                Estado = true

            };

            FileInfo indx = new FileInfo(Path.Combine(Environment.CurrentDirectory, "index.xd"));
            if (indx.Exists)
                indx.Delete();
            await Task.Run(() =>
            {
                FileStream stream = new FileStream(indx.FullName, FileMode.Create, FileAccess.Write);
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(stream, this);
                stream.Close();
            });



        }

        void EscribirEnIndice(DirectoryInfo directorio)
        {
            foreach (FileInfo fi in directorio.EnumerateFiles())
            {
                Indice.Add(new ArchivoIndexado { Nombre = fi.Name, Ruta = fi.FullName,
                Tamanno = fi.Length
                });
            }
            foreach (DirectoryInfo d in directorio.EnumerateDirectories())
            {
                if (EsValido(d))
                    EscribirEnIndice(d);
            }
        }

        bool EsValido(DirectoryInfo d)
        {
            try
            {
                d.EnumerateFiles().Count();
                return true;
            }
            catch
            { return false; }
        }

    }

}
