using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Sistema.Models
{
    public partial class sistema_facensContext : DbContext
    {
        public sistema_facensContext(DbContextOptions<sistema_facensContext> options) : base(options) { }

        public virtual DbSet<Admin> Admin { get; set; }
        public virtual DbSet<AvaliacaoPlanoDeAula> AvaliacaoPlanoDeAula { get; set; }
        public virtual DbSet<Competência> Competência { get; set; }
        public virtual DbSet<CompetênciaHasDisciplina> CompetênciaHasDisciplina { get; set; }
        public virtual DbSet<CompetenciaPlanoDeEnsino> CompetenciaPlanoDeEnsino { get; set; }
        public virtual DbSet<ConteudoPlanoDeAula> ConteudoPlanoDeAula { get; set; }
        public virtual DbSet<Coordenador> Coordenador { get; set; }
        public virtual DbSet<Curso> Curso { get; set; }
        public virtual DbSet<Disciplina> Disciplina { get; set; }
        public virtual DbSet<DisciplinaHasCurso> DisciplinaHasCurso { get; set; }
        public virtual DbSet<DisciplinaHasProfessor> DisciplinaHasProfessor { get; set; }
        public virtual DbSet<Habilidade> Habilidade { get; set; }
        public virtual DbSet<HabilidadeHasDisciplina> HabilidadeHasDisciplina { get; set; }
        public virtual DbSet<HabilidadePlanoDeEnsino> HabilidadePlanoDeEnsino { get; set; }
        public virtual DbSet<Livro> Livro { get; set; }
        public virtual DbSet<MembroNde> MembroNde { get; set; }
        public virtual DbSet<Objetivo> Objetivo { get; set; }
        public virtual DbSet<ObjetivoHasDisciplina> ObjetivoHasDisciplina { get; set; }
        public virtual DbSet<ObjetivoPlanoDeEnsino> ObjetivoPlanoDeEnsino { get; set; }
        public virtual DbSet<PlanoDeAula> PlanoDeAula { get; set; }
        public virtual DbSet<PlanoDeEnsino> PlanoDeEnsino { get; set; }
        public virtual DbSet<Professor> Professor { get; set; }
        public virtual DbSet<Turma> Turma { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(@"Data Source=localhost\SQLEXPRESS;Initial Catalog=sistema_facens;Trusted_Connection=True;");
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

            modelBuilder.Entity<AvaliacaoPlanoDeAula>(entity =>
            {
                entity.HasKey(e => e.IdAvaliacaoPlanoAula);

                entity.Property(e => e.IdAvaliacaoPlanoAula).HasColumnName("idAvaliacaoPlanoAula");

                entity.Property(e => e.Atividade)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Descricao)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.IdPlanoDeAula).HasColumnName("idPlanoDeAula");

                entity.Property(e => e.Peso)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdPlanoDeAulaNavigation)
                    .WithMany(p => p.AvaliacaoPlanoDeAula)
                    .HasForeignKey(d => d.IdPlanoDeAula)
                    .HasConstraintName("FK__Avaliacao__idPla__46B27FE2");
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

            modelBuilder.Entity<CompetenciaPlanoDeEnsino>(entity =>
            {
                entity.HasKey(e => e.IdCompetenciaPlanoDeEnsino);

                entity.Property(e => e.IdCompetenciaPlanoDeEnsino).HasColumnName("idCompetenciaPlanoDeEnsino");

                entity.Property(e => e.IdCompetencia).HasColumnName("idCompetencia");

                entity.Property(e => e.IdPlanoDeEnsino).HasColumnName("idPlanoDeEnsino");

                entity.HasOne(d => d.IdCompetenciaNavigation)
                    .WithMany(p => p.CompetenciaPlanoDeEnsino)
                    .HasForeignKey(d => d.IdCompetencia)
                    .HasConstraintName("FK__Competenc__idCom__22751F6C");

                entity.HasOne(d => d.IdPlanoDeEnsinoNavigation)
                    .WithMany(p => p.CompetenciaPlanoDeEnsino)
                    .HasForeignKey(d => d.IdPlanoDeEnsino)
                    .HasConstraintName("FK__Competenc__idPla__2180FB33");
            });

            modelBuilder.Entity<ConteudoPlanoDeAula>(entity =>
            {
                entity.HasKey(e => e.IdConteudoAula);

                entity.Property(e => e.IdConteudoAula).HasColumnName("idConteudoAula");

                entity.Property(e => e.Bibliografia)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.DataConteudo).HasColumnType("date");

                entity.Property(e => e.Descricao)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.IdPlanoDeAula).HasColumnName("idPlanoDeAula");

                entity.Property(e => e.Semana)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdPlanoDeAulaNavigation)
                    .WithMany(p => p.ConteudoPlanoDeAula)
                    .HasForeignKey(d => d.IdPlanoDeAula)
                    .HasConstraintName("FK__ConteudoP__idPla__43D61337");
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

            modelBuilder.Entity<HabilidadePlanoDeEnsino>(entity =>
            {
                entity.HasKey(e => e.IdHabilidadePlanoDeEnsino);

                entity.Property(e => e.IdHabilidadePlanoDeEnsino).HasColumnName("idHabilidadePlanoDeEnsino");

                entity.Property(e => e.IdHabilidade).HasColumnName("idHabilidade");

                entity.Property(e => e.IdPlanoDeEnsino).HasColumnName("idPlanoDeEnsino");

                entity.HasOne(d => d.IdHabilidadeNavigation)
                    .WithMany(p => p.HabilidadePlanoDeEnsino)
                    .HasForeignKey(d => d.IdHabilidade)
                    .HasConstraintName("FK__Habilidad__idHab__2A164134");

                entity.HasOne(d => d.IdPlanoDeEnsinoNavigation)
                    .WithMany(p => p.HabilidadePlanoDeEnsino)
                    .HasForeignKey(d => d.IdPlanoDeEnsino)
                    .HasConstraintName("FK__Habilidad__idPla__29221CFB");
            });

            modelBuilder.Entity<Livro>(entity =>
            {
                entity.HasKey(e => e.IdLivro);

                entity.Property(e => e.IdLivro).HasColumnName("idLivro");

                entity.Property(e => e.IdPlanoDeAula).HasColumnName("idPlanoDeAula");

                entity.Property(e => e.IdPlanoDeEnsino).HasColumnName("idPlanoDeEnsino");

                entity.Property(e => e.NomeLivro)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdPlanoDeAulaNavigation)
                    .WithMany(p => p.Livro)
                    .HasForeignKey(d => d.IdPlanoDeAula)
                    .HasConstraintName("FK__Livro__idPlanoDe__40F9A68C");

                entity.HasOne(d => d.IdPlanoDeEnsinoNavigation)
                    .WithMany(p => p.Livro)
                    .HasForeignKey(d => d.IdPlanoDeEnsino)
                    .HasConstraintName("FK__Livro__idPlanoDe__1BC821DD");
            });

            modelBuilder.Entity<MembroNde>(entity =>
            {
                entity.HasKey(e => e.IdMembroNde);

                entity.ToTable("MembroNDE");

                entity.Property(e => e.IdMembroNde).HasColumnName("idMembroNDE");

                entity.Property(e => e.IdPlanoDeEnsino).HasColumnName("idPlanoDeEnsino");

                entity.Property(e => e.Nome)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdPlanoDeEnsinoNavigation)
                    .WithMany(p => p.MembroNde)
                    .HasForeignKey(d => d.IdPlanoDeEnsino)
                    .HasConstraintName("FK__MembroNDE__idPla__1EA48E88");
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

            modelBuilder.Entity<ObjetivoPlanoDeEnsino>(entity =>
            {
                entity.HasKey(e => e.IdObjetivoPlanoDeEnsino);

                entity.Property(e => e.IdObjetivoPlanoDeEnsino).HasColumnName("idObjetivoPlanoDeEnsino");

                entity.Property(e => e.IdObjetivo).HasColumnName("idObjetivo");

                entity.Property(e => e.IdPlanoDeEnsino).HasColumnName("idPlanoDeEnsino");

                entity.HasOne(d => d.IdObjetivoNavigation)
                    .WithMany(p => p.ObjetivoPlanoDeEnsino)
                    .HasForeignKey(d => d.IdObjetivo)
                    .HasConstraintName("FK__ObjetivoP__idObj__2645B050");

                entity.HasOne(d => d.IdPlanoDeEnsinoNavigation)
                    .WithMany(p => p.ObjetivoPlanoDeEnsino)
                    .HasForeignKey(d => d.IdPlanoDeEnsino)
                    .HasConstraintName("FK__ObjetivoP__idPla__25518C17");
            });

            modelBuilder.Entity<PlanoDeAula>(entity =>
            {
                entity.HasKey(e => e.IdPlanoDeAula);

                entity.Property(e => e.IdPlanoDeAula).HasColumnName("idPlanoDeAula");

                entity.Property(e => e.IdCoordenador).HasColumnName("idCoordenador");

                entity.Property(e => e.IdCurso).HasColumnName("idCurso");

                entity.Property(e => e.IdDisciplina).HasColumnName("idDisciplina");

                entity.Property(e => e.IdProfessor).HasColumnName("idProfessor");

                entity.Property(e => e.IdTurma).HasColumnName("idTurma");

                entity.HasOne(d => d.IdCoordenadorNavigation)
                    .WithMany(p => p.PlanoDeAula)
                    .HasForeignKey(d => d.IdCoordenador)
                    .HasConstraintName("FK__PlanoDeAu__idCoo__40058253");

                entity.HasOne(d => d.IdCursoNavigation)
                    .WithMany(p => p.PlanoDeAula)
                    .HasForeignKey(d => d.IdCurso)
                    .HasConstraintName("FK__PlanoDeAu__idCur__3C34F16F");

                entity.HasOne(d => d.IdDisciplinaNavigation)
                    .WithMany(p => p.PlanoDeAula)
                    .HasForeignKey(d => d.IdDisciplina)
                    .HasConstraintName("FK__PlanoDeAu__idDis__3D2915A8");

                entity.HasOne(d => d.IdProfessorNavigation)
                    .WithMany(p => p.PlanoDeAula)
                    .HasForeignKey(d => d.IdProfessor)
                    .HasConstraintName("FK__PlanoDeAu__idPro__3F115E1A");

                entity.HasOne(d => d.IdTurmaNavigation)
                    .WithMany(p => p.PlanoDeAula)
                    .HasForeignKey(d => d.IdTurma)
                    .HasConstraintName("FK__PlanoDeAu__idTur__3E1D39E1");
            });

            modelBuilder.Entity<PlanoDeEnsino>(entity =>
            {
                entity.HasKey(e => e.IdPlanoDeEnsino);

                entity.Property(e => e.IdPlanoDeEnsino).HasColumnName("idPlanoDeEnsino");

                entity.Property(e => e.Avaliacao).IsUnicode(false);

                entity.Property(e => e.ConteudoProgramaticoM1).IsUnicode(false);

                entity.Property(e => e.ConteudoProgramaticoM2).IsUnicode(false);

                entity.Property(e => e.DateAtualizacao).HasColumnType("date");

                entity.Property(e => e.DateValidacaoNde)
                    .HasColumnName("DateValidacaoNDE")
                    .HasColumnType("date");

                entity.Property(e => e.Ementa).IsUnicode(false);

                entity.Property(e => e.IdCoordenador).HasColumnName("idCoordenador");

                entity.Property(e => e.IdCurso).HasColumnName("idCurso");

                entity.Property(e => e.IdDisciplina).HasColumnName("idDisciplina");

                entity.Property(e => e.IdProfessor).HasColumnName("idProfessor");

                entity.Property(e => e.MetodologiaDeEnsino).IsUnicode(false);

                entity.HasOne(d => d.IdCoordenadorNavigation)
                    .WithMany(p => p.PlanoDeEnsino)
                    .HasForeignKey(d => d.IdCoordenador)
                    .HasConstraintName("FK__PlanoDeEn__idCoo__18EBB532");

                entity.HasOne(d => d.IdCursoNavigation)
                    .WithMany(p => p.PlanoDeEnsino)
                    .HasForeignKey(d => d.IdCurso)
                    .HasConstraintName("FK__PlanoDeEn__idCur__160F4887");

                entity.HasOne(d => d.IdDisciplinaNavigation)
                    .WithMany(p => p.PlanoDeEnsino)
                    .HasForeignKey(d => d.IdDisciplina)
                    .HasConstraintName("FK__PlanoDeEn__idDis__17036CC0");

                entity.HasOne(d => d.IdProfessorNavigation)
                    .WithMany(p => p.PlanoDeEnsino)
                    .HasForeignKey(d => d.IdProfessor)
                    .HasConstraintName("FK__PlanoDeEn__idPro__17F790F9");
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
