-- Criar o banco de dados
CREATE DATABASE IF NOT EXISTS bdeventos;

-- Usar o banco de dados
USE bdeventos;
drop table fornecedores;
-- Criar a tabela fornecedores
CREATE TABLE IF NOT EXISTS fornecedores (
    id INT UNSIGNED AUTO_INCREMENT PRIMARY KEY,
    razaosocial VARCHAR(100) NOT NULL,
	nomefantasia VARCHAR(100) NOT NULL,
    email VARCHAR(100) NOT NULL,
    telefone VARCHAR(25) NOT NULL,
    cnpj VARCHAR(100) NOT NULL,
    endereco VARCHAR(255) NOT NULL,
    numero VARCHAR(10) NOT NULL,
    complemento VARCHAR(100),
    bairro VARCHAR(100) NOT NULL,
    cidade VARCHAR(100) NOT NULL,
    estado VARCHAR(50) NOT NULL,
    setor VARCHAR(20) NOT NULL
);
