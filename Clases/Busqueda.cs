using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace BuscadorIndex
{
    public class Busqueda: IDisposable
    {
        public List<ResultadoBusqueda> result;
        public bool EstaIndexado { get; set; }

        public Busqueda()
        {
            FileInfo indx = new FileInfo(Path.Combine(Environment.CurrentDirectory, "index.xd"));
            EstaIndexado = indx.Exists;
        }

        public async Task<List<ResultadoBusqueda>> ExBusqueda(string disco, string param)
        {
            //result = new List<ResultadoBusqueda>();
            if (!EstaIndexado)
            {
                await Task.Run(() =>
                {
                    DirectoryInfo directorio = new DirectoryInfo(disco);
                    BusquedaNoIndexada(directorio, param);
                }); 
                return result;
            }
            else
            {
                List<ResultadoBusqueda> l = new List<ResultadoBusqueda>();
                await Task.Run(() =>
                {
                    DirectoryInfo directorio = new DirectoryInfo(disco);
                    //BusquedaIndexada(param);
                    l.AddRange(result.Where(a => a.NombreArchivo.ToLower().Contains(param)));
                });
                return l;
            }
           

        }



        void BusquedaNoIndexada(DirectoryInfo directorio, string param)
        {

            foreach (FileInfo archivo in directorio.EnumerateFiles())
            {
                if (archivo.Name.ToLower().Contains(param.ToLower()))
                    result.Add(new ResultadoBusqueda { NombreArchivo = archivo.Name, Ruta = archivo.FullName, Tamanno = archivo.Length });
            }
            if (directorio.EnumerateDirectories().Count() > 0)
            {
                foreach (DirectoryInfo d in directorio.EnumerateDirectories())
                {
                    if (EsDirectorioValido(d))
                        BusquedaNoIndexada(d, param);
                }
            }

        }

       void BusquedaIndexada(string param)
        {
            //FileInfo indx = new FileInfo(Path.Combine(Environment.CurrentDirectory, "index.xd"));
            //if (indx.Exists)
            //{
            //    FileStream stream = new FileStream(indx.FullName, FileMode.Open, FileAccess.Read);
            //    BinaryFormatter bf = new BinaryFormatter();
            //    ContenidoIndexado ci = (ContenidoIndexado)bf.Deserialize(stream);
            //    stream.Close();
            //    result.AddRange(ci.Indice.Where(a => a.Nombre.ToLower().Contains(param)).Select(a => new ResultadoBusqueda
            //    {
            //        NombreArchivo = a.Nombre,
            //        Ruta = a.Ruta,
            //        Tamanno = a.Tamanno

            //    }));
            //}
        

        }
        public void CargarIndices()
        {
            FileInfo indx = new FileInfo(Path.Combine(Environment.CurrentDirectory, "index.xd"));
            if (indx.Exists)
            {
                FileStream stream = new FileStream(indx.FullName, FileMode.Open, FileAccess.Read);
                BinaryFormatter bf = new BinaryFormatter();
                ContenidoIndexado ci = (ContenidoIndexado)bf.Deserialize(stream);
                stream.Close();
                result.AddRange(ci.Indice.Select(a => new ResultadoBusqueda
                {
                    NombreArchivo = a.Nombre,
                    Ruta = a.Ruta,
                    Tamanno = a.Tamanno

                }));
                ci = null;
            }

        }

      

        bool EsDirectorioValido(DirectoryInfo d)
        {
            try
            {
                d.EnumerateFiles().Count();
                return true;
            }
            catch { return false; }
        }

        public void Dispose()
        {
            result.Clear();
        }
    }
}
