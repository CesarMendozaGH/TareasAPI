﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TareasAPI.Models;

public partial class Bdtareas904Context : DbContext
{
    public Bdtareas904Context()
    {
    }

    public Bdtareas904Context(DbContextOptions<Bdtareas904Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Tarea> Tareas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Tarea>(entity =>
        {
            entity.HasKey(e => e.IdTarea).HasName("PK__Tarea__756A5402EBBCC2D4");

            entity.ToTable("Tarea");

            entity.Property(e => e.IdTarea).HasColumnName("idTarea");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
