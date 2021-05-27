ALTER TABLE empresas MODIFY cnpj VARCHAR(14);

INSERT INTO empresas (nome, cnpj)
VALUES
    ('Bradesco', 51354318131324),
    ('Vale', 13546853151123),
    ('Cielo', 65465184616832);

desc empresas; --DESCREVE O CONTEÚDO DA TABELA, TIPOS DE DADOS ETC

SELECT * FROM cidades;
SELECT * FROM empresas;

INSERT INTO empresas_unidades(empresa_id, cidade_id, sede)
VALUES
    (1, 1, 1),
    (1, 2, 0),
    (2, 1, 0),
    (2, 2, 1);