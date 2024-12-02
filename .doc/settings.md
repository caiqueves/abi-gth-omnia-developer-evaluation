# Como Configurar o Projeto Usando Docker Desktop

## 1. Instalar o Docker Desktop

Antes de começar, você precisará instalar o Docker Desktop em sua máquina. Siga as instruções abaixo conforme o seu sistema operacional:

### Para Windows e Mac:
1. Acesse o site oficial do Docker: [docker.com](https://www.docker.com/products/docker-desktop)
2. Faça o download do instalador adequado para o seu sistema operacional (Windows ou Mac).
3. Execute o instalador e siga as instruções de instalação.
4. Após a instalação, abra o Docker Desktop. Pode ser necessário reiniciar o computador.

### Para Linux:
No Linux, o processo pode variar conforme a distribuição. Para instalar o Docker no Ubuntu, siga os seguintes comandos:


sudo apt-get update
sudo apt-get install docker.io
sudo systemctl start docker
sudo systemctl enable docker


## Para instalar o Docker Compose no Linux, use:


sudo curl -L "https://github.com/docker/compose/releases/download/1.29.2/docker-compose-$(uname -s)-$(uname -m)" -o /usr/local/bin/docker-compose
sudo chmod +x /usr/local/bin/docker-compose


## 2. Verificar se o Docker está Instalado Corretamente abra o terminal e digite o comando abaixo:


docker --version


Isso deve exibir a versão do Docker instalada. Você também pode verificar o status do Docker com:

docker info


## 3. Verificar se o Docker Compose está Instalado Corretamente:


docker-compose --version


## 4. Baixar ou Clonar o Repositório do Projeto

Clone o repositório do projeto (se necessário) ou garanta que você tenha o diretório com o arquivo docker-compose.yml na sua máquina.
Caso precise clonar o repositório, use o seguinte comando:

[git clone https://github.com/usuario/repo.git](https://github.com/caiqueves/abi-gth-omnia-developer-evaluation.git)

Após clonar, acesse o diretório do projeto

## 5. Verificar o Arquivo docker-compose.yml

Certifique-se de que o arquivo docker-compose.yml está presente no diretório raiz do projeto.
Este arquivo define todos os serviços que serão executados nos contêineres Docker.

## 6. Executar o Docker Compose

Agora você pode executar o Docker Compose para iniciar os contêineres definidos no arquivo docker-compose.yml.
No terminal, no diretório onde o arquivo está localizado, execute:

docker-compose up -d

O -d faz com que os contêineres sejam executados em segundo plano (modo detached).
Este comando irá baixar as imagens necessárias (se não estiverem no seu sistema) e iniciar os contêineres.

Para saber as portas que os contêineres estão executando podem abrir o docker mais os serviços foram configurados
para as portas :

Postgrees - http://localhost:5432/
Redis - http://localhost:6379/
RabbitMQ - http://localhost:15672/#/
WebApi - http://localhost:8080/

## 7. Como Configurar o Entity Framework Migrations

### 1. Instalar as Dependências do Projeto
Antes de tudo, o desenvolvedor precisa garantir que o projeto está com todas as dependências instaladas. Para isso, após clonar o repositório, o primeiro passo é restaurar os pacotes NuGet. No diretório do projeto, execute o comando:

dotner restore

### 2. Configurar a String de Conexão

{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=MeuBanco;User Id=usuario;Password=senha;"
  }
}

### 3. Aplicar a Migração no Banco de Dados

dotnet ef database update




Caique Neves - Desenvolvedor









