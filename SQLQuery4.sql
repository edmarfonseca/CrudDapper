SELECT 
                    e.ID AS IdEstoque,
                    e.NOME AS NomeEstoque,
                    SUM(p.QUANTIDADE) AS TotalQuantidade
                FROM 
                    ESTOQUE e
                LEFT JOIN
                    PRODUTO p ON e.ID = p.ESTOQUE_ID
                GROUP BY
                    e.ID,
                    e.NOME
                ORDER BY
                    e.NOME