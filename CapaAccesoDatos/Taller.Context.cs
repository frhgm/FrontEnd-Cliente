﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CapaAccesoDatos
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class SERVIEXPRESSEntities : DbContext
    {
        public SERVIEXPRESSEntities()
            : base("name=SERVIEXPRESSEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<almacen> almacens { get; set; }
        public virtual DbSet<boleta> boletas { get; set; }
        public virtual DbSet<cliente> clientes { get; set; }
        public virtual DbSet<detalle_pago> detalle_pago { get; set; }
        public virtual DbSet<detalle_pedido> detalle_pedido { get; set; }
        public virtual DbSet<detalle_permiso> detalle_permiso { get; set; }
        public virtual DbSet<dia_habil> dia_habil { get; set; }
        public virtual DbSet<empleado> empleadoes { get; set; }
        public virtual DbSet<familia_producto> familia_producto { get; set; }
        public virtual DbSet<horario> horarios { get; set; }
        public virtual DbSet<marca_producto> marca_producto { get; set; }
        public virtual DbSet<modulo> moduloes { get; set; }
        public virtual DbSet<pedido_cabecera> pedido_cabecera { get; set; }
        public virtual DbSet<producto> productoes { get; set; }
        public virtual DbSet<producto_almacen> producto_almacen { get; set; }
        public virtual DbSet<proveedor> proveedors { get; set; }
        public virtual DbSet<reserva> reservas { get; set; }
        public virtual DbSet<rol> rols { get; set; }
        public virtual DbSet<servicio> servicios { get; set; }
        public virtual DbSet<tipo_boleta> tipo_boleta { get; set; }
        public virtual DbSet<usuario> usuarios { get; set; }
    }
}
