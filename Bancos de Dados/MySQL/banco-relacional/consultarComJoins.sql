SELECT * FROM cidades c
INNER JOIN prefeitos p ON c.id = p.cidade_id;

SELECT * FROM cidades c
LEFT JOIN prefeitos p ON c.id = p.cidade_id;

--MESMA COISA DO LEFT JOIN
SELECT * FROM cidades c
LEFT OUTER JOIN prefeitos p ON c.id = p.cidade_id;


SELECT * FROM cidades c
RIGHT JOIN prefeitos p ON c.id = p.cidade_id;

--MESMA COISA DO RIGHT JOIN
SELECT * FROM cidades c
RIGHT OUTER JOIN prefeitos p ON c.id = p.cidade_id;

--FULL JOIN
SELECT * FROM cidades c
RIGHT JOIN prefeitos p ON c.id = p.cidade_id
UNION --"UNION ALL" TRARIA TODAS AS DUPLICAÇÕES TAMBÉM
SELECT * FROM cidades c
LEFT JOIN prefeitos p ON c.id = p.cidade_id;