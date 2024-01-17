# WakeApi

## Descrição do Projeto
<p align="center">Projeto Teste Wake Commerce </p>

### Features
- [x] Cadastro de Produto
- [x] Visualizar um produto específico
- [x] Ordenar os produtos por diferentes campos
- [x] Ordenar os produtos por diferentes campos
- [x] Buscar produto pelo nome
- [x] Deletar um produto
- [x] Atualizar um produto

### Pré-requisitos
.NET CORE SDK 6.0
SQLServer

### Rodando o Back End 
```bash
# Clone este repositório
$ git clone <https://github.com/douglascardoso77/WakeApi/>

# Acesse a pasta do projeto no terminal/cmd
$ cd WakeApi

# Abra o arquivo launch.json
- Altere na "env" o objeto DB_CONNECTION para sua conexão com sua base

# Vá para a pasta Data
$ cd Data

# Execute a migrations para a Base
dotnet ef database update

#Compile ou execute

```

### Tecnologias
As seguintes ferramentas foram usadas na construção do projeto:
.NET CORE 6.0

### Futuras melhorias
- Adiconar no asppsettings a configuração da base
- Configurar um docker compose para subir o ambiente já com a base de dados
- Add um lib como validator para validaçoes de cada entidade



