# Lista-de-Lembretes
Solução fullstack para criar e excluir lembretes

# REQUISITOS
É necessário possuir o SDK do .NET 6 instalado, assim como o Node.js e npm da versão LTS.

# MODO DE USO
Clonar os reposítórios correspondentes ao <a href=https://github.com/Uiseman/Lista-de-Lembretes>Backend</a> e ao <a href=https://github.com/Uiseman/Lista-de-Lembretes-Frontend>Frontend</a> da aplicação.

No diretório do frontend, inicializar o terminal e executar o comando npm start;
Dentro da pasta ListaDeLembretesAPI executar o comando dotnet run.

# SOBRE A APLICAÇÃO

O frontend tem a capacidade de criar, listar e excluir  os lembretes. Essas funcionalidades são disponibilizadas por meio da API REST ListaDeLembretesAPI. Os endpoints disponibilizados podem ser vizualizados por meio do Swagger. Para isso, no diretório da api deve-se executar o comando dotnet watch run.

Vale ressaltar que o Swagger possui dificuldades em lidar com o tipo de dado DateOnly do .NET 6, e portanto ao invés de:

{
  "nome": "string",
  "data": {
    "year": 0,
    "month": 0,
    "day": 0,
    "dayOfWeek": 0
  }
}

O corpo da requisição deve estar no seguinte formato:

{
  "nome": "string",
  "data": "aaaa-mm-dd"
}

# ARMAZENAMENTO

A aplicação utiliza um banco de dados persistido na memória. Ou seja, ele é apagado toda vez que a API é reiniciada.
