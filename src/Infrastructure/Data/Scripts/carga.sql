SELECT distinct municipio, escola, estudante, sexo, '', 1, 0, getdate(), GETDATE()
  FROM [DnaBrasilDb].[dbo].[carga]
  where MUNICIPIO <> '220'

  update carga set sexo = 'M' where sexo = 'Masculino'

  select * FROM[dbo].[Localidades]

select * from [dbo].[Municipios] where id = 324

select * from Alunos

insert into alunos (MunicipioId, LocalidadeId, Nome, Sexo, Email, [Status], Habilitado, Created, 
LastModified, Etnia, DtNascimento, IdCliente, AspNetUserId)
SELECT distinct municipio, escola, estudante, sexo, '', 1, 0, getdate(), GETDATE(), 
0, '0001-01-01 00:00:00.0000000', IdCliente, 0
  FROM [DnaBrasilDb].[dbo].[carga]
  where MUNICIPIO <> '220'