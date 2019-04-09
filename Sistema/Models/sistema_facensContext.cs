using System;
using System.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Sistema.Models
{
    public partial class sistema_facensContext : DbContext
    {
        public sistema_facensContext(DbContextOptions<sistema_facensContext> options) : base(options) { }
        
        public virtual DbSet<Admin> Admin { get; set; }
        public virtual DbSet<Competência> Competência { get; set; }
        public virtual DbSet<CompetênciaHasDisciplina> CompetênciaHasDisciplina { get; set; }
        public virtual DbSet<Coordenador> Coordenador { get; set; }
        public virtual DbSet<Curso> Curso { get; set; }
        public virtual DbSet<Disciplina> Disciplina { get; set; }
        public virtual DbSet<DisciplinaHasCurso> DisciplinaHasCurso { get; set; }
        public virtual DbSet<DisciplinaHasProfessor> DisciplinaHasProfessor { get; set; }
        public virtual DbSet<Habilidade> Habilidade { get; set; }
        public virtual DbSet<HabilidadeHasDisciplina> HabilidadeHasDisciplina { get; set; }
        public virtual DbSet<Objetivo> Objetivo { get; set; }
        public virtual DbSet<ObjetivoHasDisciplina> ObjetivoHasDisciplina { get; set; }
        public virtual DbSet<Professor> Professor { get; set; }
        public virtual DbSet<Turma> Turma { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(@"Data Source=localhost\SQLEXPRESS;Initial Catalog=sistema_facens;User ID=sa;Password=!usr000@;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>(entity =>
            {
                entity.HasKey(e => e.IdAdmin);

                entity.Property(e => e.IdAdmin).HasColumnName("idAdmin");

                entity.Property(e => e.Cpf)
                    .IsRequired()
                    .HasColumnName("cpf")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("nome")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Perfil)
                    .IsRequired()
                    .HasColumnName("perfil")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasColumnName("senha")
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.Titulacao)
                    .IsRequired()
                    .HasColumnName("titulacao")
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Competência>(entity =>
            {
                entity.HasKey(e => e.IdCompetência);

                entity.Property(e => e.IdCompetência).HasColumnName("idCompetência");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasColumnName("descricao")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CompetênciaHasDisciplina>(entity =>
            {
                entity.ToTable("Competência_has_Disciplina");

                entity.Property(e => e.CompetênciaHasDisciplinaId).HasColumnName("Competência_has_DisciplinaId");

                entity.Property(e => e.CompetênciaIdCompetência).HasColumnName("Competência_idCompetência");

                entity.Property(e => e.DisciplinaIdDisciplina).HasColumnName("Disciplina_idDisciplina");

                entity.HasOne(d => d.CompetênciaIdCompetênciaNavigation)
                    .WithMany(p => p.CompetênciaHasDisciplina)
                    .HasForeignKey(d => d.CompetênciaIdCompetência)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Competência_has_Disciplina_Competência1");

                entity.HasOne(d => d.DisciplinaIdDisciplinaNavigation)
                    .WithMany(p => p.CompetênciaHasDisciplina)
                    .HasForeignKey(d => d.DisciplinaIdDisciplina)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Competência_has_Disciplina_Disciplina1");
            });

            modelBuilder.Entity<Coordenador>(entity =>
            {
                entity.HasKey(e => e.IdCoordenador);

                entity.Property(e => e.IdCoordenador).HasColumnName("idCoordenador");

                entity.Property(e => e.Cpf)
                    .IsRequired()
                    .HasColumnName("cpf")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("nome")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Perfil)
                    .IsRequired()
                    .HasColumnName("perfil")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasColumnName("senha")
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.Titulacao)
                    .IsRequired()
                    .HasColumnName("titulacao")
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Curso>(entity =>
            {
                entity.HasKey(e => e.IdCurso);

                entity.Property(e => e.IdCurso).HasColumnName("idCurso");

                entity.Property(e => e.CoordenadorIdCoordenador).HasColumnName("Coordenador_idCoordenador");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasColumnName("descricao")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.CoordenadorIdCoordenadorNavigation)
                    .WithMany(p => p.Curso)
                    .HasForeignKey(d => d.CoordenadorIdCoordenador)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Curso_Coordenador1");
            });

            modelBuilder.Entity<Disciplina>(entity =>
            {
                entity.HasKey(e => e.IdDisciplina);

                entity.Property(e => e.IdDisciplina).HasColumnName("idDisciplina");

                entity.Property(e => e.CargaHoraria).HasColumnName("cargaHoraria");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasColumnName("descricao")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<DisciplinaHasCurso>(entity =>
            {
                entity.ToTable("Disciplina_has_Curso");

                entity.Property(e => e.DisciplinaHasCursoId).HasColumnName("Disciplina_has_CursoId");

                entity.Property(e => e.CursoIdCurso).HasColumnName("Curso_idCurso");

                entity.Property(e => e.DisciplinaIdDisciplina).HasColumnName("Disciplina_idDisciplina");

                entity.Property(e => e.TurmaIdTurma).HasColumnName("Turma_idTurma");

                entity.HasOne(d => d.CursoIdCursoNavigation)
                    .WithMany(p => p.DisciplinaHasCurso)
                    .HasForeignKey(d => d.CursoIdCurso)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Disciplina_has_Curso_Curso1");

                entity.HasOne(d => d.DisciplinaIdDisciplinaNavigation)
                    .WithMany(p => p.DisciplinaHasCurso)
                    .HasForeignKey(d => d.DisciplinaIdDisciplina)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Disciplina_has_Curso_Disciplina1");

                entity.HasOne(d => d.TurmaIdTurmaNavigation)
                    .WithMany(p => p.DisciplinaHasCurso)
                    .HasForeignKey(d => d.TurmaIdTurma)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Disciplina_has_Curso_Turma1");
            });

            modelBuilder.Entity<DisciplinaHasProfessor>(entity =>
            {
                entity.ToTable("Disciplina_has_Professor");

                entity.Property(e => e.DisciplinaHasProfessorId).HasColumnName("Disciplina_has_ProfessorId");

                entity.Property(e => e.DisciplinaIdDisciplina).HasColumnName("Disciplina_idDisciplina");

                entity.Property(e => e.ProfessorIdProfessor).HasColumnName("Professor_idProfessor");

                entity.HasOne(d => d.DisciplinaIdDisciplinaNavigation)
                    .WithMany(p => p.DisciplinaHasProfessor)
                    .HasForeignKey(d => d.DisciplinaIdDisciplina)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Disciplina_has_Professor_Disciplina1");

                entity.HasOne(d => d.ProfessorIdProfessorNavigation)
                    .WithMany(p => p.DisciplinaHasProfessor)
                    .HasForeignKey(d => d.ProfessorIdProfessor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Disciplina_has_Professor_Professor1");
            });

            modelBuilder.Entity<Habilidade>(entity =>
            {
                entity.HasKey(e => e.IdHabilidade);

                entity.Property(e => e.IdHabilidade).HasColumnName("idHabilidade");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasColumnName("descricao")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<HabilidadeHasDisciplina>(entity =>
            {
                entity.ToTable("Habilidade_has_Disciplina");

                entity.Property(e => e.HabilidadeHasDisciplinaId).HasColumnName("Habilidade_has_DisciplinaId");

                entity.Property(e => e.DisciplinaIdDisciplina).HasColumnName("Disciplina_idDisciplina");

                entity.Property(e => e.HabilidadeIdHabilidade).HasColumnName("Habilidade_idHabilidade");

                entity.HasOne(d => d.DisciplinaIdDisciplinaNavigation)
                    .WithMany(p => p.HabilidadeHasDisciplina)
                    .HasForeignKey(d => d.DisciplinaIdDisciplina)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Habilidade_has_Disciplina_Disciplina1");

                entity.HasOne(d => d.HabilidadeIdHabilidadeNavigation)
                    .WithMany(p => p.HabilidadeHasDisciplina)
                    .HasForeignKey(d => d.HabilidadeIdHabilidade)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Habilidade_has_Disciplina_Habilidade");
            });

            modelBuilder.Entity<Objetivo>(entity =>
            {
                entity.HasKey(e => e.IdObjetivo);

                entity.Property(e => e.IdObjetivo).HasColumnName("idObjetivo");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasColumnName("descricao")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ObjetivoHasDisciplina>(entity =>
            {
                entity.ToTable("Objetivo_has_Disciplina");

                entity.Property(e => e.ObjetivoHasDisciplinaId).HasColumnName("Objetivo_has_DisciplinaId");

                entity.Property(e => e.DisciplinaIdDisciplina).HasColumnName("Disciplina_idDisciplina");

                entity.Property(e => e.ObjetivoIdObjetivo).HasColumnName("Objetivo_idObjetivo");

                entity.HasOne(d => d.DisciplinaIdDisciplinaNavigation)
                    .WithMany(p => p.ObjetivoHasDisciplina)
                    .HasForeignKey(d => d.DisciplinaIdDisciplina)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Objetivo_has_Disciplina_Disciplina1");

                entity.HasOne(d => d.ObjetivoIdObjetivoNavigation)
                    .WithMany(p => p.ObjetivoHasDisciplina)
                    .HasForeignKey(d => d.ObjetivoIdObjetivo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Objetivo_has_Disciplina_Objetivo1");
            });

            modelBuilder.Entity<Professor>(entity =>
            {
                entity.HasKey(e => e.IdProfessor);

                entity.Property(e => e.IdProfessor).HasColumnName("idProfessor");

                entity.Property(e => e.Cpf)
                    .IsRequired()
                    .HasColumnName("cpf")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("nome")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Perfil)
                    .IsRequired()
                    .HasColumnName("perfil")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasColumnName("senha")
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.Titulacao)
                    .IsRequired()
                    .HasColumnName("titulacao")
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Turma>(entity =>
            {
                entity.HasKey(e => e.IdTurma);

                entity.Property(e => e.IdTurma).HasColumnName("idTurma");

                entity.Property(e => e.Codigo)
                    .IsRequired()
                    .HasColumnName("codigo")
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });
        }
    }
}
