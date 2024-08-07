﻿using MaxiAhorroApp.Clases;
using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Google.Protobuf.Reflection.SourceCodeInfo.Types;
using System.Xml.Linq;
using Dapper;

namespace MaxiAhorroApp.Controladores
{
    public class ServicioProducto : Connection, IRepositorio<Producto>
    {

        public virtual IEnumerable<Producto> Consultar()
        {
            try
            {
                var sql = @"
            SELECT 
                p.Id, p.nombre, p.descripcion, p.precio, p.cantidad, p.fecha_ingreso, 
                p.codigo_barra, p.fecha_vencimiento,
                c.Id as Id, c.Nombre as Nombre,
                pr.Id as Id, pr.Nombre as Nombre,
                m.Id as Id, m.Nombre as Nombre,
                u.Id as Id, u.Nombre as Nombre
            FROM minimarket.productos p
            INNER JOIN minimarket.categorias c ON p.categoria_id = c.Id
            INNER JOIN minimarket.proveedores pr ON p.proveedor_id = pr.Id
            INNER JOIN minimarket.marcas m ON p.marca_id = m.Id
            INNER JOIN minimarket.ubicaciones u ON p.ubicacion_id = u.Id
            WHERE estado = 'Activo';";

                var productos = base.cn.Query<Producto, Category, Proveedor,Marca, Ubicacion, Producto>(sql,
                    (producto, categoria, proveedor, marca, ubicacion) =>
                    {
                        producto.categoria_id = categoria;
                        producto.proveedor_id = proveedor;
                        producto.marca_id = marca;
                        producto.ubicacion_id = ubicacion;
                        return producto;
                    },
                    splitOn: "Id,Id,Id,Id"
                );

                return productos;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
            finally
            {
                base.cn.Close();
            }
        }

        public Producto ConsultarPorId(Producto pro)
        {
            try
            {
                string sql = @"
        SELECT 
            p.Id, p.nombre, p.descripcion, p.precio, p.cantidad, p.fecha_ingreso, 
            p.codigo_barra, p.fecha_vencimiento,
            c.Id as Id, c.Nombre as Nombre,
            pr.Id as Id, pr.Nombre as Nombre,
            m.Id as Id, m.Nombre as Nombre,
            u.Id as Id, u.Nombre as Nombre
        FROM minimarket.productos p
        INNER JOIN minimarket.categorias c ON p.categoria_id = c.Id
        INNER JOIN minimarket.proveedores pr ON p.proveedor_id = pr.Id
        INNER JOIN minimarket.marcas m ON p.marca_id = m.Id
        INNER JOIN minimarket.ubicaciones u ON p.ubicacion_id = u.Id
        WHERE p.Id = @Id";

                var productoExistente = base.cn.Query<Producto, Category, Proveedor, Marca, Ubicacion, Producto>(
                    sql,
                    (producto, categoria, proveedor, marca, ubicacion) =>
                    {
                        producto.categoria_id = categoria;
                        producto.proveedor_id = proveedor;
                        producto.marca_id = marca;
                        producto.ubicacion_id = ubicacion;
                        return producto;
                    },
                    new { Id = pro.Id },
                    splitOn: "Id,Id,Id,Id"
                ).FirstOrDefault();

                return productoExistente;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
            finally
            {
                base.cn.Close();
            }
        }


        public void Modificar(Producto item)
        {

            if (item.Id != 0)
            {
                try
                {
                    var sql = "UPDATE `minimarket`.`productos` SET " +
                              "nombre = @nombre, " +
                              "descripcion = @descripcion, " +
                              "categoria_id = @categoria_id, " +
                              "precio = @precio, " +
                              "cantidad = @cantidad, " +
                              "fecha_ingreso = @fecha_ingreso, " +
                              "proveedor_id = @proveedor_id, " +
                              "codigo_barra = @codigo_barra, " +
                              "fecha_vencimiento = @fecha_vencimiento, " +
                              "marca_id = @marca_id, " +
                              "ubicacion_id = @ubicacion_id " +
                              "WHERE id = @id AND estado = 'Activo'";

                    base.cn.Execute(sql, new
                    {
                        id = item.Id,
                        nombre = item.nombre,
                        descripcion = item.descripcion,
                        categoria_id = item.categoria_id?.Id,
                        precio = item.precio,
                        cantidad = item.cantidad,
                        fecha_ingreso = DateTime.Now,
                        proveedor_id = item.proveedor_id?.Id,
                        codigo_barra = item.codigo_barra,
                        fecha_vencimiento = item.fecha_vencimiento,
                        marca_id = item.marca_id?.Id,
                        ubicacion_id = item.ubicacion_id?.Id
                    });
                    MessageBox.Show("El producto se ha actualizado correctamente");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    base.cn.Close();
                }
            }

        }

        public virtual void Agregar(Producto item)
        {
            try
            {
                var productoExistente = ObtenerProductoExistente(item);

                if (productoExistente != null)
                {
                    // Actualizar el producto existente
                    string sqlUpdate = @"
                UPDATE minimarket.productos 
                SET 
                    cantidad = cantidad + @cantidad, 
                    fecha_vencimiento = @fecha_vencimiento,
                    estado = 'Activo'
                WHERE Id = @Id";

                    base.cn.Execute(sqlUpdate, new
                    {
                        cantidad = item.cantidad,
                        fecha_vencimiento = item.fecha_vencimiento,
                        Id = productoExistente.Id
                    });

                    MessageBox.Show("El producto existente ha sido actualizado correctamente");
                }
                else
                {
                    string sqlInsert = @"
                INSERT INTO minimarket.productos 
                (
                    nombre, descripcion, categoria_id, precio, cantidad, fecha_ingreso, 
                    proveedor_id, codigo_barra, fecha_vencimiento, marca_id, ubicacion_id,
                    estado
                ) 
                VALUES 
                (
                    @nombre, @descripcion, @categoria_id, @precio, @cantidad, @fecha_ingreso, 
                    @proveedor_id, @codigo_barra, @fecha_vencimiento, @marca_id, @ubicacion_id, 'Activo'
                );";

                    base.cn.Execute(sqlInsert, new
                    {
                        item.nombre,
                        item.descripcion,
                        categoria_id = item.categoria_id?.Id,  
                        item.precio,
                        item.cantidad,
                        fecha_ingreso = DateTime.Now,          
                        proveedor_id = item.proveedor_id?.Id,  
                        item.codigo_barra,
                        item.fecha_vencimiento,
                        marca_id = item.marca_id?.Id,
                        ubicacion_id = item.ubicacion_id?.Id
                    });

                    MessageBox.Show("El nuevo producto se ha guardado correctamente");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                base.cn.Close();
            }
        }


        public void Eliminar(Producto item)
        {
            try
            {
                 var sql = "UPDATE minimarket.productos set estado = 'Inactivo' WHERE id = @id";
                base.cn.Execute(sql, item);
            }catch(Exception ex )
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        public IEnumerable<Producto> Consultar(string campo)
        {
            try
            {
                var sql = @"
            SELECT 
                p.Id, p.nombre, p.descripcion, p.precio, p.cantidad, p.fecha_ingreso, 
                p.codigo_barra, p.fecha_vencimiento,
                c.Id as Id, c.Nombre as Nombre,
                pr.Id as proveedor_id, pr.Nombre as Nombre,
                m.Id as Id, m.Nombre as Nombre,
                u.Id as Id, u.Nombre as Nombre
            FROM minimarket.productos p
            INNER JOIN minimarket.categorias c ON p.categoria_id = c.Id
            INNER JOIN minimarket.proveedores pr ON p.proveedor_id = pr.Id
            INNER JOIN minimarket.marcas m ON p.marca_id = m.Id
            INNER JOIN minimarket.ubicaciones u ON p.ubicacion_id = u.Id
            WHERE
                p.estado = 'Activo' AND
                (p.id LIKE @campo OR 
                p.nombre LIKE @campo OR 
                p.descripcion LIKE @campo OR 
                c.Nombre LIKE @campo OR
                pr.Nombre LIKE @campo OR
                p.codigo_barra LIKE @campo OR 
                m.Nombre LIKE @campo OR
                u.Nombre LIKE @campo)
                 ";

                var productos = base.cn.Query<Producto, Category, Proveedor, Marca, Ubicacion, Producto>(
                    sql,
                    (producto, categoria, proveedor, marca, ubicacion) =>
                    {
                        producto.categoria_id = categoria;
                        producto.proveedor_id = proveedor;
                        producto.marca_id = marca;
                        producto.ubicacion_id = ubicacion;
                        return producto;
                    },
                    new { campo = $"{campo}%" },
                    splitOn: "Id,proveedor_id, Id, Id"
                );

                return productos;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
            finally
            {
                base.cn.Close();
            }
        }

        public Producto ObtenerProductoExistente(Producto item)
        {
            string sql = @"
        SELECT 
            p.Id, p.nombre, p.descripcion, p.precio, p.cantidad, p.fecha_ingreso, 
            p.codigo_barra, p.fecha_vencimiento,
            c.Id as categoria_id, c.Nombre as categoria_nombre,
            pr.Id as proveedor_id, pr.Nombre as proveedor_nombre,
            m.Id as Id, m.Nombre as Nombre,
            u.Id as Id, u.Nombre as Nombre
        FROM minimarket.productos p
        INNER JOIN minimarket.categorias c ON p.categoria_id = c.Id
        INNER JOIN minimarket.proveedores pr ON p.proveedor_id = pr.Id
        INNER JOIN minimarket.marcas m ON p.marca_id = m.Id
        INNER JOIN minimarket.ubicaciones u ON p.ubicacion_id = u.Id
        WHERE p.nombre = @nombre AND p.descripcion = @descripcion AND p.proveedor_id = @proveedor_id AND p.marca_id = @marca";

            var productoExistente = base.cn.Query<Producto, Category, Proveedor, Marca, Ubicacion, Producto>(
                sql,
                (producto, categoria, proveedor, marca, ubicacion) =>
                {
                    producto.categoria_id = categoria;
                    producto.proveedor_id = proveedor;
                    producto.marca_id = marca;
                    producto.ubicacion_id = ubicacion;
                    return producto;
                },
                new
                {
                    nombre = item.nombre,
                    descripcion = item.descripcion,
                    categoria_id = item.categoria_id.Id,
                    proveedor_id = item.proveedor_id.Id,
                    marca = item.marca_id.Id
                },
                splitOn: "categoria_id,proveedor_id, Id, Id"
            ).FirstOrDefault();

            return productoExistente;
        }


    }
}
