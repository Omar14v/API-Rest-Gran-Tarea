using bib_productos.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Veloz_Gary.Controllers
{

    public class ProductosController : ApiController
    {
        //Instanciamos a la Conexión con la Base de Datos
        ProductosConexion BD = new ProductosConexion();

        //Metodo que permite la consulta de datos de toda la tabla en forma de lista
        public IEnumerable<Productos> Get()
        {
            var listado = BD.Productos.ToList();
            return listado;
        }

        //Metodo que permite la consulta de datos especificos
        //Get
        public Productos GetProductos(int id)
        {
            var codigo = BD.Productos.FirstOrDefault(x => x.PRDCODIGO == id);
            return codigo;
        }

        //Post
        [HttpPost]
        public bool Insertar_Producto(Productos productos)
        {
            BD.Productos.Add(productos);
            return BD.SaveChanges() > 0;
        }

        //Put
        [HttpPut]
        public bool Actualizar_Producto(Productos productos)
        {
            var actualizarproducto = BD.Productos.FirstOrDefault(x => x.PRDCODIGO == productos.PRDCODIGO);
            actualizarproducto.PRDCODIGO = productos.PRDCODIGO;
            actualizarproducto.PRDNOMBRE = productos.PRDNOMBRE;
            actualizarproducto.PRDCANTIDAD = productos.PRDCANTIDAD;
            actualizarproducto.PRDUNIDAD = productos.PRDUNIDAD;
            actualizarproducto.PRDESTADO = productos.PRDESTADO;
            return BD.SaveChanges() > 0;
        }

        [HttpDelete]
        public bool Eliminar_Productos(int id)
        {
            var eliminardatos = BD.Productos.FirstOrDefault(x => x.PRDCODIGO == id);
            BD.Productos.Remove(eliminardatos);
            return BD.SaveChanges() > 0;
        }

    }

}
