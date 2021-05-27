SELECT 
    sum(populacao) AS Total
FROM estados;

SELECT 
    regiao AS 'Região',
    sum(populacao) AS Total
FROM estados
GROUP BY regiao
ORDER BY total desc;

SELECT 
    avg(populacao) AS Total
FROM estados;